using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Audio.Fmod.Events;
using Celeste.Core.Display;
using Celeste.Core.Lifecycle;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Modules.Updating;
using Celeste.Everest.Runtime.Startup;
using Celeste.Everest.UI.ModOptions;
using Celeste.Everest.UI.Progress;
using Celeste.Everest.UI.Settings;
using Celeste.Everest.UI.Text;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Menus.Overworld;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text;
using Celeste.Localization.Lookup;
using Celeste.Scene.Tracking;
using Celeste.Simulation.UI.Menus.Text;

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

        private readonly List<IEverestMenuItemExt> items = [];

        private readonly int buildsPerBranch = 12;

        public TextMenuPresentation CreateMenu(bool inGame, FmodEventReference snapshot)
        {
            menu = new(engine)
            {
                CompactWidthMode = true,
            };
            items.Clear();
            menu.Add(new TextMenuPresentation.Header(Dialog.Clean("updater_versions_title")));
            menu.Add(new TextMenuPresentation.SubHeader(Dialog.Clean("updater_versions_current")
                .Replace("((version))", Runtime.BuildString)));
            var option =
                new TextMenuPresentation.Option<EverestUpdateSource>(Dialog.Clean("UPDATER_CURRENT_BRANCH"));
            menu.Add(option);
            currentBranchName = new EverestMenuSubHeaderExt("")
            {
                HeightExtra = 0f,
            };
            menu.Add(currentBranchName);
            EverestUpdateSource source = null;
            foreach (var source2 in Updater.Sources)
                if ((source2.Entries?.Count ?? 0) > 0 || !string.IsNullOrWhiteSpace(source2.ErrorDialog))
                {
                    option.Add(SourceDialogTextLookup.CleanOrNull(Dialog, source2.Name) ?? source2.Name, source2,
                        source2.Name == Settings.CurrentBranch);
                    if (source2.Name == Settings.CurrentBranch) source = source2;
                }

            option.Change(ReloadItems);
            if (source != null)
                ReloadItems(source);
            else if (option.Values.Count > 0) ReloadItems(option.Values[0].Item2);

            return menu;
        }

        private void ReloadItems(EverestUpdateSource source)
        {
            using (new SourceScopeFinalizer(delegate
                   {
                       for (var i = 0; i < items.Count; i++)
                           OwnedComponents.Add(new SimulationCoroutine(engine, FadeIn(i, items[i])));

                       if (menu.Height > menu.ScrollableMinSize)
                       {
                           var scrollPosition = menu.Position;
                           scrollPosition.Y = menu.ScrollTargetY;
                           menu.Position = scrollPosition;
                       }
                   }))
            {
                using (new EverestMenuBatchModeContext(menu))
                {
                    foreach (TextMenuPresentation.Item item5 in items) menu.Remove(item5);

                    items.Clear();
                    currentBranchName.Title =
                        SourceDialogTextLookup.CleanOrNull(Dialog, source.Description) ?? source.Description;
                    if (source.ErrorDialog != null)
                    {
                        var item2 = new EverestMenuSubHeaderExt(Dialog.Clean(source.ErrorDialog))
                        {
                            Alpha = 0f,
                            AlwaysCenter = true,
                        };
                        menu.Add(item2);
                        items.Add(item2);
                        return;
                    }

                    if (source.Entries == null)
                    {
                        var item3 =
                            new EverestMenuSubHeaderExt(Dialog.Clean("updater_versions_requesting"))
                            {
                                Alpha = 0f,
                                AlwaysCenter = true,
                            };
                        menu.Add(item3);
                        items.Add(item3);
                        return;
                    }

                    var num = 0;
                    foreach (var entry in source.Entries)
                    {
                        if (num >= buildsPerBranch) continue;

                        num++;
                        var buttonExt = new EverestMenuButtonExt(entry.Name)
                        {
                            Alpha = 0f,
                            AlwaysCenter = true,
                        };
                        menu.Add(buttonExt.Pressed(delegate
                        {
                            Updater.Update(EverestModOptionsState.Instance.Overworld.Goto<EverestLoggedProgressState>(),
                                entry);
                        }));
                        items.Add(buttonExt);
                        if (!string.IsNullOrWhiteSpace(entry.Description))
                        {
                            var text = entry.Description;
                            if (text.Length > 50) text = text.Substring(0, 50) + "...";

                            var item4 = new EverestMenuSubHeaderExt(text)
                            {
                                Alpha = 0f,
                                HeightExtra = 0f,
                                AlwaysCenter = true,
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
            yield return 0.03f * i;
            var offset = item.Offset;
            for (var p = 0f; p < 1f; p += engine.DeltaTime * 4f)
            {
                var num = item.Alpha = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p);
                item.Offset = offset + new Vector2(0f, 64f * (1f - num));
                yield return null;
            }

            item.Alpha = 1f;
            item.Offset = offset;
        }

        private void ReloadMenu()
        {
            var position = Vector2.Zero;
            var num = -1;
            if (menu != null)
            {
                position = menu.Position;
                num = menu.Selection;
                ((ISourceScene)Scene).SourceScene.RemoveEntity(menu);
            }

            menu = CreateMenu(false, null);
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
            for (var p = 0f; p < 1f; p += engine.DeltaTime * 4f)
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

            for (var p = 0f; p < 1f; p += engine.DeltaTime * 4f)
            {
                if (menu != null) menu.X = 960f + 1920f * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(p);

                alpha = 1f - ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(p);
                yield return null;
            }

            if (menu != null)
            {
                var textMenu = menu;
                var ouiVersionList = this;
                var visible = false;
                ouiVersionList.Visible = false;
                textMenu.Visible = visible;
                menu.RemoveSelf();
                menu = null;
            }
        }

        public override void Update()
        {
            if (menu != null && menu.Focused && Selected && Input.MenuCancel.Pressed)
            {
                Audio.Play("event:/ui/main/button_back");
                Overworld.Goto<EverestModOptionsState>();
            }

            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            if (alpha > 0f)
                SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f, PackedColor.Black * alpha * 0.4f);

            if (waitingForRequest)
            {
                var versionListRequestTask = Updater._VersionListRequestTask;
                if (versionListRequestTask == null || !versionListRequestTask.IsFaulted)
                    ActiveFont.Draw(context, this, Dialog.Clean("updater_versions_wait_request"),
                        new(960f, 540f),
                        Vector2.One / 2f, Vector2.One * 1.2f, PackedColor.White);
                else
                    ActiveFont.Draw(context, this, Dialog.Clean("updater_versions_err_download"),
                        new(960f, 540f),
                        Vector2.One / 2f, Vector2.One * 1.2f, PackedColor.OrangeRed);
            }

            base.Render(context);
        }
    }
}
