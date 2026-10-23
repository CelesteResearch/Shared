using Celeste.Core.Display;
using Celeste.Graphics.Text.BitmapFonts;

namespace Celeste.Game.Credits
{
// These are the original shared Credits fields, updated at each source Credits constructor.
    public sealed class OriginalCreditsProcessState
    {
        public SourcePixelFont Font;
        public float FontSize;
        public float LineHeight;
        public CreditsChapterSequence Instance;
        public PackedColor BorderColor = PackedColor.Black;

        public string[] Remixers =
        [
            "Maxo", "Ben Prunty", "Christa Lee", "in love with a ghost",
            "2 Mello", "Jukio Kallio", "Kuraine", "image:matthewseiji",
        ];
    }
}
