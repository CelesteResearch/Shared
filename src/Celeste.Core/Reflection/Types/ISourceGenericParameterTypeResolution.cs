using System;

namespace Celeste.Core.Reflection.Types
{
    public interface ISourceGenericParameterTypeResolution
    {
        Type GetActualGenericParameterType(SourceTypeReference originalParameter);
    }
}
