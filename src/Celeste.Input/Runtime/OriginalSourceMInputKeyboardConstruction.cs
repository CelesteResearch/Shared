using Celeste.Input.Devices.Keyboard;

namespace Celeste.Input.Runtime
{
    public sealed class OriginalSourceMInputKeyboardConstruction : ISourceMInputKeyboardConstruction
    {
        public SourceKeyboardData CreateKeyboard(SourceFnaKeyboardStateProcess physical,
            ISourceKeyboardDisabledEnvironment disabled)
        {
            return new(physical, disabled);
        }
    }
}
