using System.Numerics;

namespace Celeste.Game.Execution.Areas
{
    public static class OriginalAreaGraphicsDefaults
    {
        public static Vector4[] CreateDefaultCobwebColors()
        {
            return [new Vector4(105, 106, 106, 255) / 255f];
        }

        public static bool TryCreateCobwebColorOverride(int vanillaAreaId, out Vector4[] colors)
        {
            if (vanillaAreaId == 5)
            {
                colors = [new Vector4(159, 33, 102, 255) / 255f];
                return true;
            }

            if (vanillaAreaId == 10)
            {
                colors =
                [
                    new Vector4(66, 193, 146, 255) / 255f,
                    new Vector4(175, 54, 168, 255) / 255f,
                    new Vector4(52, 116, 166, 255) / 255f,
                ];
                return true;
            }

            colors = null;
            return false;
        }
    }
}
