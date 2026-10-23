using Celeste.Audio.Fmod.Events;

namespace Celeste.Game.Audio.Channels
{
    public sealed class OriginalAudioEventNamePolicy : IOriginalAudioEventNamePolicy
    {
        public string GetEventName(FmodEventReference instance)
        {
            if (instance != null)
            {
                var description = instance.GetDescription();
                if (description != null)
                {
                    string path = "";
                    description.GetPath(out path);
                    return path;
                }
            }

            return "";
        }

        public string GetEventName(FmodEventDescriptionReference description)
        {
            if (description == null) return "";
            description.GetPath(out string path);
            return path;
        }
    }
}
