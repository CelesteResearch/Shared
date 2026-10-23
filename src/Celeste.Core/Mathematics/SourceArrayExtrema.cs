using Celeste.Core.Mathematics.Framework;

namespace Celeste.Core.Mathematics
{
    public static class SourceArrayExtrema
    {
        public static float Max(params float[] values)
        {
            float result = values[0];
            for (int index = 1; index < values.Length; index++)
                result = SourceFrameworkMath.Max(values[index], result);
            return result;
        }
    }
}
