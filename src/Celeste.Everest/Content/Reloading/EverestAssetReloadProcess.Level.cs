using System;
using System.Numerics;
using System.Threading.Tasks;
using Celeste.Core.Scheduling;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Everest.Runtime.Loading;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Formats.Save.Xml;

namespace Celeste.Everest.Content.Reloading
{
    public sealed partial class EverestAssetReloadProcess
    {
        private readonly object levelReloadLock = new object();
        private Task currentLevelReload;
        public void ReloadLevel() => ReloadLevel(false);

        public Task ReloadLevel(bool forceReload = false)
        {
            if (Timing.LoadTimer != null) return Task.CompletedTask;
            if (!forceReload)
            {
                lock (levelReloadLock)
                {
                    Task task = currentLevelReload;
                    if (task != null && task.IsCompleted) currentLevelReload = null;
                    if (currentLevelReload == null) currentLevelReload = ReloadLevel(true);
                    return currentLevelReload;
                }
            }

            return MainThread.Schedule(() =>
            {
                OriginalLevelSceneRoot level = EngineContext.Frame.Scenes.CurrentScene as OriginalLevelSceneRoot;
                if (level == null && IsReloading) level = ReturnToScene as OriginalLevelSceneRoot;
                if (level == null) return Task.CompletedTask;
                Logger.Log(EverestLogLevel.Info, "reload", "Starting level reload...");
                Events.ReloadLevel(level);
                return Do(
                    ((IOriginalGameTextEnvironment)EngineContext).Text.Dialog.Clean("ASSETRELOADHELPER_RELOADINGLEVEL"),
                    async _ =>
                    {
                        try
                        {
                            var loadOverride = new EverestLevelLoadOverride();
                            if (level.Transitioning)
                            {
                                var player =
                                    level.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                                        typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

                                level.Session.RespawnPoint = level.GetSpawnPoint(player?.Position ?? Vector2.Zero);
                            }

                            var loader =
                                ((IOriginalLevelLoaderEnvironment)EngineContext).LevelLoaders.CreateLevelLoader(
                                    level.Session, level.Session.RespawnPoint);
                            ReturnToScene = loader;
                            loadOverride.ShouldAutoPause = level.Paused;
                            var loadedPlayer =
                                level.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

                            if (loadedPlayer != null && !loadedPlayer.Dead)
                            {
                                loadOverride.SkipScreenWipes++;
                                loadOverride.NextLoadedPlayer = loadedPlayer;
                                loadedPlayer.OverrideIntroType = PlayerIntroType.Transition;
                                loadedPlayer.Machine.Locked = false;
                                loadedPlayer.Machine.State = 0;
                                loadedPlayer.Sprite.Visible = loadedPlayer.Hair.Visible = true;
                                loadedPlayer.Light.Index = -1;
                                loadedPlayer.Leader.LoseFollowers();
                                loadedPlayer.Holding.Holding?.Release(Vector2.Zero);
                                loadedPlayer.Holding.SetHolding(null);
                            }

                            while (!loader.Loaded) await Task.Delay(50);
                            EverestLevelLoadOverrides.Register(loader.Level, loadOverride);
                        }
                        catch (Exception exception)
                        {
                            var keys = ((IOriginalAreaKeyEnvironment)EngineContext).AreaKeys;
                            string sid = level.Session != null ? keys.GetSID(keys.GetSessionArea(level.Session)) : null;
                            sid ??= "NULL";
                            var session = level.Session;
                            int hasArea;
                            if (session == null) hasArea = 0;
                            else
                            {
                                keys.GetSessionArea(session);
                                hasArea = 1;
                            }

                            var dialog = ((IOriginalGameTextEnvironment)EngineContext).Text.Dialog;
                            string name = null;
                            string suffix = hasArea != 0 &&
                                            dialog.Has(name = keys.GetArea(keys.GetSessionArea(level.Session)).Name)
                                ? " [name: " + dialog.Clean(name, dialog.Languages["english"]) + "]"
                                : null;
                            var session2 = level.Session;
                            if (session2 != null && session2.Mode > 0)
                                suffix += " [" + (AreaMode)level.Session.Mode + "]";
                            Logger.WarnReloadLevelFailed(sid, suffix);
                            Logger.LogDetailed(exception, "reload");
                            ((IOriginalLevelEnterStaticEnvironment)EngineContext).LevelEnterStatics.ErrorMessage =
                                dialog.Get("postcard_levelloadfailed").Replace("((sid))", sid);
                            ReturnToScene =
                                ((IOriginalLevelEntryEnvironment)EngineContext).LevelEntries.CreateLevelEnter(
                                    level.Session,
                                    false);
                        }
                    });
            });
        }
    }
}
