using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Input;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.UI.Menus.Text
{
    public readonly struct TextMenuBindingValue
    {
        public readonly int Code;
        public readonly string Name;

        public TextMenuBindingValue(int code, string name)
        {
            Code = code;
            Name = name;
        }

        public override int GetHashCode() => Code;
        public override string ToString() => Name;
    }
}
