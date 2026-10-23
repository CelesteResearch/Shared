using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Celeste.Everest.Modules.Entities.Metadata;
using Celeste.Game.Menus.Overworld;

namespace Celeste.Everest.Modules.Updating
{
    public sealed partial class EverestLoaderProcess
    {
        private readonly Dictionary<Assembly, AssemblyRegistrationLease> assemblyRegistrationLeases = new();

        public void ReleaseAssemblyRegistrations(Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            if (!assemblyRegistrationLeases.TryGetValue(assembly, out var lease)) return;
            assemblyRegistrationLeases.Remove(assembly);
            lease.Dispose();
        }

        private static AssemblyRegistrationType CreateActualRegistrationType(Type type)
        {
            if (type == null) throw new ArgumentException("An assembly registration type cannot be null.");
            CustomAttributeData[] attributes = type.GetCustomAttributesData().ToArray();
            return new AssemblyRegistrationType(type.FullName ?? type.Name, () => type,
                () => typeof(OuiState).IsAssignableFrom(type), type.IsAbstract,
                attributes.Any(attribute => GetActualRegistrationIdentity(attribute.AttributeType) != null),
                identity => ReadActualRegistrationAttributes(attributes, identity));
        }

        private static string GetActualRegistrationIdentity(Type type)
        {
            if (type == typeof(CustomEntityAttribute)) return "Celeste.Mod.Entities.CustomEntityAttribute";
            if (type == typeof(RegisterStrawberryAttribute)) return "Celeste.Mod.Entities.RegisterStrawberryAttribute";
            if (type == typeof(CustomEventAttribute)) return "Celeste.Mod.Entities.CustomEventAttribute";
            if (type == typeof(CustomBackdropAttribute)) return "Celeste.Mod.Backdrops.CustomBackdropAttribute";
            if (type == typeof(CustomWipeAttribute)) return "Celeste.Mod.Entities.CustomWipeAttribute";
            return null;
        }

        private static IEnumerable<SourceRegistrationAttribute> ReadActualRegistrationAttributes(
            IEnumerable<CustomAttributeData> attributes, string identity)
        {
            foreach (CustomAttributeData attribute in attributes)
            {
                if (GetActualRegistrationIdentity(attribute.AttributeType) != identity) continue;
                var result = new SourceRegistrationAttribute();
                if (attribute.AttributeType == typeof(RegisterStrawberryAttribute))
                {
                    result.isTracked = (bool)attribute.ConstructorArguments[0].Value;
                    result.blocksNormalCollection = (bool)attribute.ConstructorArguments[1].Value;
                }
                else
                    result.IDs = ReadActualRegistrationIds(attribute.ConstructorArguments[0]);

                foreach (CustomAttributeNamedArgument named in attribute.NamedArguments)
                {
                    switch (named.MemberName)
                    {
                        case "IDs":
                            result.IDs = ReadActualRegistrationIds(named.TypedValue);
                            break;
                        case "isTracked":
                            result.isTracked = (bool)named.TypedValue.Value;
                            break;
                        case "blocksNormalCollection":
                            result.blocksNormalCollection = (bool)named.TypedValue.Value;
                            break;
                    }
                }

                yield return result;
            }
        }

        private static string[] ReadActualRegistrationIds(CustomAttributeTypedArgument argument)
            => argument.Value == null
                ? Array.Empty<string>()
                : ((IEnumerable<CustomAttributeTypedArgument>)argument.Value)
                .Select(value => (string)value.Value).ToArray();

        private sealed class AssemblyRegistrationType
        {
            public readonly string Identity;
            public readonly Func<Type> ResolveType;
            public readonly Func<bool> IsOui;
            public readonly bool IsAbstract;
            public readonly bool HasRegistration;
            public readonly Func<string, IEnumerable<SourceRegistrationAttribute>> ReadAttributes;

            public AssemblyRegistrationType(string identity, Func<Type> resolveType, Func<bool> isOui,
                bool isAbstract, bool hasRegistration,
                Func<string, IEnumerable<SourceRegistrationAttribute>> readAttributes)
            {
                Identity = identity;
                ResolveType = resolveType;
                IsOui = isOui;
                IsAbstract = isAbstract;
                HasRegistration = hasRegistration;
                ReadAttributes = readAttributes;
            }
        }
    }
}
