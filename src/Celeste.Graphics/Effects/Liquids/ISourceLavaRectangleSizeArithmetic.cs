namespace Celeste.Graphics.Effects.Liquids
{
    public interface ISourceLavaRectangleSizeArithmetic
    {
        LavaRectangleBufferSizes Compute(float width, float height, int step);
    }
}
