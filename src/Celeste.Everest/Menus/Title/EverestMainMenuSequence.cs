using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Core;
using Celeste.Everest.Runtime.Events;
using Celeste.Everest.UI.Menus.Buttons;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Menus.Chapters;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Menus.Title;
using Celeste.Game.UI.Menus.Buttons;
using Celeste.Game.UI.Menus.Buttons.Title;
using Celeste.Scene.Scenes;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Everest.Menus.Title
{
    public class EverestMainMenuSequence : MainMenuSequence
    {
        private bool needsRebuild;
        private float regularButtonOffset;
        public List<MenuButtonPresentation> Buttons => buttons;

        public EverestMainMenuSequence(ISourceEngineContext engine) : base(engine)
        {
        }

        public override void CreateButtons()
        {
            base.CreateButtons();
            regularButtonOffset = buttons[1].ButtonHeight;
            ((IEverestGameEventsEnvironment)EngineContext).GameEvents.CreateButtons(this, buttons);
            UpdateLayout();
        }

        public override void Update()
        {
            if (needsRebuild)
            {
                RebuildMainAndTitle();
                needsRebuild = false;
            }

            if (SourceCoreModule.Settings.MainMenuMode == "") ScrollButtons();

            base.Update();
        }

        protected override void OnDebug()
        {
            Audio.Play("event:/ui/main/whoosh_list_out");
            Audio.Play("event:/ui/main/button_select");
            InitializeDebugMode(true);
            if (((IOriginalGameplayProcess)EngineContext).SaveContext.CurrentSave.CurrentSessionSafe != null &&
                ((IOriginalGameplayProcess)EngineContext).SaveContext.CurrentSave.CurrentSessionSafe.InArea)
            {
                Audio.ChannelOutput.SetMusic(null);
                Audio.ChannelOutput.SetAmbience(null);
                Overworld.ShowInputUI = false;
                Focused = false;
                new FadeWipePresentation((SourceSceneState)Scene, false,
                    delegate
                    {
                        OriginalLevelEntryRouting.Go(
                            ((IOriginalGameplayProcess)EngineContext).SaveContext.CurrentSave.CurrentSessionSafe, true,
                            EngineContext.Frame.Scenes, ((IOriginalLevelEntryEnvironment)EngineContext).LevelEntries);
                    });
            }
            else
            {
                Overworld.Goto<ChapterSelectSequence>();
            }
        }

        public override PackedColor SelectionColor
        {
            get
            {
                if (SourceCoreModule.Settings.AllowTextHighlight && !((SourceSceneState)Scene).BetweenInterval(0.1f))
                    return MenuButtonPresentation.HighlightColorB;

                return MenuButtonPresentation.HighlightColorA;
            }
        }

        public void NeedsRebuild()
        {
            needsRebuild = true;
        }

        private void ScrollButtons()
        {
            var num = 0;
            for (var i = 0; i < buttons.Count; i++)
                if (buttons[i].Selected)
                {
                    num = i;
                    break;
                }

            var num2 = Math.Max(0, num - 6) * regularButtonOffset;
            var num3 = 160f;
            foreach (var button in buttons)
            {
                var num4 = num3 - num2;
                num3 += button.ButtonHeight;
                var position = button.Position;
                position.Y += (num4 - position.Y) * (1f - (float)Math.Pow(0.01, EngineContext.DeltaTime));
                button.Position = position;
            }
        }

        private void RebuildMainAndTitle()
        {
            var overworld = Overworld;
            overworld.UIs.Remove(overworld.GetUI<TitleScreenSequence>());
            OuiState oui = new EverestTitleScreenSequence(EngineContext)
            {
                Visible = false,
            };
            oui.IsStart(overworld, OverworldStartMode.MainMenu);
            overworld.SourceScene.QueueSourceEntity(oui);
            overworld.UIs.Add(oui);
            MenuButtonPresentation menuButton = null;
            foreach (var button in buttons)
                if (button.Selected)
                {
                    menuButton = button;
                    break;
                }

            CreateButtons();
            if (menuButton is MainMenuClimbPresentation)
            {
                foreach (var button2 in buttons) button2.SetSelected(button2 is MainMenuClimbPresentation);

                return;
            }

            var text = (menuButton as MainMenuSmallButtonPresentation)?.LabelName;
            foreach (var button3 in buttons)
                button3.SetSelected((button3 as MainMenuSmallButtonPresentation)?.LabelName == text);
        }

        public void UpdateLayout()
        {
            UpdateLayout(SourceCoreModule.Settings.MainMenuMode);
        }

        public void UpdateLayout(string mode)
        {
            foreach (var button in buttons)
                button.UpButton = button.DownButton = button.LeftButton = button.RightButton = null;

            if (mode == "rows")
            {
                var num = Math.Max(3, buttons.Count / 2);
                var vector = new Vector2(600f, 80f);
                var vector2 = new Vector2(0f, 640f);
                var vector3 = new Vector2(140f, 700f) - new Vector2(0f, (num - 3) * vector.Y);
                var array = new List<MenuButtonPresentation>[num];
                for (var i = 0; i < array.Length; i++) array[i] = [];

                var list = new List<MenuButtonPresentation>(buttons);
                var num2 = findButtonIndex("menu_debug", "menu/options");
                var num3 = findButtonIndex("menu_credits", "menu/credits");
                if (num2 != -1 && num3 != -1)
                {
                    var item = list[num2];
                    list.RemoveAt(num2);
                    if (num3 > num2) num3--;

                    list.Insert(num3, item);
                }

                var num4 = 0;
                var num5 = 0;
                for (var j = 0; j < list.Count; j++)
                {
                    var menuButton = list[j];
                    var vector4 = vector3 + vector * new Vector2(num4, num5);
                    var num6 = 1;
                    var num7 = 1;
                    if (menuButton == climbButton)
                    {
                        vector4.X += 140f;
                        vector4.Y += (num - 3) * vector.Y / 2f - 30f;
                        num7 = num;
                    }

                    for (var k = num5; k < num5 + num7 && k < array.Length; k++)
                    for (var l = 0; l < num6; l++)
                        array[k].Add(menuButton);

                    num5 += num7;
                    if (num5 >= array.Length)
                    {
                        num4++;
                        num5 = 0;
                    }

                    menuButton.TargetPosition = vector4;
                    menuButton.Position = menuButton.TweenFrom = vector4 + vector2;
                    if (Visible && Focused) menuButton.Position = menuButton.TargetPosition;

                    if (!((SourceSceneState)Scene).SourceScene.Entities.Contains(menuButton))
                        ((SourceSceneState)Scene).SourceScene.QueueSourceEntity(menuButton);
                }

                for (var m = 0; m < array.Length; m++)
                {
                    var list2 = array[m];
                    var num8 = m > 0 ? m - 1 : array.Length - 1;
                    var list3 = array[num8];
                    var list4 = m < array.Length - 1 ? array[m + 1] : array[0];
                    for (var n = 0; n < list2.Count; n++)
                    {
                        while (list3.Count <= n)
                        {
                            num8--;
                            if (num8 < 0) num8 += array.Length;

                            list3 = array[num8];
                        }

                        var menuButton2 = list2[n];
                        menuButton2.LeftButton =
                            menuButton2.LeftButton ?? (n > 0 ? list2[n - 1] : list2[list2.Count - 1]);
                        menuButton2.RightButton =
                            menuButton2.RightButton ?? (n < list2.Count - 1 ? list2[n + 1] : list2[0]);
                        menuButton2.UpButton = menuButton2.UpButton ?? list3[n < list3.Count ? n : list3.Count - 1];
                        menuButton2.DownButton =
                            menuButton2.DownButton ?? list4[n < list4.Count ? n : list4.Count - 1];
                        if (m != array.Length - 1 && menuButton2 is MainMenuModOptionsButton mainMenuModOptionsButton)
                            mainMenuModOptionsButton.SmallSubTextSpacing = true;
                    }
                }

                return;
            }

            var vector5 = new Vector2(320f, 160f);
            var vector6 = new Vector2(-850f, 0f);
            for (var num9 = 0; num9 < buttons.Count; num9++)
            {
                var menuButton3 = buttons[num9];
                menuButton3.UpButton =
                    menuButton3.UpButton ?? (num9 > 0 ? buttons[num9 - 1] : buttons[buttons.Count - 1]);
                menuButton3.DownButton =
                    menuButton3.DownButton ?? (num9 < buttons.Count - 1 ? buttons[num9 + 1] : buttons[0]);
                menuButton3.TargetPosition = vector5;
                menuButton3.Position = menuButton3.TweenFrom = vector5 + vector6;
                if (Visible && Focused) menuButton3.Position = menuButton3.TargetPosition;

                vector5 += Vector2.UnitY * menuButton3.ButtonHeight;
                if (menuButton3 == climbButton) vector5.X -= 140f;

                if (!((SourceSceneState)Scene).SourceScene.Entities.Contains(menuButton3))
                    ((SourceSceneState)Scene).SourceScene.QueueSourceEntity(menuButton3);
            }
        }

        private int findButtonIndex(string labelName, string iconName)
        {
            return buttons.FindIndex(delegate(MenuButtonPresentation _)
            {
                if (!(_ is MainMenuSmallButtonPresentation mainMenuSmallButton)) return false;

                return mainMenuSmallButton.LabelName == labelName && mainMenuSmallButton.IconName == iconName;
            });
        }
    }
}
