using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Audio;
using Celeste.Game.Components.Talking;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Entities.Npcs.Oshiro;
using Celeste.Game.Execution.Levels;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;

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

        private readonly List<Vector2> nodes = [];

        private SimulationCoroutine paceRoutine;

        private SimulationCoroutine talkRoutine;

        private readonly SoundSourceComponentState paceSfx;

        private float paceTimer;

        public Vector2 ZoomPoint
        {
            get
            {
                if (sectionsComplete < 2) return Position + new Vector2(0f, -30f) - Level.Camera.Position;

                return Position + new Vector2(0f, -15f) - Level.Camera.Position;
            }
        }

        public NpcOshiroClutterState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(engine, data.Position + offset)
        {
            OwnedComponents.Add(Sprite = new OshiroSpriteState(engine, -1));
            OwnedComponents.Add(Talker = new((IOriginalTalkProcess)engine,
                new(-24, -8, 48, 8), new(0f, -24f), OnTalk));
            OwnedComponents.Add(Light = new(engine, -Vector2.UnitY * 16f,
                PackedColor.White, 1f, 32, 64));
            MoveAnim = "move";
            IdleAnim = "idle";
            var array = data.Nodes;
            foreach (var vector in array) nodes.Add(vector + offset);

            OwnedComponents.Add(paceSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if (Session.GetFlag("oshiro_clutter_finished"))
            {
                RemoveSelf();
            }
            else
            {
                if (Session.GetFlag("oshiro_clutter_cleared_0")) sectionsComplete++;

                if (Session.GetFlag("oshiro_clutter_cleared_1")) sectionsComplete++;

                if (Session.GetFlag("oshiro_clutter_cleared_2")) sectionsComplete++;

                if (sectionsComplete == 0 || sectionsComplete == 3) Sprite.Scale.X = 1f;

                if (sectionsComplete > 0)
                    Position = nodes[sectionsComplete - 1];
                else if (!Session.GetFlag("oshiro_clutter_0")) OwnedComponents.Add(paceRoutine = new(Engine, Pace()));

                if (sectionsComplete == 0 && Session.GetFlag("oshiro_clutter_0") &&
                    !Session.GetFlag("oshiro_clutter_optional_0"))
                    Sprite.Play("idle_ground");

                if (sectionsComplete == 3 || Session.GetFlag("oshiro_clutter_optional_" + sectionsComplete))
                    Remove(Talker);
            }

            HomePosition = Position;
        }

        private void OnTalk(RoomPlayerSession player)
        {
            talked = true;
            if (paceRoutine != null) paceRoutine.RemoveSelf();

            paceRoutine = null;
            if (!Session.GetFlag("oshiro_clutter_" + sectionsComplete))
            {
                Level.Scheduler.QueueSourceEntity(new OshiroClutterSequence(player, this, sectionsComplete, Engine));
                return;
            }

            Level.CutscenePolicy.StartCutscene(EndTalkRoutine);
            Session.SetFlag("oshiro_clutter_optional_" + sectionsComplete);
            OwnedComponents.Add(talkRoutine = new(Engine, TalkRoutine(player)));
            if (Talker != null) Talker.Enabled = false;
        }

        private IEnumerator TalkRoutine(RoomPlayerSession player)
        {
            yield return PlayerApproach(player, true, 24f,
                sectionsComplete != 1 && sectionsComplete != 2 ? 1 : -1);
            yield return Level.ZoomTo(ZoomPoint, 2f, 0.5f);
            yield return TextboxState.Say("CH3_OSHIRO_CLUTTER" + sectionsComplete + "_B", Engine, StandUp);
            yield return Level.ZoomBack(0.5f);
            Level.CutscenePolicy.EndCutscene();
            EndTalkRoutine(Level);
        }

        private void EndTalkRoutine(OriginalLevelSceneRoot level)
        {
            if (talkRoutine != null) talkRoutine.RemoveSelf();

            talkRoutine = null;
            (Sprite as OshiroSpriteState).Pop("idle", false);
            var entity =
                ((OriginalLevelSceneRoot)Scene).Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);
            if (entity != null)
            {
                entity.Machine.Locked = false;
                entity.Machine.State = 0;
            }
        }

        private IEnumerator StandUp()
        {
            PlaySourceSound("event:/char/oshiro/chat_get_up", Position);
            (Sprite as OshiroSpriteState).Pop("idle", false);
            yield return 0.25f;
        }

        private IEnumerator Pace()
        {
            while (true)
            {
                (Sprite as OshiroSpriteState).Wiggle();
                yield return PaceLeft();
                while (paceTimer < 2.266f) yield return null;

                paceTimer = 0f;
                (Sprite as OshiroSpriteState).Wiggle();
                yield return PaceRight();
                while (paceTimer < 2.266f) yield return null;

                paceTimer = 0f;
            }
        }

        public IEnumerator PaceRight()
        {
            var homePosition = HomePosition;
            if (((ISourceVectorEnvironment)Engine).VectorArithmetic.Length(Position - homePosition) > 8f)
                paceSfx.Play("event:/char/oshiro/move_04_pace_right");

            yield return MoveTo(homePosition);
        }

        public IEnumerator PaceLeft()
        {
            var vector = HomePosition + new Vector2(-20f, 0f);
            if (((ISourceVectorEnvironment)Engine).VectorArithmetic.Length(Position - vector) > 8f)
                paceSfx.Play("event:/char/oshiro/move_04_pace_left");

            yield return MoveTo(vector);
        }

        public override void Update()
        {
            base.Update();
            paceTimer += Engine.DeltaTime;
            var entity =
                ((OriginalLevelSceneRoot)Scene).Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);
            if (sectionsComplete == 3 && !inRoutine && entity != null && entity.X < X + 32f && entity.Y <= Y)
            {
                OnTalk(entity);
                inRoutine = true;
            }

            if (sectionsComplete == 0 && !talked)
            {
                var level = Scene as OriginalLevelSceneRoot;
                if (entity != null && !entity.Dead)
                {
                    var num = ScalarMath.ClampedMap(
                        ((ISourceVectorEnvironment)Engine).VectorArithmetic.Distance(Center, entity.Center), 40f,
                        128f);
                    level.Session.Audio.Music.Layer(1, num);
                    level.Session.Audio.Music.Layer(2, 1f - num);
                    OriginalAudioSession.Apply(level.Session.Audio, Process.AudioSession.ChannelOutput,
                        Process.AudioApplyPolicy);
                }
                else
                {
                    level.Session.Audio.Music.Layer(1, true);
                    level.Session.Audio.Music.Layer(2, false);
                    OriginalAudioSession.Apply(level.Session.Audio, Process.AudioSession.ChannelOutput,
                        Process.AudioApplyPolicy);
                }
            }
        }
    }
}
