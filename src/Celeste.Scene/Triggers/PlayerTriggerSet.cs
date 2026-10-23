using System.Collections.Generic;
using Celeste.Physics.Collision;
using Celeste.Scene.Ownership;

namespace Celeste.Scene.Triggers
{
    public sealed class PlayerTriggerSet<TPlayer> where TPlayer : ISourceEntityCollider
    {
        private readonly HashSet<ISourcePlayerTrigger<TPlayer>> inside =
            new HashSet<ISourcePlayerTrigger<TPlayer>>(SceneObjectIdentityComparer.Instance);

        public IReadOnlyCollection<ISourcePlayerTrigger<TPlayer>> Inside => inside;

        public void Update(TPlayer player, ISourcePlayerTrigger<TPlayer> trigger)
            => UpdateContact(player, trigger, player.Collider != null && trigger.Collider != null &&
                                              !ReferenceEquals(player, trigger) && trigger.Collidable &&
                                              player.Collider.Collide(trigger.Collider));

        public void UpdateContact(TPlayer player, ISourcePlayerTrigger<TPlayer> trigger, bool contact)
        {
            if (contact)
            {
                if (!trigger.Triggered)
                {
                    trigger.Triggered = true;
                    inside.Add(trigger);
                    trigger.OnEnter(player);
                }

                trigger.OnStay(player);
            }
            else if (trigger.Triggered)
            {
                inside.Remove(trigger);
                trigger.Triggered = false;
                trigger.OnLeave(player);
            }
        }

        public void PlayerRemoved(TPlayer player)
        {
            foreach (var trigger in inside)
            {
                trigger.Triggered = false;
                trigger.OnLeave(player);
            }

            inside.Clear();
        }

        public void CleanUp(TPlayer player)
        {
            if (inside.Count <= 0) return;
            foreach (var trigger in inside)
            {
                trigger.OnLeave(player);
                trigger.Triggered = false;
            }

            inside.Clear();
        }
    }
}
