using System;
using System.Linq;
using System.Reflection;
using Celeste.Core.Reflection;
using Celeste.Framework.Diagnostics.Commands;

namespace Celeste.Everest.Reflection.Runtime
{
    internal sealed class RuntimeCommandMethodMetadata : ISourceCommandMethodMetadata
    {
        private readonly MethodInfo method;

        private readonly SourceCommandDeclaration[] declarations;

        private readonly SourceCommandParameter[] parameters;

        public RuntimeCommandMethodMetadata(MethodInfo method)
        {
            this.method = method;
            declarations =
            [
                .. method.GetCustomAttributes<SourceCommandAttribute>(false)
                    .Select(attribute => new SourceCommandDeclaration(attribute.Name, attribute.Help)),
            ];
            parameters =
            [
                .. method.GetParameters().Select(parameter => new SourceCommandParameter(
                    parameter.Name, parameter.ParameterType.FullName,
                    parameter.HasDefaultValue ? parameter.DefaultValue : DBNull.Value)),
            ];
        }

        public int MetadataToken => method.MetadataToken;
        public string DeclaringTypeName => method.DeclaringType!.FullName;
        public string Name => method.Name;
        public bool IsStatic => method.IsStatic;

        public SourceCommandDeclaration[] ReadDeclaredCommands()
        {
            return (SourceCommandDeclaration[])declarations.Clone();
        }

        public SourceCommandParameter[] GetCommandParameters()
        {
            return (SourceCommandParameter[])parameters.Clone();
        }

        public object Invoke(object target, object[] arguments)
        {
            return method.Invoke(target, arguments);
        }
    }
}
