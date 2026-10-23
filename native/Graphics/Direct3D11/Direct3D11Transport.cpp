#include "Direct3D11Transport.h"
#include "Direct3D11PhysicalStateScope.h"
#include <algorithm>
#include <cstring>
#include <exception>
#include <stdexcept>
#include <windows.h>

static thread_local Direct3D11PhysicalPacket* recording = nullptr;
static thread_local Direct3D11PhysicalPacket* executing = nullptr;
void SourceMarkPhysicalFailure()
{
    if (executing)
        executing->completion.store(-1, std::memory_order_release);
}

Direct3D11PhysicalPacket::~Direct3D11PhysicalPacket()
{
    {
        std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
        device->physicalPackets.erase(this);
        writes.clear();
        lastUniforms.reset();
    }
    // The last loan can delete the context: release only after unlocking its mutex.
    SourceGpuReleaseDeviceContext(device);
}

Direct3D11PhysicalPacket* SourceCurrentPhysicalPacket()
{
    return recording;
}
bool SourceRequirePhysicalScope(Direct3D11Device* device)
{
    if (!recording)
    {
        SourceSetError("Physical command recording scope is required");
        return false;
    }
    if (recording->device != device)
    {
        SourceSetError("Cannot record commands for another device context");
        return false;
    }
    return true;
}
// Caller already holds this packet's device lock. Ownership is checked before
// accepting a command; no additional lock or global device lookup is needed.
static bool SourceCanAppendPhysicalLocked(Direct3D11Device* device)
{
    if (!SourceRequirePhysicalScope(device))
        return false;
    if (recording->generation != device->generation || !SourceRequireDevice(device))
    {
        SourceSetError("Cannot append to a disposed physical scope");
        return false;
    }
    return true;
}
bool SourceCanAppendPhysicalPacketLocked(Direct3D11Device* device)
{
    return SourceCanAppendPhysicalLocked(device);
}
void SourceInvalidatePhysicalInputBindings(Direct3D11Device* device, bool vertex, bool index)
{
    if (!SourceRequirePhysicalScope(device))
        return;
    auto packet = recording;
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    if (vertex)
        packet->lastVertexBindings = nullptr;
    if (index)
        packet->hasIndexBinding = false;
}
static bool SourceAppendPhysicalLocked(Direct3D11Device* device, std::function<void()> write)
{
    if (!SourceCanAppendPhysicalLocked(device))
        return false;
    recording->writes.push_back(std::move(write));
    return true;
}
bool SourceAppendPhysical(Direct3D11Device* device, std::function<void()> write)
{
    if (!SourceRequirePhysicalScope(device))
        return false;
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    return SourceAppendPhysicalLocked(device, std::move(write));
}

bool SourceAppendPhysicalRasterizer(Direct3D11Device* device, std::shared_ptr<ID3D11RasterizerState> state)
{
    if (!SourceRequirePhysicalScope(device))
        return false;
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    if (!SourceCanAppendPhysicalLocked(device))
        return false;
    if (recording->lastRasterizerDevice == device && recording->lastRasterizerState == state.get())
        return true;
    auto identity = state.get();
    recording->writes.push_back([device, state = std::move(state)]() { device->context->RSSetState(state.get()); });
    recording->lastRasterizerDevice = device;
    recording->lastRasterizerState = identity;
    return true;
}
// Caller holds heldDevice's lock; a different packet owner is an error, never
// a reason to append the foreign context's raw pointer under another lock.
bool SourceAppendPhysicalDeviceLocked(Direct3D11Device* heldDevice, std::function<void()> write)
{
    return SourceAppendPhysicalLocked(heldDevice, std::move(write));
}

static Direct3D11PhysicalPacket* BeginPhysicalPacketLocked(Direct3D11Device* device)
{
    if (!SourceRequireDevice(device))
        return nullptr;
    if (recording)
    {
        SourceSetError("Physical command scope is already active");
        return nullptr;
    }
    recording = new Direct3D11PhysicalPacket(device);
    device->physicalPackets.insert(recording);
    return recording;
}
SOURCE_GPU_EXPORT Direct3D11PhysicalPacket* __cdecl SourceGpuBeginPhysicalPacket(Direct3D11Device* device)
{
    if (!device)
    {
        SourceSetError("Physical device is required");
        return nullptr;
    }
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    return BeginPhysicalPacketLocked(device);
}

// A source IO call borrows its caller's packet, or owns one physical upload scope.
// Ownership decides sealing/submission only; it never introduces batching or sorting.
// Caller validates device/ownsScope and holds device->physicalLock.
Direct3D11PhysicalPacket* SourceBorrowOrBeginPhysicalPacketLocked(Direct3D11Device* device, uint32_t* ownsScope)
{
    *ownsScope = 0;
    if (!SourceRequireDevice(device))
        return nullptr;
    if (recording)
    {
        if (recording->device != device || recording->generation != device->generation)
        {
            SourceSetError("Cannot borrow a physical scope for another device generation");
            return nullptr;
        }
        return recording;
    }
    auto packet = BeginPhysicalPacketLocked(device);
    if (packet)
        *ownsScope = 1;
    return packet;
}
SOURCE_GPU_EXPORT Direct3D11PhysicalPacket* __cdecl SourceGpuBorrowOrBeginPhysicalPacket(Direct3D11Device* device,
                                                                                         uint32_t* ownsScope)
{
    if (!ownsScope)
    {
        SourceSetError("Physical scope ownership output is required");
        return nullptr;
    }
    *ownsScope = 0;
    if (!device)
    {
        SourceSetError("Physical device is required");
        return nullptr;
    }
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    return SourceBorrowOrBeginPhysicalPacketLocked(device, ownsScope);
}

SOURCE_GPU_EXPORT Direct3D11PhysicalPacket* __cdecl SourceGpuSealPhysicalPacket()
{
    auto packet = recording;
    recording = nullptr;
    return packet;
}

// Shared command executor: only borrowed host contexts need pipeline isolation.
static int ExecutePhysicalPacket(Direct3D11PhysicalPacket* packet)
{
    auto device = packet->device;
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    if (device->generation != packet->generation || !SourceRequireDevice(device))
    {
        SourceSetError("Physical packet belongs to a disposed device generation");
        packet->completion = -1;
        return 0;
    }
    device->renderThread = GetCurrentThreadId();
    std::unique_ptr<Direct3D11PhysicalStateScope> hostPipeline;
    executing = packet;
    try
    {
        if (!device->ownsPhysicalDevice)
        {
            hostPipeline = std::make_unique<Direct3D11PhysicalStateScope>(device->context);
            SourceCaptureHostBackbuffer(device);
            if (device->physicalContinuation)
                device->physicalContinuation->Restore();
        }
        for (auto& write : packet->writes)
            write();
        if (!device->ownsPhysicalDevice)
            device->physicalContinuation = std::make_shared<Direct3D11PhysicalStateScope>(device->context);
        if (packet->completion.load(std::memory_order_acquire) != -1)
            packet->completion.store(1, std::memory_order_release);
    }
    catch (const std::exception& error)
    {
        SourceSetError(error.what());
        packet->completion = -1;
    }
    catch (...)
    {
        SourceSetError("Native physical packet failed");
        packet->completion = -1;
    }
    if (hostPipeline)
        hostPipeline->Restore();
    executing = nullptr;
    return packet->completion.load(std::memory_order_acquire) == 1;
}
SOURCE_GPU_EXPORT int __cdecl SourceGpuExecuteBorrowedPacket(Direct3D11PhysicalPacket* packet)
{
    if (!packet || packet->device->ownsPhysicalDevice || recording || executing ||
        packet->completion.load(std::memory_order_acquire) != 0)
    {
        SourceSetError("A sealed unexecuted borrowed-device packet is required");
        return 0;
    }
    // Called by the host on its render thread; ExecutePhysicalPacket saves/restores host state.
    return ExecutePhysicalPacket(packet);
}
SOURCE_GPU_EXPORT int __cdecl SourceGpuExecutePhysicalPacket(Direct3D11Device* device, Direct3D11PhysicalPacket* packet)
{
    if (!device || !packet || packet->device != device || !device->ownsPhysicalDevice || recording || executing ||
        packet->completion.load(std::memory_order_acquire) != 0)
    {
        SourceSetError("A sealed unexecuted independent physical packet is required");
        return 0;
    }
    if (!SourceRequireRenderThread(device))
        return 0;
    // The synchronous caller retains ownership; no asynchronous host-event retain.
    return ExecutePhysicalPacket(packet);
}
SOURCE_GPU_EXPORT void __cdecl SourceGpuRetainPacket(Direct3D11PhysicalPacket* packet)
{
    packet->references.fetch_add(1, std::memory_order_relaxed);
}
SOURCE_GPU_EXPORT void __cdecl SourceGpuReleasePacket(Direct3D11PhysicalPacket* packet)
{
    if (packet->references.fetch_sub(1, std::memory_order_acq_rel) == 1)
        delete packet;
}
SOURCE_GPU_EXPORT int __cdecl SourceGpuPacketCompletion(Direct3D11PhysicalPacket* packet)
{
    return packet->completion.load(std::memory_order_acquire);
}

struct UniformRange
{
    enum class Kind
    {
        Float,
        Int,
        Bool
    } kind;
    size_t offset;
    size_t payloadOffset;
    size_t byteCount;
};

static void RegisterFiles(MOJOSHADER_d3d11Context* context, void** files)
{
    float *vf, *pf;
    int *vi, *pi;
    unsigned char *vb, *pb;
    MOJOSHADER_d3d11MapUniformBufferMemory(context, &vf, &vi, &vb, &pf, &pi, &pb);
    files[0] = vf;
    files[1] = vi;
    files[2] = vb;
    files[3] = pf;
    files[4] = pi;
    files[5] = pb;
}

struct ShaderUniformSnapshot
{
    Direct3D11Device* device;
    MOJOSHADER_d3d11Shader* vertex;
    MOJOSHADER_d3d11Shader* pixel;
    std::vector<std::pair<int, UniformRange>> ranges;
    std::vector<uint8_t> payload;
    ~ShaderUniformSnapshot()
    {
        // Device shutdown invalidates native contexts; the lifetime bridge must
        // drain/cancel owned packets before invoking device shutdown.
        if (device->shaders)
        {
            if (vertex)
                MOJOSHADER_d3d11DeleteShader(device->shaders, vertex);
            if (pixel)
                MOJOSHADER_d3d11DeleteShader(device->shaders, pixel);
        }
    }
};

void SourceCaptureEffectUniforms(const void* opaqueContext)
{
    auto device = const_cast<Direct3D11Device*>(static_cast<const Direct3D11Device*>(opaqueContext));
    auto context = device->shaders;
    MOJOSHADER_d3d11Shader *vertex, *pixel;
    MOJOSHADER_d3d11GetBoundShaders(context, &vertex, &pixel);
    void* files[6];
    RegisterFiles(context, files);
    std::shared_ptr<ShaderUniformSnapshot> snapshot;
    auto packet = SourceCurrentPhysicalPacket();
    auto previous = packet ? packet->lastUniforms : std::shared_ptr<ShaderUniformSnapshot>{};
    if (previous && previous->vertex == vertex && previous->pixel == pixel)
    {
        bool equal = true;
        for (const auto& item : previous->ranges)
            if (std::memcmp(static_cast<uint8_t*>(files[item.first]) + item.second.offset,
                            previous->payload.data() + item.second.payloadOffset, item.second.byteCount) != 0)
            {
                equal = false;
                break;
            }
        if (equal)
            snapshot = previous;
    }
    if (!snapshot)
    {
        snapshot = std::make_shared<ShaderUniformSnapshot>();
        snapshot->device = device;
        snapshot->vertex = vertex;
        snapshot->pixel = pixel;
        if (vertex)
            MOJOSHADER_d3d11ShaderAddRef(vertex);
        if (pixel)
            MOJOSHADER_d3d11ShaderAddRef(pixel);
        auto capture = [&](MOJOSHADER_d3d11Shader* shader, int stage) {
            if (!shader)
                return;
            auto data = MOJOSHADER_d3d11GetShaderParseData(shader);
            for (int i = 0; i < data->uniform_count; ++i)
            {
                const auto& uniform = data->uniforms[i];
                if (uniform.constant)
                    continue;
                int file = stage;
                size_t stride = 16;
                UniformRange::Kind kind;
                if (uniform.type == MOJOSHADER_UNIFORM_FLOAT)
                    kind = UniformRange::Kind::Float;
                else if (uniform.type == MOJOSHADER_UNIFORM_INT)
                {
                    kind = UniformRange::Kind::Int;
                    file += 1;
                }
                else
                {
                    kind = UniformRange::Kind::Bool;
                    file += 2;
                    stride = 1;
                }
                size_t byteCount = stride * static_cast<size_t>(std::max(1, uniform.array_count));
                size_t payloadOffset = snapshot->payload.size();
                if (byteCount > snapshot->payload.max_size() - payloadOffset)
                    throw std::length_error("Uniform capture buffer size exceeds vector capacity");
                UniformRange range{kind, stride * static_cast<size_t>(uniform.index), payloadOffset, byteCount};
                snapshot->payload.resize(payloadOffset + byteCount);
                std::memcpy(snapshot->payload.data() + payloadOffset, static_cast<uint8_t*>(files[file]) + range.offset,
                            byteCount);
                snapshot->ranges.emplace_back(file, std::move(range));
            }
        };
        capture(snapshot->vertex, 0);
        capture(snapshot->pixel, 3);
    }
    if (SourceAppendPhysical(device, [snapshot, context]() {
            MOJOSHADER_d3d11Shader *previousVertex, *previousPixel;
            MOJOSHADER_d3d11GetBoundShaders(context, &previousVertex, &previousPixel);
            void* files[6];
            RegisterFiles(context, files);
            auto& restore = snapshot->device->uniformRestoreScratch;
            size_t restoreSize = 0;
            for (const auto& item : snapshot->ranges)
            {
                if (item.second.byteCount > restore.max_size() - restoreSize)
                    throw std::length_error("Uniform restore buffer size exceeds vector capacity");
                restoreSize += item.second.byteCount;
            }
            restore.resize(restoreSize);
            size_t restoreOffset = 0;
            for (const auto& item : snapshot->ranges)
            {
                auto pointer = static_cast<uint8_t*>(files[item.first]) + item.second.offset;
                std::memcpy(restore.data() + restoreOffset, pointer, item.second.byteCount);
                restoreOffset += item.second.byteCount;
                std::memcpy(pointer, snapshot->payload.data() + item.second.payloadOffset, item.second.byteCount);
            }
            MOJOSHADER_d3d11BindShaders(context, snapshot->vertex, snapshot->pixel);
            MOJOSHADER_d3d11UnmapUniformBufferMemory(context); // Actual D3D11 Map/Unmap, now on render thread.
            restoreOffset = 0;
            for (size_t i = 0; i < snapshot->ranges.size(); ++i)
            {
                const auto& item = snapshot->ranges[i];
                std::memcpy(static_cast<uint8_t*>(files[item.first]) + item.second.offset,
                            restore.data() + restoreOffset, item.second.byteCount);
                restoreOffset += item.second.byteCount;
            }
            MOJOSHADER_d3d11BindShaders(context, previousVertex, previousPixel);
        }))
        packet->lastUniforms = snapshot;
}
