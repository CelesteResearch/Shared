using Celeste.Core.Reflection;

namespace Celeste.Graphics.Content.Compiled
{
    public static class SourceContentCoreLibraryTypeBindings
    {
        public static void Register(ISourceActualTypeCatalog catalog,
            string actualSourceCoreLibraryIdentity, string actualSourceCoreLibrarySimpleName)
        {
            catalog.RegisterActualType("System.Object", "Object",
                actualSourceCoreLibraryIdentity, actualSourceCoreLibrarySimpleName, typeof(object));
            catalog.RegisterActualType("System.String", "String",
                actualSourceCoreLibraryIdentity, actualSourceCoreLibrarySimpleName, typeof(string));
            catalog.RegisterActualType("System.Boolean", "Boolean",
                actualSourceCoreLibraryIdentity, actualSourceCoreLibrarySimpleName, typeof(bool));
            catalog.RegisterActualType("System.Byte", "Byte",
                actualSourceCoreLibraryIdentity, actualSourceCoreLibrarySimpleName, typeof(byte));
            catalog.RegisterActualType("System.SByte", "SByte",
                actualSourceCoreLibraryIdentity, actualSourceCoreLibrarySimpleName, typeof(sbyte));
            catalog.RegisterActualType("System.Char", "Char",
                actualSourceCoreLibraryIdentity, actualSourceCoreLibrarySimpleName, typeof(char));
            catalog.RegisterActualType("System.Int16", "Int16",
                actualSourceCoreLibraryIdentity, actualSourceCoreLibrarySimpleName, typeof(short));
            catalog.RegisterActualType("System.UInt16", "UInt16",
                actualSourceCoreLibraryIdentity, actualSourceCoreLibrarySimpleName, typeof(ushort));
            catalog.RegisterActualType("System.Int32", "Int32",
                actualSourceCoreLibraryIdentity, actualSourceCoreLibrarySimpleName, typeof(int));
            catalog.RegisterActualType("System.UInt32", "UInt32",
                actualSourceCoreLibraryIdentity, actualSourceCoreLibrarySimpleName, typeof(uint));
            catalog.RegisterActualType("System.Int64", "Int64",
                actualSourceCoreLibraryIdentity, actualSourceCoreLibrarySimpleName, typeof(long));
            catalog.RegisterActualType("System.UInt64", "UInt64",
                actualSourceCoreLibraryIdentity, actualSourceCoreLibrarySimpleName, typeof(ulong));
            catalog.RegisterActualType("System.Single", "Single",
                actualSourceCoreLibraryIdentity, actualSourceCoreLibrarySimpleName, typeof(float));
            catalog.RegisterActualType("System.Double", "Double",
                actualSourceCoreLibraryIdentity, actualSourceCoreLibrarySimpleName, typeof(double));
            catalog.RegisterActualType("System.Decimal", "Decimal",
                actualSourceCoreLibraryIdentity, actualSourceCoreLibrarySimpleName, typeof(decimal));
            catalog.RegisterActualType("System.DateTime", "DateTime",
                actualSourceCoreLibraryIdentity, actualSourceCoreLibrarySimpleName, typeof(global::System.DateTime));
            catalog.RegisterActualType("System.Nullable`1", "Nullable`1",
                actualSourceCoreLibraryIdentity, actualSourceCoreLibrarySimpleName, typeof(global::System.Nullable<>));
            catalog.RegisterActualType("System.Collections.Generic.List`1", "List`1",
                actualSourceCoreLibraryIdentity, actualSourceCoreLibrarySimpleName,
                typeof(global::System.Collections.Generic.List<>));
            catalog.RegisterActualType("System.Collections.Generic.Dictionary`2", "Dictionary`2",
                actualSourceCoreLibraryIdentity, actualSourceCoreLibrarySimpleName,
                typeof(global::System.Collections.Generic.Dictionary<,>));
        }
    }
}
