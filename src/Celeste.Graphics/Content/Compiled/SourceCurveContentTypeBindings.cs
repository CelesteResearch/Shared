using Celeste.Core.Reflection;

namespace Celeste.Graphics.Content.Compiled
{
    public static class SourceCurveContentTypeBindings
    {
        public static void Register(ISourceActualTypeCatalog catalog,
            string actualSourceFnaAssemblyIdentity, string actualSourceFnaAssemblySimpleName)
        {
            catalog.RegisterActualType("Microsoft.Xna.Framework.Curve", "Curve",
                actualSourceFnaAssemblyIdentity, actualSourceFnaAssemblySimpleName,
                SourceSupportedContentValueTypeBindings.Types["Microsoft.Xna.Framework.Curve"]);
            catalog.RegisterActualType("Microsoft.Xna.Framework.Content.CurveReader", "CurveReader",
                actualSourceFnaAssemblyIdentity, actualSourceFnaAssemblySimpleName,
                SourceSupportedContentReaderTypeBindings.Types["Microsoft.Xna.Framework.Content.CurveReader"]);
        }
    }
}
