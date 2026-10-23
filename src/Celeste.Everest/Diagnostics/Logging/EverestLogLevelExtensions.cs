namespace Celeste.Everest.Diagnostics.Logging
{
    public static class EverestLogLevelExtensions
    {
        /// <summary>
        ///     Converts this <see cref="T:Celeste.Mod.LogLevel" /> to its string representation, in a way more performant than
        ///     <see cref="M:System.Enum.ToString" />
        /// </summary>
        public static string FastToString(this EverestLogLevel level)
        {
            return level switch
            {
                EverestLogLevel.Verbose => "Verbose",
                EverestLogLevel.Debug => "Debug",
                EverestLogLevel.Info => "Info",
                EverestLogLevel.Warn => "Warn",
                EverestLogLevel.Error => "Error",
                _ => level.ToString(),
            };
        }

        internal static string GetAnsiEscapeCodeForText(this EverestLogLevel level)
        {
            return level switch
            {
                EverestLogLevel.Verbose => "\u001b[95m",
                EverestLogLevel.Debug => "\u001b[94m",
                EverestLogLevel.Info => "\u001b[0m",
                EverestLogLevel.Warn => "\u001b[93m",
                EverestLogLevel.Error => "\u001b[91m",
                _ => "",
            };
        }

        internal static string GetAnsiEscapeCodeForLevel(this EverestLogLevel level)
        {
            return level switch
            {
                EverestLogLevel.Verbose => "\u001b[35m",
                EverestLogLevel.Debug => "\u001b[34m",
                EverestLogLevel.Info => "\u001b[97m",
                EverestLogLevel.Warn => "\u001b[33m",
                EverestLogLevel.Error => "\u001b[31m",
                _ => "",
            };
        }
    }
}
