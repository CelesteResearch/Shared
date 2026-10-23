using System;

namespace Celeste.Everest.Modules.Entities.Metadata
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class CustomEntityAttribute : Attribute
    {
        public string[] IDs;

        public CustomEntityAttribute(params string[] ids)
        {
            IDs = ids;
        }
    }
}
