using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers;

namespace Celeste.Simulation.Gameplay.Player.ChaseHistory
{
    // Call Sample at Player.Update's original tail, before UpdateHair and the duck/stand
    // sounds. Audio records are independent of native output availability. A killed
    // PlayerCollider frame returns before sampling; transition clears only the history.
    public sealed class PlayerChaseHistory
    {
        private readonly RoomPlayerSession actualPlayer;

        private List<ChaserState> states =>
            actualPlayer.ChaserStates;

        private readonly List<ChaserStateSound>
            activeSounds = [];

        public List<ChaserState> States => states;
        public int PendingSoundCount => activeSounds.Count;
        public IReadOnlyDictionary<string, string> SoundMapping { get; }

        public PlayerChaseHistory(RoomPlayerSession actualPlayer, IReadOnlyDictionary<string, string> soundMapping)
        {
            this.actualPlayer = actualPlayer;
            SoundMapping = soundMapping ?? throw new ArgumentNullException(nameof(soundMapping));
        }

        public void RecordSound(string sound, string parameter = null, float value = 0,
            ChaserStateSound.Actions action =
                ChaserStateSound.Actions.Oneshot)
        {
            SoundMapping.TryGetValue(sound, out var mapped);
            if (mapped != null)
                activeSounds.Add(new()
                    { Event = mapped, Parameter = parameter, ParameterValue = value, Action = action });
        }

        public void RecordSound(string sound,
            ChaserStateSound.Actions action)
        {
            RecordSound(sound, null, 0, action);
        }

        public void Sample(float sceneTime, Vector2 position, string animation, int facing, bool onGround,
            PackedColor hairColor, int depth, Vector2 spriteScale,
            Vector2 dashDirection)
        {
            while (states.Count > 0 && sceneTime - states[0].TimeStamp > 4f) states.RemoveAt(0);
            states.Add(new(sceneTime, position,
                animation, facing, onGround, hairColor, depth, spriteScale,
                dashDirection, activeSounds));
            activeSounds.Clear();
        }

        public bool GetChasePosition(float sceneTime, float timeAgo, bool dead,
            out ChaserState state)
        {
            if (!dead)
            {
                var passedOlder = false;
                foreach (var item in states)
                {
                    var age = sceneTime - item.TimeStamp;
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

        public void OnTransition()
        {
            states.Clear();
        }
    }
}
