using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Celeste.Core.Reflection.Interop
{
    /// <summary>Actual portable module declarations, with imports and exports owned by one module instance.</summary>
    public sealed class SourceModInteropActualTypeBinding
    {
        public Type ActualType { get; }
        public object ActualOwner { get; }
        public string ExportName { get; }
        public IReadOnlyList<MethodInfo> Methods { get; }
        public IReadOnlyList<FieldInfo> Fields { get; }

        private readonly Dictionary<MethodInfo, string> methodNames = new();

        private readonly Dictionary<FieldInfo, string> importNames = new();

        public SourceModInteropActualTypeBinding(Type actualType, object actualOwner,
            string exportName = null, IReadOnlyDictionary<string, string> exportNames = null,
            IReadOnlyList<MethodInfo> exportedMethods = null, IReadOnlyList<FieldInfo> importedFields = null)
        {
            ActualType = actualType ?? throw new ArgumentNullException(nameof(actualType));
            if (actualOwner != null && !actualType.IsInstanceOfType(actualOwner))
                throw new ArgumentException("The interop owner must be an instance of its declared type.",
                    nameof(actualOwner));
            ActualOwner = actualOwner;
            ExportName = exportName ?? ReadName(actualType.GetCustomAttributesData(), "ModExportNameAttribute")
                ?? actualType.Assembly.GetName().Name;
            var methods = exportedMethods?.ToArray() ?? actualType.GetMethods(BindingFlags.Public |
                                                                              BindingFlags.Instance |
                                                                              BindingFlags.Static |
                                                                              BindingFlags.DeclaredOnly);
            var fields = importedFields?.ToArray() ??
            [
                .. actualType.GetFields(BindingFlags.Public | BindingFlags.Instance |
                                        BindingFlags.Static |
                                        BindingFlags.DeclaredOnly)
                    .Where(field => typeof(Delegate).IsAssignableFrom(field.FieldType)),
            ];
            foreach (var method in methods)
            {
                if (method == null || !method.IsPublic || method.DeclaringType == typeof(object)
                    || !method.DeclaringType.IsAssignableFrom(actualType)
                    || method.ContainsGenericParameters || (!method.IsStatic && actualOwner == null))
                    throw new ArgumentException(
                        "Every declared interop method requires a concrete signature and its actual owner.",
                        nameof(actualOwner));
                var name = method.Name;
                if (exportNames != null && exportNames.TryGetValue(name, out var mapped)) name = mapped;
                if (string.IsNullOrEmpty(name))
                    throw new ArgumentException("An export name cannot be empty.", nameof(exportNames));
                methodNames.Add(method, name);
            }

            if (exportNames != null)
                foreach (var name in exportNames.Keys)
                    if (!methods.Any(method => method.Name == name))
                        throw new MissingMethodException(actualType.FullName, name);
            var prefix = ReadName(actualType.GetCustomAttributesData(), "ModImportNameAttribute");
            foreach (var field in fields)
            {
                if (field == null || !field.IsPublic || !field.DeclaringType.IsAssignableFrom(actualType)
                    || !typeof(Delegate).IsAssignableFrom(field.FieldType)
                    || field.IsStatic || field.IsInitOnly || field.IsLiteral || actualOwner == null)
                    throw new ArgumentException(
                        "Owned import delegates must be mutable instance fields on their actual owner.",
                        nameof(actualOwner));
                importNames.Add(field, ReadName(field.GetCustomAttributesData(), "ModImportNameAttribute")
                                       ?? (string.IsNullOrEmpty(prefix) ? field.Name : prefix + "." + field.Name));
            }

            Methods = Array.AsReadOnly(methods);
            Fields = Array.AsReadOnly(fields);
        }

        internal string GetExportName(MethodInfo method)
        {
            return methodNames[method];
        }

        internal string GetImportName(FieldInfo field)
        {
            return importNames[field];
        }

        private static string ReadName(IList<CustomAttributeData> attributes, string name)
        {
            string result = null;
            foreach (var attribute in attributes)
            {
                if (attribute.AttributeType.FullName != "MonoMod.ModInterop." + name) continue;
                if (attribute.ConstructorArguments.Count != 1 || attribute.ConstructorArguments[0].ArgumentType !=
                                                              typeof(string)
                                                              || result != null)
                    throw new CustomAttributeFormatException("Interop name requires one actual string declaration.");
                result = (string)attribute.ConstructorArguments[0].Value;
            }

            return result;
        }
    }
}
