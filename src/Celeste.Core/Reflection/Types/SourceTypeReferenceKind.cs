namespace Celeste.Core.Reflection.Types
{
    public enum SourceTypeReferenceKind
    {
        Named,
        SzArray,
        Array,
        ByReference,
        Pointer,
        GenericInstance,
        GenericParameter,
        RequiredModifier,
        OptionalModifier,
        Pinned,
        Sentinel,
        FunctionPointer,
    }
}
