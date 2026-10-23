namespace Celeste.Simulation.Rendering
{
    public readonly struct ReflectionTentaclesDraw
    {
        public readonly ReflectionTentaclesDrawKind Kind;
        public readonly string Page;
        public readonly ReflectionTentacleVertex[] Vertices;
        public readonly int Count;

        public ReflectionTentaclesDraw(ReflectionTentaclesDrawKind kind, string page = null,
            ReflectionTentacleVertex[] vertices = null, int count = 0)
        {
            Kind = kind;
            Page = page;
            Vertices = vertices;
            Count = count;
        }
    }
}
