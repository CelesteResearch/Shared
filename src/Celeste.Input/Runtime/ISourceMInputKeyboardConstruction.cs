using Celeste.Input.Devices.Keyboard;

namespace Celeste.Input.Runtime
{
    public interface ISourceMInputKeyboardConstruction
    {
        SourceKeyboardData CreateKeyboard(SourceFnaKeyboardStateProcess physical,
            ISourceKeyboardDisabledEnvironment disabled);
    }
}
