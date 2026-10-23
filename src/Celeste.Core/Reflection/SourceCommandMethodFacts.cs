using System;
using System.Reflection;

namespace Celeste.Core.Reflection
{
    // Source declaration facts retain logical token/name/order; actual invocation binds to the real CPU method.
    public sealed class SourceCommandMethodFacts : ISourceCommandMethodMetadata
    {
        public int MetadataToken { get; }
        public string DeclaringTypeName { get; }
        public string Name { get; }
        public bool IsStatic => true;
        private readonly string[] commandNames;
        private readonly string[] commandHelp;
        private readonly SourceCommandParameter[] parameters;
        private MethodInfo actualMethod;

        public SourceCommandMethodFacts(int token, string typeName, string name,
            string[] commandNames, string[] commandHelp, SourceCommandParameter[] parameters)
        {
            MetadataToken = token;
            DeclaringTypeName = typeName;
            Name = name;
            this.commandNames = commandNames;
            this.commandHelp = commandHelp;
            this.parameters = parameters;
        }

        public SourceCommandDeclaration[] ReadDeclaredCommands()
        {
            var result = new SourceCommandDeclaration[commandNames.Length];
            for (int i = 0; i < result.Length; i++)
                result[i] = new SourceCommandDeclaration(commandNames[i], commandHelp[i]);
            return result;
        }

        public SourceCommandParameter[] GetCommandParameters() => (SourceCommandParameter[])parameters.Clone();

        public void BindActualMethod(MethodInfo method)
        {
            if (actualMethod != null)
                throw new InvalidOperationException("The actual command CPU method is already bound.");
            if (method == null || !method.IsStatic || method.Name != Name)
                throw new InvalidOperationException(
                    "The actual static command method does not match its source declaration.");
            var actualParameters = method.GetParameters();
            if (actualParameters.Length != parameters.Length)
                throw new InvalidOperationException("The actual command parameter count differs from source.");
            for (int i = 0; i < parameters.Length; i++)
                if (actualParameters[i].ParameterType.FullName != parameters[i].ParameterTypeIdentity)
                    throw new InvalidOperationException("The actual command parameter type differs from source.");
            actualMethod = method;
        }

        public object Invoke(object target, object[] arguments)
        {
            if (actualMethod == null)
                throw new InvalidOperationException("The complete actual command CPU method is not bound.");
            return actualMethod.Invoke(target, arguments);
        }
    }
}
