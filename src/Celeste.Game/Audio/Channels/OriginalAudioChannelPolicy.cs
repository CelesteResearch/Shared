using System;
using Celeste.Audio.Fmod.Events;
using Celeste.Audio.Fmod.Gameplay;
using Celeste.Audio.Fmod.Gameplay.Audio;

namespace Celeste.Game.Audio.Channels
{
    public sealed class OriginalAudioChannelPolicy : IRoomAudioChannelPolicy
    {
        public static readonly OriginalAudioChannelPolicy Instance = new OriginalAudioChannelPolicy();

        private OriginalAudioChannelPolicy()
        {
        }

        private static string EventName(FmodEventInstance instance) => instance?.GetCanonicalPath() ?? "";

        public bool SetMusic(RoomAudioDriver device, string path, bool startPlaying, bool allowFadeOut)
        {
            if (string.IsNullOrEmpty(path) || path == "null")
            {
                RoomAudioDriver.StopRelease(device.Runtime.CurrentMusic, allowFadeOut);
                device.Runtime.CurrentMusic = null;
                device.CurrentMusicName = "";
            }
            else if (!device.CurrentMusicName.Equals(path, StringComparison.OrdinalIgnoreCase))
            {
                RoomAudioDriver.StopRelease(device.Runtime.CurrentMusic, allowFadeOut);
                FmodEventInstance instance = device.Create(path);
                if (instance != null && startPlaying) instance.Start();
                device.Runtime.CurrentMusic = instance;
                device.CurrentMusicName = EventName(instance);
                return true;
            }

            return false;
        }

        public bool SetAmbience(RoomAudioDriver device, string path, bool startPlaying)
        {
            if (string.IsNullOrEmpty(path) || path == "null")
            {
                RoomAudioDriver.StopRelease(device.AmbienceEvent);
                device.AmbienceEvent = null;
            }
            else if (!EventName(device.AmbienceEvent).Equals(path, StringComparison.OrdinalIgnoreCase))
            {
                RoomAudioDriver.StopRelease(device.AmbienceEvent);
                FmodEventInstance instance = device.Create(path);
                if (instance != null && startPlaying) instance.Start();
                device.AmbienceEvent = instance;
                return true;
            }

            return false;
        }

        public void SetAltMusic(RoomAudioDriver device, string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                device.MainDownSnapshot?.Stop();
                RoomAudioDriver.StopRelease(device.AlternateEvent);
                device.AlternateEvent = null;
            }
            else if (!EventName(device.AlternateEvent).Equals(path, StringComparison.OrdinalIgnoreCase))
            {
                if (device.MainDownSnapshot == null)
                    device.MainDownSnapshot = device.Runtime.CreateSnapshot("snapshot:/music_mains_mute");
                else device.MainDownSnapshot.Start();
                RoomAudioDriver.StopRelease(device.AlternateEvent);
                FmodEventInstance instance = device.Create(path);
                instance?.Start();
                device.AlternateEvent = instance;
            }
        }
    }
}
