using Celeste.Input.Devices.Keyboard;

namespace Celeste.Everest.Input
{
    public class SourceEverestKeyboardData : SourceKeyboardData
    {
        public SourceEverestKeyboardData(SourceFnaKeyboardStateProcess keyboard,
            ISourceKeyboardDisabledEnvironment environment) : base(keyboard, environment)
        {
        }

        public override bool Check(SourceKeys key) => key != SourceKeys.None && base.Check(key);
        public override bool Pressed(SourceKeys key) => key != SourceKeys.None && base.Pressed(key);
        public override bool Released(SourceKeys key) => key != SourceKeys.None && base.Released(key);
    }
}
