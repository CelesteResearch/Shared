using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.Puzzles.ForsakenSatellite;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Scene.Entities;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.Particles.Definitions;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;

namespace Celeste.Game.Entities.Collectibles.Hearts
{
    public class OriginalDreamHeartGemState : SceneEntityState
    {
        private readonly Sprite sprite;
        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        private AtlasData GameAtlas =>
            ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas;

        private ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)engine).VectorArithmetic;
        private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
        private ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;
        private ISourceCurveArithmetic CurveArithmetic => ((ISourceCurveEnvironment)engine).CurveArithmetic;
        private OriginalSatelliteProcessState SourceState => ((IOriginalSatelliteEnvironment)engine).SatelliteProcess;
        private Dictionary<string, PackedColor> Colors => Process.ParticleTypes.ForsakenCitySatellite.Colors;

        private Dictionary<string,
                ParticleTypePresentation>
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
            for (var i = 0; i < sprite.Height; i++)
                sprite.DrawSubrect(context,
                    new((float)Math.Sin(((OriginalLevelSceneRoot)Scene).TimeActive * 2f + i * 0.4f) * 2f,
                        i),
                    new(0, i, (int)sprite.Width, 1), Extrema);
        }
    }
}
