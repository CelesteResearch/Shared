namespace Celeste.Graphics.Geometry.TwoD.Camera
{
    // Value storage only; writing this public Camera.Viewport never dirties matrices.
    public struct CameraViewport
    {
        public int X, Y, Width, Height;
        public float MinDepth, MaxDepth;
        public float AspectRatio => Height != 0 && Width != 0 ? (float)Width / Height : 0f;

        public CameraViewport(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            MinDepth = 0f;
            MaxDepth = 1f;
        }
    }
}
