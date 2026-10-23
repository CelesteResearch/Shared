using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Physics.Collision;

namespace Celeste.Simulation.Gameplay.Collision.Blockers
{
    public sealed class LedgeBlockerState : SourceComponentState
    {
        public bool Blocking = true;
        public Func<ILedgeBlockerPlayer, bool> BlockChecker;

        public LedgeBlockerState(Func<ILedgeBlockerPlayer, bool> blockChecker = null) : base(false, false)
        {
            BlockChecker = blockChecker;
        }

        public bool HopBlockCheck(ILedgeBlockerPlayer player)
        {
            return Blocking && CollideCheck(player, player.Position + Vector2.UnitX * player.Facing * 8f)
                            && (BlockChecker == null || BlockChecker(player));
        }

        public bool JumpThruBoostCheck(ILedgeBlockerPlayer player)
        {
            return Blocking && CollideCheck(player, player.Position - Vector2.UnitY * 2f)
                            && (BlockChecker == null || BlockChecker(player));
        }

        public bool DashCorrectCheck(ILedgeBlockerPlayer player)
        {
            return Blocking && CollideCheck(player, player.Position)
                            && (BlockChecker == null || BlockChecker(player));
        }

        private bool CollideCheck(ILedgeBlockerPlayer player, Vector2 at)
        {
            var previous = player.Position;
            player.Position = at;
            var result = SourceEntityCollision.Check(player, (ISourceEntityCollider)Entity);
            player.Position = previous;
            return result;
        }
    }
}
