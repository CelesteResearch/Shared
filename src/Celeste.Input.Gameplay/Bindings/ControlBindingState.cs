using System;
using System.Collections.Generic;
using System.Linq;

namespace Celeste.Input.Gameplay.Bindings
{
    public sealed class ControlBindingState
    {
        public List<ControlBindingValue> Keyboard = new List<ControlBindingValue>();
        public List<ControlBindingValue> Controller = new List<ControlBindingValue>();
        public List<ControlBindingState> ExclusiveFrom = new List<ControlBindingState>();
        public bool HasInput => Keyboard.Count > 0 || Controller.Count > 0;
        private List<ControlBindingValue> Values(bool controller) => controller ? Controller : Keyboard;
        public bool AddKeyboard(params ControlBindingValue[] values) => Add(false, values);
        public bool AddController(params ControlBindingValue[] values) => Add(true, values);

        private bool Add(bool controller, ControlBindingValue[] values)
        {
            bool result = false;
            var list = Values(controller);
            foreach (var value in values)
            {
                if (list.Any(v => v.Code == value.Code)) continue;
                bool blocked = false;
                foreach (var other in ExclusiveFrom)
                    if (other.Needs(controller, value.Code))
                    {
                        blocked = true;
                        break;
                    }

                if (blocked) continue;
                list.Add(value);
                result = true;
            }

            return result;
        }

        public bool NeedsKeyboard(int code) => Needs(false, code);
        public bool NeedsController(int code) => Needs(true, code);

        private bool Needs(bool controller, int code)
        {
            var list = Values(controller);
            if (!list.Any(v => v.Code == code)) return false;
            if (list.Count <= 1) return true;
            if (!IsExclusive(controller, code)) return false;
            foreach (var value in list)
                if (value.Code != code && IsExclusive(controller, value.Code))
                    return false;
            return true;
        }

        public bool IsKeyboardExclusive(int code) => IsExclusive(false, code);
        public bool IsControllerExclusive(int code) => IsExclusive(true, code);

        private bool IsExclusive(bool controller, int code)
        {
            foreach (var other in ExclusiveFrom)
                if (other.Values(controller).Any(v => v.Code == code))
                    return false;
            return true;
        }

        public bool ClearKeyboard() => Clear(false);
        public bool ClearGamepad() => Clear(true);

        private bool Clear(bool controller)
        {
            var list = Values(controller);
            if (ExclusiveFrom.Count > 0)
            {
                if (list.Count <= 1) return false;
                int index = 0;
                for (int i = 1; i < list.Count; i++)
                    if (IsExclusive(controller, list[i].Code))
                        index = i;
                var keep = list[index];
                list.Clear();
                list.Add(keep);
            }
            else list.Clear();

            return true;
        }

        public static void SetExclusive(params ControlBindingState[] list)
        {
            foreach (var value in list) value.ExclusiveFrom.Clear();
            foreach (var value in list)
            foreach (var other in list)
                if (value != other)
                {
                    value.ExclusiveFrom.Add(other);
                    other.ExclusiveFrom.Add(value);
                }
        }
    }
}
