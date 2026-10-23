using System;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Diagnostics.Presentation
{
    // Two frozen outputs from one normally executed camera composition phase.
    public sealed class SourceCameraPresentationDifference : IDisposable
    {
        private SourceRenderTarget2DResource source;
        private string pendingRoom;
        private Matrix4x4 pendingCamera;
        private long pendingFrame;

        public SourceBackgroundPresentationSnapshot Before { get; } = new();
        public SourceBackgroundPresentationSnapshot After { get; } = new();
        public bool IsRecording { get; private set; }
        public string Room { get; private set; }
        public Matrix4x4 CameraTransform { get; private set; }
        public object Target { get; private set; }
        public long FrameSequence { get; private set; }
        public int UnsupportedCount { get; private set; }
        public int ObservedDrawCount { get; private set; }

        public bool Begin(SourceRenderTarget2DResource target, string room, in Matrix4x4 camera, long frameSequence)
        {
            var reentrant = IsRecording;
            Invalidate();
            if (reentrant || frameSequence <= 0) return false;
            Before.Capture(target, room, in camera, frameSequence);
            source = target;
            pendingRoom = room;
            pendingCamera = camera;
            pendingFrame = frameSequence;
            IsRecording = true;
            return true;
        }

        internal void Observe(in SourceNativeBlendState blend, bool hasBlend, object target, int targetCount,
            int count)
        {
            if (!IsRecording) return;
            ObservedDrawCount += count;
            if (!hasBlend || !ReferenceEquals(target, source) || targetCount != 1 ||
                blend.colorSourceBlend != SourceBlendFactor.One ||
                blend.colorDestinationBlend != SourceBlendFactor.One ||
                blend.colorBlendFunction != SourceBlendFunction.ReverseSubtract ||
                blend.alphaSourceBlend != SourceBlendFactor.Zero ||
                blend.alphaDestinationBlend != SourceBlendFactor.One ||
                blend.alphaBlendFunction != SourceBlendFunction.Add)
                UnsupportedCount += count;
        }

        public void Complete()
        {
            if (!IsRecording) return;
            After.Capture(source, pendingRoom, in pendingCamera, pendingFrame);
            Room = pendingRoom;
            CameraTransform = pendingCamera;
            Target = source;
            FrameSequence = pendingFrame;
            ResetPending();
        }

        public void Abort()
        {
            if (IsRecording) Invalidate();
        }

        public void Invalidate()
        {
            Room = null;
            CameraTransform = default;
            Target = null;
            FrameSequence = 0;
            UnsupportedCount = 0;
            ObservedDrawCount = 0;
            ResetPending();
        }

        private void ResetPending()
        {
            IsRecording = false;
            source = null;
            pendingRoom = null;
            pendingCamera = default;
            pendingFrame = 0;
        }

        public void Dispose()
        {
            Invalidate();
            Before.Dispose();
            After.Dispose();
        }
    }
}
