using Celeste.Core.Maps;
using Celeste.Scene.Scheduling;
using System;
using System.Collections.Generic;
using Celeste.Simulation;
using Celeste.Everest;

namespace Celeste.Everest.Content.Extensions.Triggers
{
    // Port-native equivalent of the map trigger construction seam. A re-ported
    // module supplies the behavior; map bytes, player state and collision are
    // owned by the engine-independent simulation layer.
    public abstract class EverestCustomTrigger
    {
        public MapDocument Map { get; internal set; }
        public global::Celeste.Core.Maps.MapElement Room { get; internal set; }
        public global::Celeste.Core.Maps.MapElement Source { get; internal set; }
        public global::Celeste.Core.Geometry.Bounds Bounds { get; internal set; }
        public string OriginalType { get; internal set; } = "Celeste.Trigger";
        public int Depth { get; set; }
        public SceneTagSet Tags { get; set; }
        public bool Active { get; set; } = true;
        public bool Collidable { get; set; } = true;
        public bool Triggered { get; internal set; }
        public bool PlayerIsInside { get; private set; }

        public virtual void OnEnter(RoomPlayerSession player)
        {
            PlayerIsInside = true;
        }

        public virtual void OnStay(RoomPlayerSession player)
        {
        }

        public virtual void OnLeave(RoomPlayerSession player)
        {
            PlayerIsInside = false;
        }

        public virtual void AddedToRoom()
        {
        }

        public virtual void AwakeInRoom()
        {
        }

        public virtual void Update(float deltaTime)
        {
        }

        public virtual void RemovedFromRoom(bool sceneEnd)
        {
        }

        public global::Celeste.Scene.Triggers.PlayerTriggerCallbacks<RoomPlayerSession> BindPlayerCallbacks()
            => new global::Celeste.Scene.Triggers.PlayerTriggerCallbacks<RoomPlayerSession>(this,
                player => Collidable && Bounds.Intersects(player.World.Bounds),
                () => Triggered, value => Triggered = value, OnEnter, OnStay, OnLeave);

        public void UpdatePlayer(RoomPlayerSession player)
        {
            if (player != null) UpdatePlayer(player.World.Bounds, player.Machine.State, player);
        }

        public void UpdatePlayer(global::Celeste.Core.Geometry.Bounds playerBounds, int playerState,
            RoomPlayerSession player = null)
        {
            if (playerState == 18) return;
            bool inside = Collidable && Bounds.Intersects(playerBounds);
            if (inside)
            {
                if (!Triggered)
                {
                    Triggered = true;
                    OnEnter(player);
                }

                OnStay(player);
            }
            else if (Triggered) Leave(player);
        }

        public void Leave(RoomPlayerSession player)
        {
            if (!Triggered) return;
            Triggered = false;
            OnLeave(player);
        }
    }
}
