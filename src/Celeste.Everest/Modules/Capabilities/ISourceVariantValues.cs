using System;

namespace Celeste.Everest.Modules.Capabilities
{
    public interface ISourceVariantValues
    {
        Type VariantEnumType { get; }
        Type GetVariantValueType(object variant);
        object GetCurrentVariantValue(object variant);
        object GetCurrentMapDefinedVariantValue(object variant);
        void SetVariantValue(object variant, object value);
    }
}
