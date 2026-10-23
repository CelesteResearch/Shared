using System;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Presentation.Idle
{
    public interface IPlayerIdleWorld
    {
        global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSprite Sprite { get; }
        bool ScenePresent { get; }
        bool Dead { get; }
        bool InCutscene { get; }
        bool CoreHot { get; }
        global::Celeste.Core.Randomness.ISourceRandom Random { get; }
        global::Celeste.Core.Audio.ISourceAudioEventReference PlaySound(string name);
        void StopSound(global::Celeste.Core.Audio.ISourceAudioEventReference instance);
    }
}
