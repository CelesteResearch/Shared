using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using Celeste.Everest;

namespace Celeste.Everest.UI.Settings
{
    // This model contains no TextMenu or engine types. An adapter owns input screens and drawing.
    public sealed class EverestSettingItem
    {
        public global::Celeste.Everest.UI.Settings.EverestSettingControl Control { get; set; }
        public string Name { get; set; }
        public string SubHeader { get; set; }
        public string Description { get; set; }
        public bool NeedsRelaunch { get; set; }
        public bool Disabled { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public int MaxLength { get; set; }
        public int MinLength { get; set; }
        public bool AllowNegatives { get; set; }
        public IReadOnlyList<object> Values { get; set; }
        public IReadOnlyList<string> ValueNames { get; set; }
        public Func<object> GetValue { get; set; }
        public Action<object> SetValue { get; set; }
        public Action Activated { get; set; }

        public List<global::Celeste.Everest.UI.Settings.EverestSettingItem> Children { get; } =
            new List<global::Celeste.Everest.UI.Settings.EverestSettingItem>();
    }
}
