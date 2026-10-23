#nullable enable annotations
using System;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Everest.Runtime.Discord
{
    public interface IEverestDiscordSdkComponent : IDisposable
    {
        void UpdatePresence(ChapterCompletionSession? session = null);
    }
}
