using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using KeraLua;
using NLua;
using Mono.Cecil.Cil;
using MonoMod.RuntimeDetour;
using MonoMod.Utils;
using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Types.Modules;
using Celeste.Everest.Diagnostics.Logging;

namespace Celeste.Everest.Scripting.Lua
{
    public partial class EverestLuaLoaderProcess
    {
        private readonly string PathEverest;
        private readonly SourceMemberCatalog SourceMembers;
        private readonly EverestContentRegistry Content;
        private readonly EverestLoggerProcess Logger;
        public EverestLuaTypeBuilderProcess TypeBuilder { get; }

        public EverestLuaLoaderProcess(string pathEverest, EverestContentRegistry content, EverestLoggerProcess logger,
            SourceMemberCatalog sourceMembers)
        {
            SourceMembers = sourceMembers ?? throw new ArgumentNullException(nameof(sourceMembers));
            PathEverest = pathEverest;
            Content = content;
            Logger = logger;
            TypeBuilder = new EverestLuaTypeBuilderProcess(this, pathEverest, content, logger);
            _Preload = delegate(string name)
            {
                if (string.IsNullOrEmpty(name)) return false;
                if (_Preloaded.Contains(name) || _Preloaded.Contains(name + ".")) return true;
                foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    if (name != assembly.GetName().Name && name != assembly.FullName) continue;
                    Precache(assembly);
                    return true;
                }

                // Assemblies can be loaded after Lua initialization, including by mods.
                foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()) Precache(assembly);
                return _Preloaded.Contains(name) || _Preloaded.Contains(name + ".");
            };

            _VFS = delegate(string ctx, string name)
            {
                if (!string.IsNullOrEmpty(name))
                {
                    name = name.Replace('.', '/');
                    if (!string.IsNullOrEmpty(ctx))
                    {
                        int num = ctx.IndexOf(':');
                        ctx = ((num != -1) ? ctx.Substring(0, num + 1) : null);
                    }

                    string text = null;
                    string text2 = null;
                    if ((!name.Contains(":") && !string.IsNullOrEmpty(ctx) &&
                         Content.TryGet<AssetTypeLua>(ctx + "/" + name, out var metadata)) ||
                        Content.TryGet<AssetTypeLua>(name, out metadata))
                    {
                        text = ReadText(metadata);
                        string text3 = metadata.Source.DefaultName;
                        if (string.IsNullOrEmpty(text3))
                        {
                            text3 = metadata.Source.Name;
                        }

                        if (string.IsNullOrEmpty(text3))
                        {
                            text3 = "???";
                        }

                        text2 = "Mods/" + text3 + "/" + metadata.PathVirtual + ".lua";
                    }

                    return new string[2] { text, text2 };
                }

                return (string[])null;
            };

            _Hook = delegate(MethodBase from, NLua.LuaFunction to)
            {
                string environmentVariable = Environment.GetEnvironmentVariable("MONOMOD_DMDType");
                Environment.SetEnvironmentVariable("MONOMOD_DMDType", "Cecil");
                try
                {
                    ParameterInfo[] parameters = from.GetParameters();
                    Type[] array2;
                    if (!from.IsStatic)
                    {
                        Type[] array = new Type[parameters.Length + 1];
                        array2 = new Type[parameters.Length + 2];
                        array[0] = from.GetThisParamType();
                        array2[1] = from.GetThisParamType();
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            array[i + 1] = parameters[i].ParameterType;
                            array2[i + 2] = parameters[i].ParameterType;
                        }
                    }
                    else
                    {
                        Type[] array = new Type[parameters.Length];
                        array2 = new Type[parameters.Length + 1];
                        for (int j = 0; j < parameters.Length; j++)
                        {
                            array[j] = parameters[j].ParameterType;
                            array2[j + 1] = parameters[j].ParameterType;
                        }
                    }

                    Type delegateType = HookHelper.GetDelegateType(from);
                    array2[0] = delegateType;
                    Type type = (from as MethodInfo)?.ReturnType ?? typeof(void);
                    MethodInfo target;
                    using (DynamicMethodDefinition dynamicMethodDefinition =
                           new DynamicMethodDefinition("HookProxy_" + to.ToString(), type, array2))
                    {
                        ILProcessor iLProcessor = dynamicMethodDefinition.GetILProcessor();
                        iLProcessor.EmitNewReference(to, out var _);
                        iLProcessor.Emit(OpCodes.Ldc_I4, array2.Length);
                        iLProcessor.Emit(OpCodes.Newarr, typeof(object));
                        for (int k = 0; k < array2.Length; k++)
                        {
                            int num = ((!from.IsStatic && k <= 1) ? ((k + 1) % 2) : k);
                            Type type2 = array2[num];
                            if (type2.IsByRef)
                            {
                                type2 = type2.GetElementType();
                            }

                            bool isValueType = type2.IsValueType;
                            iLProcessor.Emit(OpCodes.Dup);
                            iLProcessor.Emit(OpCodes.Ldc_I4, k);
                            iLProcessor.Emit(OpCodes.Ldarg, num);
                            if (isValueType)
                            {
                                iLProcessor.Emit(OpCodes.Box, type2);
                            }

                            iLProcessor.Emit(OpCodes.Stelem_Ref);
                        }

                        iLProcessor.Emit(OpCodes.Callvirt, m_LuaFunction_Call);
                        if (type != typeof(void))
                        {
                            iLProcessor.Emit(OpCodes.Ldc_I4_0);
                            iLProcessor.Emit(OpCodes.Ldelem_Ref);
                            if (type.IsValueType)
                            {
                                iLProcessor.Emit(OpCodes.Unbox_Any, type);
                            }
                        }
                        else
                        {
                            iLProcessor.Emit(OpCodes.Pop);
                        }

                        iLProcessor.Emit(OpCodes.Ret);
                        target = dynamicMethodDefinition.Generate();
                    }

                    return new Hook(from, target);
                }
                finally
                {
                    Environment.SetEnvironmentVariable("MONOMOD_DMDType", environmentVariable);
                }
            };
        }

        public class CachedNamespace
        {
            public readonly string Name;

            public readonly CachedNamespace Parent;

            public readonly string FullName;

            public readonly Dictionary<string, CachedNamespace>
                NamespaceMap = new Dictionary<string, CachedNamespace>();

            public readonly Dictionary<string, CachedType> TypeMap = new Dictionary<string, CachedType>();

            public CachedNamespace[] Namespaces => NamespaceMap.Values.ToArray();

            public CachedType[] Types => TypeMap.Values.ToArray();

            public int Count => NamespaceMap.Count + TypeMap.Count;

            public CachedNamespace(CachedNamespace ns, string name, string fullName = null)
            {
                Name = name;
                Parent = ns;
                FullName = fullName ?? ((ns == null || ns.Name == null) ? name : (ns.FullName + "." + name));
            }

            public CachedNamespace GetNamespace(string key)
            {
                if (NamespaceMap.TryGetValue(key, out var value))
                {
                    return value;
                }

                return null;
            }

            public CachedType GetType(string key)
            {
                if (TypeMap.TryGetValue(key, out var value))
                {
                    return value;
                }

                return null;
            }
        }

        public class CachedType
        {
            private readonly EverestLuaLoaderProcess loader;
            public readonly string Name;

            public readonly CachedNamespace Namespace;

            public readonly CachedType Parent;

            public readonly string FullName;

            public readonly Type Type;
            private readonly SourceTypeDefinition sourceDefinition;

            public readonly Dictionary<string, CachedType> NestedTypeMap = new Dictionary<string, CachedType>();

            public readonly Dictionary<string, CachedNamespace>
                NamespaceMap = new Dictionary<string, CachedNamespace>();

            public CachedNamespace GetNamespace(string key) =>
                NamespaceMap.TryGetValue(key, out var value) ? value : null;

            public CachedType GetType(string key) => NestedTypeMap.TryGetValue(key, out var value) ? value : null;

            private LuaTable nilMemberTable;

            private Dictionary<string, LuaTable> membersCache;

            public CachedType[] NestedTypes => NestedTypeMap.Values.ToArray();

            private CachedType(EverestLuaLoaderProcess loader, Type type, string fullName,
                SourceTypeDefinition sourceDefinition)
            {
                this.loader = loader;
                Type = type ?? throw new ArgumentNullException(nameof(type));
                FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
                this.sourceDefinition = sourceDefinition;
                int nested = FullName.LastIndexOf('+');
                int separator = nested >= 0 ? nested : FullName.LastIndexOf('.');
                Name = FullName.Substring(separator + 1);
            }

            public CachedType(EverestLuaLoaderProcess loader, CachedNamespace ns, Type type, string fullName,
                SourceTypeDefinition sourceDefinition = null)
                : this(loader, type, fullName, sourceDefinition)
            {
                Namespace = ns;
            }

            public CachedType(EverestLuaLoaderProcess loader, CachedType parent, Type type, string fullName,
                SourceTypeDefinition sourceDefinition = null)
                : this(loader, type, fullName, sourceDefinition)
            {
                Parent = parent;
            }

            private readonly Dictionary<string, SourcePhysicalMemberBinding> importedStaticMembers =
                new Dictionary<string, SourcePhysicalMemberBinding>();

            private SourcePhysicalMemberBinding GetImportedStaticMember(string key)
            {
                if (sourceDefinition == null || string.IsNullOrEmpty(key)) return null;
                if (importedStaticMembers.TryGetValue(key, out var cached)) return cached;
                SourceMemberDefinition selected = null;
                foreach (var definition in loader.SourceMembers.GetOriginalMemberDefinitions(
                             sourceDefinition.AssemblyIdentity, sourceDefinition.Identity, false))
                {
                    if (!definition.IsStatic || !definition.IsPublic || definition.IndexParameterCount != 0) continue;
                    string alias = string.Empty;
                    for (int i = 0; i < definition.Name.Length && !char.IsLower(definition.Name[i]); i++)
                        alias += char.ToLower(definition.Name[i]);
                    alias += definition.Name.Substring(alias.Length);
                    if (definition.Name == key || alias == key)
                    {
                        selected = definition;
                        break;
                    }
                }

                if (selected == null)
                {
                    importedStaticMembers.Add(key, null);
                    return null;
                }

                // Unchanged CLR static members keep NLua's original reflection/conversion protocol.
                foreach (MemberInfo member in Type.GetMember(selected.Name,
                             BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy))
                {
                    if (member is FieldInfo ||
                        member is PropertyInfo property && property.GetIndexParameters().Length == 0)
                    {
                        importedStaticMembers.Add(key, null);
                        return null;
                    }
                }

                var binding = loader.SourceMembers.RequireBinding(Type, selected);
                importedStaticMembers.Add(key, binding);
                return binding;
            }

            public bool TryGetStaticMember(string key, out object value, out string valueTypeName)
            {
                var binding = GetImportedStaticMember(key);
                value = null;
                valueTypeName = null;
                if (binding == null) return false;
                if (!binding.CanRead || binding.OriginalKind == SourceMemberKind.Property &&
                    ((MethodAttributes)binding.Definition.GetterAttributes & MethodAttributes.MemberAccessMask) !=
                    MethodAttributes.Public)
                    throw new MemberAccessException("Lua imported member is not publicly readable: " +
                                                    binding.Definition.QualifiedName);
                value = binding.Read(null);
                valueTypeName = binding.Definition.ValueTypeIdentity;
                return true;
            }

            public string GetStaticMemberTypeName(string key) =>
                GetImportedStaticMember(key)?.Definition.ValueTypeIdentity;

            public bool TrySetStaticMember(string key, object value)
            {
                var binding = GetImportedStaticMember(key);
                if (binding == null) return false;
                if (!binding.CanWrite || binding.OriginalKind == SourceMemberKind.Property &&
                    ((MethodAttributes)binding.Definition.SetterAttributes & MethodAttributes.MemberAccessMask) !=
                    MethodAttributes.Public)
                    throw new MemberAccessException("Lua imported member is not publicly writable: " +
                                                    binding.Definition.QualifiedName);
                Type valueType = Nullable.GetUnderlyingType(binding.ValueType) ?? binding.ValueType;
                if (value != null && !valueType.IsInstanceOfType(value))
                {
                    value = valueType.IsEnum
                        ? Enum.ToObject(valueType, Convert.ChangeType(value, Enum.GetUnderlyingType(valueType),
                            System.Globalization.CultureInfo.InvariantCulture))
                        : Convert.ChangeType(value, valueType, System.Globalization.CultureInfo.InvariantCulture);
                }

                binding.Write(null, value);
                return true;
            }

            public LuaTable GetMembers(string key)
            {
                if (membersCache == null)
                {
                    membersCache = new Dictionary<string, LuaTable>();
                    MemberInfo[] members =
                        Type.GetMembers(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
                    foreach (MemberInfo memberInfo in members)
                    {
                        Type value = (memberInfo as PropertyInfo)?.PropertyType ?? (memberInfo as FieldInfo)?.FieldType;
                        string name = memberInfo.Name;
                        if (!membersCache.TryGetValue(name, out var value2))
                        {
                            value2 = NewTable();
                            value2[1] = NewTable();
                            value2[2] = value;
                            membersCache.Add(name, value2);
                        }

                        InsertIntoTable((LuaTable)value2[1], memberInfo);
                        string text = string.Empty;
                        for (int j = 0; j < name.Length && !char.IsLower(name[j]); j++)
                        {
                            text += char.ToLower(name[j]);
                        }

                        text += name.Substring(text.Length);
                        if (name != text)
                        {
                            if (!membersCache.TryGetValue(text, out var value3))
                            {
                                value3 = NewTable();
                                value3[1] = NewTable();
                                value3[2] = value;
                                membersCache.Add(text, value3);
                            }

                            InsertIntoTable((LuaTable)value3[1], memberInfo);
                        }
                    }
                }

                if (membersCache.TryGetValue(key, out var value4))
                {
                    return value4;
                }

                if (nilMemberTable == null)
                {
                    nilMemberTable = NewTable();
                    LuaTable luaTable = nilMemberTable;
                    object field = 1;
                    object value5 = (nilMemberTable[2] = null);
                    luaTable[field] = value5;
                }

                return nilMemberTable;
            }

            private LuaTable NewTable()
            {
                loader.Context.State.NewTable();
                return new LuaTable(loader.Context.State.Ref(LuaRegistry.Index), loader.Context);
            }

            private static void InsertIntoTable(LuaTable table, object val)
            {
                table[table.Keys.Count + 1] = val;
            }
        }

        public static class HookHelper
        {
            public delegate void Action();

            public delegate TResult Func<TResult>();

            public delegate void Action<T1>(T1 arg1);

            public delegate TResult Func<T1, TResult>(T1 arg1);

            public delegate void Action<T1, T2>(T1 arg1, T2 arg2);

            public delegate TResult Func<T1, T2, TResult>(T1 arg1, T2 arg2);

            public delegate void Action<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3);

            public delegate TResult Func<T1, T2, T3, TResult>(T1 arg1, T2 arg2, T3 arg3);

            public delegate void Action<T1, T2, T3, T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4);

            public delegate TResult Func<T1, T2, T3, T4, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4);

            public delegate void Action<T1, T2, T3, T4, T5>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

            public delegate TResult Func<T1, T2, T3, T4, T5, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

            public delegate void Action<T1, T2, T3, T4, T5, T6>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6);

            public delegate TResult Func<T1, T2, T3, T4, T5, T6, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5,
                T6 arg6);

            public delegate void Action<T1, T2, T3, T4, T5, T6, T7>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5,
                T6 arg6,
                T7 arg7);

            public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4,
                T5 arg5,
                T6 arg6, T7 arg7);

            public delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5,
                T6 arg6, T7 arg7, T8 arg8);

            public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4,
                T5 arg5, T6 arg6, T7 arg7, T8 arg8);

            public delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5,
                T6 arg6, T7 arg7, T8 arg8, T9 arg9);

            public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(T1 arg1, T2 arg2, T3 arg3,
                T4 arg4,
                T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9);

            public delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T1 arg1, T2 arg2, T3 arg3, T4 arg4,
                T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10);

            public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(T1 arg1, T2 arg2, T3 arg3,
                T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10);

            public delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T1 arg1, T2 arg2, T3 arg3,
                T4 arg4,
                T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11);

            public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(T1 arg1, T2 arg2,
                T3 arg3,
                T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11);

            public delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T1 arg1, T2 arg2, T3 arg3,
                T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12);

            public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(T1 arg1, T2 arg2,
                T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12);

            public delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T1 arg1, T2 arg2,
                T3 arg3,
                T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13);

            public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(T1 arg1,
                T2 arg2,
                T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12,
                T13 arg13);

            public delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T1 arg1, T2 arg2,
                T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12,
                T13 arg13,
                T14 arg14);

            public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(T1 arg1,
                T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12,
                T13 arg13, T14 arg14);

            public delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T1 arg1,
                T2 arg2,
                T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12,
                T13 arg13,
                T14 arg14, T15 arg15);

            public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
                T1 arg1,
                T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12,
                T13 arg13, T14 arg14, T15 arg15);

            public delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T1 arg1,
                T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12,
                T13 arg13, T14 arg14, T15 arg15, T16 arg16);

            public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16,
                TResult>(
                T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11,
                T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16);

            private static readonly Type[] actions;

            private static readonly Type[] funcs;

            static HookHelper()
            {
                IOrderedEnumerable<Type> source = from m in typeof(HookHelper).GetNestedTypes()
                    orderby m.GetMethod("Invoke").GetParameters().Length
                    select m;
                actions = source.Where((Type m) => m.GetMethod("Invoke").ReturnType == typeof(void)).ToArray();
                funcs = source.Where((Type m) => m.GetMethod("Invoke").ReturnType != typeof(void)).ToArray();
            }

            public static Type GetDelegateType(MethodBase signature)
            {
                Type type = (signature as MethodInfo)?.ReturnType ?? typeof(void);
                bool flag = type != typeof(void);
                ParameterInfo[] parameters = signature.GetParameters();
                Type[] array;
                if (!signature.IsStatic)
                {
                    array = new Type[parameters.Length + ((!flag) ? 1 : 2)];
                    array[0] = signature.GetThisParamType();
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        array[i + 1] = parameters[i].ParameterType;
                    }
                }
                else
                {
                    array = new Type[parameters.Length + (flag ? 1 : 0)];
                    for (int j = 0; j < parameters.Length; j++)
                    {
                        array[j] = parameters[j].ParameterType;
                    }
                }

                int num = array.Length;
                if (flag)
                {
                    array[num - 1] = type;
                }

                if (num >= actions.Length)
                {
                    return null;
                }

                Type type2 = (flag ? funcs : actions)[num - (flag ? 1 : 0)];
                if (num == 0)
                {
                    return type2;
                }

                return type2.MakeGenericType(array);
            }
        }

        public readonly CachedNamespace Global = new CachedNamespace(null, null);

        public readonly Dictionary<string, CachedNamespace> AllNamespaces = new Dictionary<string, CachedNamespace>();

        public readonly Dictionary<string, CachedType> AllTypes = new Dictionary<string, CachedType>();

        private readonly HashSet<string> _Preloaded = new HashSet<string>();

        private readonly MethodInfo m_LuaFunction_Call = typeof(NLua.LuaFunction).GetMethod("Call");

        private Func<string, string, object[]> _Run;

        private Func<string, bool> _Preload;
        private Func<string, string, string[]> _VFS;
        private Func<MethodBase, NLua.LuaFunction, Hook> _Hook;

        private readonly HashSet<Assembly> loadedRuntimeAssemblies =
            new HashSet<Assembly>(EverestLuaActualAssemblyRegistry.ReferenceComparer);

        private readonly Dictionary<(string Assembly, string Name), CachedNamespace> importContainers =
            new Dictionary<(string Assembly, string Name), CachedNamespace>();

        private readonly Dictionary<(object Assembly, string Name), CachedType> qualifiedTypes =
            new Dictionary<(object Assembly, string Name), CachedType>();

        private Func<string, object[]> _Require;

        private Func<string, LuaTable> _Symbol;

        public NLua.Lua Context { get; private set; }

        public bool IsDebug { get; private set; }

        public void Initialize()
        {
            Stream stream = null;
            string code;
            try
            {
                string path = Path.Combine(PathEverest, "boot.lua");
                EverestContentAsset metadata;
                if (File.Exists(path))
                {
                    Logger.Info("Everest.LuaLoader", "Found external Lua boot script.");
                    stream = new FileStream(path, FileMode.Open, FileAccess.Read);
                }
                else if (Content.TryGet<AssetTypeLua>("Lua/boot", out metadata))
                {
                    Logger.Verbose("Everest.LuaLoader", "Found built-in Lua boot script.");
                    stream = metadata.Stream;
                }

                if (stream == null)
                {
                    Logger.Warn("Everest.LuaLoader", "Lua boot script not found, disabling Lua mod support.");
                    return;
                }

                Logger.Verbose("Everest.LuaLoader", "Creating Lua context and running Lua boot script.");
                using StreamReader streamReader = new StreamReader(stream);
                code = streamReader.ReadToEnd();
            }
            finally
            {
                stream?.Dispose();
            }

            Context = new NLua.Lua();
            Context["__source_lualoader"] = this;
            Context["__source_logger"] = Logger;
            object[] array = null;
            IsDebug = Environment.GetEnvironmentVariable("LOCAL_LUA_DEBUGGER_VSCODE") == "1";
            if (IsDebug)
            {
                object[] array2 =
                    Context.DoString("require(\"lldebugger\").start(); return function(...) return load(...) end",
                        "debuginit");
                NLua.LuaFunction load = (NLua.LuaFunction)array2[0];
                _Run = (string text, string text2) => ((NLua.LuaFunction)load.Call(text, text2)[0]).Call();
            }
            else
            {
                Context.UseTraceback = true;
                _Run = (string chunk, string chunkName) => Context.DoString(chunk, chunkName);
            }

            array = Run(code, "boot.lua");
            if (IsDebug)
            {
                object[] array3 = Context.DoString("return function(...) return require(...) end", "debugutils");
                NLua.LuaFunction require = (NLua.LuaFunction)array3[0];
                _Require = (string name) => require.Call(name);
            }
            else
            {
                NLua.LuaFunction require2 = (NLua.LuaFunction)array[2];
                _Require = (string name) => require2.Call(name);
            }

            NLua.LuaFunction symbol = (NLua.LuaFunction)array[3];
            _Symbol = (string name) => symbol.Call(name).FirstOrDefault() as LuaTable;
            AllNamespaces[""] = Global;
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()) Precache(assembly);
            foreach (string assemblyIdentity in SourceMembers.OriginalTypeNames
                         .Select(binding => SourceMembers.GetOriginalTypeDefinition(binding.Key).AssemblyIdentity)
                         .Distinct().ToArray())
                PrecacheSourceAssembly(assemblyIdentity);
            array = ((NLua.LuaFunction)array[0]).Call(_Preload, _VFS, _Hook);
            if (array != null)
            {
                object[] array4 = array;
                for (int num = 0; num < array4.Length; num++)
                {
                    Console.WriteLine(array4[num]);
                }
            }

            TypeBuilder.Initialize();
        }

        public object[] Run(string code, string path)
        {
            return _Run(code, path);
        }

        public void Precache(Assembly actualCarrier)
        {
            if (actualCarrier == null || Context == null) return;
            LoadRuntimeAssembly(actualCarrier);
            _Preloaded.Add(actualCarrier.GetName().Name);
            _Preloaded.Add(actualCarrier.FullName);
            foreach (Type type in actualCarrier.GetTypesSafe())
                if (type.FullName != null)
                    PrecacheRuntimeType(type, type.FullName, (int)type.Attributes);
            foreach (string identity in SourceMembers.OriginalTypeNames
                         .Where(binding => binding.Key.Assembly == actualCarrier)
                         .Select(binding => SourceMembers.GetOriginalTypeDefinition(binding.Key).AssemblyIdentity)
                         .Distinct().ToArray())
                PrecacheSourceAssembly(identity);
        }

        public void PrecacheSourceAssembly(string originalAssemblyIdentity)
        {
            if (originalAssemblyIdentity == null) throw new ArgumentNullException(nameof(originalAssemblyIdentity));
            if (Context == null) return;
            var definitions = SourceMembers.OriginalTypeNames
                .Select(binding => SourceMembers.GetOriginalTypeDefinition(binding.Key))
                .Where(definition => definition.AssemblyIdentity == originalAssemblyIdentity)
                .GroupBy(definition => definition.MetadataToken).Select(group => group.First())
                .OrderBy(definition => definition.MetadataToken).ToArray();
            _Preloaded.Add(new AssemblyName(originalAssemblyIdentity).Name);
            _Preloaded.Add(originalAssemblyIdentity);
            foreach (var definition in definitions) PrecacheSourceType(definition);
        }

        private CachedType PrecacheSourceType(SourceTypeDefinition definition)
        {
            Type type = SourceMembers.GetActualSourceType(definition.AssemblyIdentity, definition.Identity);
            LoadRuntimeAssembly(type.Assembly);
            return PrecacheRuntimeType(type, definition.Identity, definition.Attributes, definition);
        }

        private void LoadRuntimeAssembly(Assembly assembly)
        {
            if (assembly.IsDynamic || loadedRuntimeAssemblies.Contains(assembly)) return;
            EverestLuaActualAssemblyRegistry.Register(Context, assembly);
            loadedRuntimeAssemblies.Add(assembly);
        }

        private CachedType PrecacheRuntimeType(Type type, string fullName, int attributes,
            SourceTypeDefinition importedDefinition = null)
        {
            object origin = importedDefinition == null ? (object)type.Assembly : importedDefinition.AssemblyIdentity;
            var key = (origin, fullName);
            if (qualifiedTypes.TryGetValue(key, out var existing)) return existing;
            _Preloaded.Add(fullName);
            int nested = fullName.LastIndexOf('+');
            if (nested >= 0)
            {
                if (((TypeAttributes)attributes & TypeAttributes.VisibilityMask) != TypeAttributes.NestedPublic)
                    return null;
                if (!qualifiedTypes.TryGetValue(key, out var cached))
                {
                    string parentName = fullName.Substring(0, nested);
                    object parent;
                    if (importedDefinition == null)
                        parent = PrecacheRuntimeType(type.DeclaringType, parentName,
                            (int)type.DeclaringType.Attributes);
                    else
                        parent = GetImportParent(importedDefinition.AssemblyIdentity, parentName);
                    if (parent == null) return null;
                    cached = parent is CachedType parentType
                        ? new CachedType(this, parentType, type, fullName, importedDefinition)
                        : new CachedType(this, (CachedNamespace)parent, type, fullName, importedDefinition);
                    qualifiedTypes.Add(key, cached);
                    if (parent is CachedType actualParent)
                    {
                        if (importedDefinition != null || !actualParent.NestedTypeMap.ContainsKey(cached.Name))
                            actualParent.NestedTypeMap[cached.Name] = cached;
                    }
                    else
                    {
                        var container = (CachedNamespace)parent;
                        container.TypeMap[cached.Name] = cached;
                    }

                    if (importedDefinition != null || !AllTypes.ContainsKey(cached.FullName))
                        AllTypes[cached.FullName] = cached;
                }

                return cached;
            }

            int separator = fullName.LastIndexOf('.');
            if (((TypeAttributes)attributes & TypeAttributes.VisibilityMask) == TypeAttributes.Public && separator >= 0)
                _Preloaded.Add(fullName.Substring(0, separator) + ".");
            string ns = separator < 0 ? string.Empty : fullName.Substring(0, separator);
            var cachedNamespace = GetOrCreateNamespace(ns);

            var value = new CachedType(this, cachedNamespace, type, fullName, importedDefinition);
            qualifiedTypes.Add(key, value);
            // Unqualified physical names retain the original first-loaded lookup policy.
            // Source imports explicitly select their already-bound runtime declaration.
            if (importedDefinition != null || !cachedNamespace.TypeMap.ContainsKey(value.Name))
                cachedNamespace.TypeMap[value.Name] = value;
            if (importedDefinition != null || !AllTypes.ContainsKey(value.FullName))
                AllTypes[value.FullName] = value;
            return value;
        }

        public CachedType FindType(string fullName) => AllTypes.TryGetValue(fullName, out var type) ? type : null;

        public CachedNamespace FindNamespace(string fullName) =>
            AllNamespaces.TryGetValue(fullName, out var container) ? container : null;

        private CachedNamespace GetOrCreateNamespace(string name)
        {
            if (AllNamespaces.TryGetValue(name, out var existing)) return existing;
            CachedNamespace current = Global;
            foreach (string component in name.Length == 0 ? Array.Empty<string>() : name.Split('.'))
            {
                if (!current.NamespaceMap.TryGetValue(component, out var next))
                {
                    next = new CachedNamespace(current, component);
                    current.NamespaceMap[component] = next;
                    AllNamespaces[next.FullName] = next;
                }

                current = next;
            }

            return current;
        }

        private object GetImportParent(string assemblyIdentity, string fullName)
        {
            if (qualifiedTypes.TryGetValue(((object)assemblyIdentity, fullName), out var runtimeParent))
                return runtimeParent;
            if (importContainers.TryGetValue((assemblyIdentity, fullName), out var existing)) return existing;
            var binding = SourceMembers.OriginalTypeNames.FirstOrDefault(candidate => candidate.Value == fullName &&
                SourceMembers.GetOriginalTypeDefinition(candidate.Key).AssemblyIdentity == assemblyIdentity);
            if (binding.Key != null) return PrecacheSourceType(SourceMembers.GetOriginalTypeDefinition(binding.Key));

            // Imported names can contain structural parents whose original bodies have no
            // runtime counterpart. Such a parent is a container, never a fabricated CLR type.
            var definition = SourceMembers.GetOriginalTypeDefinition(assemblyIdentity, fullName);
            int nested = fullName.LastIndexOf('+');
            object parent;
            string name;
            if (nested >= 0)
            {
                if (((TypeAttributes)definition.Attributes & TypeAttributes.VisibilityMask) !=
                    TypeAttributes.NestedPublic)
                    return null;
                parent = GetImportParent(assemblyIdentity, fullName.Substring(0, nested));
                name = fullName.Substring(nested + 1);
            }
            else
            {
                int separator = fullName.LastIndexOf('.');
                parent = GetOrCreateNamespace(separator < 0 ? string.Empty : fullName.Substring(0, separator));
                name = fullName.Substring(separator + 1);
            }

            if (parent == null) return null;
            var container = new CachedNamespace(parent as CachedNamespace, name, fullName);
            importContainers.Add((assemblyIdentity, fullName), container);
            if (parent is CachedType actualParent) actualParent.NamespaceMap[name] = container;
            else ((CachedNamespace)parent).NamespaceMap[name] = container;
            // The namespace index is an import lookup view. Internal identity stays assembly-scoped.
            if (!AllNamespaces.ContainsKey(fullName)) AllNamespaces.Add(fullName, container);
            return container;
        }

        private string ReadText(EverestContentAsset asset)
        {
            if (asset == null)
            {
                return null;
            }

            using StreamReader streamReader = new StreamReader(asset.Stream);
            return streamReader.ReadToEnd();
        }

        public object Require(string name)
        {
            return _Require(name)?.FirstOrDefault();
        }

        public LuaTable Symbol(string name)
        {
            return _Symbol(name);
        }
    }
}
