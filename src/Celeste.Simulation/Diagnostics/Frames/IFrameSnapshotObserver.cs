namespace Celeste.Simulation.Diagnostics.Frames
{
    public interface IFrameSnapshotObserver
    {
        void OnFrame(in FrameSnapshot snapshot);
        void OnBoundary(in FrameBoundary boundary);
    }
}
