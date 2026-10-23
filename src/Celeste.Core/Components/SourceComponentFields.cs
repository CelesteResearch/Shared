using System;

namespace Celeste.Core.Components
{
    // Actual Component fields, owned by the component rather than a scene index.
    public class SourceComponentFields(bool active, bool visible)
    {
        private object _entity;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public object Entity => _entity;

        public object Scene
        {
            get
            {
                if (Entity == null)
                    return null;
                if (!(Entity is ISourceEntityScene actual))
                    throw new InvalidOperationException("The actual Entity does not expose its source Scene field.");
                return actual.Scene;
            }
        }

        public bool Active = active;

        public bool Visible = visible;

        // Component.Added's base assignment, before its optional scene Tracker call.
        public void CommitAdded(object actualEntity)
        {
            _entity = actualEntity;
        }

        // Component.Removed's base tail, after its optional scene Tracker call.
        // EntityRemoved and SceneEnd do not clear these fields.
        public void CommitRemoved()
        {
            _entity = null;
        }

        // TAS field writes bypass Added/Removed and preserve the dynamic Scene getter.
        public void SetRawEntity(object value)
        {
            _entity = value;
        }
    }
}
