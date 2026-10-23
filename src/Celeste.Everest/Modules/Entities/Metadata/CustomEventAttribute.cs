using System;

namespace Celeste.Everest.Modules.Entities.Metadata
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class CustomEventAttribute : Attribute
    {
        public string[] IDs;

        public CustomEventAttribute(params string[] ids)
        {
            IDs = ids;
        }
    }
}
