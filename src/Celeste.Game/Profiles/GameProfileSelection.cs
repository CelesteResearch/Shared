using System;
using System.Collections.Generic;

namespace Celeste.Game.Profiles
{
    public static class GameProfileSelection
    {
        public static GameProfile Resolve(GameProfile configuredProfile, IEnumerable<string> arguments)
        {
            if (arguments == null) throw new ArgumentNullException(nameof(arguments));
            foreach (var argument in arguments)
            {
                if (string.Equals(argument, "--everest", StringComparison.OrdinalIgnoreCase))
                    return GameProfile.InstalledEverest;
                if (string.Equals(argument, "--original", StringComparison.OrdinalIgnoreCase))
                    return GameProfile.Original;
            }

            return configuredProfile;
        }
    }
}
