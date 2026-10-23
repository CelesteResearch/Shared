using System;
using Celeste.Game.Execution.Processes;

namespace Celeste.Everest.UI.Settings
{
    public partial class EverestOptionSubMenu
    {
        /// <inheritdoc cref="M:Celeste.Simulation.UI.Menus.Text.TextMenuPresentation.FirstSelection" />
        public void FirstSelection()
        {
            Selection = -1;
            if (CurrentMenu.Count > 0) MoveSelection(1, true);
        }

        /// <inheritdoc cref="M:Celeste.Simulation.UI.Menus.Text.TextMenuPresentation.MoveSelection(System.Int32,System.Boolean)" />
        public void MoveSelection(int direction, bool wiggle = false)
        {
            var selection = Selection;
            direction = Math.Sign(direction);
            var num = 0;
            foreach (var item in CurrentMenu)
                if (item.Hoverable)
                    num++;

            do
            {
                Selection += direction;
                if (num > 2)
                {
                    if (Selection < 0)
                        Selection = CurrentMenu.Count - 1;
                    else if (Selection >= CurrentMenu.Count) Selection = 0;
                }
                else if (Selection < 0 || Selection > CurrentMenu.Count - 1)
                {
                    Selection = Math.Min(Math.Max(Selection, 0), CurrentMenu.Count - 1);
                    break;
                }
            } while (!Current.Hoverable);

            if (!Current.Hoverable) Selection = selection;

            if (Selection != selection && Current != null)
            {
                if (selection >= 0 && CurrentMenu[selection] != null && CurrentMenu[selection].OnLeave != null)
                    CurrentMenu[selection].OnLeave();

                Current.OnEnter?.Invoke();
                if (wiggle)
                {
                    ((IOriginalGameplayProcess)ResourceSet.EngineContext).AudioSession.Play(direction > 0
                        ? "event:/ui/main/rollover_down"
                        : "event:/ui/main/rollover_up");
                    Current.SelectWiggler.Start();
                }
            }
        }

        public override void LeftPressed()
        {
            if (!(MenuIndex > 0))
                return;
            ((IOriginalGameplayProcess)ResourceSet.EngineContext).AudioSession.Play(
                "event:/ui/main/button_toggle_off");
            MenuIndex--;
            lastDir = -1;
            ValueWiggler.Start();
            FirstSelection();
            OnValueChange?.Invoke(MenuIndex);
        }

        public override void RightPressed()
        {
            if (MenuIndex < Menus.Count - 1)
            {
                ((IOriginalGameplayProcess)ResourceSet.EngineContext).AudioSession.Play(
                    "event:/ui/main/button_toggle_on");
                MenuIndex++;
                lastDir = 1;
                ValueWiggler.Start();
                FirstSelection();
                OnValueChange?.Invoke(MenuIndex);
            }
        }

        public override void ConfirmPressed()
        {
            if (!(CurrentMenu.Count > 0))
                return;
            containerAutoScroll = Container.AutoScroll;
            Container.AutoScroll = false;
            Container.Focused = false;
            Focused = true;
            FirstSelection();
        }
    }
}
