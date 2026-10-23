using Mono.Cecil;
using System;
using System.IO;
using System.Reflection;

namespace MonoMod.Utils
{
    public static partial class ReflectionHelper
    {
        internal static Assembly LoadInOwnerContext(ModuleDefinition module)
        {
            Helpers.ThrowIfArgumentNull(module);
            var load = OwnerAssemblyLoader.Load;
            if (load == null)
                return Load(module);

            using (var stream = new MemoryStream())
            {
                module.Write(stream);
                stream.Position = 0;
                return load(stream);
            }
        }

        private static class OwnerAssemblyLoader
        {
            internal static readonly Func<Stream, Assembly>? Load = Create();

            private static Func<Stream, Assembly>? Create()
            {
                if (!IsCoreBCL)
                    return null;

                var contextType = Type.GetType(
                                      "System.Runtime.Loader.AssemblyLoadContext, System.Private.CoreLib", false)
                                  ?? Type.GetType("System.Runtime.Loader.AssemblyLoadContext, System.Runtime.Loader",
                                      true)!;
                var getContext = contextType.GetMethod("GetLoadContext", BindingFlags.Public | BindingFlags.Static,
                                     null, new[] { typeof(Assembly) }, null)
                                 ?? throw new MissingMethodException(contextType.FullName, "GetLoadContext(Assembly)");
                var context = getContext.Invoke(null, new object[] { typeof(ReflectionHelper).Assembly })
                              ?? throw new InvalidOperationException("MonoMod.Utils has no assembly load context.");
                var load = contextType.GetMethod("LoadFromStream", BindingFlags.Public | BindingFlags.Instance,
                               null, new[] { typeof(Stream) }, null)
                           ?? throw new MissingMethodException(contextType.FullName, "LoadFromStream(Stream)");
                return (Func<Stream, Assembly>)Delegate.CreateDelegate(typeof(Func<Stream, Assembly>), context, load);
            }
        }
    }
}
