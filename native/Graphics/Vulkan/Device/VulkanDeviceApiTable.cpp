#include "CelesteGraphicsVulkan.h"
#include "VulkanApiErrors.h"
#include "VulkanPacketApi.h"
#include "CelesteGraphicsOutput.h"
#include "VulkanResourceApi.h"
#include "VulkanDepthApi.h"
#include "VulkanColorRenderbufferApi.h"
#include "VulkanDrawApi.h"
#include "VulkanPresentationApi.h"
#include <cstdlib>
#include <stdexcept>
#include <type_traits>
namespace
{
    template <auto Function> struct Checked;
    template <class... Args, void (*Function)(Args...)> struct Checked<Function>
    {
        static int32_t Call(Args... args) noexcept
        {
            return VulkanInvoke([&] { Function(args...); });
        }
    };
    template <auto Function> struct Status;
    template <class... Args, int32_t (*Function)(Args...)> struct Status<Function>
    {
        static int32_t Call(Args... args) noexcept
        {
            int32_t result = -1;
            return VulkanInvoke([&] { result = Function(args...); }) ? result : -1;
        }
    };
    int32_t Allocate(uint32_t count, void** bytes) noexcept
    {
        if (bytes)
            *bytes = nullptr;
        return VulkanInvoke([&] {
            if (!bytes)
                throw std::invalid_argument("Allocation requires output");
            *bytes = std::malloc(count);
            if (!*bytes && count)
                throw std::bad_alloc();
        });
    }
    void ReleaseOutput(CelesteGraphicsOutput* output) noexcept
    {
        delete output;
    }
    CelesteGraphicsDeviceApi BuildApi()
    {
        CelesteGraphicsDeviceApi api{};
        api.abiVersion = CELESTE_GRAPHICS_DEVICE_ABI_VERSION;

        api.GetLastError = CelesteVulkanGetLastError;
        api.DestroyDevice = CelesteVulkanReleaseDevice;
        api.BeginPacket = Checked<VulkanBeginPacket>::Call;
        api.Submit = Checked<VulkanSubmitPacket>::Call;
        api.ReleasePacket = VulkanReleasePacket;
        api.GetCompletion = Status<VulkanSubmissionCompletion>::Call;
        api.Wait = Checked<VulkanWaitSubmission>::Call;
        api.ReleaseSubmission = VulkanReleaseSubmission;
        api.ReleaseOutput = ReleaseOutput;
        using namespace Celeste::Graphics::Vulkan;
        api.CreateTexture = Checked<CreateTexture>::Call;
        api.ReleaseTexture = ReleaseTexture;
        api.SetTextureName = Checked<SetTextureName>::Call;
        api.WriteTexture = Checked<WriteTexture>::Call;
        api.CopyTexture = Checked<CopyTexture>::Call;
        api.ReadTexture = Checked<ReadTexture>::Call;
        api.ReadBackbuffer = Checked<ReadBackbuffer>::Call;
        api.CreateBuffer = Checked<CreateBuffer>::Call;
        api.ReleaseBuffer = ReleaseBuffer;
        api.WriteBuffer = Checked<WriteBuffer>::Call;
        api.ReadBuffer = Checked<ReadBuffer>::Call;
        api.GetReadbackStatus = Status<GetReadbackStatus>::Call;
        api.GetReadbackBytes = Checked<GetReadbackBytes>::Call;
        api.ReleaseReadback = ReleaseReadback;
        api.CreateDepthRenderbuffer = Checked<CreateDepthRenderbuffer>::Call;
        api.CreateColorRenderbuffer = Checked<CreateColorRenderbuffer>::Call;
        api.ResolveTarget = Checked<ResolveTarget>::Call;
        api.ReleaseRenderbuffer = ReleaseRenderbuffer;
        api.Allocate = Allocate;
        api.Free = std::free;
        api.GetCapabilities = Checked<GetCapabilities>::Call;
        api.GetMaxMultiSampleCount = Checked<GetMaxMultiSampleCount>::Call;
        api.Present = Checked<Present>::Call;
        api.PresentBackbuffer = Checked<PresentBackbuffer>::Call;
        api.ConfigureBackbuffer = Checked<ConfigureBackbuffer>::Call;
        api.GetBackbufferInfo = Checked<GetBackbufferInfo>::Call;
        api.Clear = Checked<Clear>::Call;
        api.GetBlendFactor = Checked<GetBlendFactor>::Call;
        api.GetSampleMask = Checked<GetSampleMask>::Call;
        api.GetStencilReference = Checked<GetStencilReference>::Call;
        api.SetViewport = Checked<SetViewport>::Call;
        api.SetScissorRect = Checked<SetScissorRect>::Call;
        api.SetBlendState = Checked<SetBlendState>::Call;
        api.SetDepthStencilState = Checked<SetDepthStencilState>::Call;
        api.SetRasterizerState = Checked<SetRasterizerState>::Call;
        api.SetSampler = Checked<SetSampler>::Call;
        api.SetBlendFactor = Checked<SetBlendFactor>::Call;
        api.SetSampleMask = Checked<SetSampleMask>::Call;
        api.SetStencilReference = Checked<SetStencilReference>::Call;
        api.SetRenderTargets = Checked<SetRenderTargets>::Call;
        api.SetVertexBindings = Checked<SetVertexBindings>::Call;
        api.Draw = Checked<Draw>::Call;
        api.DrawIndexed = Checked<DrawIndexed>::Call;
        api.ApplyEffect = Checked<ApplyEffect>::Call;
        return api;
    }
}
extern "C" const CelesteGraphicsDeviceApi* CELESTE_GRAPHICS_CALL CelesteVulkanGetDeviceApi()
{
    static const CelesteGraphicsDeviceApi api = BuildApi();
    return &api;
}
