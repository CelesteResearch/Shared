using System;

namespace Celeste.Hosting
{
    public sealed class EmbeddedGameConfiguration
    {
        public string ContentRoot { get; set; } = string.Empty;
        public string DataRoot { get; set; } = string.Empty;
        public string FrameworkTimeResourcesRoot { get; set; } = string.Empty;
        public int Width { get; set; } = 960;
        public int Height { get; set; } = 540;
        public bool AudioOutputAvailable { get; set; } = true;
        public Func<int, int> TranslateScancode { get; set; } = key => key;
        public Func<string> GetClipboardText { get; set; } = () => string.Empty;
        public Action<string> SetClipboardText { get; set; } = _ => { };
        public Action<bool> SetTextInputActive { get; set; } = _ => { };
        public Action<string, string> ReportError { get; set; } = (_, _) => { };
    }
}
