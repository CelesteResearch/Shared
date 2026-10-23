using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Graphics;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Scene.Entities;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;

namespace Celeste.Game.Stories.Temple
{
    public class TemplePortalTorchState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;

        private static OriginalGameGraphicsResources Graphics(ISourceEngineContext e)
        {
            return (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)e).GameGraphics;
        }

        private ISourceRenderContext Context => ((ISourceRenderEnvironment)engine).CurrentContext;

        private readonly Sprite sprite;

        private VertexLightState light;

        private BloomPointState bloom;

        private SoundSourceComponentState loopSfx;

        public TemplePortalTorchState(Vector2 pos, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, pos)
        {
            this.engine = engine;
            Add(sprite = new(engine, Graphics(engine).GameAtlas, "objects/temple/portal/portaltorch"));
            sprite.AddLoop("idle", "", 0f, default(int));
            sprite.AddLoop("lit", "", 0.08f, 1, 2, 3, 4, 5, 6);
            sprite.Play("idle");
            sprite.Origin = new(32f, 64f);
            Depth = 8999;
        }

        public void Light(int count = 0)
        {
            sprite.Play("lit");
            Add(bloom = new(1f, 16f));
            Add(light = new(engine, PackedColor.LightSeaGreen, 0f, 32, 128));
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                count == 0
                    ? "event:/game/05_mirror_temple/mainmirror_torch_lit_1"
                    : "event:/game/05_mirror_temple/mainmirror_torch_lit_2", Position);
            Add(loopSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
            loopSfx.Play("event:/game/05_mirror_temple/mainmirror_torch_loop");
        }

        public override void Update()
        {
            base.Update();
            if (bloom != null && bloom.Alpha > 0.5f) bloom.Alpha -= engine.DeltaTime;

            if (light != null && light.Alpha < 1f)
                light.Alpha = ScalarMath.Approach(light.Alpha, 1f, engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
        }
    }
}
