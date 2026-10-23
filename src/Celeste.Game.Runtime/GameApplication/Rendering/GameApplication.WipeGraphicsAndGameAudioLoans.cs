using Celeste.Graphics.Rendering.Primitives;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourcePrimitiveGraphicsEnvironment,
        global::Celeste.Core.Audio.ISourceAudioEnvironment
    {
        ISourcePrimitiveGraphicsDevice ISourcePrimitiveGraphicsEnvironment.PrimitiveGraphics => this;

        global::Celeste.Core.Audio.ISourceAudio global::Celeste.Core.Audio.ISourceAudioEnvironment.SourceAudio
            => AudioSession;
    }
}
