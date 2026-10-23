#include "Direct3D11Device.h"
#include "Direct3D11Transport.h"
#include <new>
#include <cstddef>

// Managed SourceEffect.Schema reads this exact x64 prefix. The native effect
// remains the real Mojo object, including its full private backend fields.
static_assert(offsetof(MOJOSHADER_effect, error_count) == 0);
static_assert(offsetof(MOJOSHADER_effect, errors) == 8);
static_assert(offsetof(MOJOSHADER_effect, param_count) == 16);
static_assert(offsetof(MOJOSHADER_effect, params) == 24);
static_assert(offsetof(MOJOSHADER_effect, technique_count) == 32);
static_assert(offsetof(MOJOSHADER_effect, techniques) == 40);
static_assert(offsetof(MOJOSHADER_effect, object_count) == 48);
static_assert(offsetof(MOJOSHADER_effect, objects) == 56);

bool SourceCheckEffect(Direct3D11Effect* effect)
{
    if (!effect || !effect->data || effect->device->generation != effect->generation)
    {
        SourceSetError("Effect belongs to a disposed D3D11 device generation");
        return false;
    }
    return SourceRequireDevice(effect->device);
}

// Mojo keeps this explicit owner in each effect (including clones), so effect
// callbacks never infer the device from a singleton or another thread's scope.
static MOJOSHADER_d3d11Context* ShaderContext(const void* owner)
{
    return static_cast<const Direct3D11Device*>(owner)->shaders;
}

static void* MOJOSHADERCALL CompileShader(const void* owner, const char* entry, const unsigned char* bytes,
                                          unsigned int length, const MOJOSHADER_swizzle* swizzles,
                                          unsigned int swizzleCount, const MOJOSHADER_samplerMap* samplers,
                                          unsigned int samplerCount)
{
    return MOJOSHADER_d3d11CompileShader(ShaderContext(owner), entry, bytes, length, swizzles, swizzleCount, samplers,
                                         samplerCount);
}

static void MOJOSHADERCALL DeleteShader(const void* owner, void* shader)
{
    MOJOSHADER_d3d11DeleteShader(ShaderContext(owner), static_cast<MOJOSHADER_d3d11Shader*>(shader));
}

static void MOJOSHADERCALL BindShaders(const void* owner, void* vertex, void* pixel)
{
    MOJOSHADER_d3d11BindShaders(ShaderContext(owner), static_cast<MOJOSHADER_d3d11Shader*>(vertex),
                                static_cast<MOJOSHADER_d3d11Shader*>(pixel));
}

static void MOJOSHADERCALL GetBoundShaders(const void* owner, void** vertex, void** pixel)
{
    MOJOSHADER_d3d11Shader *actualVertex, *actualPixel;
    MOJOSHADER_d3d11GetBoundShaders(ShaderContext(owner), &actualVertex, &actualPixel);
    *vertex = actualVertex;
    *pixel = actualPixel;
}

static void MOJOSHADERCALL MapUniforms(const void* owner, float** vertexFloats, int** vertexInts,
                                       unsigned char** vertexBools, float** pixelFloats, int** pixelInts,
                                       unsigned char** pixelBools)
{
    MOJOSHADER_d3d11MapUniformBufferMemory(ShaderContext(owner), vertexFloats, vertexInts, vertexBools, pixelFloats,
                                           pixelInts, pixelBools);
}

static const char* MOJOSHADERCALL GetShaderError(const void* owner)
{
    return MOJOSHADER_d3d11GetError(ShaderContext(owner));
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuCreateEffect(Direct3D11Device* device, const uint8_t* bytes, uint32_t length,
                                                    Direct3D11Effect** handle, MOJOSHADER_effect** data)
{
    if (!handle || !data)
    {
        SourceSetError("Effect output pointers are required");
        return 0;
    }
    *handle = nullptr;
    *data = nullptr;
    if (!SourceRequireDevice(device))
        return 0;
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    if (!SourceRequireDevice(device))
        return 0;
    MOJOSHADER_effectShaderContext backend = {};
    backend.shaderContext = device;
    backend.compileShader = CompileShader;
    backend.shaderAddRef = reinterpret_cast<MOJOSHADER_shaderAddRefFunc>(MOJOSHADER_d3d11ShaderAddRef);
    backend.deleteShader = DeleteShader;
    backend.getParseData = reinterpret_cast<MOJOSHADER_getParseDataFunc>(MOJOSHADER_d3d11GetShaderParseData);
    backend.bindShaders = BindShaders;
    backend.getBoundShaders = GetBoundShaders;
    backend.mapUniformBufferMemory = MapUniforms;
    backend.unmapUniformBufferMemory = SourceCaptureEffectUniforms;
    backend.getError = GetShaderError;
    auto effect = MOJOSHADER_compileEffect(bytes, length, nullptr, 0, nullptr, 0, &backend);
    if (!effect)
    {
        SourceSetError(MOJOSHADER_d3d11GetError(device->shaders));
        return 0;
    }
    if (effect->error_count)
    {
        SourceSetError(effect->errors[0].error);
        MOJOSHADER_deleteEffect(effect);
        return 0;
    }
    auto resource = new (std::nothrow) Direct3D11Effect{device, device->generation, effect};
    if (!resource)
    {
        MOJOSHADER_deleteEffect(effect);
        SourceSetError("Effect handle allocation failed");
        return 0;
    }
    resource->device->physicalEffects.insert(resource);
    *handle = resource;
    *data = effect;
    return 1;
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuCloneEffect(Direct3D11Effect* original, Direct3D11Effect** handle,
                                                   MOJOSHADER_effect** data)
{
    if (!handle || !data)
        return 0;
    *handle = nullptr;
    *data = nullptr;
    if (!SourceCheckEffect(original))
        return 0;
    std::lock_guard<std::recursive_mutex> lock(original->device->physicalLock);
    if (!SourceCheckEffect(original))
        return 0;
    auto effect = MOJOSHADER_cloneEffect(original->data);
    if (!effect)
    {
        SourceSetError(MOJOSHADER_d3d11GetError(original->device->shaders));
        return 0;
    }
    auto resource = new (std::nothrow) Direct3D11Effect{original->device, original->generation, effect};
    if (!resource)
    {
        MOJOSHADER_deleteEffect(effect);
        SourceSetError("Effect handle allocation failed");
        return 0;
    }
    resource->device->physicalEffects.insert(resource);
    *handle = resource;
    *data = effect;
    return 1;
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuSetEffectTechnique(Direct3D11Effect* effect,
                                                          const MOJOSHADER_effectTechnique* technique)
{
    if (!SourceCheckEffect(effect))
        return 0;
    std::lock_guard<std::recursive_mutex> lock(effect->device->physicalLock);
    if (!SourceCheckEffect(effect))
        return 0;
    MOJOSHADER_effectSetTechnique(effect->data, technique);
    return 1;
}

// Physical effect commands. The shared SourceEffect/pass iteration chooses
// the original technique/pass; this native layer performs no iteration/sort.
SOURCE_GPU_EXPORT int __cdecl SourceGpuBeginEffect(Direct3D11Effect* effect, MOJOSHADER_effectStateChanges* changes)
{
    if (!SourceCheckEffect(effect))
        return 0;
    if (!SourceRequirePhysicalScope(effect->device))
        return 0;
    std::lock_guard<std::recursive_mutex> lock(effect->device->physicalLock);
    if (!SourceCheckEffect(effect))
        return 0;
    unsigned passes;
    MOJOSHADER_effectBegin(effect->data, &passes, 0, changes);
    return 1;
}
SOURCE_GPU_EXPORT int __cdecl SourceGpuBeginPass(Direct3D11Effect* effect, uint32_t pass)
{
    if (!SourceCheckEffect(effect))
        return 0;
    if (!SourceRequirePhysicalScope(effect->device))
        return 0;
    std::lock_guard<std::recursive_mutex> lock(effect->device->physicalLock);
    if (!SourceCheckEffect(effect))
        return 0;
    MOJOSHADER_effectBeginPass(effect->data, pass);
    return 1;
}
SOURCE_GPU_EXPORT int __cdecl SourceGpuCommitEffect(Direct3D11Effect* effect)
{
    if (!SourceCheckEffect(effect))
        return 0;
    if (!SourceRequirePhysicalScope(effect->device))
        return 0;
    std::lock_guard<std::recursive_mutex> lock(effect->device->physicalLock);
    if (!SourceCheckEffect(effect))
        return 0;
    MOJOSHADER_effectCommitChanges(effect->data);
    return 1;
}
SOURCE_GPU_EXPORT int __cdecl SourceGpuEndPass(Direct3D11Effect* effect)
{
    if (!SourceCheckEffect(effect))
        return 0;
    std::lock_guard<std::recursive_mutex> lock(effect->device->physicalLock);
    if (!SourceCheckEffect(effect))
        return 0;
    MOJOSHADER_effectEndPass(effect->data);
    return 1;
}
SOURCE_GPU_EXPORT int __cdecl SourceGpuEndEffect(Direct3D11Effect* effect)
{
    if (!SourceCheckEffect(effect))
        return 0;
    std::lock_guard<std::recursive_mutex> lock(effect->device->physicalLock);
    if (!SourceCheckEffect(effect))
        return 0;
    MOJOSHADER_effectEnd(effect->data);
    return 1;
}
SOURCE_GPU_EXPORT int __cdecl SourceGpuDisposeEffect(Direct3D11Effect* effect)
{
    if (!effect)
        return 1;
    auto device = effect->device;
    {
        std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
        if (effect->data && device->currentEffect == effect->data)
        {
            MOJOSHADER_effectEndPass(effect->data);
            MOJOSHADER_effectEnd(effect->data);
            device->currentEffect = nullptr;
            device->currentTechnique = nullptr;
        }
        if (effect->data)
            MOJOSHADER_deleteEffect(effect->data);
        device->physicalEffects.erase(effect);
        delete effect;
    }
    SourceGpuReleaseDeviceContext(device);
    return 1;
}

// FNA3D D3D11_ApplyEffect's physical backend transition, on this same Mojo
// context. Shared SourceEffect owns parameter/pass selection; this owns only
// the backend begin/end/commit transition. Uniform writes are captured here.
SOURCE_GPU_EXPORT int __cdecl SourceGpuApplyEffect(Direct3D11Effect* effect, uint32_t pass,
                                                   MOJOSHADER_effectStateChanges* changes)
{
    if (!SourceCheckEffect(effect) || !SourceRequirePhysicalScope(effect->device))
        return 0;
    auto device = effect->device;
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    if (!SourceCheckEffect(effect))
        return 0;
    auto data = effect->data;
    auto technique = data->current_technique;
    if (data == device->currentEffect)
    {
        if (technique == device->currentTechnique && pass == device->currentPass)
        {
            MOJOSHADER_effectCommitChanges(data);
            return 1;
        }
        MOJOSHADER_effectEndPass(data);
        MOJOSHADER_effectBeginPass(data, pass);
        device->currentTechnique = technique;
        device->currentPass = pass;
        return 1;
    }
    if (device->currentEffect)
    {
        MOJOSHADER_effectEndPass(device->currentEffect);
        MOJOSHADER_effectEnd(device->currentEffect);
    }
    unsigned count;
    MOJOSHADER_effectBegin(data, &count, 0, changes);
    MOJOSHADER_effectBeginPass(data, pass);
    device->currentEffect = data;
    device->currentTechnique = technique;
    device->currentPass = pass;
    return 1;
}
