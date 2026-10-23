using Celeste.Core.Display;
using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components.Animation;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Rendering;
using Celeste.Scene.Tracking;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Entities.BadelineDummy;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Execution.Processes;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Audio.Emitters;
using Celeste.Simulation.Presentation.Effects.Trails.Lifecycle;
using Celeste.Graphics.Display;

namespace Celeste.Game.Stories.Temple.Badeline
{
    public class OriginalTempleBadelineState : OriginalNpcState
    {
        public const string FirstLevel = "c-00";

        public const string SecondLevel = "c-01";

        public const string ThirdLevel = "c-01b";

        private BadelineDummyPresentation shadow;

        private Vector2[] nodes;

        private global::Celeste.Core.Geometry.IntRect levelBounds;

        private SoundSourceComponentState moveSfx;

        public OriginalTempleBadelineState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(engine, data.Position + offset)
        {
            nodes = data.NodesOffset(offset);
            OwnedComponents.Add(moveSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
            OwnedComponents.Add(new RoomTransitionListener
            {
                OnOut = delegate(float f)
                {
                    if (shadow != null)
                    {
                        shadow.Hair.Alpha = 1f - ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(1f, f * 2f);
                        shadow.Sprite.Color = PackedColor.White * shadow.Hair.Alpha;
                        shadow.Light.Alpha = shadow.Hair.Alpha;
                    }
                }
            });
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            if (base.Session.Level.Equals("c-00"))
            {
                if (!base.Session.GetLevelFlag("c-01"))
                {
                    ((OriginalLevelSceneRoot)scene).Scheduler.QueueSourceEntity(shadow =
                        BadelineDummyPresentation.Create((OriginalLevelSceneRoot)scene, Position));
                    shadow.Depth = -1000000;
                    OwnedComponents.Add(new SimulationCoroutine(Engine, FirstScene()));
                }
                else
                {
                    RemoveSelf();
                }
            }
            else if (base.Session.Level.Equals("c-01"))
            {
                if (!base.Session.GetLevelFlag("c-01b"))
                {
                    int i;
                    for (i = 0; i < 4 && base.Session.GetFlag(CS05BadelineState.GetFlag(i)); i++)
                    {
                    }

                    if (i >= 4)
                    {
                        RemoveSelf();
                    }
                    else
                    {
                        Vector2 position = Position;
                        if (i > 0)
                        {
                            position = nodes[i - 1];
                        }

                        ((OriginalLevelSceneRoot)scene).Scheduler.QueueSourceEntity(shadow =
                            BadelineDummyPresentation.Create((OriginalLevelSceneRoot)scene, position));
                        shadow.Depth = -1000000;
                        OwnedComponents.Add(new SimulationCoroutine(Engine, SecondScene(i)));
                    }
                }
                else
                {
                    RemoveSelf();
                }
            }

            levelBounds = ((OriginalLevelSceneRoot)scene).Bounds;
        }

        private IEnumerator FirstScene()
        {
            shadow.Sprite.Scale.X = -1f;
            shadow.FloatSpeed = 150f;
            bool playerHasFallen = false;
            bool startedMusic = false;
            RoomPlayerSession player;
            while (true)
            {
                player =
                    ((ISourceScene)base.Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
                if (player != null && player.Y > (float)(Level.Bounds.Top + 180) && !player.OnGround() &&
                    !playerHasFallen)
                {
                    player.Machine.State = 20;
                    playerHasFallen = true;
                }

                if (player != null && playerHasFallen && !startedMusic && player.OnGround())
                {
                    Level.Session.Audio.Music.Event = "event:/music/lvl5/middle_temple";
                    global::Celeste.Game.Audio.OriginalAudioSession.Apply(Level.Session.Audio,
                        Process.AudioSession.ChannelOutput, Process.AudioApplyPolicy, forceSixteenthNoteHack: true);
                    startedMusic = true;
                }

                if (player != null && player.X > base.X - 64f && player.Y > base.Y - 32f)
                {
                    break;
                }

                yield return null;
            }

            MoveToNode(0, chatMove: false);
            while (shadow.X < (float)(Level.Bounds.Right + 8))
            {
                yield return null;
                if (player.X > shadow.X - 24f)
                {
                    shadow.X = player.X + 24f;
                }
            }

            shadow.RemoveSelf();
            RemoveSelf();
        }

        private IEnumerator SecondScene(int startIndex)
        {
            shadow.Sprite.Scale.X = -1f;
            shadow.FloatSpeed = 300f;
            shadow.FloatAccel = 400f;
            yield return 0.1f;
            int index = startIndex;
            while (index < nodes.Length)
            {
                RoomPlayerSession player =
                    ((ISourceScene)base.Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
                while (player == null ||
                       ((ISourceVectorEnvironment)Engine).VectorArithmetic.Length(player.Position - shadow.Position) >
                       70f)
                {
                    yield return null;
                }

                if (index < 4 && !base.Session.GetFlag(CS05BadelineState.GetFlag(index)))
                {
                    CS05BadelineState cutscene = new CS05BadelineState(player, this, shadow, index, Engine);
                    ((OriginalLevelSceneRoot)base.Scene).Scheduler.QueueSourceEntity(cutscene);
                    yield return null;
                    while (cutscene.Scene != null)
                    {
                        yield return null;
                    }

                    index++;
                }
            }

            base.Tags |= ((IOriginalGameTagsEnvironment)Engine).Tags.TransitionUpdate.Value;
            shadow.Tags |= ((IOriginalGameTagsEnvironment)Engine).Tags.TransitionUpdate.Value;
            shadow.RemoveSelf();
            RemoveSelf();
        }

        public void MoveToNode(int index, bool chatMove = true)
        {
            if (chatMove)
            {
                moveSfx.Play("event:/char/badeline/temple_move_chats");
            }
            else
            {
                SoundEmitterState.Play("event:/char/badeline/temple_move_first", this, Engine);
            }

            Vector2 start = shadow.Position;
            Vector2 end = nodes[index];
            SourceTweenState tween = SourceTweenState.Create(Engine.TweenPool, SourceTweenState.TweenMode.Oneshot,
                ((ISourceEasingEnvironment)Engine).EasingArithmetic.CubeInOut, 0.5f, start: true);
            tween.OnUpdate = delegate(SourceTweenState t)
            {
                shadow.Position =
                    Vector2Interpolation.Lerp(start, end, t.Eased, ((ISourceScalarEnvironment)Engine).ScalarArithmetic);
                if (((OriginalLevelSceneRoot)base.Scene).OnInterval(0.03f))
                {
                    ((OriginalLevelSceneRoot)Scene).ParticlesFG.Emit(Process.ParticleTypes.BadelineOldsite.P_Vanish, 2,
                        shadow.Position + new Vector2(0f, -6f), Vector2.One * 2f);
                }

                if (t.Eased >= 0.1f && t.Eased <= 0.9f && ((OriginalLevelSceneRoot)base.Scene).OnInterval(0.05f))
                {
                    TrailManagerState.Add(Engine, (ISourceRenderEnvironment)Engine, shadow, PackedColor.Red, 0.5f);
                }
            };
            OwnedComponents.Add(tween);
        }

        public void SnapToNode(int index)
        {
            shadow.Position = nodes[index];
        }
    }
}
