namespace Celeste.Core.Reflection
{
    public interface ISourceCommandMethodMetadata
    {
        int MetadataToken { get; }
        string DeclaringTypeName { get; }
        string Name { get; }
        bool IsStatic { get; }
        SourceCommandDeclaration[] ReadDeclaredCommands();
        SourceCommandParameter[] GetCommandParameters();
        object Invoke(object target, object[] arguments);
    }
}
