using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Trails;
using Celeste.Simulation.Presentation.Effects.Trails.Lifecycle;

namespace Celeste.Everest.Presentation.Effects.Trails
{
    public sealed class EverestTrailManagerState : TrailManagerState
    {
        private VirtualRenderTarget[] buffers = new VirtualRenderTarget[64];

        public EverestTrailManagerState(ISourceEngineContext engine, ISourceRenderEnvironment renderEngine) : base(
            engine,
            renderEngine)
        {
        }

        protected override void DisposeBuffer()
        {
            for (var i = 0; i < buffers.Length; i++)
            {
                buffers[i]?.Dispose();
                buffers[i] = null;
            }

            buffers = new VirtualRenderTarget[snapshots.Length];
        }

        protected override void BeforeRender()
        {
            if (!dirty) return;
            var array = snapshots;
            for (var i = 0; i < array.Length; i++)
                if (array[i] != null && !array[i].Drawn)
                {
                    dirty = true;
                    snapshots = [array[i]];
                    var array2 = buffers;
                    var index = i;
                    if (array2[index] == null)
                        array2[index] =
                            ((ISourceVirtualContentEnvironment)engine).VirtualContent.CreateRenderTarget(
                                "trail-manager-snapshot-" + i, 512, 512);
                    Buffer = buffers[i];
                    DrawCurrentSnapshot();
                }

            snapshots = array;
            dirty = false;
            Buffer = null;
        }

        private void DrawCurrentSnapshot()
        {
            if (!dirty) return;
            if (Buffer == null)
                Buffer = ((ISourceVirtualContentEnvironment)engine).VirtualContent.CreateRenderTarget("trail-manager",
                    512,
                    512);
            var context = renderEngine.CurrentContext;
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(
                Buffer.Target);
            var batch = ((ISourceDrawScope)context).Draw.SpriteBatch;
            batch.Begin(SourceSpriteSortMode.Deferred,
                ((ISourceTrailBlendEnvironment)engine).TrailBlends.OccludeBlendState);
            for (var i = 0; i < snapshots.Length; i++)
                if (snapshots[i] != null && !snapshots[i].Drawn)
                    SourcePrimitiveDrawing.Rect(context, this, 0f, 0f, Buffer.Width, Buffer.Height,
                        PackedColor.Transparent);
            batch.End();
            batch.Begin(SourceSpriteSortMode.Deferred, SourceBlendState.AlphaBlend, SourceSamplerState.PointClamp, null,
                SourceRasterizerState.CullNone);
            for (var j = 0; j < snapshots.Length; j++)
            {
                if (snapshots[j] == null || snapshots[j].Drawn) continue;
                var snapshot = snapshots[j];
                var offset = new Vector2(Buffer.Width * .5f, Buffer.Height * .5f) - snapshot.Position;
                if (snapshot.Hair != null)
                {
                    for (var k = 0; k < snapshot.Hair.Nodes.Count; k++) snapshot.Hair.Nodes[k] += offset;
                    snapshot.Hair.Render(context);
                    for (var l = 0; l < snapshot.Hair.Nodes.Count; l++) snapshot.Hair.Nodes[l] -= offset;
                }

                var scale = snapshot.Sprite.Scale;
                snapshot.Sprite.Scale = snapshot.SpriteScale;
                snapshot.Sprite.Position += offset;
                snapshot.Sprite.Render(context);
                snapshot.Sprite.Scale = scale;
                snapshot.Sprite.Position -= offset;
                snapshot.Drawn = true;
            }

            batch.End();
            batch.Begin(SourceSpriteSortMode.Deferred,
                ((ISourceTrailBlendEnvironment)engine).TrailBlends.MaxBlendState);
            SourcePrimitiveDrawing.Rect(context, this, 0f, 0f, Buffer.Width, Buffer.Height, PackedColor.White);
            batch.End();
            dirty = false;
        }

        protected override void RenderSnapshot(ISourceRenderContext context, TrailSnapshotState snapshot)
        {
            var buffer = buffers[snapshot.Index];
            var source = new IntRect(0, 0, 512, 512);
            var fade = snapshot.Duration > 0f ? .75f * (1f - CubeOut(snapshot.Percent)) : 1f;
            if (buffer != null)
                ((ISourceDrawScope)context).Draw.SpriteBatch.Draw(buffer.Target,
                    snapshot.Position, source, (snapshot.Color * fade).PackedValue, 0f,
                    new Vector2(buffer.Width, buffer.Height) * .5f, Vector2.One, SourceSpriteEffects.None, 0f);
        }
    }
}
