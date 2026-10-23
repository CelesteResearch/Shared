#include "CelesteGraphicsPacket.h"
#include "CelesteGraphicsOutput.h"
#include "Direct3D12ApiErrors.h"
#include "Direct3D12ResourceApi.h"
#include "Direct3D12StateApi.h"
#include "Direct3D12Backbuffer.h"
#include "Direct3D12DrawApi.h"
#include "Direct3D12Clear.h"
#include "Direct3D12Effects.h"
#include "Direct3D12PresentationApi.h"
#include <cstdlib>
using namespace Celeste::Graphics::Direct3D12;
namespace
{
    int32_t CELESTE_GRAPHICS_CALL ReadbackStatus(CelesteGraphicsReadback* readback)
    {
        int32_t result = -1;
        Invoke([&] { result = GetReadbackStatus(readback); });
        return result;
    }
    int32_t CELESTE_GRAPHICS_CALL Destroy(CelesteGraphicsDevice* device)
    {
        return Invoke([&] {
            if (device)
            {
                SubmissionQueue::Destroy(device->submissions);
                delete device;
            }
        });
    }
    int32_t CELESTE_GRAPHICS_CALL Begin(CelesteGraphicsDevice* device, CelesteGraphicsPacket** result)
    {
        return Invoke([&] {
            if (!device || !result)
                throw std::invalid_argument("Missing packet owner");
            *result = new CelesteGraphicsPacket(*device);
        });
    }
    int32_t CELESTE_GRAPHICS_CALL Submit(CelesteGraphicsPacket* packet, CelesteGraphicsSubmission** result)
    {
        return Invoke([&] {
            if (!packet || !result || packet->device.host)
                throw std::invalid_argument("Owned submission requires owned device");
            *result = nullptr;
            auto observer = std::make_unique<CelesteGraphicsSubmission>();
            auto lease = packet->Prepare();
            observer->completion = packet->device.submissions->Submit(std::move(lease));
            packet->storage->completion->Publish(observer->completion);
            packet->Commit();
            *result = observer.release();
        });
    }
    void CELESTE_GRAPHICS_CALL ReleasePacket(CelesteGraphicsPacket* packet)
    {
        if (packet && packet->references.fetch_sub(1, std::memory_order_acq_rel) == 1)
            delete packet;
    }
    int32_t CELESTE_GRAPHICS_CALL Completion(CelesteGraphicsSubmission* submission)
    {
        int32_t result = -1;
        Invoke([&] {
            if (!submission)
                throw std::invalid_argument("Missing submission");
            result = submission->completion->IsComplete() ? 1 : 0;
        });
        return result;
    }
    int32_t CELESTE_GRAPHICS_CALL Wait(CelesteGraphicsSubmission* submission)
    {
        return Invoke([&] {
            if (!submission)
                throw std::invalid_argument("Missing submission");
            submission->completion->Wait();
        });
    }
    void CELESTE_GRAPHICS_CALL ReleaseSubmission(CelesteGraphicsSubmission* submission)
    {
        delete submission;
    }
    void CELESTE_GRAPHICS_CALL ReleaseOutput(CelesteGraphicsOutput* output)
    {
        delete output;
    }
    int32_t CELESTE_GRAPHICS_CALL Allocate(uint32_t count, void** bytes)
    {
        return Invoke([&] {
            if (!bytes)
                throw std::invalid_argument("Missing allocation output");
            *bytes = std::malloc(count ? count : 1);
            if (!*bytes)
                throw std::bad_alloc();
        });
    }
    void CELESTE_GRAPHICS_CALL Free(void* bytes)
    {
        std::free(bytes);
    }
}
extern "C"
{
    const CelesteGraphicsDeviceApi* CELESTE_GRAPHICS_CALL CelesteDirect3D12GetDeviceApi()
    {
        static const auto api = [] {
            CelesteGraphicsDeviceApi value{};
            value.abiVersion = CELESTE_GRAPHICS_DEVICE_ABI_VERSION;
            value.GetLastError = CelesteDirect3D12GetLastError;
            value.DestroyDevice = Destroy;
            value.BeginPacket = Begin;
            value.Submit = Submit;
            value.ReleasePacket = ReleasePacket;
            value.GetCompletion = Completion;
            value.Wait = Wait;
            value.ReleaseSubmission = ReleaseSubmission;
            value.ReleaseOutput = ReleaseOutput;
            value.Allocate = Allocate;
            value.Free = Free;
            value.CreateTexture = CheckedFunction<CreateTexture>::Call;
            value.ReleaseTexture = ReleaseTexture;
            value.SetTextureName = CheckedFunction<SetTextureName>::Call;
            value.WriteTexture = CheckedFunction<WriteTexture>::Call;
            value.CopyTexture = CheckedFunction<CopyTexture>::Call;
            value.ReadTexture = CheckedFunction<ReadTexture>::Call;
            value.CreateBuffer = CheckedFunction<CreateBuffer>::Call;
            value.ReleaseBuffer = ReleaseBuffer;
            value.WriteBuffer = CheckedFunction<WriteBuffer>::Call;
            value.ReadBuffer = CheckedFunction<ReadBuffer>::Call;
            value.GetReadbackStatus = ReadbackStatus;
            value.GetReadbackBytes = CheckedFunction<GetReadbackBytes>::Call;
            value.ReleaseReadback = ReleaseReadback;
            value.CreateDepthRenderbuffer = CheckedFunction<CreateDepthRenderbuffer>::Call;
            value.CreateColorRenderbuffer = CheckedFunction<CreateColorRenderbuffer>::Call;
            value.ReleaseRenderbuffer = ReleaseRenderbuffer;
            value.ResolveTarget = CheckedFunction<ResolveTarget>::Call;
            value.GetCapabilities = CheckedFunction<GetCapabilities>::Call;
            value.GetMaxMultiSampleCount = CheckedFunction<GetMaxMultiSampleCount>::Call;
            value.ConfigureBackbuffer = CheckedFunction<ConfigureBackbuffer>::Call;
            value.GetBackbufferInfo = CheckedFunction<GetBackbufferInfo>::Call;
            value.SetViewport = CheckedFunction<SetViewport>::Call;
            value.SetScissorRect = CheckedFunction<SetScissorRect>::Call;
            value.Clear = CheckedFunction<Clear>::Call;
            value.SetBlendState = CheckedFunction<SetBlendState>::Call;
            value.SetDepthStencilState = CheckedFunction<SetDepthStencilState>::Call;
            value.SetRasterizerState = CheckedFunction<SetRasterizerState>::Call;
            value.SetSampler = CheckedFunction<SetSampler>::Call;
            value.GetBlendFactor = CheckedFunction<GetBlendFactor>::Call;
            value.SetBlendFactor = CheckedFunction<SetBlendFactor>::Call;
            value.GetSampleMask = CheckedFunction<GetSampleMask>::Call;
            value.SetSampleMask = CheckedFunction<SetSampleMask>::Call;
            value.GetStencilReference = CheckedFunction<GetStencilReference>::Call;
            value.SetStencilReference = CheckedFunction<SetStencilReference>::Call;
            value.SetRenderTargets = CheckedFunction<SetRenderTargets>::Call;
            value.ReadBackbuffer = CheckedFunction<ReadBackbuffer>::Call;
            value.SetVertexBindings = CheckedFunction<SetVertexBindings>::Call;
            value.Draw = CheckedFunction<Draw>::Call;
            value.DrawIndexed = CheckedFunction<DrawIndexed>::Call;
            value.ApplyEffect = CheckedFunction<ApplyEffect>::Call;
            BindPresentationApi(value);
            return value;
        }();
        return &api;
    }
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12RetainPacket(CelesteGraphicsPacket* packet)
    {
        return Invoke([&] {
            if (!packet)
                throw std::invalid_argument("Missing packet");
            packet->references.fetch_add(1, std::memory_order_relaxed);
        });
    }
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12PrepareHostPacket(CelesteGraphicsPacket* packet,
                                                                     CelesteDirect3D12HostRecording* result)
    {
        return Invoke([&] {
            if (!packet || !result || !packet->device.host)
                throw std::invalid_argument("Host packet requires borrowed device");
            *result = {};
            packet->hostSubmission = std::make_unique<CelesteGraphicsSubmission>();
            auto lease = packet->Prepare();
            packet->hostCommands = lease->List();
            packet->hostSubmission->completion = packet->device.submissions->PrepareExternal(std::move(lease));
            *result = {packet->hostCommands, packet->storage->outputStates.data(),
                       static_cast<uint32_t>(packet->storage->outputStates.size())};
        });
    }
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12CommitHostPacket(CelesteGraphicsPacket* packet, ID3D12Fence* fence,
                                                                    uint64_t value, CelesteGraphicsSubmission** result)
    {
        return Invoke([&] {
            if (!packet || !result || packet->phase != CelesteGraphicsPacket::Phase::Prepared ||
                !packet->hostSubmission)
                throw std::invalid_argument("Missing prepared host packet");
            *result = nullptr;
            packet->device.submissions->CommitExternal(packet->hostSubmission->completion,
                                                       {Microsoft::WRL::ComPtr<ID3D12Fence>(fence), value});
            packet->storage->completion->Publish(packet->hostSubmission->completion);
            packet->Commit();
            *result = packet->hostSubmission.release();
        });
    }
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12CancelPreparedHostPacket(CelesteGraphicsPacket* packet)
    {
        return Invoke([&] {
            if (!packet || packet->phase != CelesteGraphicsPacket::Phase::Prepared || !packet->hostSubmission)
                throw std::invalid_argument("Missing prepared host packet");
            packet->device.submissions->CancelExternal(packet->hostSubmission->completion);
            packet->hostSubmission.reset();
            packet->storage->completion->Cancel();
            packet->phase = CelesteGraphicsPacket::Phase::Canceled;
        });
    }
}
static_assert(sizeof(CelesteDirect3D12OwnedDeviceInfo) == 16);
static_assert(sizeof(CelesteDirect3D12BorrowedDeviceInfo) == 8);
static_assert(sizeof(CelesteDirect3D12OutputInfo) == 32);
static_assert(sizeof(CelesteDirect3D12HostResourceState) == 16);
static_assert(sizeof(CelesteDirect3D12HostRecording) == 24);
