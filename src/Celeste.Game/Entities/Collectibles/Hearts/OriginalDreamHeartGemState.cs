using Celeste.Core.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Timing;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Scheduling;
using Celeste.Core.Randomness;
using Celeste.Core.Audio;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Dash;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Runtime.Session;
using Celeste.Simulation.Presentation.Particles;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Entities.Collectibles.Hearts;
using Celeste.Game.Entities.Effects.AbsorbOrbs;
using Celeste.Game.Presentation.Particles;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Particles.Sources;
using Celeste.Core.Rendering;
using Celeste.Game.Entities.Puzzles.ForsakenSatellite;

namespace Celeste.Game.Entities.Collectibles.Hearts
{
    public class OriginalDreamHeartGemState : SceneEntityState
    {
        private Sprite sprite;
        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        private global::Celeste.Graphics.Content.Atlas.AtlasData GameAtlas =>
            ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas;

        private ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)engine).VectorArithmetic;
        private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
        private ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;
        private ISourceCurveArithmetic CurveArithmetic => ((ISourceCurveEnvironment)engine).CurveArithmetic;
        private OriginalSatelliteProcessState SourceState => ((IOriginalSatelliteEnvironment)engine).SatelliteProcess;
        private Dictionary<string, PackedColor> Colors => Process.ParticleTypes.ForsakenCitySatellite.Colors;

        private Dictionary<string,
                global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation>
            Particles => Process.ParticleTypes.ForsakenCitySatellite.Particles;


        public OriginalDreamHeartGemState(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset)
        {
            this.engine = engine;
            OwnedComponents.Add(sprite =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("heartgem0"));
            sprite.Color = PackedColor.White * 0.25f;
            sprite.Play("spin");
            OwnedComponents.Add(new BloomPointState(0.5f, 16f));
            OwnedComponents.Add(new VertexLightState(engine, PackedColor.Aqua, 1f, 32, 64));
        }

        public override void Render(ISourceRenderContext context)
        {
            for (int i = 0; (float)i < sprite.Height; i++)
            {
                sprite.DrawSubrect(context,
                    new Vector2((float)Math.Sin(((OriginalLevelSceneRoot)Scene).TimeActive * 2f + (float)i * 0.4f) * 2f,
                        i),
                    new IntRect(0, i, (int)sprite.Width, 1), Extrema);
            }
        }
    }
}
