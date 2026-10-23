using System;
using Celeste.Core.Display;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Graphics.Rendering.Devices.Native;

public unsafe partial class NativeGraphicsDeviceIO : ISourceGraphicsDeviceStateIO
{
    public void GetBlendFactor(out PackedColor color)
    {
        uint value;
        RequireSuccess(api->GetBlendFactor(device, &value));
        color = new PackedColor { PackedValue = value };
    }

    public void SetBlendFactor(ref PackedColor color)
    {
        uint owned = BorrowWriteScope();
        try
        {
            RequireSuccess(api->SetBlendFactor(packet, color.PackedValue));
        }
        finally
        {
            CompleteWriteScope(owned);
        }
    }

    public int GetMultiSampleMask()
    {
        int value;
        RequireSuccess(api->GetSampleMask(device, &value));
        return value;
    }

    public void SetMultiSampleMask(int mask)
    {
        uint owned = BorrowWriteScope();
        try
        {
            RequireSuccess(api->SetSampleMask(packet, mask));
        }
        finally
        {
            CompleteWriteScope(owned);
        }
    }

    public int GetReferenceStencil()
    {
        int value;
        RequireSuccess(api->GetStencilReference(device, &value));
        return value;
    }

    public void SetReferenceStencil(int stencil)
    {
        uint owned = BorrowWriteScope();
        try
        {
            RequireSuccess(api->SetStencilReference(packet, stencil));
        }
        finally
        {
            CompleteWriteScope(owned);
        }
    }

    public void SetBlendState(ref SourceNativeBlendState state)
    {
        uint owned = BorrowWriteScope();
        try
        {
            fixed (SourceNativeBlendState* pointer = &state)
                RequireSuccess(api->SetBlendState(packet, pointer));
        }
        finally
        {
            CompleteWriteScope(owned);
        }
    }

    public void SetDepthStencilState(ref SourceNativeDepthStencilState state)
    {
        uint owned = BorrowWriteScope();
        try
        {
            fixed (SourceNativeDepthStencilState* pointer = &state)
                RequireSuccess(api->SetDepthStencilState(packet, pointer));
        }
        finally
        {
            CompleteWriteScope(owned);
        }
    }

    public void ApplyRasterizerState(ref SourceNativeRasterizerState state)
    {
        uint owned = BorrowWriteScope();
        try
        {
            fixed (SourceNativeRasterizerState* pointer = &state)
                RequireSuccess(api->SetRasterizerState(packet, pointer));
        }
        finally
        {
            CompleteWriteScope(owned);
        }
    }

    public void VerifySampler(int index, IntPtr texture, ref SourceNativeSamplerState state)
        => SetSampler(index, texture, ref state, 0);

    public void VerifyVertexSampler(int index, IntPtr texture, ref SourceNativeSamplerState state)
        => SetSampler(index, texture, ref state, 1);

    private void SetSampler(int index, IntPtr texture, ref SourceNativeSamplerState state, byte vertexStage)
    {
        uint owned = BorrowWriteScope();
        try
        {
            fixed (SourceNativeSamplerState* pointer = &state)
                RequireSuccess(api->SetSampler(packet, unchecked((uint)index), vertexStage, texture, pointer));
        }
        finally
        {
            CompleteWriteScope(owned);
        }
    }
}
