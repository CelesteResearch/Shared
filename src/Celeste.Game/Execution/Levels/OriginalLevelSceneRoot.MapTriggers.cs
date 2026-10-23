using System;
using System.Numerics;
using Celeste.Core.Maps;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Gameplay.Triggers.Inventory;
using Celeste.Game.Gameplay.Triggers.Movement;
using Celeste.Game.Gameplay.Triggers.Checkpoints;
using Celeste.Simulation.Gameplay.Lookout;
using Celeste.Game.Gameplay.Collectibles.Strawberries;
using Celeste.Game.Gameplay.Collectibles.Strawberries.Triggers;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public void LoadSourceMapTrigger(OriginalLevelEntityData record, Vector2 offset, MapEntityId id)
        {
            switch (record.Name)
            {
                case "bloomFadeTrigger":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Triggers.Rendering.OriginalBloomFadeTriggerState(
                            EngineContext, record, offset));
                    break;
                case "lightFadeTrigger":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Triggers.Rendering.OriginalLightFadeTriggerState(
                            EngineContext, record, offset));
                    break;
                case "ambienceParamTrigger":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Triggers.Audio.OriginalAmbienceParamTriggerState(record,
                            offset, EngineContext));
                    break;
                case "altMusicTrigger":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Triggers.Audio.OriginalAltMusicTriggerState(record,
                            offset, EngineContext));
                    break;
                case "musicTrigger":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Triggers.Audio.OriginalMusicTriggerState(record, offset,
                            EngineContext));
                    break;
                case "musicFadeTrigger":
                    if (((global::Celeste.Game.Profiles.IGameProfileEnvironment)
                            EngineContext).SourceProfile == global::Celeste.Game.Profiles
                            .GameProfile.InstalledEverest)
                        Scheduler.QueueSourceEntity(
                            new global::Celeste.Game.Gameplay.Triggers.Audio.InstalledMusicFadeTriggerState(record,
                                offset, EngineContext));
                    else
                        Scheduler.QueueSourceEntity(
                            new global::Celeste.Game.Gameplay.Triggers.Audio.OriginalMusicFadeTriggerState(record,
                                offset, EngineContext));
                    break;
                case "spawnFacingTrigger":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Triggers.Respawning.OriginalSpawnFacingTrigger(record,
                            offset, EngineContext));
                    break;
                case "windTrigger":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Triggers.Wind.OriginalWindTrigger(record, offset,
                            EngineContext));
                    break;
                case "changeRespawnTrigger":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Triggers.Respawning.OriginalChangeRespawnTrigger(record,
                            offset, EngineContext));
                    break;
                case "respawnTargetTrigger":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Triggers.Respawning.OriginalRespawnTargetTrigger(record,
                            offset, EngineContext));
                    break;

                case "windAttackTrigger":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Hazards.Snowballs.OriginalWindAttackTriggerState(record,
                            offset,
                            (global::Celeste.Game.Entities.Hazards.Snowballs.IOriginalSnowballEnvironment)
                            EngineContext));
                    break;

                case "blackholeStrength":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Triggers.Backdrops.OriginalBlackholeStrengthTriggerState(
                            EngineContext, record, offset));
                    break;
                case "moonGlitchBackgroundTrigger":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Birds.Fling.OriginalMoonGlitchBackgroundTriggerState(
                            EngineContext, record, offset));
                    break;
                case "goldenBerryCollectTrigger":
                    Scheduler.QueueSourceEntity(new GoldBerryCollectTriggerState(record, offset, EngineContext));
                    break;
                case "detachFollowersTrigger":
                    Scheduler.QueueSourceEntity(new DetachStrawberryTriggerState(record, offset,
                        (IOriginalStrawberryProcess)EngineContext));
                    break;
                case "noRefillTrigger":
                    Scheduler.QueueSourceEntity(new NoRefillTriggerState(EngineContext, record, offset));
                    break;
                case "stopBoostTrigger":
                    Scheduler.QueueSourceEntity(new StopBoostTriggerState(EngineContext, record, offset));
                    break;
                case "checkpointBlockerTrigger":
                    Scheduler.QueueSourceEntity(new CheckpointBlockerTriggerState(record, offset, EngineContext));
                    break;
                case "lookoutBlocker":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Lookouts.OriginalLookoutBlockerState(record, offset,
                            EngineContext));
                    break;
                case "birdPathTrigger":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Birds.Paths.BirdPathTriggerState(record, offset,
                            EngineContext));
                    break;
                case "interactTrigger":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Stories.Interactions.OriginalInteractTriggerState(record, offset,
                            EngineContext));
                    break;
                case "oshiroTrigger":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Enemies.AngryOshiro.OriginalOshiroTriggerState(
                            record.Position + offset, record.Width, record.Height,
                            global::Celeste.Formats.Map.Entities.Attributes.EntityAttributeReader.Bool(
                                record.Values, "state", true), EngineContext));
                    break;
                case "creditsTrigger":
                    Scheduler.QueueSourceEntity(new global::Celeste.Game.Credits.Triggers.CreditsTriggerState(
                        record.Position + offset, record.Width, record.Height,
                        global::Celeste.Formats.Map.Entities.Attributes.EntityAttributeReader.Attr(record.Values,
                            "event"), EngineContext));
                    break;
                case "rumbleTrigger":
                    Scheduler.QueueSourceEntity(
                        ((global::Celeste.Game.Entities.Mechanisms.RumbleWalls.
                            IOriginalRumbleTriggerConstructionEnvironment)EngineContext).RumbleTriggers
                        .Create(record, offset, id, EngineContext));
                    break;
                case "minitextboxTrigger":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Triggers.Dialogue.MiniTextboxTriggerState(record, offset,
                            id, EngineContext));
                    break;
                case "eventTrigger":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Triggers.Events.OriginalEventTriggerState(EngineContext,
                            record, offset));
                    break;
                case "cameraOffsetTrigger":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Triggers.Camera.OriginalCameraOffsetTriggerState(
                            EngineContext, record, offset));
                    break;
                case "cameraTargetTrigger":
                {
                    var deleteFlag = global::Celeste.Formats.Map.Entities.Attributes.EntityAttributeReader.Attr(
                        record.Values, "deleteFlag");
                    if (string.IsNullOrEmpty(deleteFlag) || !Session.GetFlag(deleteFlag))
                        Scheduler.QueueSourceEntity(
                            new global::Celeste.Game.Entities.Triggers.Camera.OriginalCameraTargetTriggerState(
                                EngineContext, record, offset));
                    break;
                }
                case "cameraAdvanceTargetTrigger":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Triggers.Camera.OriginalCameraAdvanceTargetTriggerState(
                            EngineContext, record, offset));
                    break;
            }
        }
    }
}
