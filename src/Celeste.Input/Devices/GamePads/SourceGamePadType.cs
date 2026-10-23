using System.Numerics;
using Buttons = Celeste.Input.Devices.GamePads.SourceGamePadButtonFlags;
using ButtonState = Celeste.Input.Devices.GamePads.SourceButtonState;
using MathHelper = Celeste.Core.Mathematics.ScalarMath;
using GamePad = Celeste.Input.Devices.GamePads.SourceGamePadArithmetic;

namespace Celeste.Input.Devices.GamePads
{
    public enum SourceGamePadType
    {
        Unknown,
        GamePad,
        Wheel,
        ArcadeStick,
        FlightStick,
        DancePad,
        Guitar,
        AlternateGuitar,
        DrumKit,
        BigButtonPad
    }
}
