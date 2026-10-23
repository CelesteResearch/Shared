using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Celeste.Everest.Runtime.Compatibility
{
    public sealed class EverestLegacyDynamicDataHookProcess
    {
        private readonly Type DynamicData_Cache;

        private readonly FieldInfo Cache_Setters;

        private IDisposable cacheCtorHook;
        private readonly IEverestLegacyDynamicDataRuntime runtime;
        private readonly EverestMonoModPoliceProcess police;

        public EverestLegacyDynamicDataHookProcess(IEverestLegacyDynamicDataRuntime runtime,
            EverestMonoModPoliceProcess police)
        {
            this.runtime = runtime ?? throw new ArgumentNullException(nameof(runtime));
            this.police = police ?? throw new ArgumentNullException(nameof(police));
            DynamicData_Cache = runtime.DynamicDataCacheType;
            Cache_Setters = DynamicData_Cache.GetField("Setters");
        }

        public void InstallHook()
        {
            cacheCtorHook =
                runtime.InstallCacheConstructorHook(DynamicData_Cache.GetConstructor([typeof(Type)]),
                    CacheCtorHook);
        }

        public void UninstallHook()
        {
            cacheCtorHook?.Dispose();
            cacheCtorHook = null;
        }

        private void CacheCtorHook(Action<object, Type> orig, object cache, Type targetType)
        {
            orig(cache, targetType);
            var dictionary =
                (Dictionary<string, Action<object, object>>)Cache_Setters.GetValue(cache);
            while (targetType != null && targetType != targetType.BaseType)
            {
                var fields = targetType.GetFields(BindingFlags.Instance | BindingFlags.Static |
                                                  BindingFlags.Public | BindingFlags.NonPublic);
                foreach (var field in fields)
                    if (dictionary.TryGetValue(field.Name, out var setter))
                        dictionary[field.Name] = delegate(object obj, object val)
                        {
                            setter(obj, CheckTypeMismatch(val, field.FieldType, field));
                        };

                var properties = targetType.GetProperties(BindingFlags.Instance | BindingFlags.Static |
                                                          BindingFlags.Public | BindingFlags.NonPublic);
                foreach (var prop in properties)
                    if (prop.CanWrite && dictionary.TryGetValue(prop.Name, out var setter2))
                        dictionary[prop.Name] = delegate(object obj, object val)
                        {
                            setter2(obj, CheckTypeMismatch(val, prop.PropertyType, prop));
                        };

                targetType = targetType.BaseType;
            }
        }

        private object CheckTypeMismatch(object val, Type valType, MemberInfo memb)
        {
            if ((val == null ? (bool?)null : valType.IsAssignableFrom(val.GetType())) ?? true) return val;

            var perpetrator = (from f in new StackTrace().GetFrames()
                    select f.GetMethod())
                .SkipWhile(m => m?.DeclaringType == typeof(EverestLegacyDynamicDataHookProcess))
                .FirstOrDefault();
            police.ReportMonoModCrime(
                $"DynamicData field/property '{memb.DeclaringType.FullName}.{memb.Name}' setter type mismatch: expected {valType.FullName}, got {val?.GetType()?.FullName ?? "null"}",
                perpetrator);
            return Convert.ChangeType(val, valType);
        }
    }
}
