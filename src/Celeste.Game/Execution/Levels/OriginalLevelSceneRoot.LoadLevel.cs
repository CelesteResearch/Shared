using System.Numerics;
using Celeste.Core.Framework.Timing;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation.Gameplay.Player.Intro;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public void LoadLevel(PlayerIntroType playerIntro, bool isFromLoader = false)
        {
            var diagnostics = SourceFrameDiagnostics.Current;
            var measuring = diagnostics?.BeginLevelLoad(Session.Level) ?? false;
            try
            {
                ResetSourceLevelLoad(playerIntro);
                InitializeSourceHiccupRandom();
                ResetSourceFirstLightningRenderer();
                PushSourceRoomRandom();
                _ = Session.MapData;
                var room = (OriginalLevelRoomData)Session.LevelData;
                var offset = new Vector2(room.Bounds.Left, room.Bounds.Top);
                var checkpointsEnabled = playerIntro != PlayerIntroType.Fall || room.Name == "0";
                DarkRoom = room.Dark && !Session.GetFlag("ignore_darkness_" + room.Name);
                Zoom = 1f;
                ApplySourceRoomAudio(room, isFromLoader);
                CoreMode = Session.CoreMode;
                NewLevel = !Session.LevelFlags.Contains(room.Name);
                if (checkpointsEnabled)
                {
                    if (!Session.LevelFlags.Contains(room.Name))
                        Session.FurthestSeenLevel = room.Name;
                    Session.LevelFlags.Add(room.Name);
                    Session.UpdateLevelStartDashes();
                }

                CameraOffset = new Vector2(48f, 32f) * room.CameraOffset;
                ReplaceSourceWindController(room.WindPattern, playerIntro);
                if (room.Underwater)
                    AddSourceUnderwaterRoom(offset, room.Bounds.Width, room.Bounds.Height);
                InSpace = room.Space;
                if (InSpace)
                    AddSourceSpaceController();
                if (room.Name == "-1" && Session.AreaID == 0 &&
                    !((IOriginalGameplayProcess)EngineContext).SaveContext
                        .CurrentSave.CheatMode)
                    AddSourceUnlockEverything();

                LoadSourceRoomMapPhases(room, offset, checkpointsEnabled,
                    out var checkpointStart, out var hasRoomLightning);

                if (playerIntro != PlayerIntroType.Transition)
                {
                    LoadSourceRoomPlayer(playerIntro, isFromLoader, checkpointStart);
                }
                else
                {
                    if (measuring)
                        diagnostics.ChangeLevelLoadPhase(SourceLevelLoadPhase
                            .EntityCommit);
                    Scheduler.CommitQueuedEntityLists();
                }

                if (measuring)
                    diagnostics.ChangeLevelLoadPhase(
                        SourceLevelLoadPhase.PostLoad);

                if (HasCassetteBlocks && ShouldCreateCassetteManager)
                    StartSourceCassetteManager();
                if (measuring)
                    diagnostics.ChangeLevelLoadPhase(SourceLevelLoadPhase
                        .ObjectTile);
                InterceptSourceObjectTiles(room);
                if (measuring)
                    diagnostics.ChangeLevelLoadPhase(
                        SourceLevelLoadPhase.PostLoad);
                SetSourceRoomLightningAmbience(hasRoomLightning);
                PopSourceRoomRandom();
                ((IOriginalLevelLoadSourceHooksEnvironment)EngineContext).AfterSourceLevelLoad(this, playerIntro,
                    isFromLoader);
            }
            finally
            {
                if (measuring) diagnostics.EndLevelLoad();
            }
        }
    }
}
