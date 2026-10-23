using System.Collections.Generic;
using System.Numerics;
using Celeste.Graphics.Display;

namespace Celeste.Simulation
{
    // Vanilla _3dSoundTest is a developer map entity with no Collider or RNG.
    // Its SoundSource starts in the constructor; the engine adapter owns FMOD.
    public sealed class SoundTest3dState
    {
        public const string EventName = "event:/3d_testing";
        public readonly Vector2 Position;
        public bool Active = true, Visible = true, Collidable = true;

        public SoundTest3dState(Vector2 position)
        {
            Position = position;
        }

        public IEnumerable<ColoredGeometry> Geometry(float cameraY, int depth)
        {
            var yellow = new Vector4(1, 1, 0, 1);
            var red = new Vector4(1, 0, 0, 1);
            yield return Rectangle(Position.X - 8, Position.Y - 8, 16, 16, yellow, depth);
            foreach (var line in Hollow(Position.X - 320, cameraY, 640, 180, red, depth)) yield return line;
            foreach (var line in Hollow(Position.X - 160, cameraY, 320, 180, yellow, depth)) yield return line;
            foreach (var line in Hollow(Position.X - 480, cameraY, 960, 180, yellow, depth)) yield return line;
        }

        private static IEnumerable<ColoredGeometry> Hollow(float x, float y,
            float width, float height, Vector4 color,
            int depth)
        {
            yield return Rectangle(x, y, width, 1, color, depth);
            yield return Rectangle(x, y + height - 1, width, 1, color, depth);
            yield return Rectangle(x, y, 1, height, color, depth);
            yield return Rectangle(x + width - 1, y, 1, height, color, depth);
        }

        private static ColoredGeometry Rectangle(float x, float y, float width,
            float height, Vector4 color, int depth)
        {
            var a = new Vector2(x, y);
            var b = new Vector2(x + width, y);
            var c = new Vector2(x, y + height);
            var d = new Vector2(x + width, y + height);
            return new(depth, [
                new(a, color),
                new(b, color),
                new(c, color),
                new(b, color),
                new(d, color),
                new(c, color),
            ]);
        }
    }
}
