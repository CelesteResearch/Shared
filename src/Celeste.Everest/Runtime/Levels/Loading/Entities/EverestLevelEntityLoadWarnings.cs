using System;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Game.Content.Maps.Entities;

namespace Celeste.Everest.Runtime.Levels.Loading.Entities
{
    public sealed class EverestLevelEntityLoadWarnings
    {
        private readonly EverestLoggerProcess logger;

        public EverestLevelEntityLoadWarnings(EverestLoggerProcess logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void WarnUnknownEntity(OriginalLevelEntityData record)
        {
            logger.WarnUnknownLevelEntity(record);
        }
    }
}
