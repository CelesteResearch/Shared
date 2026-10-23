using System;
using JetBrains.Annotations;

namespace Celeste.Everest.Modules.Entities.Metadata
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    [MeansImplicitUse(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Itself)]
    public class CustomWipeAttribute : Attribute
    {
        public string[] IDs;

        // ReSharper disable once ConvertToPrimaryConstructor
        public CustomWipeAttribute(params string[] ids)
        {
            IDs = ids;
        }
    }
}
