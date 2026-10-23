using Celeste.Core.Audio;
using Celeste.Graphics.Rendering.Primitives;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourcePrimitiveGraphicsEnvironment,
        ISourceAudioEnvironment
    {
        ISourcePrimitiveGraphicsDevice ISourcePrimitiveGraphicsEnvironment.PrimitiveGraphics => this;

        ISourceAudio ISourceAudioEnvironment.SourceAudio
            => AudioSession;
    }
}
