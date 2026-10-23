using System;
using System.Reflection;

namespace Celeste.Core.Reflection
{
    // Source declaration facts retain logical token/name/order; actual invocation binds to the real CPU method.
    public sealed class SourceCommandMethodFacts(
        int token,
        string typeName,
        string name,
        string[] commandNames,
        string[] commandHelp,
        SourceCommandParameter[] parameters) : ISourceCommandMethodMetadata
    {
        public int MetadataToken { get; }
            = token;

        public string DeclaringTypeName { get; }
            = typeName;

        public string Name { get; }
            = name;

        public bool IsStatic => true;

        // ReSharper disable once ReplaceWithPrimaryConstructorParameter
        private readonly string[] _commandNames = commandNames;

        // ReSharper disable once ReplaceWithPrimaryConstructorParameter
        private readonly string[] _commandHelp = commandHelp;

        // ReSharper disable once ReplaceWithPrimaryConstructorParameter
        private readonly SourceCommandParameter[] _parameters = parameters;
        private MethodInfo _actualMethod;


        public SourceCommandDeclaration[] ReadDeclaredCommands()
        {
            var result = new SourceCommandDeclaration[_commandNames.Length];
            for (var i = 0; i < result.Length; i++)
                result[i] = new(_commandNames[i], _commandHelp[i]);
            return result;
        }

        public SourceCommandParameter[] GetCommandParameters()
        {
            return (SourceCommandParameter[])_parameters.Clone();
        }

        public void BindActualMethod(MethodInfo method)
        {
            if (_actualMethod != null)
                throw new InvalidOperationException("The actual command CPU method is already bound.");
            if (method == null || !method.IsStatic || method.Name != Name)
                throw new InvalidOperationException(
                    "The actual static command method does not match its source declaration.");
            var actualParameters = method.GetParameters();
            if (actualParameters.Length != _parameters.Length)
                throw new InvalidOperationException("The actual command parameter count differs from source.");
            for (var i = 0; i < _parameters.Length; i++)
                if (actualParameters[i].ParameterType.FullName != _parameters[i].ParameterTypeIdentity)
                    throw new InvalidOperationException("The actual command parameter type differs from source.");
            _actualMethod = method;
        }

        public object Invoke(object target, object[] arguments)
        {
            if (_actualMethod == null)
                throw new InvalidOperationException("The complete actual command CPU method is not bound.");
            return _actualMethod.Invoke(target, arguments);
        }
    }
}
