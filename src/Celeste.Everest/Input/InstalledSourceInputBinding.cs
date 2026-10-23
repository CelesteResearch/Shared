using Celeste.Input.Runtime;
using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Devices.GamePads;
using Celeste.Input.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using Keys = Celeste.Input.Devices.Keyboard.SourceKeys;
using Buttons = Celeste.Input.Devices.GamePads.SourceGamePadButtonFlags;
using MouseButtons = Celeste.Everest.Input.SourceEverestMouseData.MouseButtons;

namespace Celeste.Everest.Input
{
    [Serializable]
    public class InstalledSourceInputBinding : SourceInputBinding
    {
        public List<MouseButtons> Mouse;

        public InstalledSourceInputBinding()
        {
            Mouse = new List<MouseButtons>();
        }

        public override bool HasInput => Keyboard.Count > 0 || Controller.Count > 0 || Mouse.Count > 0;

        public bool Add(params MouseButtons[] buttons)
        {
            bool result = false;
            foreach (MouseButtons button in buttons)
            {
                if (!Mouse.Contains(button) &&
                    ExclusiveFrom.TrueForAll(binding => !((InstalledSourceInputBinding)binding).Needs(button)))
                {
                    Mouse.Add(button);
                    result = true;
                }
            }

            return result;
        }

        public bool Needs(MouseButtons button)
        {
            if (Mouse.Contains(button))
            {
                if (Keyboard.Count + Mouse.Count <= 1) return true;
                if (!IsExclusive(button)) return false;
                foreach (MouseButtons item in Mouse)
                    if (item != button && IsExclusive(item))
                        return false;
                return true;
            }

            return false;
        }

        public bool IsExclusive(MouseButtons button)
        {
            foreach (SourceInputBinding original in ExclusiveFrom)
                if (((InstalledSourceInputBinding)original).Mouse.Contains(button))
                    return false;
            return true;
        }

        public bool ClearMouse()
        {
            int count = Mouse.Count;
            Mouse.Clear();
            return count > 0;
        }

        public override float Axis(SourceMInputProcess process, int gamepadIndex, float threshold)
        {
            float value = base.Axis(process, gamepadIndex, threshold);
            if (value == 0f)
                for (int i = 0; i < Mouse.Count; i++)
                    if (((SourceEverestMouseData)process.Mouse).Check(Mouse[i]))
                        return 1f;
            return value;
        }

        public override bool Check(SourceMInputProcess process, int gamepadIndex, float threshold)
        {
            if (base.Check(process, gamepadIndex, threshold)) return true;
            for (int i = 0; i < Mouse.Count; i++)
                if (((SourceEverestMouseData)process.Mouse).Check(Mouse[i]))
                    return true;
            return false;
        }

        public override bool Pressed(SourceMInputProcess process, int gamepadIndex, float threshold)
        {
            if (base.Pressed(process, gamepadIndex, threshold)) return true;
            for (int i = 0; i < Mouse.Count; i++)
                if (((SourceEverestMouseData)process.Mouse).Pressed(Mouse[i]))
                    return true;
            return false;
        }

        public override bool Released(SourceMInputProcess process, int gamepadIndex, float threshold)
        {
            if (base.Released(process, gamepadIndex, threshold)) return true;
            for (int i = 0; i < Mouse.Count; i++)
                if (((SourceEverestMouseData)process.Mouse).Released(Mouse[i]))
                    return true;
            return false;
        }

        public bool Remove(params Keys[] keys)
        {
            var old = new List<Keys>(Keyboard);
            var remaining = Keyboard.Where(value => !keys.Contains(value)).ToList();
            if (remaining.Count == 0 && ExclusiveFrom.Count > 0) return false;
            Keyboard = remaining;
            bool allowed = true;
            foreach (Keys value in remaining)
            {
                if (ExclusiveFrom.Any(binding => binding.Needs(value)))
                {
                    allowed = false;
                    break;
                }
            }

            Keyboard = allowed ? remaining : old;
            return allowed;
        }

        public bool Remove(params Buttons[] buttons)
        {
            var old = new List<Buttons>(Controller);
            var remaining = Controller.Where(value => !buttons.Contains(value)).ToList();
            if (remaining.Count == 0 && ExclusiveFrom.Count > 0) return false;
            Controller = remaining;
            bool allowed = true;
            foreach (Buttons value in remaining)
            {
                if (ExclusiveFrom.Any(binding => binding.Needs(value)))
                {
                    allowed = false;
                    break;
                }
            }

            Controller = allowed ? remaining : old;
            return allowed;
        }
    }
}
