namespace Celeste.Everest.Diagnostics.Logging
{
    public sealed partial class EverestLoggerProcess
    {
        private bool enabledVTSupport;

        public bool TryEnableWindowsVTSupport()
        {
            if (enabledVTSupport) return true;
            var stdHandle = Environment.ConsoleModes.GetStdHandle(-11);
            if (!Environment.ConsoleModes.GetConsoleMode(stdHandle, out var mode)) return false;
            if ((mode & 4) == 0)
            {
                Environment.ConsoleModes.SetConsoleMode(stdHandle, mode | 4);
                enabledVTSupport = true;
                return true;
            }

            return false;
        }
    }
}
