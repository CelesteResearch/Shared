using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Celeste.Graphics.Effects;

namespace Celeste.Graphics.Rendering.Devices.Native
{
    public unsafe partial class NativeGraphicsDeviceIO
    {
        private CpuEffectFrontend effectFrontend;
        private readonly HashSet<IntPtr> liveEffects = new();
        private readonly ConcurrentQueue<IntPtr> disposedEffects = new();
        private volatile bool effectsDisposed;

        private CpuEffectFrontend Effects
        {
            get
            {
                if (effectsDisposed) throw new ObjectDisposedException(nameof(NativeGraphicsDeviceIO));
                return effectFrontend ??= new CpuEffectFrontend(shaderProfile);
            }
        }

        public void CreateEffect(byte[] code, int length, out IntPtr effect, out IntPtr effectData)
        {
            Effects.CreateEffect(code, length, out effect, out effectData);
            liveEffects.Add(effect);
        }

        public void CloneEffect(IntPtr originalEffect, out IntPtr effect, out IntPtr effectData)
        {
            Effects.CloneEffect(originalEffect, out effect, out effectData);
            liveEffects.Add(effect);
        }

        public void SetEffectTechnique(IntPtr effect, IntPtr technique)
            => Effects.SetEffectTechnique(effect, technique);

        public void AddDisposeEffect(IntPtr effect)
        {
            if (!effectsDisposed && effect != IntPtr.Zero) disposedEffects.Enqueue(effect);
        }

        public void ApplyEffect(IntPtr effect, uint pass, IntPtr changes)
        {
            uint owned = BorrowWriteScope();
            try
            {
                // The native packet evaluates once and captures the selected shaders/registers.
                RequireSuccess(api->ApplyEffect(packet, (void*)effect, pass, (void*)changes));
            }
            finally
            {
                CompleteWriteScope(owned);
            }
        }

        // Called by the core on its owner thread at packet boundaries.
        private void DrainDisposedEffects()
        {
            while (disposedEffects.TryDequeue(out var effect))
                if (liveEffects.Remove(effect))
                    effectFrontend.DestroyEffect(effect);
        }

        // Called after the core has finished/drained its native submissions.
        private void DisposeEffects()
        {
            if (effectsDisposed) return;
            effectsDisposed = true;
            DrainDisposedEffects();
            foreach (var effect in liveEffects) effectFrontend.DestroyEffect(effect);
            liveEffects.Clear();
            effectFrontend?.Dispose();
            effectFrontend = null;
        }
    }
}
