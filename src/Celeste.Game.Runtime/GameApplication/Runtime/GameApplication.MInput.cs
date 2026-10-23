using Celeste.Input.Runtime;
using Celeste.Input.Devices.Mouse;
using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Devices.GamePads;
using Celeste.Input.Bindings;
using System;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceMInputEnvironment
    {
        private SourceMInputProcess sourceMInput;

        public SourceMInputProcess MInput => sourceMInput ??
                                             throw new InvalidOperationException(
                                                 "The actual MInput process has not been published.");

        public void ConstructSourceMInputProcess(ISourceMInputEngine actualGame,
            SourceFnaKeyboardStateProcess physicalKeyboard, SourceFnaMouse mouse, SourceFnaGamePadProcess gamePads)
        {
            if (sourceMInput != null) throw new InvalidOperationException("The actual MInput is already constructed.");
            ISourceMInputKeyboardConstruction keyboardConstruction;
            ISourceMInputMouseConstruction mouseConstruction;
            ISourceVirtualInputPolicy virtualInputs;
            switch (SourceProfile)
            {
                case global::Celeste.Game.Profiles.GameProfile.Original:
                    keyboardConstruction = new OriginalSourceMInputKeyboardConstruction();
                    mouseConstruction = new OriginalSourceMInputMouseConstruction();
                    virtualInputs = new OriginalSourceVirtualInputPolicy();
                    break;
                case global::Celeste.Game.Profiles.GameProfile.InstalledEverest:
                    keyboardConstruction =
                        new global::Celeste.Everest.Input.InstalledSourceMInputKeyboardConstruction();
                    mouseConstruction = new global::Celeste.Everest.Input.InstalledSourceMInputMouseConstruction();
                    virtualInputs = new global::Celeste.Everest.Input.InstalledSourceVirtualInputPolicy();
                    break;
                default:
                    throw new InvalidOperationException("The actual MInput source profile is invalid.");
            }

            InitializeSourceMInput(new SourceMInputProcess(actualGame, physicalKeyboard,
                mouse, gamePads, keyboardConstruction, virtualInputs, mouseConstruction));
        }

        private void InitializeSourceMInput(SourceMInputProcess actualProcess)
        {
            if (sourceMInput != null)
                throw new InvalidOperationException("The actual MInput process is already published.");
            sourceMInput = actualProcess ?? throw new ArgumentNullException(nameof(actualProcess));
        }
    }
}
