using System;
using System.Numerics;
using Celeste.Everest.Modules.Core;
using Celeste.Simulation.Presentation.Decals.Entities;

namespace Celeste.Everest.Content.Extensions.Decals
{
    public sealed class EverestDecalAttachmentHistory : ISourceDecalAttachmentHistory
    {
        private readonly Func<SourceCoreModuleSession> currentSession;

        public EverestDecalAttachmentHistory(Func<SourceCoreModuleSession> currentSession)
        {
            this.currentSession = currentSession ?? throw new ArgumentNullException(nameof(currentSession));
        }

        public bool Contains(string name, Vector2 position)
            => currentSession().AttachedDecals.Contains($"{name}||{position.X}||{position.Y}");

        public void Record(string name, Vector2 position)
            => currentSession().AttachedDecals.Add($"{name}||{position.X}||{position.Y}");
    }
}
