using Celeste.Core.Audio;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        private ISourceAudioEventReference conveyorLoopSfx;
        internal bool ConveyorLoopActive => conveyorLoopSfx != null;

        internal void StartConveyorAudio()
            => conveyorLoopSfx = ((ISourceSpatialAudioEnvironment)engineContext).SpatialAudio.Play(
                "event:/game/09_core/conveyor_activate", Position, "end", 0f);

        internal void PositionConveyorAudio()
            => ((ISourceSpatialAudioEnvironment)engineContext).SpatialAudio.Position(conveyorLoopSfx, Position);

        internal void EndConveyorAudio()
        {
            conveyorLoopSfx.SetParameter("end", 1f);
            conveyorLoopSfx.Release();
            conveyorLoopSfx = null;
        }

        private void StopConveyorAudio()
            => ((ISourceSpatialAudioEnvironment)engineContext).SpatialAudio.Stop(conveyorLoopSfx);
    }
}
