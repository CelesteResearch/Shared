using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Celeste.Simulation.Audio
{
    // Return true only when SetMusic/SetAmbience creates a different event instance, as Celeste.Audio does.
    // HasMusic/HasAmbience are strict non-null checks of the actual current instances,
    // including failed event lookup. Release/validity flags must not alter this source gate.
    public interface IRoomAudioOutput
    {
        bool SetMusic(string path, bool startPlaying = true, bool allowFadeOut = true);
        bool HasMusic { get; }
        void SetMusicParam(string key, float value);
        void StartMusic();
        bool SetAmbience(string path, bool startPlaying = true);
        bool HasAmbience { get; }
        void SetAmbienceParam(string key, float value);
        void SetAmbienceVolume(float value);
        void StartAmbience();
        void SetAltMusic(string path);
    }
}
