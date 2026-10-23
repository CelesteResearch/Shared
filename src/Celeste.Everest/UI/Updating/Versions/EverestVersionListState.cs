using Celeste.Core.Display;
using Celeste.Localization.Lookup;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics.Easing;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Menus.Overworld;
using Celeste.Scene.Tracking;
using Celeste.Graphics.Display;
using Celeste.Graphics.Text;
using Celeste.Graphics.Rendering;
using Celeste.Simulation.UI.Menus.Text;
using Celeste.Everest.UI.Settings;
using Celeste.Everest.UI.ModOptions;
using Celeste.Everest.UI.Progress;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Modules.Updating;
using Celeste.Everest.Runtime.Startup;
using Celeste.Everest.UI.Text;
using Celeste.Core.Lifecycle;
using Celeste.Audio.Fmod.Events;

namespace Celeste.Everest.UI.Updating.Versions
{
    public class EverestVersionListState : OuiState, IEverestModOptionsSubmenu
    {
        private readonly ISourceEngineContext engine;

        public EverestVersionListState(ISourceEngineContext engine) : base(engine)
        {
            this.engine = engine;
        }

        private OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)engine).InputSource;
        private OriginalGameAudioSession Audio => ((IOriginalGameplayProcess)engine).AudioSession;
        private DialogCatalog Dialog => ((IOriginalGameTextEnvironment)engine).Text.Dialog;
        private ActiveBitmapFont ActiveFont => ((ISourceActiveFontScope)engine).ActiveFont;
        private EverestUpdaterProcess Updater => ((IEverestUpdaterEnvironment)engine).Updater;
        private EverestCoreSettings Settings => ((IEverestCoreSettingsEnvironment)engine).CurrentCoreSettings;
        private EverestStartupRuntimeProcess Runtime => ((IEverestStartupRuntimeEnvironment)engine).EverestRuntime;

        private TextMenuPresentation menu;

        private TextMenuPresentation.SubHeader currentBranchName;

        private const float onScreenX = 960f;

        private const float offScreenX = 2880f;

        private bool waitingForRequest;

        private float alpha;

        private List<IEverestMenuItemExt> items = new List<IEverestMenuItemExt>();

        private int buildsPerBranch = 12;

        public TextMenuPresentation CreateMenu(bool inGame, FmodEventReference snapshot)
        {
            menu = new TextMenuPresentation(engine)
            {
                CompactWidthMode = true
            };
            items.Clear();
            menu.Add(new TextMenuPresentation.Header(Dialog.Clean("updater_versions_title")));
            menu.Add(new TextMenuPresentation.SubHeader(Dialog.Clean("updater_versions_current")
                .Replace("((version))", Runtime.BuildString)));
            TextMenuPresentation.Option<EverestUpdateSource> option =
                new TextMenuPresentation.Option<EverestUpdateSource>(Dialog.Clean("UPDATER_CURRENT_BRANCH"));
            menu.Add(option);
            currentBranchName = new EverestMenuSubHeaderExt("")
            {
                HeightExtra = 0f
            };
            menu.Add(currentBranchName);
            EverestUpdateSource source = null;
            foreach (EverestUpdateSource source2 in Updater.Sources)
            {
                if ((source2.Entries?.Count ?? 0) > 0 || !string.IsNullOrWhiteSpace(source2.ErrorDialog))
                {
                    option.Add(SourceDialogTextLookup.CleanOrNull(Dialog, source2.Name) ?? source2.Name, source2,
                        source2.Name == Settings.CurrentBranch);
                    if (source2.Name == Settings.CurrentBranch)
                    {
                        source = source2;
                    }
                }
            }

            option.Change(ReloadItems);
            if (source != null)
            {
                ReloadItems(source);
            }
            else if (option.Values.Count > 0)
            {
                ReloadItems(option.Values[0].Item2);
            }

            return menu;
        }

        private void ReloadItems(EverestUpdateSource source)
        {
            using (new SourceScopeFinalizer(delegate
                   {
                       for (int i = 0; i < items.Count; i++)
                       {
                           OwnedComponents.Add(new SimulationCoroutine(engine, FadeIn(i, items[i])));
                       }

                       if (menu.Height > menu.ScrollableMinSize)
                       {
                           Vector2 scrollPosition = menu.Position;
                           scrollPosition.Y = menu.ScrollTargetY;
                           menu.Position = scrollPosition;
                       }
                   }))
            {
                using (new EverestMenuBatchModeContext(menu))
                {
                    foreach (TextMenuPresentation.Item item5 in items)
                    {
                        menu.Remove(item5);
                    }

                    items.Clear();
                    currentBranchName.Title =
                        SourceDialogTextLookup.CleanOrNull(Dialog, source.Description) ?? source.Description;
                    if (source.ErrorDialog != null)
                    {
                        EverestMenuSubHeaderExt item2 = new EverestMenuSubHeaderExt(Dialog.Clean(source.ErrorDialog))
                        {
                            Alpha = 0f,
                            AlwaysCenter = true
                        };
                        menu.Add(item2);
                        items.Add(item2);
                        return;
                    }

                    if (source.Entries == null)
                    {
                        EverestMenuSubHeaderExt item3 =
                            new EverestMenuSubHeaderExt(Dialog.Clean("updater_versions_requesting"))
                            {
                                Alpha = 0f,
                                AlwaysCenter = true
                            };
                        menu.Add(item3);
                        items.Add(item3);
                        return;
                    }

                    int num = 0;
                    foreach (EverestUpdateEntry entry in source.Entries)
                    {
                        if (num >= buildsPerBranch)
                        {
                            continue;
                        }

                        num++;
                        EverestMenuButtonExt buttonExt = new EverestMenuButtonExt(entry.Name)
                        {
                            Alpha = 0f,
                            AlwaysCenter = true
                        };
                        menu.Add(buttonExt.Pressed(delegate
                        {
                            Updater.Update(EverestModOptionsState.Instance.Overworld.Goto<EverestLoggedProgressState>(),
                                entry);
                        }));
                        items.Add(buttonExt);
                        if (!string.IsNullOrWhiteSpace(entry.Description))
                        {
                            string text = entry.Description;
                            if (text.Length > 50)
                            {
                                text = text.Substring(0, 50) + "...";
                            }

                            EverestMenuSubHeaderExt item4 = new EverestMenuSubHeaderExt(text)
                            {
                                Alpha = 0f,
                                HeightExtra = 0f,
                                AlwaysCenter = true
                            };
                            menu.Add(item4);
                            items.Add(item4);
                        }
                    }
                }
            }
        }

        private IEnumerator FadeIn(int i, IEverestMenuItemExt item)
        {
            yield return 0.03f * (float)i;
            Vector2 offset = item.Offset;
            for (float p = 0f; p < 1f; p += engine.DeltaTime * 4f)
            {
                float num = (item.Alpha = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p));
                item.Offset = offset + new Vector2(0f, 64f * (1f - num));
                yield return null;
            }

            item.Alpha = 1f;
            item.Offset = offset;
        }

        private void ReloadMenu()
        {
            Vector2 position = Vector2.Zero;
            int num = -1;
            if (menu != null)
            {
                position = menu.Position;
                num = menu.Selection;
                ((ISourceScene)Scene).SourceScene.RemoveEntity(menu);
            }

            menu = CreateMenu(inGame: false, null);
            if (num >= 0)
            {
                menu.Selection = num;
                menu.Position = position;
            }

            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(menu);
        }

        public override IEnumerator Enter(OuiState from)
        {
            Visible = true;
            if (!(Updater._VersionListRequestTask?.IsCompleted ?? false))
            {
                waitingForRequest = true;
                alpha = 1f;
                while (!(Updater._VersionListRequestTask?.IsCompletedSuccessfully ?? false))
                {
                    if (Input.MenuCancel.Pressed)
                    {
                        Audio.Play("event:/ui/main/button_back");
                        Overworld.Goto<EverestModOptionsState>();
                        yield break;
                    }

                    yield return null;
                }

                waitingForRequest = false;
            }

            ReloadMenu();
            menu.Visible = true;
            menu.Focused = false;
            for (float p = 0f; p < 1f; p += engine.DeltaTime * 4f)
            {
                menu.X = 2880f + -1920f * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p);
                alpha = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p);
                yield return null;
            }

            menu.Focused = true;
        }

        public override IEnumerator Leave(OuiState next)
        {
            waitingForRequest = false;
            if (menu != null)
            {
                Audio.Play("event:/ui/main/whoosh_large_out");
                menu.Focused = false;
            }

            for (float p = 0f; p < 1f; p += engine.DeltaTime * 4f)
            {
                if (menu != null)
                {
                    menu.X = 960f + 1920f * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(p);
                }

                alpha = 1f - ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(p);
                yield return null;
            }

            if (menu != null)
            {
                TextMenuPresentation textMenu = menu;
                EverestVersionListState ouiVersionList = this;
                bool visible = false;
                ouiVersionList.Visible = false;
                textMenu.Visible = visible;
                menu.RemoveSelf();
                menu = null;
            }
        }

        public override void Update()
        {
            if (menu != null && menu.Focused && base.Selected && Input.MenuCancel.Pressed)
            {
                Audio.Play("event:/ui/main/button_back");
                base.Overworld.Goto<EverestModOptionsState>();
            }

            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            if (alpha > 0f)
            {
                SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f, PackedColor.Black * alpha * 0.4f);
            }

            if (waitingForRequest)
            {
                Task versionListRequestTask = Updater._VersionListRequestTask;
                if (versionListRequestTask == null || !versionListRequestTask.IsFaulted)
                {
                    ActiveFont.Draw(context, this, Dialog.Clean("updater_versions_wait_request"),
                        new Vector2(960f, 540f),
                        Vector2.One / 2f, Vector2.One * 1.2f, PackedColor.White);
                }
                else
                {
                    ActiveFont.Draw(context, this, Dialog.Clean("updater_versions_err_download"),
                        new Vector2(960f, 540f),
                        Vector2.One / 2f, Vector2.One * 1.2f, PackedColor.OrangeRed);
                }
            }

            base.Render(context);
        }
    }
}
