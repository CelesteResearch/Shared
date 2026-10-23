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

namespace Celeste.Game.Entities.Puzzles.ReflectionHeart
{
    public class OriginalReflectionHeartStatueState : SceneEntityState
    {
        public class Torch : SceneEntityState
        {
            public string[] Code;

            private Sprite sprite;
            private readonly ISourceEngineContext engine;
            private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

            private global::Celeste.Graphics.Content.Atlas.AtlasData GameAtlas =>
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas;

            private ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)engine).VectorArithmetic;
            private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
            private ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;
            private ISourceCurveArithmetic CurveArithmetic => ((ISourceCurveEnvironment)engine).CurveArithmetic;

            private OriginalSatelliteProcessState SourceState =>
                ((IOriginalSatelliteEnvironment)engine).SatelliteProcess;

            private Dictionary<string, PackedColor> Colors => Process.ParticleTypes.ForsakenCitySatellite.Colors;

            private Dictionary<string,
                global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation> Particles =>
                Process.ParticleTypes.ForsakenCitySatellite.Particles;


            private ChapterCompletionSession session;

            public string Flag => "heartTorch_" + Index;

            public bool Activated => session.GetFlag(Flag);

            public int Index { get; private set; }

            public Torch(ISourceEngineContext engine, ChapterCompletionSession session, Vector2 position, int index,
                string[] code)
                : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
            {
                this.engine = engine;
                Index = index;
                Code = code;
                base.Depth = 8999;
                this.session = session;
                SpriteImage image =
                    new SpriteImage(GameAtlas.GetAtlasSubtextures("objects/reflectionHeart/hint")[index]);
                image.CenterOrigin();
                image.Position = new Vector2(0f, 28f);
                OwnedComponents.Add(image);
                OwnedComponents.Add(sprite = new Sprite(engine, GameAtlas, "objects/reflectionHeart/torch"));
                sprite.AddLoop("idle", "", 0f, default(int));
                sprite.AddLoop("lit", "", 0.08f, 1, 2, 3, 4, 5, 6);
                sprite.Play("idle");
                sprite.Origin = new Vector2(32f, 64f);
            }

            public override void Added(object scene)
            {
                base.Added(scene);
                if (Activated)
                {
                    PlayLit();
                }
            }

            public void Activate()
            {
                session.SetFlag(Flag);
                SourceAlarmState.Set(engine.AlarmPool, OwnedComponents, 0.2f, delegate
                {
                    Process.AudioSession.Play("event:/game/06_reflection/supersecret_torch_" + (Index + 1), Position,
                        Process.SaveContext);
                    PlayLit();
                });
            }

            private void PlayLit()
            {
                sprite.Play("lit");
                sprite.SetAnimationFrame(
                    ((ISourceRandomEnvironment)engine).Random.Next(sprite.CurrentAnimationTotalFrames));
                OwnedComponents.Add(new VertexLightState(engine, PackedColor.LightSeaGreen, 1f, 24, 48));
                OwnedComponents.Add(new BloomPointState(0.6f, 16f));
            }
        }


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

        private string[] Code => SourceState.ReflectionCode;

        private const string FlagPrefix = "heartTorch_";

        private List<string> currentInputs = new List<string>();

        private List<Torch> torches = new List<Torch>();

        private Vector2 offset;

        private Vector2[] nodes;

        private DashListenerState dashListener;

        private bool enabled;

        public OriginalReflectionHeartStatueState(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset)
        {
            this.engine = engine;
            this.offset = offset;
            nodes = data.Nodes;
            base.Depth = 8999;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            ChapterCompletionSession session = (base.Scene as OriginalLevelSceneRoot).Session;
            SpriteImage image = new SpriteImage(GameAtlas["objects/reflectionHeart/statue"]);
            image.JustifyOrigin(0.5f, 1f);
            image.Origin.Y -= 1f;
            OwnedComponents.Add(image);
            List<string[]> list = new List<string[]>();
            list.Add(Code);
            list.Add(FlipCode(h: true, v: false));
            list.Add(FlipCode(h: false, v: true));
            list.Add(FlipCode(h: true, v: true));
            for (int i = 0; i < 4; i++)
            {
                Torch torch = new Torch(engine, session, offset + nodes[i], i, list[i]);
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(torch);
                torches.Add(torch);
            }

            int num = Code.Length;
            Vector2 vector = nodes[4] + offset - Position;
            for (int j = 0; j < num; j++)
            {
                SpriteImage image2 = new SpriteImage(GameAtlas["objects/reflectionHeart/gem"]);
                image2.CenterOrigin();
                image2.Color = Colors[Code[j]];
                image2.Position = vector + new Vector2(((float)j - (float)(num - 1) / 2f) * 24f, 0f);
                OwnedComponents.Add(image2);
                OwnedComponents.Add(new BloomPointState(image2.Position, 0.3f, 12f));
            }

            enabled = !session.HeartGem;
            if (!enabled)
            {
                return;
            }

            OwnedComponents.Add(dashListener = new DashListenerState());
            dashListener.OnDash = delegate(Vector2 dir)
            {
                string text = "";
                if (dir.Y < 0f)
                {
                    text = "U";
                }
                else if (dir.Y > 0f)
                {
                    text = "D";
                }

                if (dir.X < 0f)
                {
                    text += "L";
                }
                else if (dir.X > 0f)
                {
                    text += "R";
                }

                int num2 = 0;
                if (dir.X < 0f && dir.Y == 0f)
                {
                    num2 = 1;
                }
                else if (dir.X < 0f && dir.Y < 0f)
                {
                    num2 = 2;
                }
                else if (dir.X == 0f && dir.Y < 0f)
                {
                    num2 = 3;
                }
                else if (dir.X > 0f && dir.Y < 0f)
                {
                    num2 = 4;
                }
                else if (dir.X > 0f && dir.Y == 0f)
                {
                    num2 = 5;
                }
                else if (dir.X > 0f && dir.Y > 0f)
                {
                    num2 = 6;
                }
                else if (dir.X == 0f && dir.Y > 0f)
                {
                    num2 = 7;
                }
                else if (dir.X < 0f && dir.Y > 0f)
                {
                    num2 = 8;
                }

                Process.AudioSession.Play("event:/game/06_reflection/supersecret_dashflavour",
                    ((ISourceScene)Scene).SourceScene.Entities
                    .GetTrackedEntity<RoomPlayerSession>(typeof(global::Celeste.Simulation.RoomPlayerSession).FullName)
                    ?.Position ?? Vector2.Zero, Process.SaveContext, "dash_direction", num2);
                currentInputs.Add(text);
                if (currentInputs.Count > Code.Length)
                {
                    currentInputs.RemoveAt(0);
                }

                foreach (Torch torch2 in torches)
                {
                    if (!torch2.Activated && CheckCode(torch2.Code))
                    {
                        torch2.Activate();
                    }
                }

                CheckIfAllActivated();
            };
            CheckIfAllActivated(skipActivateRoutine: true);
        }

        private string[] FlipCode(bool h, bool v)
        {
            string[] array = new string[Code.Length];
            for (int i = 0; i < Code.Length; i++)
            {
                string text = Code[i];
                if (h)
                {
                    text = (Enumerable.Contains(text, 'L') ? text.Replace('L', 'R') : text.Replace('R', 'L'));
                }

                if (v)
                {
                    text = (Enumerable.Contains(text, 'U') ? text.Replace('U', 'D') : text.Replace('D', 'U'));
                }

                array[i] = text;
            }

            return array;
        }

        private bool CheckCode(string[] code)
        {
            if (currentInputs.Count < code.Length)
            {
                return false;
            }

            for (int i = 0; i < code.Length; i++)
            {
                if (!currentInputs[i].Equals(code[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private void CheckIfAllActivated(bool skipActivateRoutine = false)
        {
            if (!enabled)
            {
                return;
            }

            bool flag = true;
            foreach (Torch torch in torches)
            {
                if (!torch.Activated)
                {
                    flag = false;
                }
            }

            if (flag)
            {
                Activate(skipActivateRoutine);
            }
        }

        public void Activate(bool skipActivateRoutine)
        {
            enabled = false;
            if (skipActivateRoutine)
            {
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(new OriginalHeartGemState(engine,
                    Position + new Vector2(0f, -52f)));
            }
            else
            {
                OwnedComponents.Add(new SimulationCoroutine(engine, ActivateRoutine()));
            }
        }

        private IEnumerator ActivateRoutine()
        {
            yield return 0.533f;
            Process.AudioSession.Play("event:/game/06_reflection/supersecret_heartappear");
            SceneEntityState dummy =
                new SceneEntityState(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                    Position + new Vector2(0f, -52f))
                {
                    Depth = 1
                };
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(dummy);
            SpriteImage white = new SpriteImage(GameAtlas["collectables/heartgem/white00"]);
            white.CenterOrigin();
            white.Scale = Vector2.Zero;
            dummy.OwnedComponents.Add(white);
            BloomPointState glow = new BloomPointState(0f, 16f);
            dummy.OwnedComponents.Add(glow);
            List<SceneEntityState> absorbs = new List<SceneEntityState>();
            for (int i = 0; i < 20; i++)
            {
                OriginalAbsorbOrbState absorbOrb =
                    new OriginalAbsorbOrbState(engine, Position + new Vector2(0f, -20f), dummy);
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(absorbOrb);
                absorbs.Add(absorbOrb);
                yield return null;
            }

            yield return 0.8f;
            float duration = 0.6f;
            for (float p = 0f; p < 1f; p += engine.DeltaTime / duration)
            {
                white.Scale = Vector2.One * p;
                glow.Alpha = p;
                (base.Scene as OriginalLevelSceneRoot).Shake();
                yield return null;
            }

            foreach (SceneEntityState item in absorbs)
            {
                item.RemoveSelf();
            }

            ((OriginalLevelSceneRoot)Scene).Flash(PackedColor.White);
            ((ISourceScene)Scene).SourceScene.RemoveScheduledEntity(dummy);
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(new OriginalHeartGemState(engine,
                Position + new Vector2(0f, -52f)));
        }

        public override void Update()
        {
            if (dashListener != null && !enabled)
            {
                OwnedComponents.Remove(dashListener);
                dashListener = null;
            }

            base.Update();
        }
    }
}
