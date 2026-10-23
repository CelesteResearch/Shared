using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.Observation;
using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Rendering.Batches;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Diagnostics.Presentation
{
    // Only the latest completed main gameplay pass is retained. No entity/component references are retained.
    public sealed partial class SourceSpritePresentationCapture : ISourceRenderObserver
    {
        public SourceBackgroundPresentationSnapshot BackgroundSnapshot { get; } = new();

        public SourceCameraPresentationLayer CameraLayer { get; } = new();

        public SourceCameraPresentationDifference GameplayDifference { get; } = new();

        public SourceCameraPresentationPair ForegroundPair { get; } = new();

        public const int EntityBody = 0;
        public const int Component = 1;
        public const int TileGridComponent = 2;
        public const int AnimatedTilesComponent = 3;
        public const int Debug = 4;
        private SourceSpritePresentationQuad[] completed = new SourceSpritePresentationQuad[256];
        private int[] completedBatchGroups = new int[256];

        private int completedCount;
        private SourceSpritePresentationQuad[] pending = new SourceSpritePresentationQuad[256];
        private int[] pendingBatchGroups = new int[256];
        private int pendingCount;
        private SourceSpritePresentationQuad.Header lastHeader;

        private List<SourceSpritePresentationTileCoverage> completedCoverage = [];

        private List<SourceSpritePresentationTileCoverage> pendingCoverage = [];

        public int TileCoverageCount => completedCoverage.Count;

        public SourceSpritePresentationTileCoverage GetTileCoverage(int index)
        {
            return completedCoverage[index];
        }

        private SourceRenderObservationScope scope;
        private readonly Dictionary<Type, int> tileComponentKinds = new();
        private string pendingRoom;
        private object pendingTarget;
        private Matrix4x4 pendingCamera;
        private int pendingDropped;
        public bool IsRecording { get; private set; }
        public SourceRenderObservationScope CurrentScope => scope;
        internal ref readonly SourceRenderObservationScope CurrentScopeRef => ref scope;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public int Count => completedCount;
        public ReadOnlySpan<SourceSpritePresentationQuad> CompletedQuads => completed.AsSpan(0, Count);

        // Borrowed view, valid until the next producer mutation. Synchronous consumers
        // must finish reading before BeginFrame/CompleteFrame/AbortFrame/Clear can run.
        public ReadOnlyMemory<SourceSpritePresentationQuad> CompletedQuadMemory =>
            completed.AsMemory(0, Count);

        // A nonzero value identifies consecutive records sharing one immutable state header.
        // Texture, quad, scope and unsupported counts can differ within a group.
        // Zero means no header guarantee. Groups belong only to this completed array.
        public ReadOnlySpan<int> CompletedBatchGroups => completedBatchGroups.AsSpan(0, Count);

        public SourceSpritePresentationQuad this[int index]
        {
            get
            {
                if ((uint)index >= (uint)Count) throw new ArgumentOutOfRangeException(nameof(index));
                return completed[index];
            }
        }

        public string Room { get; private set; }
        public object Target { get; private set; }
        public Matrix4x4 CameraTransform { get; private set; }
        public long FrameSequence { get; private set; }
        public long Revision { get; private set; }
        public int DroppedCount { get; private set; }

        // Owner-thread hooks for synchronous publication and fencing borrowed Quad/Groups/matrix reads.
        // Auxiliary texture snapshots are independent and are not protected by this contract.
        // Subscribers must not throw; asynchronous failures are observed by their consumer instead.
        public event Action GeometryFrameCompleted;
        public event Action GeometryFrameChanging;

        public bool BeginFrame(string room, in Matrix4x4 camera, object target)
        {
            if (IsRecording) return false;
            GeometryFrameChanging?.Invoke();
            CameraLayer.Invalidate();
            GameplayDifference.Invalidate();
            ForegroundPair.Invalidate();
            ClearPending();
            pendingCoverage.Clear();
            pendingRoom = room;
            pendingTarget = target;
            pendingCamera = camera;
            pendingDropped = 0;
            scope = new(-1, -1, EntityBody, default, default);
            IsRecording = true;
            return true;
        }

        public void CompleteFrame()
        {
            if (!IsRecording) return;
            GeometryFrameChanging?.Invoke();
            var changed = Room != pendingRoom || !ReferenceEquals(Target, pendingTarget)
                                              || !CameraTransform.Equals(pendingCamera) ||
                                              DroppedCount != pendingDropped
                                              || Count != pendingCount ||
                                              completedCoverage.Count != pendingCoverage.Count;
            if (!changed)
                for (var index = 0; index < pendingCount; index++)
                {
                    ref readonly var next = ref pending[index];
                    if (!completed[index].Matches(in next))
                    {
                        changed = true;
                        break;
                    }
                }

            if (!changed)
                for (var index = 0; index < pendingCoverage.Count; index++)
                {
                    var next = pendingCoverage[index];
                    if (!completedCoverage[index].Matches(in next))
                    {
                        changed = true;
                        break;
                    }
                }

            if (changed)
            {
                var previous = completed;
                completed = pending;
                pending = previous;
                var previousBatchGroups = completedBatchGroups;
                completedBatchGroups = pendingBatchGroups;
                pendingBatchGroups = previousBatchGroups;
                var previousCount = Count;
                completedCount = pendingCount;
                pendingCount = previousCount;
                var previousCoverage = completedCoverage;
                completedCoverage = pendingCoverage;
                pendingCoverage = previousCoverage;
                Revision++;
            }

            ClearPending();
            pendingCoverage.Clear();
            Room = pendingRoom;
            Target = pendingTarget;
            CameraTransform = pendingCamera;
            DroppedCount = pendingDropped;
            FrameSequence++;
            // Retain only a header owned by the completed frame. A prepared but
            // unrecorded template must not keep an old target or effect alive.
            lastHeader = Count > 0 ? completed[Count - 1].HeaderRef : null;
            ResetPending();
            GeometryFrameCompleted?.Invoke();
        }

        public void AbortFrame()
        {
            GeometryFrameChanging?.Invoke();
            ForegroundPair.Invalidate();
            lastHeader = null;
            ClearPending();
            pendingCoverage.Clear();
            ResetPending();
        }

        private void ClearPending()
        {
            Array.Clear(pending, 0, pendingCount);
            pendingCount = 0;
        }

        private void AddPending(in SourceSpritePresentationQuad value, int batchGroup = 0)
        {
            if (pendingCount == pending.Length)
            {
                var capacity = pending.Length > int.MaxValue / 2 ? int.MaxValue : pending.Length * 2;
                Array.Resize(ref pending, capacity);
                Array.Resize(ref pendingBatchGroups, capacity);
            }

            if (batchGroup == 0)
                batchGroup = pendingCount > 0 &&
                             ReferenceEquals(pending[pendingCount - 1].HeaderRef, value.HeaderRef) &&
                             pendingBatchGroups[pendingCount - 1] != 0
                    ? pendingBatchGroups[pendingCount - 1]
                    : pendingCount + 1;
            pending[pendingCount] = value;
            pendingBatchGroups[pendingCount] = batchGroup;
            pendingCount++;
        }

        private void ResetPending()
        {
            IsRecording = false;
            pendingRoom = null;
            pendingTarget = null;
            pendingCamera = default;
            scope = default;
            pendingDropped = 0;
        }

        public void CaptureBackground(SourceRenderTarget2DResource source)
        {
            if (FrameSequence > 0)
            {
                var camera = CameraTransform;
                BackgroundSnapshot.Capture(source, Room, in camera, FrameSequence);
            }
        }

        public void Clear()
        {
            GeometryFrameChanging?.Invoke();
            ReleaseParallelCopyResources();
            BackgroundSnapshot.Dispose();
            CameraLayer.Dispose();
            GameplayDifference.Dispose();
            ForegroundPair.Dispose();
            Array.Clear(completed, 0, Count);
            completedCount = 0;
            completedCoverage.Clear();
            tileComponentKinds.Clear();
            AbortFrame();
            Room = null;
            Target = null;
            CameraTransform = default;
            DroppedCount = 0;
            Revision++;
        }

        public SourceRenderObservationScope EnterEntity(int entityIndex, in SourceRenderEntityPresentation owner)
        {
            var previous = scope;
            scope = new(entityIndex, -1,
                previous.ComponentKind == Debug ? Debug : EntityBody, owner);
            return previous;
        }

        public SourceRenderObservationScope EnterNestedEntity(int entityIndex, in SourceRenderEntityPresentation owner)
        {
            var previous = scope;
            var phase = previous.RenderPhase.IsActive ? previous.RenderPhase : new(in owner);
            scope = new(entityIndex, -1,
                previous.ComponentKind == Debug ? Debug : EntityBody, owner, in phase);
            return previous;
        }

        public SourceRenderObservationScope EnterComponent(object component, int componentIndex)
        {
            var previous = scope;
            var kind = Component;
            if (component is TileGrid || component is AnimatedTiles)
            {
                var type = component.GetType();
                var standardType = component is TileGrid ? typeof(TileGrid) : typeof(AnimatedTiles);
                var standardKind = standardType == typeof(TileGrid) ? TileGridComponent : AnimatedTilesComponent;
                if (type == standardType)
                {
                    kind = standardKind;
                }
                else if (!tileComponentKinds.TryGetValue(type, out kind))
                {
                    // A derived Render override must retain its actual captured output rather than be replaced by base tiles.
                    var render = type.GetMethod("Render", [typeof(ISourceRenderContext)]);
                    kind = render?.DeclaringType == standardType ? standardKind : Component;
                    tileComponentKinds.Add(type, kind);
                }
            }

            scope = new(previous.EntityIndex, componentIndex,
                previous.ComponentKind == Debug ? Debug : kind, previous.Owner, in previous.RenderPhase);
            if (scope.ComponentKind == TileGridComponent)
            {
                var grid = (TileGrid)component;
                var tiles = grid.GetClippedRenderTiles();
                var at = ((ISourceEntityPosition)grid.Entity).Position + grid.Position;
                pendingCoverage.Add(new(in scope, in tiles, at, grid.TileWidth,
                    grid.TileHeight));
            }
            else if (scope.ComponentKind == AnimatedTilesComponent)
            {
                var grid = (AnimatedTiles)component;
                var tiles = grid.GetClippedRenderTiles(1);
                var at = ((ISourceEntityPosition)grid.Entity).Position + grid.Position;
                pendingCoverage.Add(new(in scope, in tiles, at, 8, 8));
            }

            return previous;
        }

        public SourceRenderObservationScope EnterDebug()
        {
            var previous = scope;
            scope = new(-1, -1, Debug, default, default);
            return previous;
        }

        public void Exit(in SourceRenderObservationScope previous)
        {
            scope = previous;
        }

        internal void RecordDropped(int primitiveCount)
        {
            if (IsRecording) pendingDropped += primitiveCount;
        }

        internal void RecordUnsupported(in SourceSpritePresentationQuad template, int primitiveCount)
        {
            if (IsRecording) AddPending(new(in template, primitiveCount));
        }

        internal void RecordPrepared(in SourceSpritePresentationQuad template, in SourceSpriteQuad quad,
            bool isPrimitiveTrianglePair = false)
        {
            if (IsRecording)
                AddPending(new(in template, in quad, isPrimitiveTrianglePair));
        }

        private SourceSpritePresentationQuad.Header ResolveHeader(
            in SourceSpritePresentationQuad.HeaderSnapshot snapshot)
        {
            if (lastHeader != null && lastHeader.Value.SameBits(in snapshot)) return lastHeader;
            return lastHeader = new(in snapshot);
        }

        internal SourceSpritePresentationQuad CreateTemplate(SourceTexture2DResource texture,
            in SourceSpriteQuad quad, in SourceSpritePresentationQuad.HeaderSnapshot snapshot,
            in SourceRenderObservationScope owner)
        {
            return new(ResolveHeader(in snapshot), texture, in quad, in owner);
        }

        internal void RecordBatch(SourceTexture2DResource[] textures, SourceSpriteQuad[] quads,
            SourceRenderObservationScope[] owners, int count, in SourceRenderBatchState state,
            object target, int targetCount)
        {
            if (!IsRecording) return;
            var snapshot = new SourceSpritePresentationQuad.HeaderSnapshot(in state, target, targetCount);
            if (count <= 0) return;
            var header = ResolveHeader(in snapshot);
            if (parallelRecords && count >= MinimumParallelRecords &&
                TryRecordBatchParallel(header, textures, quads, owners, count)) return;
            var batchGroup = pendingCount + 1;
            for (var index = 0; index < count; index++)
            {
                var recorded = new SourceSpritePresentationQuad(header, textures[index],
                    in quads[index], in owners[index]);
                if (pendingCount == pending.Length)
                {
                    var capacity = pending.Length > int.MaxValue / 2 ? int.MaxValue : pending.Length * 2;
                    Array.Resize(ref pending, capacity);
                    Array.Resize(ref pendingBatchGroups, capacity);
                }

                pending[pendingCount] = recorded;
                pendingBatchGroups[pendingCount] = batchGroup;
                pendingCount++;
            }
        }

        internal void Record(SourceTexture2DResource texture, in SourceSpriteQuad quad,
            in SourceRenderBatchState state, object target, int targetCount, in SourceRenderObservationScope owner)
        {
            if (!IsRecording) return;
            var recordedQuad = quad;
            var recordedOwner = owner;
            var snapshot = new SourceSpritePresentationQuad.HeaderSnapshot(in state, target, targetCount);
            AddPending(new(ResolveHeader(in snapshot), texture,
                in recordedQuad, in recordedOwner));
        }
    }
}
