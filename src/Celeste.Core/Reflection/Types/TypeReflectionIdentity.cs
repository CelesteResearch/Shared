using System;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Types
{
    // Original bindings retain their source identity; external types keep CLR identity.
    public readonly struct TypeReflectionIdentity
    {
        public string AssemblyIdentity { get; }
        public string TypeIdentity { get; }

        private TypeReflectionIdentity(string assemblyIdentity, string typeIdentity)
        {
            AssemblyIdentity = assemblyIdentity;
            TypeIdentity = typeIdentity;
        }

        public static TypeReflectionIdentity Resolve(SourceMemberCatalog members, Type type)
        {
            if (members == null) throw new ArgumentNullException(nameof(members));
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (members.ContainsSourceType(type))
            {
                var source = members.GetOriginalTypeDefinition(type);
                return new(source.AssemblyIdentity, source.Identity);
            }

            return new(type.Assembly.FullName, type.FullName ?? type.Name);
        }
    }
}
