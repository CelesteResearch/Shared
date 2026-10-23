namespace Celeste.Everest.Diagnostics.Logging
{
    public sealed partial class EverestLoggerProcess
    {
        public readonly struct EnabledMessage
        {
            private readonly EverestLoggerProcess logger;
            private readonly string tag;
            private readonly EverestLogLevel level;
            public bool ShouldLog { get; }

            internal EnabledMessage(EverestLoggerProcess logger, string tag, EverestLogLevel level)
            {
                this.logger = logger;
                this.tag = tag;
                this.level = level;
                ShouldLog = logger.shouldLog(tag, level);
            }

            public void Write(string message)
            {
                if (ShouldLog)
                {
                    logger.LogUnchecked(level, tag, message);
                }
            }
        }

        public EnabledMessage BeginEnabledMessage(string tag, EverestLogLevel level)
            => new EnabledMessage(this, tag, level);
    }
}
