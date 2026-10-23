using System;

namespace Celeste.Graphics.Rendering.Devices.Native.Interop
{
    public static unsafe class NativeGraphicsDeviceApi
    {
        public const uint AbiVersion = 3;

        public static CelesteGraphicsDeviceApi* RequireComplete(CelesteGraphicsDeviceApi* api)
        {
            if (api == null) throw new InvalidOperationException("Native graphics device API is unavailable.");
            if (api->abiVersion != AbiVersion)
                throw new InvalidOperationException(
                    $"Unsupported native graphics device ABI {api->abiVersion}; expected {AbiVersion}.");
            if (api->GetLastError == null)
                throw new InvalidOperationException("Native graphics device API is missing GetLastError.");
            if (api->DestroyDevice == null)
                throw new InvalidOperationException("Native graphics device API is missing DestroyDevice.");
            if (api->CreateTexture == null)
                throw new InvalidOperationException("Native graphics device API is missing CreateTexture.");
            if (api->ReleaseTexture == null)
                throw new InvalidOperationException("Native graphics device API is missing ReleaseTexture.");
            if (api->BeginPacket == null)
                throw new InvalidOperationException("Native graphics device API is missing BeginPacket.");
            if (api->WriteTexture == null)
                throw new InvalidOperationException("Native graphics device API is missing WriteTexture.");
            if (api->CopyTexture == null)
                throw new InvalidOperationException("Native graphics device API is missing CopyTexture.");
            if (api->Present == null)
                throw new InvalidOperationException("Native graphics device API is missing Present.");
            if (api->Submit == null)
                throw new InvalidOperationException("Native graphics device API is missing Submit.");
            if (api->ReleasePacket == null)
                throw new InvalidOperationException("Native graphics device API is missing ReleasePacket.");
            if (api->GetCompletion == null)
                throw new InvalidOperationException("Native graphics device API is missing GetCompletion.");
            if (api->Wait == null)
                throw new InvalidOperationException("Native graphics device API is missing Wait.");
            if (api->ReleaseSubmission == null)
                throw new InvalidOperationException("Native graphics device API is missing ReleaseSubmission.");
            if (api->ReleaseOutput == null)
                throw new InvalidOperationException("Native graphics device API is missing ReleaseOutput.");
            if (api->GetCapabilities == null)
                throw new InvalidOperationException("Native graphics device API is missing GetCapabilities.");
            if (api->GetMaxMultiSampleCount == null)
                throw new InvalidOperationException("Native graphics device API is missing GetMaxMultiSampleCount.");
            if (api->ConfigureBackbuffer == null)
                throw new InvalidOperationException("Native graphics device API is missing ConfigureBackbuffer.");
            if (api->GetBackbufferInfo == null)
                throw new InvalidOperationException("Native graphics device API is missing GetBackbufferInfo.");
            if (api->PresentBackbuffer == null)
                throw new InvalidOperationException("Native graphics device API is missing PresentBackbuffer.");
            if (api->SetViewport == null)
                throw new InvalidOperationException("Native graphics device API is missing SetViewport.");
            if (api->SetScissorRect == null)
                throw new InvalidOperationException("Native graphics device API is missing SetScissorRect.");
            if (api->Clear == null)
                throw new InvalidOperationException("Native graphics device API is missing Clear.");
            if (api->SetBlendState == null)
                throw new InvalidOperationException("Native graphics device API is missing SetBlendState.");
            if (api->SetDepthStencilState == null)
                throw new InvalidOperationException("Native graphics device API is missing SetDepthStencilState.");
            if (api->SetRasterizerState == null)
                throw new InvalidOperationException("Native graphics device API is missing SetRasterizerState.");
            if (api->SetSampler == null)
                throw new InvalidOperationException("Native graphics device API is missing SetSampler.");
            if (api->GetBlendFactor == null)
                throw new InvalidOperationException("Native graphics device API is missing GetBlendFactor.");
            if (api->SetBlendFactor == null)
                throw new InvalidOperationException("Native graphics device API is missing SetBlendFactor.");
            if (api->GetSampleMask == null)
                throw new InvalidOperationException("Native graphics device API is missing GetSampleMask.");
            if (api->SetSampleMask == null)
                throw new InvalidOperationException("Native graphics device API is missing SetSampleMask.");
            if (api->GetStencilReference == null)
                throw new InvalidOperationException("Native graphics device API is missing GetStencilReference.");
            if (api->SetStencilReference == null)
                throw new InvalidOperationException("Native graphics device API is missing SetStencilReference.");
            if (api->SetRenderTargets == null)
                throw new InvalidOperationException("Native graphics device API is missing SetRenderTargets.");
            if (api->ResolveTarget == null)
                throw new InvalidOperationException("Native graphics device API is missing ResolveTarget.");
            if (api->CreateColorRenderbuffer == null)
                throw new InvalidOperationException("Native graphics device API is missing CreateColorRenderbuffer.");
            if (api->CreateDepthRenderbuffer == null)
                throw new InvalidOperationException("Native graphics device API is missing CreateDepthRenderbuffer.");
            if (api->ReleaseRenderbuffer == null)
                throw new InvalidOperationException("Native graphics device API is missing ReleaseRenderbuffer.");
            if (api->SetTextureName == null)
                throw new InvalidOperationException("Native graphics device API is missing SetTextureName.");
            if (api->ReadTexture == null)
                throw new InvalidOperationException("Native graphics device API is missing ReadTexture.");
            if (api->ReadBackbuffer == null)
                throw new InvalidOperationException("Native graphics device API is missing ReadBackbuffer.");
            if (api->CreateBuffer == null)
                throw new InvalidOperationException("Native graphics device API is missing CreateBuffer.");
            if (api->ReleaseBuffer == null)
                throw new InvalidOperationException("Native graphics device API is missing ReleaseBuffer.");
            if (api->WriteBuffer == null)
                throw new InvalidOperationException("Native graphics device API is missing WriteBuffer.");
            if (api->ReadBuffer == null)
                throw new InvalidOperationException("Native graphics device API is missing ReadBuffer.");
            if (api->SetVertexBindings == null)
                throw new InvalidOperationException("Native graphics device API is missing SetVertexBindings.");
            if (api->Draw == null)
                throw new InvalidOperationException("Native graphics device API is missing Draw.");
            if (api->DrawIndexed == null)
                throw new InvalidOperationException("Native graphics device API is missing DrawIndexed.");
            if (api->ApplyEffect == null)
                throw new InvalidOperationException("Native graphics device API is missing ApplyEffect.");
            if (api->GetReadbackStatus == null)
                throw new InvalidOperationException("Native graphics device API is missing GetReadbackStatus.");
            if (api->GetReadbackBytes == null)
                throw new InvalidOperationException("Native graphics device API is missing GetReadbackBytes.");
            if (api->ReleaseReadback == null)
                throw new InvalidOperationException("Native graphics device API is missing ReleaseReadback.");
            if (api->Allocate == null)
                throw new InvalidOperationException("Native graphics device API is missing Allocate.");
            if (api->Free == null)
                throw new InvalidOperationException("Native graphics device API is missing Free.");
            return api;
        }
    }
}
