using System;
using System.Reflection;

namespace Celeste.Graphics.Content.Compiled
{
    internal static class SourceContentTypeReflection
    {
        public static ConstructorInfo GetDefaultConstructor(Type type)
        {
            return type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                null, /* ReSharper disable once UseCollectionExpression */ new Type[0], null);
        }
    }
}
