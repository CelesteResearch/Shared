namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public System.Collections.Generic.List<global::Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers.ChaserState>
            ChaserStates;

        public readonly global::Celeste.Simulation.Gameplay.Player.ChaseHistory.PlayerChaseHistory ChaseHistory;
        private bool chaseWasDucking;

        private void BindChaseHistory()
        {
            World.Emitted += message =>
            {
                if (message.Kind != global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind.Sound ||
                    !message.RecordForChase) return;
                ChaseHistory.RecordSound(message.Name, message.Parameter, message.Value);
            };
        }

        private void CaptureChaseState()
            => ChaseHistory.Sample(World.SceneTime, Body.Position, Sprite.CurrentAnimationID, Data.Facing,
                Data.OnGround, Hair.Color, Depth, Sprite.Scale, Data.Direction);

        private void UpdateChaseTail()
        {
            // Native Player.Update records history before these sounds. They belong
            // to the next sample, including when a transition clears only the history.
            if (chaseWasDucking == Data.Motion.Ducking) return;
            chaseWasDucking = Data.Motion.Ducking;
            if (chaseWasDucking)
                Report(global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind.Sound,
                    "event:/char/madeline/duck", World.Center);
            else if (Data.OnGround)
                Report(global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind.Sound,
                    "event:/char/madeline/stand", World.Center);
        }
    }
}
