using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.ExceptionServices;

namespace Celeste.Everest.Modules.Runtime.Assemblies
{
    internal sealed class SourceAssemblyLoadContextApi
    {
        private readonly Type contextType;
        private readonly ConstructorInfo resolvedContextConstructor;

        private SourceAssemblyLoadContextApi(Type contextType)
        {
            this.contextType = contextType;
            resolvedContextConstructor = BuildResolvedContextType(contextType);
        }

        public static SourceAssemblyLoadContextApi TryCreate()
        {
            var type = Type.GetType("System.Runtime.Loader.AssemblyLoadContext, System.Private.CoreLib")
                       ?? Type.GetType("System.Runtime.Loader.AssemblyLoadContext, System.Runtime.Loader");
            return type?.GetConstructor(new[] { typeof(string), typeof(bool) }) != null
                ? new SourceAssemblyLoadContextApi(type)
                : null;
        }

        public object Create(string name, Func<AssemblyName, Assembly> resolveManaged,
            Func<string, nint> resolveUnmanaged)
        {
            return resolvedContextConstructor.Invoke(new object[] { name, resolveManaged, resolveUnmanaged });
        }

        public object GetContext(Assembly assembly)
        {
            return Invoke(contextType.GetMethod("GetLoadContext", new[] { typeof(Assembly) }), null, assembly);
        }

        public IEnumerable<Assembly> GetAssemblies(object context)
        {
            return (IEnumerable<Assembly>)contextType.GetProperty("Assemblies").GetValue(context);
        }

        public Assembly LoadByName(object context, AssemblyName name)
        {
            return (Assembly)Invoke(contextType.GetMethod("LoadFromAssemblyName", new[] { typeof(AssemblyName) }),
                context, name);
        }

        public Assembly LoadFromStream(object context, Stream assembly, Stream symbols)
        {
            return (Assembly)Invoke(contextType.GetMethod("LoadFromStream", new[] { typeof(Stream), typeof(Stream) }),
                context, assembly, symbols);
        }

        public void Unload(object context)
        {
            Invoke(contextType.GetMethod("Unload", Type.EmptyTypes), context);
        }

        public void Subscribe(object context, string eventName, object receiver, string methodName)
        {
            var sourceEvent = contextType.GetEvent(eventName);
            var method = receiver.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
            sourceEvent.AddEventHandler(context,
                Delegate.CreateDelegate(sourceEvent.EventHandlerType, receiver, method));
        }

        private static ConstructorInfo BuildResolvedContextType(Type baseType)
        {
            // A Resolving event runs only after Default-context probing, so it cannot preserve mod resolver priority.
            var module = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("Celeste.Everest.AssemblyContexts"),
                AssemblyBuilderAccess.RunAndCollect).DefineDynamicModule("Contexts");
            var type = module.DefineType("Celeste.Everest.Modules.Runtime.Assemblies.ManagedModAssemblyLoadContext",
                TypeAttributes.Public | TypeAttributes.Sealed, baseType);
            var managedField = type.DefineField("resolveManaged", typeof(Func<AssemblyName, Assembly>),
                FieldAttributes.Private);
            var unmanagedField =
                type.DefineField("resolveUnmanaged", typeof(Func<string, nint>), FieldAttributes.Private);
            var constructor = type.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard,
                new[] { typeof(string), managedField.FieldType, unmanagedField.FieldType });
            var il = constructor.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Ldc_I4_1);
            il.Emit(OpCodes.Call, baseType.GetConstructor(new[] { typeof(string), typeof(bool) }));
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_2);
            il.Emit(OpCodes.Stfld, managedField);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_3);
            il.Emit(OpCodes.Stfld, unmanagedField);
            il.Emit(OpCodes.Ret);
            OverrideResolver(type, baseType, "Load", typeof(AssemblyName), typeof(Assembly), managedField);
            OverrideResolver(type, baseType, "LoadUnmanagedDll", typeof(string), typeof(nint), unmanagedField);
            return type.CreateTypeInfo().GetConstructor(new[]
                { typeof(string), managedField.FieldType, unmanagedField.FieldType });
        }

        private static void OverrideResolver(TypeBuilder type, Type baseType, string name, Type parameterType,
            Type returnType, FieldBuilder resolverField)
        {
            var method = type.DefineMethod(name,
                MethodAttributes.Family | MethodAttributes.Virtual | MethodAttributes.HideBySig,
                returnType, new[] { parameterType });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldfld, resolverField);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Callvirt, resolverField.FieldType.GetMethod("Invoke"));
            il.Emit(OpCodes.Ret);
            type.DefineMethodOverride(method, baseType.GetMethod(name, BindingFlags.Instance | BindingFlags.NonPublic));
        }

        private static object Invoke(MethodInfo method, object receiver, params object[] arguments)
        {
            try
            {
                return method.Invoke(receiver, arguments);
            }
            catch (TargetInvocationException exception) when (exception.InnerException != null)
            {
                ExceptionDispatchInfo.Capture(exception.InnerException).Throw();
                throw;
            }
        }
    }
}
