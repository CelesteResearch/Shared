using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Simulation.Audio.Sources;

namespace Celeste.Simulation.Gameplay.Hazards.Lightning
{
    public sealed partial class LightningRendererState : TiledLightningRendererState<LightningState>
    {
        public new sealed class Edge : TiledLightningRendererState<LightningState>.Edge
        {
            public Edge(LightningState parent, Vector2 a, Vector2 b) : base(parent, a, b)
            {
            }

            public override bool InView(Celeste.Core.Geometry.IntRect view) => base.InView(view);
        }

        public new sealed class Bolt : TiledLightningRendererState<LightningState>.Bolt
        {
            public Bolt(LightningRendererState owner, PackedColor color, float scale, int width, int height)
                : base(owner, color, scale, width, height)
            {
            }

            public override void Render(ISourceRenderContext context) => base.Render(context);
            public override void Update() => base.Update();
        }

        public LightningRendererState(ISourceEngineContext engine, ISourceRenderEnvironment environment,
            ISourceSoundSourceFactory sounds)
            : base(engine, environment, sounds)
        {
        }

        protected override TiledLightningRendererState<LightningState>.Bolt CreateBolt(PackedColor color, float scale,
            int width, int height) => new Bolt(this, color, scale, width, height);

        protected override TiledLightningRendererState<LightningState>.Edge CreateEdge(LightningState parent, Vector2 a,
            Vector2 b) => new Edge(parent, a, b);

        // Retain distinct vanilla hook targets. Hooks of this type must never affect sibling hazards.
        public override void Update() => base.Update();
        public override void Awake(object scene) => base.Awake(scene);
        public override void Render(ISourceRenderContext context) => base.Render(context);
        protected override bool ShouldRenderBlock(LightningState block) => block.Visible;
        protected override bool ShouldRenderEdges() => DrawEdges;
    }
}
