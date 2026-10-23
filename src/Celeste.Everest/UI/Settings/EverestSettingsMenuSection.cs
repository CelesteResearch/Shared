using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using Celeste.Everest;

namespace Celeste.Everest.UI.Settings
{
    public sealed class EverestSettingsMenuSection
    {
        public string Title { get; set; }

        public readonly List<global::Celeste.Everest.UI.Settings.EverestSettingItem> Items =
            new List<global::Celeste.Everest.UI.Settings.EverestSettingItem>();
    }
}
