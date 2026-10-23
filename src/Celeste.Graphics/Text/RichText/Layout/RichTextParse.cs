using System.Numerics;

namespace Celeste.Graphics.Text.RichText.Layout
{
    public delegate RichTextLayout RichTextParse(string text, int maxLineWidth, int linesPerPage,
        float startFade = 1f, Vector4? defaultColor = null);
}
