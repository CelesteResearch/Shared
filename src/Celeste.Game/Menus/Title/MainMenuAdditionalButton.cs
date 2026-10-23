#nullable enable

using System;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Game.Menus.Title
{
    public sealed class MainMenuAdditionalButton
    {
        public string Label { get; }
        public Func<AtlasEntry> ReadIcon { get; }
        public Action OnConfirm { get; }
        public Action<float, float, float, float>? PublishPointerRegion { get; }

        public MainMenuAdditionalButton(string label, Func<AtlasEntry> readIcon, Action onConfirm,
            Action<float, float, float, float>? publishPointerRegion = null)
        {
            Label = label ?? throw new ArgumentNullException(nameof(label));
            ReadIcon = readIcon ?? throw new ArgumentNullException(nameof(readIcon));
            OnConfirm = onConfirm ?? throw new ArgumentNullException(nameof(onConfirm));
            PublishPointerRegion = publishPointerRegion;
        }
    }
}
