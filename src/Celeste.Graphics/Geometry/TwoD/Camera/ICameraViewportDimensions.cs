namespace Celeste.Graphics.Geometry.TwoD.Camera
{
    // Reads the actual engine logical viewport at the default constructor boundary.
    public interface ICameraViewportDimensions
    {
        int Width { get; }
        int Height { get; }
    }
}
