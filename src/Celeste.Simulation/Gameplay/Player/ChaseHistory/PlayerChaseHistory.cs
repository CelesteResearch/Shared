using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.ChaseHistory
{
    // Call Sample at Player.Update's original tail, before UpdateHair and the duck/stand
    // sounds. Audio records are independent of native output availability. A killed
    // PlayerCollider frame returns before sampling; transition clears only the history.
    public sealed class PlayerChaseHistory
    {
        private readonly RoomPlayerSession actualPlayer;

        private List<global::Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers.ChaserState> states =>
            actualPlayer.ChaserStates;

        private readonly List<global::Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers.ChaserStateSound>
            activeSounds = new List<global::Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers.ChaserStateSound>();

        private readonly IReadOnlyDictionary<string, string> soundMapping;
        public List<global::Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers.ChaserState> States => states;
        public int PendingSoundCount => activeSounds.Count;
        public IReadOnlyDictionary<string, string> SoundMapping => soundMapping;

        public PlayerChaseHistory(RoomPlayerSession actualPlayer, IReadOnlyDictionary<string, string> soundMapping)
        {
            this.actualPlayer = actualPlayer;
            this.soundMapping = soundMapping ?? throw new ArgumentNullException(nameof(soundMapping));
        }

        public void RecordSound(string sound, string parameter = null, float value = 0,
            global::Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers.ChaserStateSound.Actions action =
                global::Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers.ChaserStateSound.Actions.Oneshot)
        {
            soundMapping.TryGetValue(sound, out var mapped);
            if (mapped != null)
                activeSounds.Add(new global::Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers.ChaserStateSound
                    { Event = mapped, Parameter = parameter, ParameterValue = value, Action = action });
        }

        public void RecordSound(string sound,
            global::Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers.ChaserStateSound.Actions action) =>
            RecordSound(sound, null, 0, action);

        public void Sample(float sceneTime, Vector2 position, string animation, int facing, bool onGround,
            global::Celeste.Core.Display.PackedColor hairColor, int depth, Vector2 spriteScale,
            Vector2 dashDirection)
        {
            while (states.Count > 0 && sceneTime - states[0].TimeStamp > 4f) states.RemoveAt(0);
            states.Add(new global::Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers.ChaserState(sceneTime, position,
                animation, facing, onGround, hairColor, depth, spriteScale,
                dashDirection, activeSounds));
            activeSounds.Clear();
        }

        public bool GetChasePosition(float sceneTime, float timeAgo, bool dead,
            out global::Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers.ChaserState state)
        {
            if (!dead)
            {
                bool passedOlder = false;
                foreach (var item in states)
                {
                    float age = sceneTime - item.TimeStamp;
                    if (age <= timeAgo)
                    {
                        if (passedOlder || timeAgo - age < .02f)
                        {
                            state = item;
                            return true;
                        }

                        state = default;
                        return false;
                    }

                    passedOlder = true;
                }
            }

            state = default;
            return false;
        }

        public void OnTransition() => states.Clear();
    }
}
