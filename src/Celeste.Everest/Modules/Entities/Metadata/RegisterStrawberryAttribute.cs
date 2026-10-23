using System;

namespace Celeste.Everest.Modules.Entities.Metadata
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class RegisterStrawberryAttribute : Attribute
    {
        public bool isTracked;
        public bool blocksNormalCollection;

        public RegisterStrawberryAttribute(bool tracked, bool blocksCollection)
        {
            isTracked = tracked;
            blocksNormalCollection = blocksCollection;
        }
    }
}
