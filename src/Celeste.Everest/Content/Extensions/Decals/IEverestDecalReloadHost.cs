using System;
using System.Collections.Generic;
using Celeste.Everest.Content.Packages;

namespace Celeste.Everest.Content.Extensions.Decals
{
    public interface IEverestDecalReloadHost
    {
        IReadOnlyList<EverestContentPackage> Packages { get; }
        bool IsReloading { get; }
        void ScheduleAfterReload(Action callback);
        void ScheduleEndOfFrame(Action callback);
        void ReloadLevel();
    }
}
