using System.Numerics;

namespace Celeste.Core.Mathematics
{
    public static class SourceVector2Formatting
    {
        public static string Format(Vector2 value)
        {
            return string.Concat(new string[]
            {
                "{X:", value.X.ToString(), " Y:", value.Y.ToString(), "}"
            });
        }
    }
}
