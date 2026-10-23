namespace Celeste.Simulation.Gameplay.Hazards.Spinners.Dust
{
    public sealed class DustNoiseTexture
    {
        public const int Width = 128, Height = 72;

        public readonly string Name;

        // Original Color(float,0,0,0), not alpha-premultiplied random red.
        public readonly byte[] Rgba = new byte[Width * Height * 4];
        public bool IsDisposed { get; private set; }

        public DustNoiseTexture(string name)
        {
            Name = name;
        }

        public void Dispose()
        {
            IsDisposed = true;
        }
    }
}
