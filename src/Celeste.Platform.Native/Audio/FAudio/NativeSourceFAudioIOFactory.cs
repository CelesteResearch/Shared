using Celeste.Audio.IO;
using Celeste.Core.Diagnostics;

namespace Celeste.Platform.Native.Audio.FAudio
{
    public sealed class NativeSourceFAudioIOFactory : ISourceFAudioIOFactory
    {
        public ISourceFAudioIO Create(ISourceFnaLoggingEnvironment actualLogging)
        {
            return new NativeSourceFAudioIO(actualLogging);
        }
    }
}
