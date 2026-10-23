namespace Celeste.Graphics.Geometry.TwoD.Camera
{
    // Value storage only; writing this public Camera.Viewport never dirties matrices.
    public struct CameraViewport(int x, int y, int width, int height)
    {
        public int X = x, Y = y, Width = width, Height = height;
        public float MinDepth = 0f, MaxDepth = 1f;
        public float AspectRatio => Height != 0 && Width != 0 ? (float)Width / Height : 0f;
    }
}
