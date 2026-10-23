using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Effects
{
    // All handles/views are owned by this binding and its native module.
    public interface ICpuEffectNativeBinding
    {
        IntPtr CelesteEffectGetError();

        int CelesteEffectFrontendCreate([MarshalAs(UnmanagedType.LPUTF8Str)] string profile,
            out IntPtr frontend);

        void CelesteEffectFrontendDestroy(IntPtr frontend);

        int CelesteEffectCreate(IntPtr frontend, IntPtr code, uint length, out IntPtr effect,
            out IntPtr metadata);

        int CelesteEffectClone(IntPtr source, out IntPtr effect, out IntPtr metadata);

        void CelesteEffectDestroy(IntPtr effect);

        int CelesteEffectSetTechnique(IntPtr effect, IntPtr technique);

        int CelesteEffectApply(IntPtr effect, uint pass, IntPtr changes);

        int CelesteEffectGetShaderCount(IntPtr effect, out uint count);

        int CelesteEffectGetTechniqueCount(IntPtr effect, out uint count);

        int CelesteEffectGetTechnique(IntPtr effect, uint index,
            out IntPtr technique, out uint passCount);

        int CelesteEffectGetPassStageFlags(IntPtr effect, uint technique,
            uint pass, out uint flags);

        int CelesteEffectGetPassShaderCount(IntPtr effect, uint technique,
            uint pass, int vertex, out uint count);

        int CelesteEffectAcquirePassShader(IntPtr effect, uint technique,
            uint pass, int vertex, uint index, out IntPtr shader);

        int CelesteEffectAcquireShader(IntPtr effect, uint index, out IntPtr shader);

        int CelesteEffectAcquireBoundShader(IntPtr effect, int vertex, out IntPtr shader);

        int CelesteEffectGetShaderDescription(IntPtr shader,
            out CpuShaderDescription description);

        void CelesteEffectReleaseShader(IntPtr shader);

        int CelesteEffectBorrowRegisters(IntPtr effect, out CpuRegisterView view);

        int CelesteEffectCopyRegisters(IntPtr effect, in CpuRegisterView target);

        int CelesteEffectCopyHlslConstants(IntPtr effect, int vertex, IntPtr target,
            uint capacityBytes);
    }
}
