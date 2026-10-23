using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Audio.Mixing;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Menus.Options;
using Celeste.Game.Menus.Pause;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Session;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Save.Runtime;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Configuration;
using Celeste.Simulation.UI.Menus.Text;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public bool PauseMainMenuOpen;
        private IOriginalGameplayProcess PauseProcess => (IOriginalGameplayProcess)EngineContext;
        private OriginalGameTextProcess PauseText => ((IOriginalGameTextEnvironment)EngineContext).Text;

        private OriginalGameInputProcess PauseInput =>
            ((IOriginalGameInputProcessEnvironment)EngineContext).InputSource;

        private IOriginalLevelExitFactory PauseLevelExits => ((IOriginalLevelExitEnvironment)EngineContext).LevelExits;

        public void Pause(int startIndex = 0, bool minimal = false, bool quickReset = false)
            => ((IOriginalLevelPauseEnvironment)EngineContext).LevelPause.Pause(this, startIndex, minimal, quickReset);

        public void PauseOriginalGame(int startIndex = 0, bool minimal = false, bool quickReset = false)
        {
            wasPaused = true;
            RoomPlayerSession player =
                Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession)
                        .FullName);

            if (!Paused)
            {
                StartPauseEffects();
            }

            Paused = true;
            if (quickReset)
            {
                sourceAudioSession.Play("event:/ui/main/message_confirm");
                PauseMainMenuOpen = false;
                GiveUp(0, restartArea: true, minimal, showHint: false);
                return;
            }

            PauseMainMenuOpen = true;
            TextMenuPresentation menu = new TextMenuPresentation(EngineContext);
            if (!minimal)
            {
                menu.Add(new TextMenuPresentation.Header(PauseText.CleanDialog("menu_pause_title")));
            }

            menu.Add(new TextMenuPresentation.Button(PauseText.CleanDialog("menu_pause_resume")).Pressed(delegate
            {
                menu.OnCancel();
            }));
            if (InCutscene && !SkippingCutscene)
            {
                menu.Add(new TextMenuPresentation.Button(PauseText.CleanDialog("menu_pause_skip_cutscene")).Pressed(
                    delegate
                    {
                        SkipCutscene();
                        Paused = false;
                        PauseMainMenuOpen = false;
                        menu.RemoveSelf();
                    }));
            }

            if (!minimal && !InCutscene && !SkippingCutscene)
            {
                TextMenuPresentation.Item item;
                menu.Add(item = new TextMenuPresentation.Button(PauseText.CleanDialog("menu_pause_retry")).Pressed(
                    delegate
                    {
                        if (player != null && !player.Dead)
                        {
                            EngineContext.Effects.TimeRate = 1f;
                            EngineContext.Effects.GameRate = 1f;
                            EngineContext.Effects.Anxiety = 0f;
                            InCutscene = (Cutscene.SkippingCutscene = false);
                            RetryPlayerCorpse = player.Die(Vector2.Zero, evenIfInvincible: true);
                            foreach (Celeste.Scene.Lifecycle.ILevelEndingCallback component in Scheduler.Components
                                         .GetTrackedComponents("Celeste.LevelEndingHook"))
                            {
                                if (component.OnEnd != null)
                                {
                                    component.OnEnd();
                                }
                            }
                        }

                        Paused = false;
                        PauseMainMenuOpen = false;
                        EndPauseEffects();
                        menu.RemoveSelf();
                    }));
                item.Disabled = !CanRetry || (player != null && !player.CanRetry) || Frozen || Completed;
            }

            if (!minimal && PauseProcess.SaveContext.CurrentSave.AssistMode)
            {
                TextMenuPresentation.Item item2 = null;
                menu.Add(item2 = new TextMenuPresentation.Button(PauseText.CleanDialog("menu_pause_assist")).Pressed(
                    delegate
                    {
                        menu.RemoveSelf();
                        PauseMainMenuOpen = false;
                        AssistMode(menu.IndexOf(item2), minimal);
                    }));
            }

            if (!minimal && PauseProcess.SaveContext.CurrentSave.VariantMode)
            {
                TextMenuPresentation.Item item3 = null;
                menu.Add(item3 = new TextMenuPresentation.Button(PauseText.CleanDialog("menu_pause_variant")).Pressed(
                    delegate
                    {
                        menu.RemoveSelf();
                        PauseMainMenuOpen = false;
                        VariantMode(menu.IndexOf(item3), minimal);
                    }));
            }

            TextMenuPresentation.Item item4 = null;
            menu.Add(item4 = new TextMenuPresentation.Button(PauseText.CleanDialog("menu_pause_options")).Pressed(
                delegate
                {
                    menu.RemoveSelf();
                    PauseMainMenuOpen = false;
                    Options(menu.IndexOf(item4), minimal);
                }));
            if (!minimal && ((IOriginalGamePlayModeEnvironment)EngineContext).PlayMode !=
                GameRuntime.PlayModes.Event)
            {
                TextMenuPresentation.Item item5 = null;
                menu.Add(item5 = new TextMenuPresentation.Button(PauseText.CleanDialog("menu_pause_savequit")).Pressed(
                    delegate
                    {
                        if (global::Celeste.Core.Scheduling.SourceRuntimeExtensions
                                .Get<global::Celeste.Core.Scheduling.ISourceGameplayLifecycleExtension>(EngineContext)
                            is { } protection)
                            protection.BeforeSaveAndQuit();
                        menu.Focused = false;
                        EngineContext.Effects.TimeRate = 1f;
                        sourceAudioSession.SetMusic(null);
                        sourceAudioSession.Runtime.StopGameplaySfx(true);
                        Session.InArea = true;
                        Session.Deaths++;
                        Session.DeathsInCurrentLevel++;
                        var saveQuitArea =
                            ((global::Celeste.Game.Execution.Areas.IOriginalAreaKeyEnvironment)EngineContext).AreaKeys
                            .GetSessionArea(Session);
                        PauseProcess.SaveContext.AddDeath(
                            new global::Celeste.Core.Campaigns.CampaignAreaKey(saveQuitArea.ID, saveQuitArea.Mode));
                        DoScreenWipe(wipeIn: false,
                            delegate
                            {
                                EngineContext.Frame.Scenes.NextScene =
                                    PauseLevelExits.CreateLevelExit(LevelExitMode.SaveAndQuit, Session, HiresSnow);
                            }, hiresSnow: true);
                        foreach (Celeste.Scene.Lifecycle.ILevelEndingCallback component2 in Scheduler.Components
                                     .GetTrackedComponents("Celeste.LevelEndingHook"))
                        {
                            if (component2.OnEnd != null)
                            {
                                component2.OnEnd();
                            }
                        }
                    }));
                if (SaveQuitDisabled || (player != null && player.Machine.State == 18))
                {
                    item5.Disabled = true;
                }
            }

            if (!minimal)
            {
                menu.Add(new TextMenuPresentation.SubHeader(""));
                TextMenuPresentation.Item item6 = null;
                menu.Add(item6 =
                    new TextMenuPresentation.Button(PauseText.CleanDialog("menu_pause_restartarea")).Pressed(
                        delegate
                        {
                            PauseMainMenuOpen = false;
                            menu.RemoveSelf();
                            GiveUp(menu.IndexOf(item6), restartArea: true, minimal, showHint: true);
                        }));
                (item6 as TextMenuPresentation.Button).ConfirmSfx = "event:/ui/main/message_confirm";
                if (PauseProcess.SaveContext.CurrentSave.Areas[0].Modes[0].Completed ||
                    PauseProcess.SaveContext.CurrentSave.DebugMode || PauseProcess.SaveContext.CurrentSave.CheatMode)
                {
                    TextMenuPresentation.Item item7 = null;
                    menu.Add(item7 =
                        new TextMenuPresentation.Button(PauseText.CleanDialog("menu_pause_return")).Pressed(
                            delegate
                            {
                                PauseMainMenuOpen = false;
                                menu.RemoveSelf();
                                GiveUp(menu.IndexOf(item7), restartArea: false, minimal, showHint: false);
                            }));
                    (item7 as TextMenuPresentation.Button).ConfirmSfx = "event:/ui/main/message_confirm";
                }

                if (((IOriginalGamePlayModeEnvironment)EngineContext).PlayMode == GameRuntime.PlayModes.Event)
                {
                    menu.Add(new TextMenuPresentation.Button(PauseText.CleanDialog("menu_pause_restartdemo")).Pressed(
                        delegate
                        {
                            EndPauseEffects();
                            sourceAudioSession.SetMusic(null);
                            menu.Focused = false;
                            if (EngineContext is
                                global::Celeste.Game.Content.Loading.IOriginalChapterPreparationEnvironment preparation)
                                preparation.ChapterPreparation?.PrepareArea(0);
                            DoScreenWipe(wipeIn: false,
                                delegate
                                {
                                    OriginalLevelEntryRouting.Go(
                                        ((IOriginalSessionEnvironment)EngineContext).Sessions.CreateSession(
                                            ((IOriginalAreaKeyEnvironment)EngineContext).AreaKeys.Create(0)), false,
                                        EngineContext.Frame.Scenes,
                                        ((IOriginalLevelEntryEnvironment)EngineContext).LevelEntries);
                                });
                        }));
                }
            }

            menu.OnESC = (menu.OnCancel = (menu.OnPause = delegate
            {
                PauseMainMenuOpen = false;
                menu.RemoveSelf();
                Paused = false;
                sourceAudioSession.Play("event:/ui/game/unpause");
                unpauseTimer = 0.15f;
            }));
            if (startIndex > 0)
            {
                menu.Selection = startIndex;
            }

            Scheduler.QueueSourceEntity(menu);
        }

        private void GiveUp(int returnIndex, bool restartArea, bool minimal, bool showHint)
        {
            Paused = true;
            Celeste.Scene.Entities.SceneEntityState quickHint = null;
            ReturnMapHintPresentation returnHint = null;
            if (!restartArea)
            {
                Scheduler.QueueSourceEntity(returnHint =
                    ((IOriginalLevelPauseEnvironment)EngineContext).LevelPause.CreateReturnMapHint(EngineContext));
            }

            TextMenuPresentation menu = new TextMenuPresentation(EngineContext);
            menu.AutoScroll = false;
            menu.Position =
                new Vector2((float)((IOriginalEngineGraphicsEnvironment)EngineContext).EngineGraphics.Width / 2f,
                    (float)((IOriginalEngineGraphicsEnvironment)EngineContext).EngineGraphics.Height / 2f - 100f);
            menu.Add(new TextMenuPresentation.Header(
                PauseText.CleanDialog(restartArea ? "menu_restart_title" : "menu_return_title")));
            menu.Add(new TextMenuPresentation.Button(
                PauseText.CleanDialog(restartArea ? "menu_restart_continue" : "menu_return_continue")).Pressed(delegate
            {
                EngineContext.Effects.TimeRate = 1f;
                menu.Focused = false;
                Session.InArea = false;
                sourceAudioSession.SetMusic(null);
                sourceAudioSession.Runtime.StopGameplaySfx(true);
                if (restartArea)
                {
                    DoScreenWipe(wipeIn: false,
                        delegate
                        {
                            EngineContext.Frame.Scenes.NextScene =
                                PauseLevelExits.CreateLevelExit(LevelExitMode.Restart, Session);
                        });
                }
                else
                {
                    DoScreenWipe(wipeIn: false,
                        delegate
                        {
                            EngineContext.Frame.Scenes.NextScene =
                                PauseLevelExits.CreateLevelExit(LevelExitMode.GiveUp, Session, HiresSnow);
                        }, hiresSnow: true);
                }

                foreach (Celeste.Scene.Lifecycle.ILevelEndingCallback component in
                         Scheduler.Components.GetTrackedComponents("Celeste.LevelEndingHook"))
                {
                    if (component.OnEnd != null)
                    {
                        component.OnEnd();
                    }
                }
            }));
            menu.Add(new TextMenuPresentation.Button(
                    PauseText.CleanDialog(restartArea ? "menu_restart_cancel" : "menu_return_cancel"))
                .Pressed(delegate { menu.OnCancel(); }));
            menu.OnPause = (menu.OnESC = delegate
            {
                menu.RemoveSelf();
                if (quickHint != null)
                {
                    quickHint.RemoveSelf();
                }

                if (returnHint != null)
                {
                    returnHint.RemoveSelf();
                }

                Paused = false;
                unpauseTimer = 0.15f;
                sourceAudioSession.Play("event:/ui/game/unpause");
            });
            menu.OnCancel = delegate
            {
                sourceAudioSession.Play("event:/ui/main/button_back");
                menu.RemoveSelf();
                if (quickHint != null)
                {
                    quickHint.RemoveSelf();
                }

                if (returnHint != null)
                {
                    returnHint.RemoveSelf();
                }

                Pause(returnIndex, minimal);
            };
            Scheduler.QueueSourceEntity(menu);
        }

        private void Options(int returnIndex, bool minimal)
        {
            Paused = true;
            bool oldAllowHudHide = AllowHudHide;
            AllowHudHide = false;
            TextMenuPresentation options =
                ((IOriginalMenuOptionsEnvironment)EngineContext).MenuOptions.Create(inGame: true, PauseSnapshot);
            options.OnESC = (options.OnCancel = delegate
            {
                sourceAudioSession.Play("event:/ui/main/button_back");
                AllowHudHide = oldAllowHudHide;
                options.CloseAndRun(SaveFromOptions(), delegate { Pause(returnIndex, minimal); });
            });
            options.OnPause = delegate
            {
                sourceAudioSession.Play("event:/ui/main/button_back");
                options.CloseAndRun(SaveFromOptions(), delegate
                {
                    AllowHudHide = oldAllowHudHide;
                    Paused = false;
                    unpauseTimer = 0.15f;
                });
            };
            Scheduler.QueueSourceEntity(options);
        }

        private IEnumerator SaveFromOptions()
        {
            ((IOriginalUserIOEnvironment)EngineContext).UserIO.SaveHandler(file: false, settings: true);
            while (((IOriginalUserIOEnvironment)EngineContext).UserIO.Saving)
            {
                yield return null;
            }
        }

        private void AssistMode(int returnIndex, bool minimal)
        {
            Paused = true;
            TextMenuPresentation menu = new TextMenuPresentation(EngineContext);
            menu.Add(new TextMenuPresentation.Header(PauseText.CleanDialog("MENU_ASSIST_TITLE")));
            menu.Add(new TextMenuPresentation.Slider(PauseText.CleanDialog("MENU_ASSIST_GAMESPEED"),
                (int i) => i * 10 + "%", 5, 10, PauseProcess.SaveContext.CurrentSave.Assists.GameSpeed).Change(
                delegate(int i)
                {
                    PauseProcess.SaveContext.CurrentSave.Assists.GameSpeed = i;
                    EngineContext.Effects.TimeRateB =
                        (float)PauseProcess.SaveContext.CurrentSave.Assists.GameSpeed / 10f;
                }));
            menu.Add(new TextMenuPresentation.OnOff(PauseText.CleanDialog("MENU_ASSIST_INFINITE_STAMINA"),
                PauseProcess.SaveContext.CurrentSave.Assists.InfiniteStamina, EngineContext).Change(delegate(bool on)
            {
                PauseProcess.SaveContext.CurrentSave.Assists.InfiniteStamina = on;
            }));
            TextMenuPresentation.Option<int> option;
            menu.Add(option = new TextMenuPresentation.Slider(PauseText.CleanDialog("MENU_ASSIST_AIR_DASHES"),
                (int i) =>
                    i switch
                    {
                        0 => PauseText.CleanDialog("MENU_ASSIST_AIR_DASHES_NORMAL"),
                        1 => PauseText.CleanDialog("MENU_ASSIST_AIR_DASHES_TWO"),
                        _ => PauseText.CleanDialog("MENU_ASSIST_AIR_DASHES_INFINITE"),
                    }, 0, 2, (int)PauseProcess.SaveContext.CurrentSave.Assists.DashMode).Change(delegate(int on)
            {
                PauseProcess.SaveContext.CurrentSave.Assists.DashMode = (DashMode)on;
                RoomPlayerSession entity =
                    Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

                if (entity != null)
                {
                    entity.Data.Dashes = Math.Min(entity.Data.Dashes, entity.Motor.BeforeState.MaxDashes);
                }
            }));
            if (Session.AreaID == 0)
            {
                option.Disabled = true;
            }

            menu.Add(new TextMenuPresentation.OnOff(PauseText.CleanDialog("MENU_ASSIST_DASH_ASSIST"),
                PauseProcess.SaveContext.CurrentSave.Assists.DashAssist, EngineContext).Change(delegate(bool on)
            {
                PauseProcess.SaveContext.CurrentSave.Assists.DashAssist = on;
            }));
            menu.Add(new TextMenuPresentation.OnOff(PauseText.CleanDialog("MENU_ASSIST_INVINCIBLE"),
                PauseProcess.SaveContext.CurrentSave.Assists.Invincible, EngineContext).Change(delegate(bool on)
            {
                PauseProcess.SaveContext.CurrentSave.Assists.Invincible = on;
            }));
            menu.OnESC = (menu.OnCancel = delegate
            {
                sourceAudioSession.Play("event:/ui/main/button_back");
                Pause(returnIndex, minimal);
                menu.Close();
            });
            menu.OnPause = delegate
            {
                sourceAudioSession.Play("event:/ui/main/button_back");
                Paused = false;
                unpauseTimer = 0.15f;
                menu.Close();
            };
            Scheduler.QueueSourceEntity(menu);
        }

        private void VariantMode(int returnIndex, bool minimal)
        {
            Paused = true;
            TextMenuPresentation menu = new TextMenuPresentation(EngineContext);
            menu.Add(new TextMenuPresentation.Header(PauseText.CleanDialog("MENU_VARIANT_TITLE")));
            menu.Add(new TextMenuPresentation.SubHeader(PauseText.CleanDialog("MENU_VARIANT_SUBTITLE")));
            TextMenuPresentation.Slider speed;
            menu.Add(speed = new TextMenuPresentation.Slider(PauseText.CleanDialog("MENU_ASSIST_GAMESPEED"),
                (int i) => i * 10 + "%", 5, 16, PauseProcess.SaveContext.CurrentSave.Assists.GameSpeed));
            speed.Change(delegate(int i)
            {
                if (i > 10)
                {
                    i = ((speed.Values[speed.PreviousIndex].Item2 <= i) ? (i + 1) : (i - 1));
                }

                speed.Index = i - 5;
                PauseProcess.SaveContext.CurrentSave.Assists.GameSpeed = i;
                EngineContext.Effects.TimeRateB = (float)PauseProcess.SaveContext.CurrentSave.Assists.GameSpeed / 10f;
            });
            menu.Add(new TextMenuPresentation.OnOff(PauseText.CleanDialog("MENU_VARIANT_MIRROR"),
                PauseProcess.SaveContext.CurrentSave.Assists.MirrorMode, EngineContext).Change(delegate(bool on)
            {
                PauseProcess.SaveContext.CurrentSave.Assists.MirrorMode = on;
                PauseInput.MoveX.Inverted = (PauseInput.Aim.InvertedX = (PauseInput.Feather.InvertedX = on));
            }));
            menu.Add(new TextMenuPresentation.OnOff(PauseText.CleanDialog("MENU_VARIANT_360DASHING"),
                PauseProcess.SaveContext.CurrentSave.Assists.ThreeSixtyDashing, EngineContext).Change(delegate(bool on)
            {
                PauseProcess.SaveContext.CurrentSave.Assists.ThreeSixtyDashing = on;
            }));
            menu.Add(new TextMenuPresentation.OnOff(PauseText.CleanDialog("MENU_VARIANT_INVISMOTION"),
                PauseProcess.SaveContext.CurrentSave.Assists.InvisibleMotion, EngineContext).Change(delegate(bool on)
            {
                PauseProcess.SaveContext.CurrentSave.Assists.InvisibleMotion = on;
            }));
            menu.Add(new TextMenuPresentation.OnOff(PauseText.CleanDialog("MENU_VARIANT_NOGRABBING"),
                PauseProcess.SaveContext.CurrentSave.Assists.NoGrabbing, EngineContext).Change(delegate(bool on)
            {
                PauseProcess.SaveContext.CurrentSave.Assists.NoGrabbing = on;
            }));
            menu.Add(new TextMenuPresentation.OnOff(PauseText.CleanDialog("MENU_VARIANT_LOWFRICTION"),
                PauseProcess.SaveContext.CurrentSave.Assists.LowFriction, EngineContext).Change(delegate(bool on)
            {
                PauseProcess.SaveContext.CurrentSave.Assists.LowFriction = on;
            }));
            menu.Add(new TextMenuPresentation.OnOff(PauseText.CleanDialog("MENU_VARIANT_SUPERDASHING"),
                PauseProcess.SaveContext.CurrentSave.Assists.SuperDashing, EngineContext).Change(delegate(bool on)
            {
                PauseProcess.SaveContext.CurrentSave.Assists.SuperDashing = on;
            }));
            menu.Add(new TextMenuPresentation.OnOff(PauseText.CleanDialog("MENU_VARIANT_HICCUPS"),
                PauseProcess.SaveContext.CurrentSave.Assists.Hiccups, EngineContext).Change(delegate(bool on)
            {
                PauseProcess.SaveContext.CurrentSave.Assists.Hiccups = on;
            }));
            menu.Add(new TextMenuPresentation.OnOff(PauseText.CleanDialog("MENU_VARIANT_PLAYASBADELINE"),
                PauseProcess.SaveContext.CurrentSave.Assists.PlayAsBadeline, EngineContext).Change(delegate(bool on)
            {
                PauseProcess.SaveContext.CurrentSave.Assists.PlayAsBadeline = on;
                RoomPlayerSession entity =
                    Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

                if (entity != null)
                {
                    Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSpriteMode mode =
                        (PauseProcess.SaveContext.CurrentSave.Assists.PlayAsBadeline
                            ? Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSpriteMode
                                .MadelineAsBadeline
                            : entity.DefaultSpriteMode);
                    if (entity.Active)
                    {
                        entity.ResetSpriteNextFrame(mode);
                    }
                    else
                    {
                        entity.ResetSprite(mode);
                    }
                }
            }));
            menu.Add(new TextMenuPresentation.SubHeader(PauseText.CleanDialog("MENU_ASSIST_SUBTITLE")));
            menu.Add(new TextMenuPresentation.OnOff(PauseText.CleanDialog("MENU_ASSIST_INFINITE_STAMINA"),
                PauseProcess.SaveContext.CurrentSave.Assists.InfiniteStamina, EngineContext).Change(delegate(bool on)
            {
                PauseProcess.SaveContext.CurrentSave.Assists.InfiniteStamina = on;
            }));
            TextMenuPresentation.Option<int> option;
            menu.Add(option = new TextMenuPresentation.Slider(PauseText.CleanDialog("MENU_ASSIST_AIR_DASHES"),
                (int i) =>
                    i switch
                    {
                        0 => PauseText.CleanDialog("MENU_ASSIST_AIR_DASHES_NORMAL"),
                        1 => PauseText.CleanDialog("MENU_ASSIST_AIR_DASHES_TWO"),
                        _ => PauseText.CleanDialog("MENU_ASSIST_AIR_DASHES_INFINITE"),
                    }, 0, 2, (int)PauseProcess.SaveContext.CurrentSave.Assists.DashMode).Change(delegate(int on)
            {
                PauseProcess.SaveContext.CurrentSave.Assists.DashMode = (DashMode)on;
                RoomPlayerSession entity =
                    Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

                if (entity != null)
                {
                    entity.Data.Dashes = Math.Min(entity.Data.Dashes, entity.Motor.BeforeState.MaxDashes);
                }
            }));
            if (Session.AreaID == 0)
            {
                option.Disabled = true;
            }

            menu.Add(new TextMenuPresentation.OnOff(PauseText.CleanDialog("MENU_ASSIST_DASH_ASSIST"),
                PauseProcess.SaveContext.CurrentSave.Assists.DashAssist, EngineContext).Change(delegate(bool on)
            {
                PauseProcess.SaveContext.CurrentSave.Assists.DashAssist = on;
            }));
            menu.Add(new TextMenuPresentation.OnOff(PauseText.CleanDialog("MENU_ASSIST_INVINCIBLE"),
                PauseProcess.SaveContext.CurrentSave.Assists.Invincible, EngineContext).Change(delegate(bool on)
            {
                PauseProcess.SaveContext.CurrentSave.Assists.Invincible = on;
            }));
            menu.OnESC = (menu.OnCancel = delegate
            {
                sourceAudioSession.Play("event:/ui/main/button_back");
                Pause(returnIndex, minimal);
                menu.Close();
            });
            menu.OnPause = delegate
            {
                sourceAudioSession.Play("event:/ui/main/button_back");
                Paused = false;
                unpauseTimer = 0.15f;
                menu.Close();
            };
            Scheduler.QueueSourceEntity(menu);
        }
    }
}
