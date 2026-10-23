using System;

namespace Celeste.Scene.Tracking.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class SceneTrackedAttribute : Attribute
    {
        public bool Inherited { get; }

        public SceneTrackedAttribute(bool inherited = false)
        {
            Inherited = inherited;
        }
    }
}
