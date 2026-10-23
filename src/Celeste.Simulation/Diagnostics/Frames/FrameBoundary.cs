namespace Celeste.Simulation.Diagnostics.Frames
{
    public readonly struct FrameBoundary
    {
        public readonly long LastFedInputIndex;
        public readonly int SceneGeneration;
        public readonly FrameBoundaryKind Kind;

        public FrameBoundary(long lastFedInputIndex, int sceneGeneration, FrameBoundaryKind kind)
        {
            LastFedInputIndex = lastFedInputIndex;
            SceneGeneration = sceneGeneration;
            Kind = kind;
        }
    }
}
