using System;
using System.Numerics;
using System.Text;

namespace Celeste.Core.Geometry.Intersections
{
    internal static class SourceGeometryFormatting
    {
        internal static string Vector(Vector3 value, Func<float, string> format)
        {
            var builder = new StringBuilder(32);
            builder.Append("{X:");
            builder.Append(format(value.X));
            builder.Append(" Y:");
            builder.Append(format(value.Y));
            builder.Append(" Z:");
            builder.Append(format(value.Z));
            builder.Append("}");
            return builder.ToString();
        }

        internal static string Plane(Plane value, Func<float, string> format)
        {
            return "{Normal:" + Vector(value.Normal, format) + " D:" + format(value.D) + "}";
        }
    }
}
