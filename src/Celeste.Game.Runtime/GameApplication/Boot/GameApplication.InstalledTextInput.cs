using System;
using Celeste.Everest.Runtime.Input;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IEverestTextInputEnvironment
    {
        private EverestTextInputProcess sourceInstalledTextInput;
        EverestTextInputProcess IEverestTextInputEnvironment.TextInput => InstalledTextInput;

        public EverestTextInputProcess InstalledTextInput => sourceInstalledTextInput ??
                                                             throw new InvalidOperationException(
                                                                 "The actual installed text input process is not constructed.");

        internal void ConstructSourceInstalledTextInput()
        {
            if (SourceProfile != GameProfile.InstalledEverest || sourceInstalledTextInput != null)
                throw new InvalidOperationException("The installed text input process requires one installed birth.");
            sourceInstalledTextInput = new(
                new EverestSourceTextInputDevice(TextInput, PhysicalIO.Clipboard), Logger);
        }
    }
}
