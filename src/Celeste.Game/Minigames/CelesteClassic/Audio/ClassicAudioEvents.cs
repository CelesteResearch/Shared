using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation;
using Celeste.Simulation.Rendering;

namespace Celeste.Game.Minigames.CelesteClassic.Audio
{
    public sealed class ClassicAudioEvents
    {
        private readonly Action<string, Vector2> play;
        private readonly Action<string> record;
        private readonly Func<Vector2> position;

        public ClassicAudioEvents(Action<string, Vector2> play, Func<Vector2> position, Action<string> record = null)
        {
            this.play = play;
            this.position = position;
            this.record = record;
        }

        public void Sound(string eventName)
        {
            record?.Invoke("Pico8 sfx: " + eventName);
            play?.Invoke(eventName, position?.Invoke() ?? Vector2.Zero);
        }

        public void Music(string eventName)
        {
            record?.Invoke("Pico8 music: " + (eventName ?? "null"));
            if (eventName != null) play?.Invoke(eventName, position?.Invoke() ?? Vector2.Zero);
        }

        public void BusStopAll() => record?.Invoke("Pico8 audio: bus stop");
    }
}
