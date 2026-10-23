using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Entities.StarJump
{
    public class OriginalFallEffectsState : SceneEntityState
    {
        private struct Particle
        {
            public Vector2 Position;

            public float Speed;

            public int Color;
        }

        private readonly ISourceEngineContext engine;
        private OriginalFallEffectsProcessState Process => ((IOriginalFallEffectsEnvironment)engine).FallEffectsProcess;

        private Particle[] particles = new Particle[50];

        private float fade;

        private bool enabled;


        public OriginalFallEffectsState(ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.Global.Value;
            base.Depth = -1000000;
            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].Position =
                    new Vector2(SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, 0, 320),
                        SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, 0, 180));
                particles[i].Speed = SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, 120, 240);
                particles[i].Color = ((ISourceRandomEnvironment)engine).Random.Next(Process.Colors.Length);
            }
        }

        public static void Show(ISourceEngineContext engine, bool visible)
        {
            OriginalFallEffectsState fallEffects =
                ((ISourceScene)engine.Frame.Scenes.CurrentScene).SourceScene.Entities
                .GetTrackedEntity<OriginalFallEffectsState>("Celeste.FallEffects");
            if (fallEffects == null && visible)
            {
                ((ISourceScene)engine.Frame.Scenes.CurrentScene).SourceScene.QueueSourceEntity(fallEffects =
                    new OriginalFallEffectsState(engine));
            }

            if (fallEffects != null)
            {
                fallEffects.enabled = visible;
            }

            ((IOriginalFallEffectsEnvironment)engine).FallEffectsProcess.SpeedMultiplier = 1f;
        }

        public override void Update()
        {
            base.Update();
            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].Position -=
                    Vector2.UnitY * particles[i].Speed * Process.SpeedMultiplier * engine.DeltaTime;
            }

            fade = ScalarMath.Approach(fade, enabled ? 1f : 0f, (float)(enabled ? 1 : 4) * engine.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
        }

        public override void Render(ISourceRenderContext context)
        {
            if (!(fade <= 0f))
            {
                var camera = (base.Scene as OriginalLevelSceneRoot).Camera;
                for (int i = 0; i < Process.Faded.Length; i++)
                {
                    Process.Faded[i] = Process.Colors[i] * fade;
                }

                for (int j = 0; j < particles.Length; j++)
                {
                    float num = 8f * Process.SpeedMultiplier;
                    Vector2 vector = new Vector2
                    {
                        X = mod(particles[j].Position.X - camera.X, 320f),
                        Y = mod(particles[j].Position.Y - camera.Y - 16f, 212f)
                    };
                    vector += camera.Position;
                    SourcePrimitiveDrawing.Rect(context, this, vector - new Vector2(0f, num / 2f), 1f, num,
                        Process.Faded[particles[j].Color]);
                }
            }
        }

        private float mod(float x, float m)
        {
            return (x % m + m) % m;
        }
    }
}
