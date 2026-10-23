using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Enemies.Seeker
{
    public interface ISeekerEffectsWorld
    {
        Random Random { get; }
        bool OnInterval(float interval);
        Vector2 CameraPosition { get; }
        global::Celeste.Simulation.Gameplay.Enemies.Seeker.ISeekerEffectsPlayer FirstPlayer { get; }
        IEnumerable<global::Celeste.Simulation.Gameplay.Enemies.Seeker.ISeekerEffectsSource> Seekers { get; }
        int SeekerCount { get; }
        float TimeRate { get; set; }
        float GameRate { get; set; }
        float Anxiety { get; set; }
        Vector2 AnxietyOrigin { get; set; }
        void SetMusicLayer(int layer, float value);
        void ApplyAudio();
    }
}
