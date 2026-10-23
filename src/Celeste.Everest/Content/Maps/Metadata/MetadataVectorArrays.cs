using System.Numerics;

namespace Celeste.Everest.Content.Maps.Metadata
{
    public static class MetadataVectorArrays
    {
        public static Vector3? ToVector3(float[] values)
        {
            if (values == null) return null;
            if (values.Length == 1) return new Vector3(values[0]);
            if (values.Length != 3) return null;
            return new Vector3(values[0], values[1], values[2]);
        }
    }
}
