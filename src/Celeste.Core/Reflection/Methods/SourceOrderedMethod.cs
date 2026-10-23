using System;
using System.Reflection;

namespace Celeste.Core.Reflection.Methods
{
    public sealed class SourceOrderedMethod
    {
        public string SourceAssemblyIdentity { get; }
        public string SourceDeclaringType { get; }
        public int SourceTypeDefinitionToken { get; }
        public int SourceMethodDefinitionToken { get; }
        public MethodInfo ActualMethod { get; }
        public object ActualOwner { get; }
        public bool OriginalIsStatic { get; }

        internal SourceOrderedMethod(string assemblyIdentity, string declaringType, int typeToken,
            int methodToken, MethodInfo method, object owner, bool originalIsStatic)
        {
            SourceAssemblyIdentity = assemblyIdentity;
            SourceDeclaringType = declaringType;
            SourceTypeDefinitionToken = typeToken;
            SourceMethodDefinitionToken = methodToken;
            ActualMethod = method ?? throw new ArgumentNullException(nameof(method));
            if (method.IsStatic && owner != null)
                throw new ArgumentException("A static CLR method must not have an instance owner.", nameof(owner));
            if (!method.IsStatic && originalIsStatic &&
                (owner == null || !method.DeclaringType.IsInstanceOfType(owner)))
                throw new ArgumentException("The actual source process must own this instance method.", nameof(owner));
            if (!originalIsStatic && (method.IsStatic || owner != null))
                throw new ArgumentException(
                    "An original instance method requires an actual instance method and caller-provided target.");
            ActualOwner = owner;
            OriginalIsStatic = originalIsStatic;
        }

        public object Invoke(object[] arguments) => OriginalIsStatic
            ? ActualMethod.Invoke(ActualOwner, arguments)
            : throw new InvalidOperationException("An original instance method requires its current actual target.");

        public object Invoke(object target, object[] arguments) => OriginalIsStatic
            ? ActualMethod.Invoke(ActualOwner, arguments)
            : ActualMethod.Invoke(target, arguments);
    }
}
