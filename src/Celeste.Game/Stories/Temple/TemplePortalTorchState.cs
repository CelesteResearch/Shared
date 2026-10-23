using Celeste.Core.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Components.Timing;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Controls.Source;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Presentation.Effects.Mirrors;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Simulation.Presentation.PostProcessing.Displacement;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Physics.Collision.Shapes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;

namespace Celeste.Game.Stories.Temple
{
    public class TemplePortalTorchState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;

        private static OriginalGameGraphicsResources Graphics(ISourceEngineContext e)
            => (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)e).GameGraphics;

        private ISourceRenderContext Context => ((ISourceRenderEnvironment)engine).CurrentContext;

        private Sprite sprite;

        private VertexLightState light;

        private BloomPointState bloom;

        private SoundSourceComponentState loopSfx;

        public TemplePortalTorchState(Vector2 pos, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, pos)
        {
            this.engine = engine;
            Add(sprite = new Sprite(engine, Graphics(engine).GameAtlas, "objects/temple/portal/portaltorch"));
            sprite.AddLoop("idle", "", 0f, default(int));
            sprite.AddLoop("lit", "", 0.08f, 1, 2, 3, 4, 5, 6);
            sprite.Play("idle");
            sprite.Origin = new Vector2(32f, 64f);
            base.Depth = 8999;
        }

        public void Light(int count = 0)
        {
            sprite.Play("lit");
            Add(bloom = new BloomPointState(1f, 16f));
            Add(light = new VertexLightState(engine, PackedColor.LightSeaGreen, 0f, 32, 128));
            ((Celeste.Core.Audio.ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                (count == 0)
                    ? "event:/game/05_mirror_temple/mainmirror_torch_lit_1"
                    : "event:/game/05_mirror_temple/mainmirror_torch_lit_2", Position);
            Add(loopSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
            loopSfx.Play("event:/game/05_mirror_temple/mainmirror_torch_loop");
        }

        public override void Update()
        {
            base.Update();
            if (bloom != null && bloom.Alpha > 0.5f)
            {
                bloom.Alpha -= engine.DeltaTime;
            }

            if (light != null && light.Alpha < 1f)
            {
                light.Alpha = ScalarMath.Approach(light.Alpha, 1f, engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            }
        }
    }
}
