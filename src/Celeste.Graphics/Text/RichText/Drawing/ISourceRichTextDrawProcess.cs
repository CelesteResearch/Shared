using Celeste.Core.Randomness;
using Celeste.Core.Mathematics.Extrema;

namespace Celeste.Graphics.Text.RichText.Drawing
{
    public interface ISourceRichTextDrawProcess : ISourceRandomEnvironment, ISourceExtremaEnvironment
    {
        float RawTimeActive { get; }
    }
}
