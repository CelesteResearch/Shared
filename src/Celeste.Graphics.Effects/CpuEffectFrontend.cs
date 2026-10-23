using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Effects
{
    // Owner-thread CPU operations composed by the host IO. The host AddDisposeEffect
    // must enqueue finalizer requests and drain them on the device owner thread.
    public sealed class CpuEffectFrontend : IDisposable
    {
        private IntPtr handle;
        private readonly ICpuEffectNativeBinding binding;

        public CpuEffectFrontend(string profile) : this(profile, CpuEffectNative.Instance)
        {
        }

        public CpuEffectFrontend(string profile, ICpuEffectNativeBinding binding)
        {
            this.binding = binding ?? throw new ArgumentNullException(nameof(binding));
            CpuEffectNative.Require(binding, binding.CelesteEffectFrontendCreate(profile, out handle));
        }

        public unsafe void CreateEffect(byte[] code, int length, out IntPtr effect, out IntPtr effectData)
        {
            if (handle == IntPtr.Zero) throw new ObjectDisposedException(nameof(CpuEffectFrontend));
            if (code == null) throw new ArgumentNullException(nameof(code));
            if ((uint)length > (uint)code.Length) throw new ArgumentOutOfRangeException(nameof(length));
            fixed (byte* bytes = code)
                CpuEffectNative.Require(binding, binding.CelesteEffectCreate(handle, (IntPtr)bytes,
                    (uint)length, out effect, out effectData));
        }

        public void CloneEffect(IntPtr original, out IntPtr effect, out IntPtr effectData)
            => CpuEffectNative.Require(binding, binding.CelesteEffectClone(original, out effect, out effectData));

        public void SetEffectTechnique(IntPtr effect, IntPtr technique)
            => CpuEffectNative.Require(binding, binding.CelesteEffectSetTechnique(effect, technique));

        // Synchronous owner-thread destruction, never a finalizer enqueue operation.
        public void DestroyEffect(IntPtr effect) => binding.CelesteEffectDestroy(effect);

        public void ApplyEffect(IntPtr effect, uint pass, IntPtr changes)
            => CpuEffectNative.Require(binding, binding.CelesteEffectApply(effect, pass, changes));

        public uint GetShaderCount(IntPtr effect)
        {
            CpuEffectNative.Require(binding, binding.CelesteEffectGetShaderCount(effect, out var count));
            return count;
        }

        public CpuShaderLease AcquireShader(IntPtr effect, uint index)
        {
            CpuEffectNative.Require(binding, binding.CelesteEffectAcquireShader(effect, index, out var shader));
            return new CpuShaderLease(shader, binding);
        }

        public uint GetTechniqueCount(IntPtr effect)
        {
            CpuEffectNative.Require(binding, binding.CelesteEffectGetTechniqueCount(effect, out var count));
            return count;
        }

        public IntPtr GetTechnique(IntPtr effect, uint index, out uint passCount)
        {
            CpuEffectNative.Require(binding, binding.CelesteEffectGetTechnique(effect, index,
                out var technique, out passCount));
            return technique;
        }

        public uint GetPassStageFlags(IntPtr effect, uint technique, uint pass)
        {
            CpuEffectNative.Require(binding, binding.CelesteEffectGetPassStageFlags(effect, technique,
                pass, out var flags));
            return flags;
        }

        public uint GetPassShaderCount(IntPtr effect, uint technique, uint pass, bool vertex)
        {
            CpuEffectNative.Require(binding, binding.CelesteEffectGetPassShaderCount(effect, technique,
                pass, vertex ? 1 : 0, out var count));
            return count;
        }

        public CpuShaderLease AcquirePassShader(IntPtr effect, uint technique, uint pass, bool vertex, uint index)
        {
            CpuEffectNative.Require(binding, binding.CelesteEffectAcquirePassShader(effect, technique,
                pass, vertex ? 1 : 0, index, out var shader));
            return new CpuShaderLease(shader, binding);
        }

        public CpuShaderLease AcquireBoundShader(IntPtr effect, bool vertex)
        {
            CpuEffectNative.Require(binding,
                binding.CelesteEffectAcquireBoundShader(effect, vertex ? 1 : 0, out var shader));
            return shader == IntPtr.Zero ? null : new CpuShaderLease(shader, binding);
        }

        // View is invalidated by the next Apply in this context or by effect disposal.
        public CpuRegisterView BorrowRegisters(IntPtr effect)
        {
            CpuEffectNative.Require(binding, binding.CelesteEffectBorrowRegisters(effect, out var view));
            return view;
        }

        public void CopyRegisters(IntPtr effect, in CpuRegisterView target)
            => CpuEffectNative.Require(binding, binding.CelesteEffectCopyRegisters(effect, in target));

        public void CopyHlslConstants(IntPtr effect, bool vertex, IntPtr target, uint capacityBytes)
            => CpuEffectNative.Require(binding, binding.CelesteEffectCopyHlslConstants(effect, vertex ? 1 : 0,
                target, capacityBytes));

        public void Dispose()
        {
            if (handle == IntPtr.Zero) return;
            binding.CelesteEffectFrontendDestroy(handle);
            handle = IntPtr.Zero;
        }
    }
}
