using Celeste.Core.Audio;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        private ISourceAudioEventReference conveyorLoopSfx;
        internal bool ConveyorLoopActive => conveyorLoopSfx != null;

        internal void StartConveyorAudio()
        {
            conveyorLoopSfx = ((ISourceSpatialAudioEnvironment)EngineContext).SpatialAudio.Play(
                "event:/game/09_core/conveyor_activate", Position, "end");
        }

        internal void PositionConveyorAudio()
        {
            ((ISourceSpatialAudioEnvironment)EngineContext).SpatialAudio.Position(conveyorLoopSfx, Position);
        }

        internal void EndConveyorAudio()
        {
            conveyorLoopSfx.SetParameter("end", 1f);
            conveyorLoopSfx.Release();
            conveyorLoopSfx = null;
        }

        private void StopConveyorAudio()
        {
            ((ISourceSpatialAudioEnvironment)EngineContext).SpatialAudio.Stop(conveyorLoopSfx);
        }
    }
}
