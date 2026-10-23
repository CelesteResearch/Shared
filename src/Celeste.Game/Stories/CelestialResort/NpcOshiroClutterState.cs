using Celeste.Core.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Game.Audio;
using Celeste.Game.Components.Talking;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Entities.Npcs.Oshiro;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Clutter;
using Celeste.Simulation.Presentation.Lighting;

namespace Celeste.Game.Stories.CelestialResort
{
    public class NpcOshiroClutterState : OriginalNpcState
    {
        public const string TalkFlagsA = "oshiro_clutter_";

        public const string TalkFlagsB = "oshiro_clutter_optional_";

        public const string ClearedFlags = "oshiro_clutter_cleared_";

        public const string FinishedFlag = "oshiro_clutter_finished";

        public const string DoorOpenFlag = "oshiro_clutter_door_open";

        public Vector2 HomePosition;

        private int sectionsComplete;

        private bool talked;

        private bool inRoutine;

        private List<Vector2> nodes = new List<Vector2>();

        private SimulationCoroutine paceRoutine;

        private SimulationCoroutine talkRoutine;

        private SoundSourceComponentState paceSfx;

        private float paceTimer;

        public Vector2 ZoomPoint
        {
            get
            {
                if (sectionsComplete < 2)
                {
                    return Position + new Vector2(0f, -30f) - Level.Camera.Position;
                }

                return Position + new Vector2(0f, -15f) - Level.Camera.Position;
            }
        }

        public NpcOshiroClutterState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(engine, data.Position + offset)
        {
            OwnedComponents.Add(Sprite = new OshiroSpriteState(engine, -1));
            OwnedComponents.Add(Talker = new OriginalTalkComponent((IOriginalTalkProcess)engine,
                new IntRect(-24, -8, 48, 8), new Vector2(0f, -24f), OnTalk));
            OwnedComponents.Add(Light = new VertexLightState(engine, -Vector2.UnitY * 16f,
                global::Celeste.Core.Display.PackedColor.White, 1f, 32, 64));
            MoveAnim = "move";
            IdleAnim = "idle";
            Vector2[] array = data.Nodes;
            foreach (Vector2 vector in array)
            {
                nodes.Add(vector + offset);
            }

            OwnedComponents.Add(paceSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if (base.Session.GetFlag("oshiro_clutter_finished"))
            {
                RemoveSelf();
            }
            else
            {
                if (base.Session.GetFlag("oshiro_clutter_cleared_0"))
                {
                    sectionsComplete++;
                }

                if (base.Session.GetFlag("oshiro_clutter_cleared_1"))
                {
                    sectionsComplete++;
                }

                if (base.Session.GetFlag("oshiro_clutter_cleared_2"))
                {
                    sectionsComplete++;
                }

                if (sectionsComplete == 0 || sectionsComplete == 3)
                {
                    Sprite.Scale.X = 1f;
                }

                if (sectionsComplete > 0)
                {
                    Position = nodes[sectionsComplete - 1];
                }
                else if (!base.Session.GetFlag("oshiro_clutter_0"))
                {
                    OwnedComponents.Add(paceRoutine = new SimulationCoroutine(Engine, Pace()));
                }

                if (sectionsComplete == 0 && base.Session.GetFlag("oshiro_clutter_0") &&
                    !base.Session.GetFlag("oshiro_clutter_optional_0"))
                {
                    Sprite.Play("idle_ground");
                }

                if (sectionsComplete == 3 || base.Session.GetFlag("oshiro_clutter_optional_" + sectionsComplete))
                {
                    Remove(Talker);
                }
            }

            HomePosition = Position;
        }

        private void OnTalk(RoomPlayerSession player)
        {
            talked = true;
            if (paceRoutine != null)
            {
                paceRoutine.RemoveSelf();
            }

            paceRoutine = null;
            if (!base.Session.GetFlag("oshiro_clutter_" + sectionsComplete))
            {
                Level.Scheduler.QueueSourceEntity(new OshiroClutterSequence(player, this, sectionsComplete, Engine));
                return;
            }

            Level.CutscenePolicy.StartCutscene(EndTalkRoutine);
            base.Session.SetFlag("oshiro_clutter_optional_" + sectionsComplete);
            OwnedComponents.Add(talkRoutine = new SimulationCoroutine(Engine, TalkRoutine(player)));
            if (Talker != null)
            {
                Talker.Enabled = false;
            }
        }

        private IEnumerator TalkRoutine(RoomPlayerSession player)
        {
            yield return PlayerApproach(player, turnToFace: true, 24f,
                (sectionsComplete != 1 && sectionsComplete != 2) ? 1 : (-1));
            yield return Level.ZoomTo(ZoomPoint, 2f, 0.5f);
            yield return TextboxState.Say("CH3_OSHIRO_CLUTTER" + sectionsComplete + "_B", Engine, StandUp);
            yield return Level.ZoomBack(0.5f);
            Level.CutscenePolicy.EndCutscene();
            EndTalkRoutine(Level);
        }

        private void EndTalkRoutine(OriginalLevelSceneRoot level)
        {
            if (talkRoutine != null)
            {
                talkRoutine.RemoveSelf();
            }

            talkRoutine = null;
            (Sprite as OshiroSpriteState).Pop("idle", flip: false);
            RoomPlayerSession entity =
                ((OriginalLevelSceneRoot)Scene).Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
            if (entity != null)
            {
                entity.Machine.Locked = false;
                entity.Machine.State = 0;
            }
        }

        private IEnumerator StandUp()
        {
            PlaySourceSound("event:/char/oshiro/chat_get_up", Position);
            (Sprite as OshiroSpriteState).Pop("idle", flip: false);
            yield return 0.25f;
        }

        private IEnumerator Pace()
        {
            while (true)
            {
                (Sprite as OshiroSpriteState).Wiggle();
                yield return PaceLeft();
                while (paceTimer < 2.266f)
                {
                    yield return null;
                }

                paceTimer = 0f;
                (Sprite as OshiroSpriteState).Wiggle();
                yield return PaceRight();
                while (paceTimer < 2.266f)
                {
                    yield return null;
                }

                paceTimer = 0f;
            }
        }

        public IEnumerator PaceRight()
        {
            Vector2 homePosition = HomePosition;
            if (((ISourceVectorEnvironment)Engine).VectorArithmetic.Length(Position - homePosition) > 8f)
            {
                paceSfx.Play("event:/char/oshiro/move_04_pace_right");
            }

            yield return MoveTo(homePosition);
        }

        public IEnumerator PaceLeft()
        {
            Vector2 vector = HomePosition + new Vector2(-20f, 0f);
            if (((ISourceVectorEnvironment)Engine).VectorArithmetic.Length(Position - vector) > 8f)
            {
                paceSfx.Play("event:/char/oshiro/move_04_pace_left");
            }

            yield return MoveTo(vector);
        }

        public override void Update()
        {
            base.Update();
            paceTimer += Engine.DeltaTime;
            RoomPlayerSession entity =
                ((OriginalLevelSceneRoot)Scene).Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
            if (sectionsComplete == 3 && !inRoutine && entity != null && entity.X < base.X + 32f && entity.Y <= base.Y)
            {
                OnTalk(entity);
                inRoutine = true;
            }

            if (sectionsComplete == 0 && !talked)
            {
                OriginalLevelSceneRoot level = base.Scene as OriginalLevelSceneRoot;
                if (entity != null && !entity.Dead)
                {
                    float num = ScalarMath.ClampedMap(
                        ((ISourceVectorEnvironment)Engine).VectorArithmetic.Distance(base.Center, entity.Center), 40f,
                        128f);
                    level.Session.Audio.Music.Layer(1, num);
                    level.Session.Audio.Music.Layer(2, 1f - num);
                    OriginalAudioSession.Apply(level.Session.Audio, Process.AudioSession.ChannelOutput,
                        Process.AudioApplyPolicy);
                }
                else
                {
                    level.Session.Audio.Music.Layer(1, value: true);
                    level.Session.Audio.Music.Layer(2, value: false);
                    OriginalAudioSession.Apply(level.Session.Audio, Process.AudioSession.ChannelOutput,
                        Process.AudioApplyPolicy);
                }
            }
        }
    }
}
