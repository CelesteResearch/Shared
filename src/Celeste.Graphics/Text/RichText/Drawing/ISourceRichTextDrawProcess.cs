using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;

namespace Celeste.Graphics.Text.RichText.Drawing
{
    public interface ISourceRichTextDrawProcess : ISourceRandomEnvironment, ISourceExtremaEnvironment
    {
        float RawTimeActive { get; }
    }
}
