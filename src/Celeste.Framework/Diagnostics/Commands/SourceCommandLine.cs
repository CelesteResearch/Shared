using Celeste.Core.Display;
using Celeste.Graphics.Display;

namespace Celeste.Framework.Diagnostics.Commands
{
    public struct SourceCommandLine
    {
        public string Text;
        public PackedColor Color;

        public SourceCommandLine(string text)
        {
            Text = text;
            Color = PackedColor.White;
        }

        public SourceCommandLine(string text, PackedColor color)
        {
            Text = text;
            Color = color;
        }
    }
}
