namespace Celeste.Simulation.Diagnostics.Frames
{
    // Install once per run. The host checks Observer before creating a key or
    // asking for RNG evidence; no per-frame allocation or collision scans when off.
    public sealed class FrameSnapshotSampler
    {
        public IFrameSnapshotObserver Observer { get; set; }
        public bool Enabled => Observer != null;

        public void Publish(FrameSnapshotKey key, RoomPlayerSession player, RngSnapshot rng)
        {
            var observer = Observer;
            if (observer == null) return;
            var snapshot = FrameSnapshot.Capture(key, player, rng);
            observer.OnFrame(in snapshot);
        }

        // A host may copy the old room before a scene handoff and notify only
        // after its TAS seeded-update scope has ended.
        public void PublishPrepared(in FrameSnapshot snapshot)
        {
            var observer = Observer;
            if (observer != null) observer.OnFrame(in snapshot);
        }

        public void PublishBoundary(FrameBoundary boundary)
        {
            var observer = Observer;
            if (observer != null) observer.OnBoundary(in boundary);
        }
    }
}
