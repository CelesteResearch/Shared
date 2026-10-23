using System;

namespace Celeste.Everest.Tracking.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public sealed class EverestTrackedAsAttribute : Attribute
    {
        public Type TrackedAs { get; }
        public bool Inherited { get; }

        public EverestTrackedAsAttribute(Type trackedAs, bool inherited = false)
        {
            TrackedAs = trackedAs ?? throw new ArgumentNullException(nameof(trackedAs));
            Inherited = inherited;
        }
    }
}
