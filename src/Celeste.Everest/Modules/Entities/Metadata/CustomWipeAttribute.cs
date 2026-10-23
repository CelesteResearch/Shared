using System;

namespace Celeste.Everest.Modules.Entities.Metadata
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class CustomWipeAttribute : Attribute
    {
        public string[] IDs;

        public CustomWipeAttribute(params string[] ids)
        {
            IDs = ids;
        }
    }
}
