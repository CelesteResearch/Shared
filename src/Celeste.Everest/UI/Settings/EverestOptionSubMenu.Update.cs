using System;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Processes;
using Celeste.Scene.Tracking;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Everest.UI.Settings
{
    public partial class EverestOptionSubMenu
    {
        public override void Update()
        {
            MenuHeight = ScalarMath.Approach(MenuHeight, targetMenuHeight,
                ResourceSet.EngineContext.RawDeltaTime * Math.Abs(MenuHeight - targetMenuHeight) * 8f,
                ((ISourceExtremaEnvironment)ResourceSet.EngineContext).ExtremaArithmetic);
            sine += ResourceSet.EngineContext.RawDeltaTime;
            base.Update();
            if (CurrentMenu == null) return;

            if (Focused)
            {
                if (!wasFocused)
                {
                    wasFocused = true;
                }
                else
                {
                    if (((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource.MenuDown
                        .Pressed && (!((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource
                            .MenuDown.Repeating || Selection != LastPossibleSelection))
                        MoveSelection(1, true);
                    else if (((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource.MenuUp
                             .Pressed && (!((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource
                                 .MenuUp.Repeating || Selection != FirstPossibleSelection))
                        MoveSelection(-1, true);

                    if (Current != null)
                    {
                        if (((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource.MenuLeft
                            .Pressed)
                            Current.LeftPressed();

                        if (((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource.MenuRight
                            .Pressed)
                            Current.RightPressed();

                        if (((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource.MenuConfirm
                            .Pressed)
                        {
                            Current.ConfirmPressed();
                            Current.OnPressed?.Invoke();
                        }

                        if (((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource.MenuJournal
                            .Pressed && Current.OnAltPressed != null)
                            Current.OnAltPressed();
                    }

                    if (!((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource.MenuConfirm
                            .Pressed &&
                        (((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource.MenuCancel
                         .Pressed ||
                         ((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource.ESC.Pressed ||
                         ((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource.Pause
                         .Pressed))
                    {
                        Current?.OnLeave?.Invoke();
                        Focused = false;
                        ((IOriginalGameplayProcess)ResourceSet.EngineContext).AudioSession.Play(
                            "event:/ui/main/button_back");
                        Container.AutoScroll = containerAutoScroll;
                        Container.Focused = true;
                    }
                }
            }
            else
            {
                wasFocused = false;
            }

            foreach (var menu in Menus)
            foreach (var item in menu.Item2)
            {
                item.OnUpdate?.Invoke();
                item.Update();
            }

            if (!((ITextMenuProcessEnvironment)ResourceSet.EngineContext).AllowTextHighlight)
            {
                HighlightColor = TextMenuPresentation.HighlightColorA;
            }
            else if (((ISourceScene)ResourceSet.EngineContext.Frame.Scenes.CurrentScene).SourceScene.Clock
                     .OnRawInterval(0.1f, ResourceSet.EngineContext))
            {
                if (HighlightColor == TextMenuPresentation.HighlightColorA)
                    HighlightColor = TextMenuPresentation.HighlightColorB;
                else
                    HighlightColor = TextMenuPresentation.HighlightColorA;
            }

            if (Focused && containerAutoScroll)
            {
                if (Container.Height > Container.ScrollableMinSize)
                {
                    var menuPosition = Container.Position;
                    menuPosition.Y += (ScrollTargetY - Container.Position.Y) *
                                      (1f - (float)Math.Pow(0.009999999776482582,
                                          ResourceSet.EngineContext.RawDeltaTime));
                    Container.Position = menuPosition;
                }
                else
                {
                    var menuPosition = Container.Position;
                    menuPosition.Y = 540f;
                    Container.Position = menuPosition;
                }
            }
        }
    }
}
