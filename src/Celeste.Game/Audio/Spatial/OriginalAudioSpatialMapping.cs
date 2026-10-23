using System.Numerics;

namespace Celeste.Game.Audio.Spatial
{
    // Audio.Position: currentCamera.Position + (320, 180) / 2 is supplied by the scene.
    public static class OriginalAudioSpatialMapping
    {
        public static Vector3 Position(Vector2 position, Vector2 cameraCenter, bool mirrorMode)
        {
            var x = position.X - cameraCenter.X;
            if (mirrorMode) x = 0f - x;
            return new(x, position.Y - cameraCenter.Y, 0f);
        }
    }
}
