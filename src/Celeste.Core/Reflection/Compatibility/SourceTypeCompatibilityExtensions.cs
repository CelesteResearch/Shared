using System;

namespace Celeste.Core.Reflection.Compatibility
{
    public static class SourceTypeCompatibilityExtensions
    {
        public static bool IsCompatible(this Type type, Type other)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (other == null) throw new ArgumentNullException(nameof(other));
            if (!type._IsCompatible(other))
            {
                return other._IsCompatible(type);
            }

            return true;
        }

        private static bool _IsCompatible(this Type type, Type other)
        {
            if (type == other)
            {
                return true;
            }

            if (other.IsEnum && type == typeof(Enum))
            {
                return false;
            }

            if (other.IsValueType && type == typeof(ValueType))
            {
                return false;
            }

            if (type.IsAssignableFrom(other))
            {
                return true;
            }

            if (other.IsEnum && type.IsCompatible(Enum.GetUnderlyingType(other)))
            {
                return true;
            }

            if ((other.IsPointer || other.IsByRef) && type == typeof(nint))
            {
                return true;
            }

            if (type.IsPointer && other.IsPointer)
            {
                return true;
            }

            if (type.IsByRef && other.IsPointer)
            {
                return true;
            }

            return false;
        }
    }
}
