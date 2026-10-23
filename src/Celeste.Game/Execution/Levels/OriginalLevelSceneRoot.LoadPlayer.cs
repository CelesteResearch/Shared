using System.Numerics;
using Celeste.Core.Framework.Timing;
using Celeste.Core.Scheduling;
using Celeste.Simulation.Gameplay.Camera;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Gameplay.Player.Scene;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        private void LoadSourceRoomPlayer(PlayerIntroType playerIntro, bool isFromLoader,
            Vector2? checkpointStart)
        {
            var diagnostics = SourceFrameDiagnostics.Current;
            diagnostics?.ChangeLevelLoadPhase(SourceLevelLoadPhase.ActorPrepare);
            if (Session.JustStarted && !Session.StartedFromBeginning &&
                checkpointStart.HasValue && !StartPosition.HasValue)
                StartPosition = checkpointStart;
            if (!Session.RespawnPoint.HasValue)
                Session.RespawnPoint = StartPosition.HasValue
                    ? GetSpawnPoint(StartPosition.Value)
                    : DefaultSpawnPoint;
            var spriteMode = !Session.Inventory.Backpack
                ? PlayerSpriteMode.MadelineNoBackpack
                : PlayerSpriteMode.Madeline;
            var player = CreatePlayer(Session.RespawnPoint.Value, spriteMode);
            var playerCreation =
                SourceRuntimeExtensions
                    .Get<ISourcePlayerCreationExtension>(
                        EngineContext);
            if (playerCreation != null) player = playerCreation.AfterPlayerCreatedBeforeIntro(player);
            player.IntroType = playerIntro;
            Scheduler.QueueSourceEntity(player);
            diagnostics?.ChangeLevelLoadPhase(SourceLevelLoadPhase.EntityCommit);
            Scheduler.CommitQueuedEntityLists();
            diagnostics?.ChangeLevelLoadPhase(SourceLevelLoadPhase
                .ActorFinalize);
            var cameraLockMode = CameraLockMode;
            CameraLockMode = RoomCameraLockMode.None;
            Camera.Position = GetFullCameraTargetAt(player, player.Body.Position);
            CameraLockMode = cameraLockMode;
            CameraUpwardMaxY = Camera.Position.Y + 180f;
            QueueRestoredSourceKeys(player);
            ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.SpotlightFocusPoint =
                Session.RespawnPoint.Value - Camera.Position;
            if (playerIntro != PlayerIntroType.Respawn && playerIntro != PlayerIntroType.Fall)
                _ = new SpotlightWipePresentation(this, true);
            else
                DoScreenWipe(true);
            if (isFromLoader) Renderers.UpdateLists();
            Lighting.Alpha = DarkRoom ? Session.DarkRoomAlpha : BaseLightingAlpha + Session.LightingAlphaAdd;
            Bloom.Base = AreaData.BloomBase + Session.BloomBaseAdd;
        }
    }
}
