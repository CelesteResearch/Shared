using System;
using System.Reflection;
using Celeste.Everest.Runtime.Compatibility;
using MonoMod.RuntimeDetour;
using MonoMod.Utils;

namespace Celeste.Everest.Detours
{
    public sealed class EverestLegacyDynamicDataRuntime : IEverestLegacyDynamicDataRuntime
    {
        public Type DynamicDataCacheType => typeof(DynamicData).GetNestedType("_Cache_", BindingFlags.NonPublic);

        public IDisposable InstallCacheConstructorHook(ConstructorInfo constructor,
            Action<Action<object, Type>, object, Type> replacement)
        {
            return new Hook(constructor, replacement);
        }
    }
}
