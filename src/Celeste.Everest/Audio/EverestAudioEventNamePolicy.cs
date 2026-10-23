using System;
using System.Collections.Generic;
using Celeste.Audio.Fmod.Banks;
using Celeste.Audio.Fmod.Events;
using Celeste.Everest.Runtime;
using Celeste.Game.Audio.Channels;

namespace Celeste.Everest.Audio
{
    public sealed class EverestAudioEventNamePolicy : IOriginalAudioEventNamePolicy
    {
        private readonly IEverestHeadlessEnvironment environment;
        public Dictionary<Guid, string> cachedPaths = new();

        public EverestAudioEventNamePolicy(IEverestHeadlessEnvironment environment)
        {
            this.environment = environment;
        }

        public string GetEventName(FmodEventReference instance)
        {
            if (environment.IsHeadless || instance == null) return "";
            var description = instance.GetDescription();
            if (description == null) return "";
            return GetEventName(description);
        }

        public string GetEventName(FmodEventDescriptionReference description)
        {
            if (environment.IsHeadless || description == null) return "";
            description.GetID(out var id);
            if (cachedPaths.TryGetValue(id, out var value)) return value;
            description.GetPath(out value);
            if (string.IsNullOrEmpty(value)) value = "guid://" + id;
            return cachedPaths[id] = value;
        }

        public Dictionary<Guid, string> cachedBankPaths = new();

        public string GetBankName(FmodBankReference bank)
        {
            if (environment.IsHeadless || bank == null) return "";
            bank.GetID(out var id);
            if (cachedBankPaths.TryGetValue(id, out var value)) return value;
            bank.GetPath(out value);
            return cachedBankPaths[id] = value;
        }
    }
}
