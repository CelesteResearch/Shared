using System.Collections.Generic;
using Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers;
using Celeste.Simulation.Gameplay.Player.ChaseHistory;
using Celeste.Simulation.Gameplay.Player.Events;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public List<ChaserState>
            ChaserStates;

        public readonly PlayerChaseHistory ChaseHistory;
        private bool chaseWasDucking;

        private void BindChaseHistory()
        {
            World.Emitted += message =>
            {
                if (message.Kind != RoomPlayerEventKind.Sound ||
                    !message.RecordForChase) return;
                ChaseHistory.RecordSound(message.Name, message.Parameter, message.Value);
            };
        }

        private void CaptureChaseState()
        {
            ChaseHistory.Sample(World.SceneTime, Body.Position, Sprite.CurrentAnimationID, Data.Facing,
                Data.OnGround, Hair.Color, Depth, Sprite.Scale, Data.Direction);
        }

        private void UpdateChaseTail()
        {
            // Native Player.Update records history before these sounds. They belong
            // to the next sample, including when a transition clears only the history.
            if (chaseWasDucking == Data.Motion.Ducking) return;
            chaseWasDucking = Data.Motion.Ducking;
            if (chaseWasDucking)
                Report(RoomPlayerEventKind.Sound,
                    "event:/char/madeline/duck", World.Center);
            else if (Data.OnGround)
                Report(RoomPlayerEventKind.Sound,
                    "event:/char/madeline/stand", World.Center);
        }
    }
}
