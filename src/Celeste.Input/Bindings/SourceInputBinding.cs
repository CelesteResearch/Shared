using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Celeste.Input.Runtime;
using Keys = Celeste.Input.Devices.Keyboard.SourceKeys;
using Buttons = Celeste.Input.Devices.GamePads.SourceGamePadButtonFlags;

namespace Celeste.Input.Bindings
{
    [Serializable]
    public class SourceInputBinding
    {
        public List<Keys> Keyboard = [];

        public List<Buttons> Controller = [];

        [XmlIgnore] public List<SourceInputBinding> ExclusiveFrom = [];

        public virtual bool HasInput
        {
            get
            {
                if (Keyboard.Count <= 0) return Controller.Count > 0;

                return true;
            }
        }

        public bool Add(params Keys[] keys)
        {
            var result = false;
            foreach (var keys2 in keys)
            {
                if (Keyboard.Contains(keys2)) continue;

                foreach (var item in ExclusiveFrom)
                {
                    if (!item.Needs(keys2)) continue;

                    goto IL_0061;
                }

                Keyboard.Add(keys2);
                result = true;
                IL_0061: ;
            }

            return result;
        }

        public bool Add(params Buttons[] buttons)
        {
            var result = false;
            foreach (var buttons2 in buttons)
            {
                if (Controller.Contains(buttons2)) continue;

                foreach (var item in ExclusiveFrom)
                {
                    if (!item.Needs(buttons2)) continue;

                    goto IL_0061;
                }

                Controller.Add(buttons2);
                result = true;
                IL_0061: ;
            }

            return result;
        }

        public bool Needs(Buttons button)
        {
            if (Controller.Contains(button))
            {
                if (Controller.Count <= 1) return true;

                if (!IsExclusive(button)) return false;

                foreach (var item in Controller)
                    if (item != button && IsExclusive(item))
                        return false;

                return true;
            }

            return false;
        }

        public bool Needs(Keys key)
        {
            if (Keyboard.Contains(key))
            {
                if (Keyboard.Count <= 1) return true;

                if (!IsExclusive(key)) return false;

                foreach (var item in Keyboard)
                    if (item != key && IsExclusive(item))
                        return false;

                return true;
            }

            return false;
        }

        public bool IsExclusive(Buttons button)
        {
            foreach (var item in ExclusiveFrom)
                if (item.Controller.Contains(button))
                    return false;

            return true;
        }

        public bool IsExclusive(Keys key)
        {
            foreach (var item in ExclusiveFrom)
                if (item.Keyboard.Contains(key))
                    return false;

            return true;
        }

        public bool ClearKeyboard()
        {
            if (ExclusiveFrom.Count > 0)
            {
                if (Keyboard.Count <= 1) return false;

                var index = 0;
                for (var i = 1; i < Keyboard.Count; i++)
                    if (IsExclusive(Keyboard[i]))
                        index = i;

                var item = Keyboard[index];
                Keyboard.Clear();
                Keyboard.Add(item);
            }
            else
            {
                Keyboard.Clear();
            }

            return true;
        }

        public bool ClearGamepad()
        {
            if (ExclusiveFrom.Count > 0)
            {
                if (Controller.Count <= 1) return false;

                var index = 0;
                for (var i = 1; i < Controller.Count; i++)
                    if (IsExclusive(Controller[i]))
                        index = i;

                var item = Controller[index];
                Controller.Clear();
                Controller.Add(item);
            }
            else
            {
                Controller.Clear();
            }

            return true;
        }

        public virtual float Axis(SourceMInputProcess process, int gamepadIndex, float threshold)
        {
            foreach (var item in Keyboard)
                if (process.Keyboard.Check(item))
                    return 1f;

            foreach (var item2 in Controller)
            {
                var num = process.GamePads[gamepadIndex].Axis(item2, threshold);
                if (num != 0f) return num;
            }

            return 0f;
        }

        public virtual bool Check(SourceMInputProcess process, int gamepadIndex, float threshold)
        {
            for (var i = 0; i < Keyboard.Count; i++)
                if (process.Keyboard.Check(Keyboard[i]))
                    return true;

            for (var j = 0; j < Controller.Count; j++)
                if (process.GamePads[gamepadIndex].Check(Controller[j], threshold))
                    return true;

            return false;
        }

        public virtual bool Pressed(SourceMInputProcess process, int gamepadIndex, float threshold)
        {
            for (var i = 0; i < Keyboard.Count; i++)
                if (process.Keyboard.Pressed(Keyboard[i]))
                    return true;

            for (var j = 0; j < Controller.Count; j++)
                if (process.GamePads[gamepadIndex].Pressed(Controller[j], threshold))
                    return true;

            return false;
        }

        public virtual bool Released(SourceMInputProcess process, int gamepadIndex, float threshold)
        {
            for (var i = 0; i < Keyboard.Count; i++)
                if (process.Keyboard.Released(Keyboard[i]))
                    return true;

            for (var j = 0; j < Controller.Count; j++)
                if (process.GamePads[gamepadIndex].Released(Controller[j], threshold))
                    return true;

            return false;
        }

        public static void SetExclusive(params SourceInputBinding[] list)
        {
            var array = list;
            for (var i = 0; i < array.Length; i++) array[i].ExclusiveFrom.Clear();

            array = list;
            foreach (var binding in array)
            foreach (var binding2 in list)
                if (binding != binding2)
                {
                    binding.ExclusiveFrom.Add(binding2);
                    binding2.ExclusiveFrom.Add(binding);
                }
        }
    }
}
