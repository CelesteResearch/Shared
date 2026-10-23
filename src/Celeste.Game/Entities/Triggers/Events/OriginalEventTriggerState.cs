using System;
using System.Collections;
using System.Numerics;
using Celeste.Audio.Fmod.Events;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.Birds;
using Celeste.Game.Entities.City.Cutscenes;
using Celeste.Game.Entities.Decoration.Decals;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Enemies.BadelineBoss;
using Celeste.Game.Gameplay.Enemies.BadelineBoss.Cutscenes;
using Celeste.Game.Gameplay.Hazards.Lightning;
using Celeste.Game.Stories.Epilogue;
using Celeste.Game.Stories.Farewell.Ending;
using Celeste.Game.Stories.Farewell.Farewell;
using Celeste.Game.Stories.Farewell.FinalRoom;
using Celeste.Game.Stories.Farewell.Help;
using Celeste.Game.Stories.Farewell.Hub;
using Celeste.Game.Stories.Farewell.Moon;
using Celeste.Game.Stories.OldSite.Phone;
using Celeste.Game.Stories.Reflection.After;
using Celeste.Game.Stories.Summit.Ending;
using Celeste.Game.Stories.Temple.Cutscenes;
using Celeste.Physics.Collision;
using Celeste.Scene.Scenes;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Simulation.Gameplay.Triggers.Foundation;
using Celeste.Simulation.Presentation.Backdrops.Runtime;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Entities.Triggers.Events
{
    public class OriginalEventTriggerState : SourceTriggerEntityState
    {
        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;
        public string Event;

        public bool OnSpawnHack;

        private bool triggered;

        private FmodEventReference snapshot;

        public float Time { get; private set; }

        public OriginalEventTriggerState(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset,
                data.Width, data.Height, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            this.engine = engine;
            Event = EntityAttributeReader.Attr(data.Values, "event");
            OnSpawnHack = EntityAttributeReader.Bool(data.Values, "onSpawn");
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            if (OnSpawnHack)
            {
                var player = CollideSourcePlayer();
                if (player != null) OnEnter(player);
            }

            if (Event == "ch9_badeline_helps")
            {
                var entity =
                    ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(RoomPlayerSession).FullName);

                if (entity != null && entity.Left > Right) RemoveSelf();
            }
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            if (triggered) return;

            triggered = true;
            var level = Scene as OriginalLevelSceneRoot;
            if (((IOriginalEventTriggerEnvironment)engine).EventTriggers.TriggerCustomEvent(this, player, Event))
                return;
            switch (Event)
            {
                case "end_city":
                    ((OriginalLevelSceneRoot)Scene).Scheduler.QueueSourceEntity(
                        new CS01EndingState(engine, player));
                    break;
                case "end_oldsite_dream":
                    ((OriginalLevelSceneRoot)Scene).Scheduler.QueueSourceEntity(
                        new CS02DreamingPhonecallState(engine, player));
                    break;
                case "end_oldsite_awake":
                    ((OriginalLevelSceneRoot)Scene).Scheduler.QueueSourceEntity(
                        new CS02EndingState(engine, player));
                    break;
                case "ch5_see_theo":
                    if (!(Scene as OriginalLevelSceneRoot).Session.GetFlag("seeTheoInCrystal"))
                        ((OriginalLevelSceneRoot)Scene).Scheduler.QueueSourceEntity(
                            new CS05SeeTheoState(engine, player, 0));

                    break;
                case "ch5_found_theo":
                    if (!level.Session.GetFlag("foundTheoInCrystal"))
                        ((OriginalLevelSceneRoot)Scene).Scheduler.QueueSourceEntity(
                            new CS05SaveTheoState(engine, player));

                    break;
                case "ch5_mirror_reflection":
                    if (!level.Session.GetFlag("reflection"))
                        ((OriginalLevelSceneRoot)Scene).Scheduler.QueueSourceEntity(
                            new CS05Reflection1State(engine, player));

                    break;
                case "cancel_ch5_see_theo":
                    level.Session.SetFlag("it_ch5_see_theo");
                    level.Session.SetFlag("it_ch5_see_theo_b");
                    level.Session.SetFlag("ignore_darkness_" + level.Session.Level);
                    OwnedComponents.Add(new SimulationCoroutine(engine, Brighten()));
                    break;
                case "ch6_boss_intro":
                    if (!level.Session.GetFlag("boss_intro"))
                        level.Scheduler.QueueSourceEntity(
                            new CS06BossIntroState(
                                Center.X, player,
                                level.Scheduler.Entities
                                    .FindFirst<FinalBossState>(),
                                engine));

                    break;
                case "ch6_reflect":
                    if (!level.Session.GetFlag("reflection"))
                        ((OriginalLevelSceneRoot)Scene).Scheduler.QueueSourceEntity(
                            new CS06ReflectionState(engine, player,
                                Center.X - 5f));

                    break;
                case "ch7_summit":
                    ((OriginalLevelSceneRoot)Scene).Scheduler.QueueSourceEntity(
                        new CS07EndingState(player,
                            new(Center.X, Bottom), engine));
                    break;
                case "ch8_door":
                    ((OriginalLevelSceneRoot)Scene).Scheduler.QueueSourceEntity(
                        new CS08EnterDoorState(engine, player, Left));
                    break;
                case "ch9_goto_the_future":
                case "ch9_goto_the_past":
                    level.OnEndOfFrame += delegate
                    {
                        new Vector2(level.LevelOffset.X + level.Bounds.Width - player.X,
                            player.Y - level.LevelOffset.Y);
                        var levelOffset = level.LevelOffset;
                        var vector = player.Position - level.LevelOffset;
                        var vector2 = level.Camera.Position - level.LevelOffset;
                        var facing = player.Data.Facing;
                        level.RemoveEntity(player);
                        level.UnloadLevel();
                        level.Session.Dreaming = true;
                        level.Session.Level = Event == "ch9_goto_the_future" ? "intro-01-future" : "intro-00-past";
                        level.Session.RespawnPoint =
                            level.GetSpawnPoint(new(level.Bounds.Left, level.Bounds.Top));
                        level.Session.FirstLevel = false;
                        level.LoadLevel(PlayerIntroType.Transition);
                        level.Camera.Position = level.LevelOffset + vector2;
                        level.Session.Inventory.Dashes = 1;
                        player.Data.Dashes = Math.Min(player.Data.Dashes, 1);
                        level.Scheduler.QueueSourceEntity(player);
                        player.Position = level.LevelOffset + vector;
                        player.Data.Facing = facing;
                        player.Hair.MoveHairBy(level.LevelOffset - levelOffset);
                        if (level.Wipe != null) level.Wipe.Cancel();

                        level.Flash(PackedColor.White);
                        level.Shake();
                        level.Scheduler.QueueSourceEntity(
                            new LightningStrikeState(
                                new(player.X + 60f, level.Bounds.Bottom - 180), 10, 200f, engine));
                        level.Scheduler.QueueSourceEntity(
                            new LightningStrikeState(
                                new(player.X + 220f, level.Bounds.Bottom - 180), 40, 200f, engine, .25f));
                        Process.AudioSession.Play("event:/new_content/game/10_farewell/lightning_strike");
                    };
                    break;
                case "ch9_moon_intro":
                    if (!level.Session.GetFlag("moon_intro") && player.Machine.State == 13)
                    {
                        ((OriginalLevelSceneRoot)Scene).Scheduler.QueueSourceEntity(
                            new MoonIntroSequence(player, engine));
                        break;
                    }

                    level.Scheduler.Entities.FindFirst<BirdNpcState>()
                        ?.RemoveSelf();
                    level.Session.Inventory.Dashes = 1;
                    player.Data.Dashes = 1;
                    break;
                case "ch9_hub_intro":
                    if (!level.Session.GetFlag("hub_intro"))
                        ((OriginalLevelSceneRoot)Scene).Scheduler.QueueSourceEntity(
                            new OriginalHubIntroCutscene(engine,
                                (SourceSceneState)Scene, player));

                    break;
                case "ch9_hub_transition_out":
                    OwnedComponents.Add(new SimulationCoroutine(engine, Ch9HubTransitionBackgroundToBright(player)));
                    break;
                case "ch9_badeline_helps":
                    if (!level.Session.GetFlag("badeline_helps"))
                        ((OriginalLevelSceneRoot)Scene).Scheduler.QueueSourceEntity(
                            new OriginalBadelineHelpsCutscene(engine,
                                player));

                    break;
                case "ch9_farewell":
                    ((OriginalLevelSceneRoot)Scene).Scheduler.QueueSourceEntity(
                        new OriginalFarewellCutscene(engine,
                            player));
                    break;
                case "ch9_ending":
                    ((OriginalLevelSceneRoot)Scene).Scheduler.QueueSourceEntity(
                        ((IOriginalFarewellEndingConstructionEnvironment)engine).FarewellEndingConstruction
                        .Create(engine, player));
                    break;
                case "ch9_end_golden":
                    ((ISourceScreenWipeEnvironment)engine).ProcessWipe.WipeColor = PackedColor.White;
                    new FadeWipePresentation(level, false, delegate
                    {
                        level.OnEndOfFrame += delegate
                        {
                            level.TeleportTo(player, "end-granny", PlayerIntroType.Transition);
                            player.Data.Motion.Normal.Speed = Vector2.Zero;
                        };
                    }).Duration = 1f;
                    break;
                case "ch9_final_room":
                {
                    var session =
                        (Scene as OriginalLevelSceneRoot).Session;
                    switch (session.GetCounter("final_room_deaths"))
                    {
                        case 0:
                            ((OriginalLevelSceneRoot)Scene).Scheduler.QueueSourceEntity(
                                new OriginalFinalRoomCutscene(
                                    engine, player, true));
                            break;
                        case 50:
                            ((OriginalLevelSceneRoot)Scene).Scheduler.QueueSourceEntity(
                                new OriginalFinalRoomCutscene(
                                    engine, player, false));
                            break;
                    }

                    session.IncrementCounter("final_room_deaths");
                    break;
                }
                case "ch9_ding_ding_ding":
                {
                    Process.AudioSession.Play("event:/new_content/game/10_farewell/pico8_flag", Center,
                        Process.SaveContext);
                    OriginalDecalEntity decal = null;
                    foreach (var item in ((ISourceScene)Scene).SourceScene.Entities
                             .FindAll<OriginalDecalEntity>())
                        if (item.Name.ToLower() == "decals/10-farewell/finalflag")
                        {
                            decal = item;
                            break;
                        }

                    decal?.FinalFlagTrigger();
                    break;
                }
                case "ch9_golden_snapshot":
                    snapshot = Process.AudioSession.CreateSnapshot("snapshot:/game_10_golden_room_flavour");
                    (Scene as OriginalLevelSceneRoot).SnapColorGrade("golden");
                    break;
                default:
                    throw new("Event '" + Event + "' does not exist!");
            }
        }

        public override void Removed(object scene)
        {
            base.Removed(scene);
            Process.AudioSession.ReleaseSnapshot(snapshot);
        }

        public override void SceneEnd(object scene)
        {
            base.SceneEnd(scene);
            Process.AudioSession.ReleaseSnapshot(snapshot);
        }

        private IEnumerator Brighten()
        {
            var level = Scene as OriginalLevelSceneRoot;
            var darkness = level.AreaData.DarknessAlpha;
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            while (level.Lighting.Alpha != darkness)
            {
                level.Lighting.Alpha = ScalarMath.Approach(level.Lighting.Alpha, darkness, engine.DeltaTime * 4f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                yield return null;
            }
        }

        private IEnumerator Ch9HubTransitionBackgroundToBright(RoomPlayerSession player)
        {
            var level = Scene as OriginalLevelSceneRoot;
            var start = Bottom;
            var end = Top;
            while (true)
            {
                var fadeAlphaMultiplier = ScalarMath.ClampedMap(player.Y, start, end);
                foreach (var item in level
                             .Background
                             .GetEach<BackdropPresentation>(
                                 "bright"))
                {
                    item.ForceVisible = true;
                    item.FadeAlphaMultiplier = fadeAlphaMultiplier;
                }

                yield return null;
            }
        }

        private RoomPlayerSession CollideSourcePlayer()
        {
            foreach (var value in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         typeof(RoomPlayerSession).FullName))

            {
                var player = (RoomPlayerSession)value;
                if (SourceEntityCollision.Check(this, player)) return player;
            }

            return null;
        }
    }
}
