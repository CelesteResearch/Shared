using System;
using System.Collections.Generic;
using System.Linq;
using Celeste.Everest;

namespace Celeste.Everest.Modules.Dependencies
{
    public enum EverestDependencyDisposition
    {
        Delayed,
        UpdateEverest,
        UpdateEverestManually,
        Unblacklist,
        NotFound,
        MultipleDownloads,
        IncompatibleDatabaseVersion,
        Install,
        Update
    }
}
