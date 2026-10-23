using System.Numerics;

namespace Celeste.Game.Presentation.Hud.CoreMessages
{
    public static class CoreMessageLayout
    {
        public static Vector2 UnlockedPosition(Vector2 position, Vector2 camera)
        {
            var center = camera + new Vector2(160, 90);
            return (position - camera + (position - center) * .2f) * 6f;
        }

        public static Vector2 LockedPosition(Vector2 position, Vector2 camera) => (position - camera) * 6f;
    }
}
