using System.Numerics;
using System.Runtime.InteropServices;

namespace Celeste.Core.Rendering.Sprites
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct SourceSpriteShaderTransform
    {
        public readonly float Value0, Value1, Value2, Value3;
        public readonly float Value4, Value5, Value6, Value7;
        public readonly float Value8, Value9, Value10, Value11;
        public readonly float Value12, Value13, Value14, Value15;

        public SourceSpriteShaderTransform(in Matrix4x4 transform, int viewportWidth, int viewportHeight)
        {
            var x = (float)(2.0 / viewportWidth);
            var y = (float)(-2.0 / viewportHeight);
            Value0 = x * transform.M11 - transform.M14;
            Value1 = x * transform.M21 - transform.M24;
            Value2 = x * transform.M31 - transform.M34;
            Value3 = x * transform.M41 - transform.M44;
            Value4 = y * transform.M12 + transform.M14;
            Value5 = y * transform.M22 + transform.M24;
            Value6 = y * transform.M32 + transform.M34;
            Value7 = y * transform.M42 + transform.M44;
            Value8 = transform.M13;
            Value9 = transform.M23;
            Value10 = transform.M33;
            Value11 = transform.M43;
            Value12 = transform.M14;
            Value13 = transform.M24;
            Value14 = transform.M34;
            Value15 = transform.M44;
        }
    }
}
