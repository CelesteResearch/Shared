using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Game.Execution.Engine.Actions;
using Celeste.Game.Gameplay.Effects.Slashes;
using Celeste.Graphics.Rendering;
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

namespace Celeste.Game.Entities.Collectibles.SummitGems
{
    public class OriginalSummitGemManagerState : SceneEntityState
    {
        private class Gem : SceneEntityState
        {
            private readonly ISourceEngineContext engine;
            private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

            private global::Celeste.Graphics.Content.Atlas.AtlasData GameAtlas =>
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas;

            private ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)engine).VectorArithmetic;
            private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
            private ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;

            private global::Celeste.Scene.Components.Oscillation.WigglerComponentPool WigglerPool =>
                ((ISourceWigglerPoolScope)engine).WigglerPool;

            public Vector2 Shake;

            public Sprite Sprite;

            public SpriteImage Bg;

            public BloomPointState Bloom;

            public Gem(ISourceEngineContext engine, int index, Vector2 position)
                : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
            {
                this.engine = engine;
                base.Depth = -10010;
                OwnedComponents.Add(Bg = new SpriteImage(GameAtlas["collectables/summitgems/" + index + "/bg"]));
                OwnedComponents.Add(Sprite =
                    new Sprite(engine, GameAtlas, "collectables/summitgems/" + index + "/gem"));
                OwnedComponents.Add(Bloom = new BloomPointState(0f, 20f));
                Sprite.AddLoop("idle", "", 0.05f, default(int));
                Sprite.Add("spin", "", 0.05f, new Chooser<string>("idle"));
                Sprite.Play("idle");
                Sprite.CenterOrigin();
                Bg.CenterOrigin();
            }

            public override void Update()
            {
                Bloom.Position = Sprite.Position;
                base.Update();
            }

            public override void Render(ISourceRenderContext context)
            {
                Vector2 position = Sprite.Position;
                Sprite.Position += Shake;
                base.Render(context);
                Sprite.Position = position;
            }
        }


        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        private global::Celeste.Graphics.Content.Atlas.AtlasData GameAtlas =>
            ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas;

        private ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)engine).VectorArithmetic;
        private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
        private ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;

        private global::Celeste.Scene.Components.Oscillation.WigglerComponentPool WigglerPool =>
            ((ISourceWigglerPoolScope)engine).WigglerPool;

        private List<Gem> gems = new List<Gem>();

        public OriginalSummitGemManagerState(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset)
        {
            this.engine = engine;
            base.Depth = -10010;
            int num = 0;
            Vector2[] array = data.NodesOffset(offset);
            foreach (Vector2 position in array)
            {
                Gem item = new Gem(engine, num, position);
                gems.Add(item);
                num++;
            }

            OwnedComponents.Add(new SimulationCoroutine(engine, Routine()));
        }

        public override void Awake(object scene)
        {
            foreach (Gem gem in gems)
            {
                ((ISourceScene)scene).SourceScene.QueueSourceEntity(gem);
            }

            base.Awake(scene);
        }

        private IEnumerator Routine()
        {
            OriginalLevelSceneRoot level = base.Scene as OriginalLevelSceneRoot;
            if (level.Session.HeartGem)
            {
                foreach (Gem gem2 in gems)
                {
                    gem2.Sprite.RemoveSelf();
                }

                gems.Clear();
                yield break;
            }

            while (true)
            {
                RoomPlayerSession entity =
                    ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
                if (entity != null && VectorArithmetic.Length(entity.Position - Position) < 64f)
                {
                    break;
                }

                yield return null;
            }

            yield return 0.5f;
            bool alreadyHasHeart = level.Session.OldStats.Modes[0].HeartGem;
            int broken = 0;
            int index = 0;
            foreach (Gem gem in gems)
            {
                bool flag = level.Session.SummitGems[index];
                if (!alreadyHasHeart)
                {
                    flag |= Process.SaveContext.CurrentSave.SummitGems != null &&
                            Process.SaveContext.CurrentSave.SummitGems[index];
                }

                if (flag)
                {
                    switch (index)
                    {
                        case 0:
                            Process.AudioSession.Play("event:/game/07_summit/gem_unlock_1", gem.Position,
                                Process.SaveContext);
                            break;
                        case 1:
                            Process.AudioSession.Play("event:/game/07_summit/gem_unlock_2", gem.Position,
                                Process.SaveContext);
                            break;
                        case 2:
                            Process.AudioSession.Play("event:/game/07_summit/gem_unlock_3", gem.Position,
                                Process.SaveContext);
                            break;
                        case 3:
                            Process.AudioSession.Play("event:/game/07_summit/gem_unlock_4", gem.Position,
                                Process.SaveContext);
                            break;
                        case 4:
                            Process.AudioSession.Play("event:/game/07_summit/gem_unlock_5", gem.Position,
                                Process.SaveContext);
                            break;
                        case 5:
                            Process.AudioSession.Play("event:/game/07_summit/gem_unlock_6", gem.Position,
                                Process.SaveContext);
                            break;
                    }

                    gem.Sprite.Play("spin");
                    while (gem.Sprite.CurrentAnimationID == "spin")
                    {
                        gem.Bloom.Alpha = ScalarMath.Approach(gem.Bloom.Alpha, 1f, engine.DeltaTime * 3f, Extrema);
                        if (gem.Bloom.Alpha > 0.5f)
                        {
                            gem.Shake = RandomShakeVector.Next(((ISourceRandomEnvironment)engine).Random);
                        }

                        gem.Sprite.Position.Y -= engine.DeltaTime * 8f;
                        gem.Sprite.Scale = Vector2.One * (1f + gem.Bloom.Alpha * 0.1f);
                        yield return null;
                    }

                    yield return 0.2f;
                    level.Shake();
                    ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(0, 0);
                    for (int i = 0; i < 20; i++)
                    {
                        level.ParticlesFG.Emit(Process.ParticleTypes.SummitGem.P_Shatter,
                            gem.Position +
                            new Vector2(SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, -8, 8),
                                SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, -8, 8)),
                            OriginalSummitGemState.GemColors[index],
                            SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, (float)Math.PI * 2f));
                    }

                    broken++;
                    gem.Bloom.RemoveSelf();
                    gem.Sprite.RemoveSelf();
                    yield return 0.25f;
                }

                index++;
            }

            if (broken < 6)
            {
                yield break;
            }

            OriginalHeartGemState heart = ((ISourceScene)Scene).SourceScene.Entities.FindFirst<OriginalHeartGemState>();
            if (heart == null)
            {
                yield break;
            }

            Process.AudioSession.Play("event:/game/07_summit/gem_unlock_complete", heart.Position, Process.SaveContext);
            yield return 0.1f;
            Vector2 from = heart.Position;
            for (float p = 0f; p < 1f; p += engine.DeltaTime)
            {
                if (heart.Scene == null)
                {
                    break;
                }

                heart.Position = Vector2Interpolation.Lerp(from, Position + new Vector2(0f, -16f), Easing.CubeOut(p),
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                yield return null;
            }
        }
    }
}
