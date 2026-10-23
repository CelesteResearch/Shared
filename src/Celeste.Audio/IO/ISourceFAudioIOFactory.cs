using Celeste.Core.Diagnostics;

namespace Celeste.Audio.IO
{
    public interface ISourceFAudioIOFactory
    {
        ISourceFAudioIO Create(ISourceFnaLoggingEnvironment actualLogging);
    }
}
