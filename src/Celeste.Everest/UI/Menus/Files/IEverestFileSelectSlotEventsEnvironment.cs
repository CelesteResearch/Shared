using System;
using System.Collections.Generic;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Modules.Persistence;

namespace Celeste.Everest.UI.Menus.Files
{
    public interface IEverestFileSelectSlotEventsEnvironment
    {
        EverestFileSelectSlotEvents FileSelectSlotEvents { get; }
    }
}
