using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Celeste.Simulation.Rendering;
using Celeste.Everest;

namespace Celeste.Everest.Content.Extensions.Decals
{
    public interface IEverestDecalReloadHost
    {
        IReadOnlyList<global::Celeste.Everest.Content.Packages.EverestContentPackage> Packages { get; }
        bool IsReloading { get; }
        void ScheduleAfterReload(Action callback);
        void ScheduleEndOfFrame(Action callback);
        void ReloadLevel();
    }
}
