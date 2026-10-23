using System.Collections.Generic;
using Celeste.Audio.Fmod.Events;

namespace Celeste.Audio.Fmod.Runtime
{
    public interface ISourceFmodEventDescriptionCache
    {
        Dictionary<string, FmodEventDescriptionReference> CachedEventDescriptions { get; }
    }
}
