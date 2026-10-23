namespace Celeste.Graphics.Effects.Displacement
{
    public readonly struct DisplacementMask(float x, float y, float width, float height)
    {
        public readonly float X = x, Y = y, Width = width, Height = height;
    }
}
