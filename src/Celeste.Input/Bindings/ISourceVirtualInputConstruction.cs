using Celeste.Input.Runtime;

namespace Celeste.Input.Bindings
{
    public interface ISourceVirtualInputConstruction
    {
        SourceVirtualButton CreateButton(SourceMInputProcess process, SourceInputBinding binding, int gamepadIndex,
            float bufferTime, float threshold);

        SourceVirtualIntegerAxis CreateIntegerAxis(SourceMInputProcess process, SourceInputBinding negative,
            SourceInputBinding positive, int gamepadIndex, float threshold);

        SourceVirtualIntegerAxis CreateIntegerAxis(SourceMInputProcess process, SourceInputBinding negative,
            SourceInputBinding negativeAlt, SourceInputBinding positive, SourceInputBinding positiveAlt,
            int gamepadIndex,
            float threshold);

        SourceVirtualJoystick CreateJoystick(SourceMInputProcess process, SourceInputBinding up,
            SourceInputBinding down,
            SourceInputBinding left, SourceInputBinding right, int gamepadIndex, float threshold);

        SourceVirtualJoystick CreateJoystick(SourceMInputProcess process, SourceInputBinding up,
            SourceInputBinding upAlt,
            SourceInputBinding down, SourceInputBinding downAlt, SourceInputBinding left, SourceInputBinding leftAlt,
            SourceInputBinding right, SourceInputBinding rightAlt, int gamepadIndex, float threshold);
    }
}
