using System;
using JetBrains.Annotations;

namespace Celeste.Everest.Modules.Entities.Metadata
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    [MeansImplicitUse(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Itself)]
    public class CustomBackdropAttribute : Attribute
    {
        public string[] IDs;

        // ReSharper disable once ConvertToPrimaryConstructor
        public CustomBackdropAttribute(params string[] ids)
        {
            IDs = ids;
        }
    }
}
