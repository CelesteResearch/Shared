using System;
using System.Reflection;

namespace Celeste.Graphics.Content.Compiled
{
    // Wire identities borrow the same typed tables used by catalog registration.
    internal static class SourceXnbWireTypeResolver
    {
        internal static Type Resolve(string wireName)
        {
            try
            {
                return Type.GetType(wireName, ResolveAssembly, ResolveType, false, false);
            }
            catch (ArgumentException)
            {
                // Not a supported standard wire shape; leave custom identity handling to its owner.
                return null;
            }
        }

        private static Assembly ResolveAssembly(AssemblyName requested)
        {
            string name = requested.Name;
            if (name == "Microsoft.Xna.Framework" || name == "Microsoft.Xna.Framework.Graphics"
                                                  || name == "Microsoft.Xna.Framework.Video" ||
                                                  name == "MonoGame.Framework" || name == "FNA"
                                                  || name == typeof(SourceContentTypeReaderManager).Assembly.GetName()
                                                      .Name)
                return typeof(SourceContentTypeReaderManager).Assembly;
            if (name == "mscorlib" || name == "System.Private.CoreLib" || name == "System.Runtime"
                || name == "System.Collections" || name == "netstandard")
                return typeof(object).Assembly;
            return null;
        }

        private static Type ResolveType(Assembly assembly, string name, bool ignoreCase)
        {
            if ((assembly == null || assembly == typeof(SourceContentTypeReaderManager).Assembly)
                && (SourceSupportedContentReaderTypeBindings.Types.TryGetValue(name, out Type type)
                    || SourceSupportedContentValueTypeBindings.Types.TryGetValue(name, out type)))
                return type;
            if (assembly == null || assembly == typeof(object).Assembly)
                return typeof(object).Assembly.GetType(name, false, ignoreCase);
            return null;
        }
    }
}
