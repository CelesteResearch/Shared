using System.Collections.Generic;

namespace Celeste.Everest.UI.Settings
{
    public sealed class EverestSettingsMenuSection
    {
        public string Title { get; set; }

        public readonly List<EverestSettingItem> Items = [];
    }
}
