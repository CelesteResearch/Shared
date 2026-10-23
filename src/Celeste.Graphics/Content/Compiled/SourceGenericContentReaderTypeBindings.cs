using Celeste.Core.Reflection;

namespace Celeste.Graphics.Content.Compiled
{
    public static class SourceGenericContentReaderTypeBindings
    {
        public static void Register(ISourceActualTypeCatalog catalog,
            string actualSourceFnaAssemblyIdentity, string actualSourceFnaAssemblySimpleName)
        {
            catalog.RegisterActualType("Microsoft.Xna.Framework.Content.ListReader`1", "ListReader`1",
                actualSourceFnaAssemblyIdentity, actualSourceFnaAssemblySimpleName,
                SourceSupportedContentReaderTypeBindings.Types["Microsoft.Xna.Framework.Content.ListReader`1"]);
            catalog.RegisterActualType("Microsoft.Xna.Framework.Content.ArrayReader`1", "ArrayReader`1",
                actualSourceFnaAssemblyIdentity, actualSourceFnaAssemblySimpleName,
                SourceSupportedContentReaderTypeBindings.Types["Microsoft.Xna.Framework.Content.ArrayReader`1"]);
            catalog.RegisterActualType("Microsoft.Xna.Framework.Content.NullableReader`1", "NullableReader`1",
                actualSourceFnaAssemblyIdentity, actualSourceFnaAssemblySimpleName,
                SourceSupportedContentReaderTypeBindings.Types["Microsoft.Xna.Framework.Content.NullableReader`1"]);
            catalog.RegisterActualType("Microsoft.Xna.Framework.Content.EnumReader`1", "EnumReader`1",
                actualSourceFnaAssemblyIdentity, actualSourceFnaAssemblySimpleName,
                SourceSupportedContentReaderTypeBindings.Types["Microsoft.Xna.Framework.Content.EnumReader`1"]);
        }
    }
}
