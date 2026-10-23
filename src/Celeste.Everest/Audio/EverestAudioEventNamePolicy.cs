using System;
using System.Collections.Generic;
using Celeste.Audio.Fmod.Events;
using Celeste.Audio.Fmod.Banks;
using Celeste.Game.Audio.Channels;
using Celeste.Everest.Runtime;

namespace Celeste.Everest.Audio
{
    public sealed class EverestAudioEventNamePolicy : IOriginalAudioEventNamePolicy
    {
        private readonly IEverestHeadlessEnvironment environment;
        public Dictionary<Guid, string> cachedPaths = new Dictionary<Guid, string>();
        public EverestAudioEventNamePolicy(IEverestHeadlessEnvironment environment) => this.environment = environment;

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
            description.GetID(out Guid id);
            if (cachedPaths.TryGetValue(id, out string value)) return value;
            description.GetPath(out value);
            if (string.IsNullOrEmpty(value)) value = "guid://" + id;
            return cachedPaths[id] = value;
        }

        public Dictionary<Guid, string> cachedBankPaths = new Dictionary<Guid, string>();

        public string GetBankName(FmodBankReference bank)
        {
            if (environment.IsHeadless || bank == null) return "";
            bank.GetID(out Guid id);
            if (cachedBankPaths.TryGetValue(id, out string value)) return value;
            bank.GetPath(out value);
            return cachedBankPaths[id] = value;
        }
    }
}
