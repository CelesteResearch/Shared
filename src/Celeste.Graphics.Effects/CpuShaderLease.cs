using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Effects
{
    public sealed class CpuShaderLease : IDisposable
    {
        private IntPtr handle;
        private readonly ICpuEffectNativeBinding binding;

        internal CpuShaderLease(IntPtr handle, ICpuEffectNativeBinding binding)
        {
            this.handle = handle;
            this.binding = binding;
        }

        // Borrowed until Dispose; a native consumer must belong to the same binding/module.
        public IntPtr BorrowNativeHandle(ICpuEffectNativeBinding owner)
        {
            if (handle == IntPtr.Zero) throw new ObjectDisposedException(nameof(CpuShaderLease));
            if (!ReferenceEquals(owner, binding))
                throw new ArgumentException("Shader lease belongs to another native binding.", nameof(owner));
            return handle;
        }

        public CpuShaderDescription Describe()
        {
            if (handle == IntPtr.Zero) throw new ObjectDisposedException(nameof(CpuShaderLease));
            CpuEffectNative.Require(binding, binding.CelesteEffectGetShaderDescription(handle, out var description));
            return description;
        }

        // Cold compiler/generator convenience. Binary SPIR-V must use Output/OutputLength instead.
        public string ReadOutputText()
        {
            var description = Describe();
            return Marshal.PtrToStringUTF8(description.Output, description.OutputLength);
        }

        public CpuShaderSampler ReadSampler(int index)
        {
            var description = Describe();
            if ((uint)index >= (uint)description.SamplerCount) throw new ArgumentOutOfRangeException(nameof(index));
            return Marshal.PtrToStructure<CpuShaderSampler>(description.Samplers +
                                                            index * Marshal.SizeOf<CpuShaderSampler>());
        }

        public void Dispose()
        {
            if (handle == IntPtr.Zero) return;
            binding.CelesteEffectReleaseShader(handle);
            handle = IntPtr.Zero;
        }
    }
}
