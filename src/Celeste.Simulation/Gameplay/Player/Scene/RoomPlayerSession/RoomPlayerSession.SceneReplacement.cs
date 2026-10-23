using System;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        // Scene.EntityList can replace the Player before that frame's entity
        // update. The outer Engine/Input tick still belongs to the existing call.
        public Func<RoomPlayerSession> ResolveScenePlayer;

        private RoomPlayerSession ResolveLevelFramePlayer(float raw)
        {
            var current = ResolveScenePlayer?.Invoke() ?? this;
            if (!ReferenceEquals(current, this)) current.rawDelta = raw;

            return current;
        }
    }
}
