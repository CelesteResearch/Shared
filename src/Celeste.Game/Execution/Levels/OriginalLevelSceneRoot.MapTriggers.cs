using System.Numerics;
using Celeste.Core.Maps;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Credits.Triggers;
using Celeste.Game.Entities.Birds.Fling;
using Celeste.Game.Entities.Birds.Paths;
using Celeste.Game.Entities.Hazards.Snowballs;
using Celeste.Game.Entities.Lookouts;
using Celeste.Game.Entities.Mechanisms.RumbleWalls;
using Celeste.Game.Entities.Triggers.Camera;
using Celeste.Game.Entities.Triggers.Events;
using Celeste.Game.Entities.Triggers.Rendering;
using Celeste.Game.Entities.Triggers.Respawning;
using Celeste.Game.Entities.Triggers.Wind;
using Celeste.Game.Gameplay.Collectibles.Strawberries;
using Celeste.Game.Gameplay.Collectibles.Strawberries.Triggers;
using Celeste.Game.Gameplay.Enemies.AngryOshiro;
using Celeste.Game.Gameplay.Triggers.Audio;
using Celeste.Game.Gameplay.Triggers.Backdrops;
using Celeste.Game.Gameplay.Triggers.Checkpoints;
using Celeste.Game.Gameplay.Triggers.Dialogue;
using Celeste.Game.Gameplay.Triggers.Inventory;
using Celeste.Game.Gameplay.Triggers.Movement;
using Celeste.Game.Profiles;
using Celeste.Game.Stories.Interactions;

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
                        new OriginalBloomFadeTriggerState(
                            EngineContext, record, offset));
                    break;
                case "lightFadeTrigger":
                    Scheduler.QueueSourceEntity(
                        new OriginalLightFadeTriggerState(
                            EngineContext, record, offset));
                    break;
                case "ambienceParamTrigger":
                    Scheduler.QueueSourceEntity(
                        new OriginalAmbienceParamTriggerState(record,
                            offset, EngineContext));
                    break;
                case "altMusicTrigger":
                    Scheduler.QueueSourceEntity(
                        new OriginalAltMusicTriggerState(record,
                            offset, EngineContext));
                    break;
                case "musicTrigger":
                    Scheduler.QueueSourceEntity(
                        new OriginalMusicTriggerState(record, offset,
                            EngineContext));
                    break;
                case "musicFadeTrigger":
                    if (((IGameProfileEnvironment)
                            EngineContext).SourceProfile == GameProfile.InstalledEverest)
                        Scheduler.QueueSourceEntity(
                            new InstalledMusicFadeTriggerState(record,
                                offset, EngineContext));
                    else
                        Scheduler.QueueSourceEntity(
                            new OriginalMusicFadeTriggerState(record,
                                offset, EngineContext));
                    break;
                case "spawnFacingTrigger":
                    Scheduler.QueueSourceEntity(
                        new OriginalSpawnFacingTrigger(record,
                            offset, EngineContext));
                    break;
                case "windTrigger":
                    Scheduler.QueueSourceEntity(
                        new OriginalWindTrigger(record, offset,
                            EngineContext));
                    break;
                case "changeRespawnTrigger":
                    Scheduler.QueueSourceEntity(
                        new OriginalChangeRespawnTrigger(record,
                            offset, EngineContext));
                    break;
                case "respawnTargetTrigger":
                    Scheduler.QueueSourceEntity(
                        new OriginalRespawnTargetTrigger(record,
                            offset, EngineContext));
                    break;

                case "windAttackTrigger":
                    Scheduler.QueueSourceEntity(
                        new OriginalWindAttackTriggerState(record,
                            offset,
                            (IOriginalSnowballEnvironment)
                            EngineContext));
                    break;

                case "blackholeStrength":
                    Scheduler.QueueSourceEntity(
                        new OriginalBlackholeStrengthTriggerState(
                            EngineContext, record, offset));
                    break;
                case "moonGlitchBackgroundTrigger":
                    Scheduler.QueueSourceEntity(
                        new OriginalMoonGlitchBackgroundTriggerState(
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
                        new OriginalLookoutBlockerState(record, offset,
                            EngineContext));
                    break;
                case "birdPathTrigger":
                    Scheduler.QueueSourceEntity(
                        new BirdPathTriggerState(record, offset,
                            EngineContext));
                    break;
                case "interactTrigger":
                    Scheduler.QueueSourceEntity(
                        new OriginalInteractTriggerState(record, offset,
                            EngineContext));
                    break;
                case "oshiroTrigger":
                    Scheduler.QueueSourceEntity(
                        new OriginalOshiroTriggerState(
                            record.Position + offset, record.Width, record.Height,
                            EntityAttributeReader.Bool(
                                record.Values, "state", true), EngineContext));
                    break;
                case "creditsTrigger":
                    Scheduler.QueueSourceEntity(new CreditsTriggerState(
                        record.Position + offset, record.Width, record.Height,
                        EntityAttributeReader.Attr(record.Values,
                            "event"), EngineContext));
                    break;
                case "rumbleTrigger":
                    Scheduler.QueueSourceEntity(
                        ((IOriginalRumbleTriggerConstructionEnvironment)EngineContext).RumbleTriggers
                        .Create(record, offset, id, EngineContext));
                    break;
                case "minitextboxTrigger":
                    Scheduler.QueueSourceEntity(
                        new MiniTextboxTriggerState(record, offset,
                            id, EngineContext));
                    break;
                case "eventTrigger":
                    Scheduler.QueueSourceEntity(
                        new OriginalEventTriggerState(EngineContext,
                            record, offset));
                    break;
                case "cameraOffsetTrigger":
                    Scheduler.QueueSourceEntity(
                        new OriginalCameraOffsetTriggerState(
                            EngineContext, record, offset));
                    break;
                case "cameraTargetTrigger":
                {
                    var deleteFlag = EntityAttributeReader.Attr(
                        record.Values, "deleteFlag");
                    if (string.IsNullOrEmpty(deleteFlag) || !Session.GetFlag(deleteFlag))
                        Scheduler.QueueSourceEntity(
                            new OriginalCameraTargetTriggerState(
                                EngineContext, record, offset));
                    break;
                }
                case "cameraAdvanceTargetTrigger":
                    Scheduler.QueueSourceEntity(
                        new OriginalCameraAdvanceTargetTriggerState(
                            EngineContext, record, offset));
                    break;
            }
        }
    }
}
