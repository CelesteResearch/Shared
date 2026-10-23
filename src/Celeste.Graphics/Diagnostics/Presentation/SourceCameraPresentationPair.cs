using System;
using System.Numerics;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Diagnostics.Presentation
{
    // Frozen outputs surrounding one normally executed camera composition phase.
    public sealed class SourceCameraPresentationPair : IDisposable
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
