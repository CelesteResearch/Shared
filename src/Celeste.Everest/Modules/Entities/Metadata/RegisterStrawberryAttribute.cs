using System;

namespace Celeste.Everest.Modules.Entities.Metadata
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class RegisterStrawberryAttribute : Attribute
    {
        public bool isTracked;

        public bool blocksNormalCollection;

        // ReSharper disable once ConvertToPrimaryConstructor
        public RegisterStrawberryAttribute(bool tracked, bool blocksCollection)
        {
            isTracked = tracked;
            blocksNormalCollection = blocksCollection;
        }
    }
}
