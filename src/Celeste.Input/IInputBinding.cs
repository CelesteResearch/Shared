using System;
using System.Numerics;

namespace Celeste.Input
{
    // Bindings expose physical edges independently: pressing a second bound key is still a press.
    public interface IInputBinding
    {
        bool Check(int gamepadIndex, float threshold);
        bool Pressed(int gamepadIndex, float threshold);
        bool Released(int gamepadIndex, float threshold);
        float Axis(int gamepadIndex, float threshold);
    }
}
