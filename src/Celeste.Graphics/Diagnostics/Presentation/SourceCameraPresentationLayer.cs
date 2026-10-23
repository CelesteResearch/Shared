using System;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.Observation;
using Celeste.Graphics.Rendering.Batches;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Diagnostics.Presentation
{
    // Observes one real camera-space composition batch; it never executes rendering.
    public sealed class SourceCameraPresentationLayer : IDisposable
    {
        private SourceSpritePresentationQuad[] records = new SourceSpritePresentationQuad[4];
        private int count;
        private SourceRenderTarget2DResource source;
        private string pendingRoom;
        private Matrix4x4 pendingCamera;
        private long pendingFrame;
        private object pendingTarget;

        public SourceBackgroundPresentationSnapshot Snapshot { get; } = new();
        public bool IsRecording { get; private set; }
        public int Count => FrameSequence > 0 ? count : 0;
        public ReadOnlySpan<SourceSpritePresentationQuad> CompletedQuads => records.AsSpan(0, Count);
        public string Room { get; private set; }
        public Matrix4x4 CameraTransform { get; private set; }
        public object Target { get; private set; }
        public long FrameSequence { get; private set; }
        public int UnsupportedCount { get; private set; }

        public bool Begin(SourceRenderTarget2DResource texture, object target, string room,
            in Matrix4x4 camera, long frameSequence)
        {
            var reentrant = IsRecording;
            Invalidate();
            if (reentrant || frameSequence <= 0) return false;
            Snapshot.Capture(texture, room, in camera, frameSequence);
            source = texture;
            pendingTarget = target;
            pendingRoom = room;
            pendingCamera = camera;
            pendingFrame = frameSequence;
            IsRecording = true;
            return true;
        }

        internal void RecordBatch(SourceTexture2DResource[] textures, SourceSpriteQuad[] quads, int length,
            in SourceRenderBatchState state, object target, int targetCount)
        {
            if (!IsRecording) return;
            var quad = default(SourceSpriteQuad);
            var owner = default(SourceRenderObservationScope);
            var template = new SourceSpritePresentationQuad(null, in quad, in state, target, targetCount, in owner);
            for (var index = 0; index < length; index++)
                Record(in template, textures[index], in quads[index]);
        }

        internal void Record(SourceTexture2DResource texture, in SourceSpriteQuad quad,
            in SourceRenderBatchState state, object target, int targetCount)
        {
            if (!IsRecording) return;
            var owner = default(SourceRenderObservationScope);
            var template = new SourceSpritePresentationQuad(null, in quad, in state, target, targetCount, in owner);
            Record(in template, texture, in quad);
        }

        private void Record(in SourceSpritePresentationQuad template, SourceTexture2DResource texture,
            in SourceSpriteQuad quad)
        {
            if (!ReferenceEquals(texture, source) || !ReferenceEquals(template.Target, pendingTarget) ||
                template.TargetCount != 1)
            {
                UnsupportedCount++;
                return;
            }

            if (count == records.Length) Array.Resize(ref records, checked(records.Length * 2));
            var owner = default(SourceRenderObservationScope);
            records[count++] = new(in template, Snapshot.Texture, in quad, in owner);
        }

        public void Complete()
        {
            if (!IsRecording) return;
            Room = pendingRoom;
            CameraTransform = pendingCamera;
            Target = pendingTarget;
            FrameSequence = pendingFrame;
            ResetPending();
        }

        public void Abort()
        {
            if (IsRecording) Invalidate();
        }

        public void Invalidate()
        {
            Array.Clear(records, 0, count);
            count = 0;
            FrameSequence = 0;
            Room = null;
            Target = null;
            CameraTransform = default;
            UnsupportedCount = 0;
            ResetPending();
        }

        private void ResetPending()
        {
            IsRecording = false;
            source = null;
            pendingTarget = null;
            pendingRoom = null;
            pendingCamera = default;
            pendingFrame = 0;
        }

        public void Dispose()
        {
            Invalidate();
            Snapshot.Dispose();
        }
    }
}
