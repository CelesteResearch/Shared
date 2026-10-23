using System.Numerics;

namespace Celeste.Core.Mathematics
{
    public static class Vector3ArrayConversion
    {
        public static Vector3? ToVector3(float[] array)
        {
            if (array == null) return null;
            if (array.Length == 1) return new Vector3(array[0]);
            if (array.Length != 3) return null;
            return new Vector3(array[0], array[1], array[2]);
        }
    }
}
