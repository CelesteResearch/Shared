using System;

namespace Celeste.Everest.Modules.Entities.Metadata
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class CustomBackdropAttribute : Attribute
    {
        public string[] IDs;

        public CustomBackdropAttribute(params string[] ids)
        {
            IDs = ids;
        }
    }
}
