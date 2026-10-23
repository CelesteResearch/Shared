using System;
using JetBrains.Annotations;

namespace Celeste.Everest.Modules.Entities.Metadata
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    [MeansImplicitUse(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Itself)]
    public class CustomEventAttribute : Attribute
    {
        public string[] IDs;

        // ReSharper disable once ConvertToPrimaryConstructor
        public CustomEventAttribute(params string[] ids)
        {
            IDs = ids;
        }
    }
}
