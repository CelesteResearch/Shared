using System.Numerics;
using Buttons = Celeste.Input.Devices.GamePads.SourceGamePadButtonFlags;
using ButtonState = Celeste.Input.Devices.GamePads.SourceButtonState;
using MathHelper = Celeste.Core.Mathematics.ScalarMath;
using GamePad = Celeste.Input.Devices.GamePads.SourceGamePadArithmetic;

namespace Celeste.Input.Devices.GamePads
{
    public enum SourceGamePadDeadZone
    {
        None,
        IndependentAxes,
        Circular
    }
}
