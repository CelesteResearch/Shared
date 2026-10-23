using System;

namespace Celeste.Scene.Triggers
{
    public sealed class PlayerTriggerCallbacks<TPlayer>
    {
        public readonly object Identity;
        public readonly Func<TPlayer, bool> CollideCheck;
        public readonly Func<bool> ReadTriggered;
        public readonly Action<bool> WriteTriggered;
        public readonly Action<TPlayer> OnEnter, OnStay, OnLeave;

        public PlayerTriggerCallbacks(object identity, Func<TPlayer, bool> collideCheck,
            Func<bool> readTriggered, Action<bool> writeTriggered,
            Action<TPlayer> onEnter, Action<TPlayer> onStay, Action<TPlayer> onLeave)
        {
            Identity = identity ?? throw new ArgumentNullException(nameof(identity));
            CollideCheck = collideCheck ?? throw new ArgumentNullException(nameof(collideCheck));
            ReadTriggered = readTriggered ?? throw new ArgumentNullException(nameof(readTriggered));
            WriteTriggered = writeTriggered ?? throw new ArgumentNullException(nameof(writeTriggered));
            OnEnter = onEnter;
            OnStay = onStay;
            OnLeave = onLeave;
        }
    }
}
