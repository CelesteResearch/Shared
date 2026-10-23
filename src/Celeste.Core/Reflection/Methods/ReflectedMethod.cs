using System;
using System.Reflection;

namespace Celeste.Core.Reflection.Methods
{
    public sealed class ReflectedMethod
    {
        public SourceOrderedMethod OriginalBinding { get; }
        public MethodInfo ActualMethod { get; }
        public string Name { get; }
        public Type DeclaringType { get; }

        public ReflectedMethod(SourceOrderedMethod binding, string originalName, Type declaringType = null)
        {
            OriginalBinding = binding ?? throw new ArgumentNullException(nameof(binding));
            ActualMethod = binding.ActualMethod;
            DeclaringType = declaringType ?? binding.ActualMethod.DeclaringType;
            Name = originalName ?? throw new ArgumentNullException(nameof(originalName));
        }

        public ReflectedMethod(MethodInfo method)
        {
            ActualMethod = method ?? throw new ArgumentNullException(nameof(method));
            DeclaringType = method.DeclaringType;
            Name = method.Name;
        }

        public object Invoke(object[] arguments)
            => OriginalBinding != null ? OriginalBinding.Invoke(arguments) : ActualMethod.Invoke(null, arguments);

        public object Invoke(object target, object[] arguments)
            => OriginalBinding != null
                ? OriginalBinding.Invoke(target, arguments)
                : ActualMethod.Invoke(target, arguments);
    }
}
