using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Devices.GamePads;
using System;
using Celeste.Game.Profiles;

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
                : new Celeste.Everest.Input.SourceEverestKeyboardStateProcess(PhysicalIO.Keyboard);
            sourceFnaGamePads = new SourceFnaGamePadProcess(PhysicalIO.GamePads, this, this, VectorArithmetic);
        }

        void ISourceSDLGamePadLog.LogInfo(string message) => FnaLogger.LogInfo(message);

        string ISourceGamePadEnvironmentDevice.GetEnvironmentVariable(string name) =>
            Environment.GetEnvironmentVariable(name);

        public void ConstructSourceMInputForActualGame()
            => ConstructSourceMInputProcess(ActualGame, KeyboardState, FnaInput.Mouse, FnaGamePads);
    }
}
