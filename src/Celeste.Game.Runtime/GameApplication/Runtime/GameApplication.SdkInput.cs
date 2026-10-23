using System;
using Celeste.Everest.Input;
using Celeste.Game.Profiles;
using Celeste.Input.Devices.GamePads;
using Celeste.Input.Devices.Keyboard;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceFnaGamePadEnvironment,
        ISourceSDLGamePadLog, ISourceGamePadEnvironmentDevice, ISourceFnaKeyboardStateEnvironment
    {
        private SourceFnaKeyboardStateProcess sourceKeyboardState;
        private SourceFnaGamePadProcess sourceFnaGamePads;

        public SourceFnaKeyboardStateProcess KeyboardState => sourceKeyboardState ??
                                                              throw new InvalidOperationException(
                                                                  "The actual SDK keyboard state is not constructed.");

        public SourceFnaGamePadProcess FnaGamePads => sourceFnaGamePads ??
                                                      throw new InvalidOperationException(
                                                          "The actual SDK game pad process is not constructed.");

        public void ConstructSourceKeyboardAndGamePads()
        {
            if (sourceKeyboardState != null)
                throw new InvalidOperationException(
                    "The actual SDK keyboard/game pad processes are already constructed.");
            sourceKeyboardState = SourceProfile == GameProfile.Original
                ? new SourceFnaKeyboardStateProcess(PhysicalIO.Keyboard)
                : new SourceEverestKeyboardStateProcess(PhysicalIO.Keyboard);
            sourceFnaGamePads = new(PhysicalIO.GamePads, this, this, VectorArithmetic);
        }

        void ISourceSDLGamePadLog.LogInfo(string message)
        {
            FnaLogger.LogInfo(message);
        }

        string ISourceGamePadEnvironmentDevice.GetEnvironmentVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name);
        }

        public void ConstructSourceMInputForActualGame()
        {
            ConstructSourceMInputProcess(ActualGame, KeyboardState, FnaInput.Mouse, FnaGamePads);
        }
    }
}
