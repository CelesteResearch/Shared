using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Simulation.Gameplay.Enemies.Seeker
{
    public interface ISeekerEffectsWorld
    {
        Random Random { get; }
        bool OnInterval(float interval);
        Vector2 CameraPosition { get; }
        ISeekerEffectsPlayer FirstPlayer { get; }
        IEnumerable<ISeekerEffectsSource> Seekers { get; }
        int SeekerCount { get; }
        float TimeRate { get; set; }
        float GameRate { get; set; }
        float Anxiety { get; set; }
        Vector2 AnxietyOrigin { get; set; }
        void SetMusicLayer(int layer, float value);
        void ApplyAudio();
    }
}
