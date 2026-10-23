using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Celeste.Input.Gameplay.Bindings
{
    public struct ControlBindingValue
    {
        public int Code;
        public string Name;

        public ControlBindingValue(int code, string name)
        {
            Code = code;
            Name = name;
        }

        public override string ToString() => Name;
    }
}
