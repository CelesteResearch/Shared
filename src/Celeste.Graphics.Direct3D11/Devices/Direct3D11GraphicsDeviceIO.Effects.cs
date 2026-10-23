using System;
using Celeste.Graphics.Direct3D11.Interop;

namespace Celeste.Graphics.Direct3D11.Devices
{
    public sealed unsafe partial class Direct3D11GraphicsDeviceIO
    {
        public void CreateEffect(byte[] code, int length, out IntPtr effect, out IntPtr effectData)
        {
            fixed (byte* pointer = code)
            {
                Direct3D11GraphicsBindings.RequireSuccess(
                    Direct3D11GraphicsBindings.SourceGpuCreateEffect(device, pointer,
                        unchecked((uint)length), out effect, out effectData));
            }
        }

        public void CloneEffect(IntPtr originalEffect, out IntPtr effect, out IntPtr effectData)
        {
            Direct3D11GraphicsBindings.RequireSuccess(
                Direct3D11GraphicsBindings.SourceGpuCloneEffect(originalEffect, out effect, out effectData));
        }

        public void SetEffectTechnique(IntPtr effect, IntPtr technique)
        {
            Direct3D11GraphicsBindings.RequireSuccess(
                Direct3D11GraphicsBindings.SourceGpuSetEffectTechnique(effect, technique));
        }

        public void AddDisposeEffect(IntPtr effect)
        {
            Direct3D11GraphicsBindings.RequireSuccess(
                Direct3D11GraphicsBindings.SourceGpuDisposeEffect(effect));
        }

        public void ApplyEffect(IntPtr effect, uint pass, IntPtr changes)
        {
            var owned = BorrowWriteScope();
            try
            {
                Direct3D11GraphicsBindings.RequireSuccess(
                    Direct3D11GraphicsBindings.SourceGpuApplyEffect(effect, pass, changes));
            }
            finally
            {
                CompleteWriteScope(owned);
            }
        }
    }
}
