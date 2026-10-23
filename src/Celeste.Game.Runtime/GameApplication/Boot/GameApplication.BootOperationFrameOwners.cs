using System;
using System.Reflection;
using Celeste.Core.Reflection.Methods;
using Celeste.Everest.Detours;
using Celeste.Game.Execution;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        private void PublishSourceInstalledBootOperationFrameOwners()
        {
            const string assembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            var methods = Reflection.SourceMethods;

            SourceMethodDefinition Operation(int token, string owner, int typeToken, string name)
            {
                var definition = methods.RequireDefinition(assembly, token);
                if (definition.DeclaringType != owner || definition.TypeDefinitionToken != typeToken ||
                    definition.Name != name)
                    throw new InvalidOperationException(
                        "The exact Boot bridge operation differs from the selected actual original PE.");
                return definition;
            }

            var install = Operation(100680943, "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks",
                33557338,
                "InstallHook");
            Admit(typeof(EverestLegacyDynamicDataRuntime),
                "InstallCacheConstructorHook",
                false, typeof(IDisposable),
                [typeof(ConstructorInfo), typeof(Action<Action<object, Type>, object, Type>)], install);
            var boot = Operation(100677691, "Celeste.Mod.Everest", 33556765, "Boot");
            foreach (var name in new[]
                     {
                         "CompleteSourceInstalledBoot", "RegisterSourceBuiltinModulesAtBoot",
                         "RegisterSourceVanillaModuleAtBoot",
                     })
                Admit(typeof(GameApplication), name, false, typeof(void), Type.EmptyTypes, boot);
            // The factory and its construction helpers coordinate the same original startup.
            // This records their assembly owner only, without inventing original TypeDefs or MethodDefs.
            methods.RegisterActualHelperFrameOwnership(SourceMembers, typeof(GameApplicationFactory),
                typeof(GameRuntime));
            // Lua's genuine __hook operation is its original cctor closure, not GetDelegateType.
            var luaHook = Operation(100678403, "Celeste.Mod.Everest+LuaLoader+<>c", 33556894, "<.cctor>b__29_2");
            methods.RegisterActualHelperOperationFrameOwnership(SourceMembers,
                EverestLuaDetourAdapter.HookMethodMetadata, luaHook);
        }

        private void Admit(Type actualType, string actualName, bool isStatic, Type result,
            Type[] parameters, SourceMethodDefinition originalOperation)
        {
            Reflection.SourceMethods.RegisterActualHelperOperationFrameOwnership(SourceMembers,
                RequireBridge(actualType, actualName, isStatic, result, parameters), originalOperation);
        }

        private static MethodInfo RequireBridge(Type actualType, string actualName, bool isStatic,
            Type result, Type[] parameters)
        {
            const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance |
                                       BindingFlags.Static | BindingFlags.DeclaredOnly;
            var method = actualType.GetMethod(actualName, flags, null, parameters, null)
                         ?? throw new MissingMethodException(actualType.FullName, actualName);
            if (method.DeclaringType != actualType || method.IsStatic != isStatic || method.ReturnType != result ||
                method.ContainsGenericParameters)
                throw new InvalidOperationException(
                    "The exact Boot SDK bridge physical ABI differs from the actual installed source operation adaptation.");
            return method;
        }
    }
}
