namespace Celeste.Graphics.Effects.Sampling
{
    public readonly struct RenderTargetReference(object handle, int width, int height)
    {
        public readonly object Handle = handle;
        public readonly int Width = width, Height = height;
    }
}
