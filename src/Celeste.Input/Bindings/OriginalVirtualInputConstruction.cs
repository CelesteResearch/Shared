using Celeste.Input.Runtime;

namespace Celeste.Input.Bindings
{
    public sealed class OriginalVirtualInputConstruction : ISourceVirtualInputConstruction
    {
        public SourceVirtualButton CreateButton(SourceMInputProcess process, SourceInputBinding binding,
            int gamepadIndex,
            float bufferTime, float threshold) =>
            new SourceVirtualButton(process, binding, gamepadIndex, bufferTime, threshold);

        public SourceVirtualIntegerAxis CreateIntegerAxis(SourceMInputProcess process, SourceInputBinding negative,
            SourceInputBinding positive, int gamepadIndex, float threshold) =>
            new SourceVirtualIntegerAxis(process, negative, positive, gamepadIndex, threshold);

        public SourceVirtualIntegerAxis CreateIntegerAxis(SourceMInputProcess process, SourceInputBinding negative,
            SourceInputBinding negativeAlt, SourceInputBinding positive, SourceInputBinding positiveAlt,
            int gamepadIndex,
            float threshold) => new SourceVirtualIntegerAxis(process, negative, negativeAlt, positive, positiveAlt,
            gamepadIndex, threshold);

        public SourceVirtualJoystick CreateJoystick(SourceMInputProcess process, SourceInputBinding up,
            SourceInputBinding down, SourceInputBinding left, SourceInputBinding right, int gamepadIndex,
            float threshold) => new SourceVirtualJoystick(process, up, down, left, right, gamepadIndex, threshold);

        public SourceVirtualJoystick CreateJoystick(SourceMInputProcess process, SourceInputBinding up,
            SourceInputBinding upAlt, SourceInputBinding down, SourceInputBinding downAlt, SourceInputBinding left,
            SourceInputBinding leftAlt, SourceInputBinding right, SourceInputBinding rightAlt, int gamepadIndex,
            float threshold) => new SourceVirtualJoystick(process, up, upAlt, down, downAlt, left, leftAlt, right,
            rightAlt,
            gamepadIndex, threshold);
    }
}
