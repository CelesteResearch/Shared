using System;

namespace Celeste.Core.Components
{
    // Actual Component fields, owned by the component rather than a scene index.
    public class SourceComponentFields
    {
        private object entity;
        public object Entity => entity;

        public object Scene
        {
            get
            {
                if (entity == null) return null;
                if (!(entity is ISourceEntityScene actual))
                    throw new InvalidOperationException("The actual Entity does not expose its source Scene field.");
                return actual.Scene;
            }
        }

        public bool Active;
        public bool Visible;

        public SourceComponentFields(bool active, bool visible)
        {
            Active = active;
            Visible = visible;
        }

        // Component.Added's base assignment, before its optional scene Tracker call.
        public void CommitAdded(object actualEntity)
        {
            entity = actualEntity;
        }

        // Component.Removed's base tail, after its optional scene Tracker call.
        // EntityRemoved and SceneEnd do not clear these fields.
        public void CommitRemoved() => entity = null;

        // TAS field writes bypass Added/Removed and preserve the dynamic Scene getter.
        public void SetRawEntity(object value) => entity = value;
    }
}
