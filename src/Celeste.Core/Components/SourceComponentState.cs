using System;
using Celeste.Core.Rendering;

namespace Celeste.Core.Components
{
    public class SourceComponentState(bool active, bool visible)
        : SourceComponentFields(active, visible), ISourceComponentFields
    {
        public SourceComponentFields ComponentFields => this;

        private static ISourceComponentIndex Tracker(object scene)
        {
            if (scene == null)
                throw new NullReferenceException();
            return ((ISourceComponentIndexScene)scene).ComponentIndex;
        }

        public virtual void Added(object entity)
        {
            ComponentFields.CommitAdded(entity);
            var scene = Scene;
            if (scene != null)
                ((ISourceComponentIndexScene)scene).ComponentIndex.Track(this);
        }

        public virtual void Removed(object entity)
        {
            var scene = Scene;
            if (scene != null)
                ((ISourceComponentIndexScene)scene).ComponentIndex.Untrack(this);
            ComponentFields.CommitRemoved();
        }

        public virtual void EntityAdded(object scene)
        {
            Tracker(scene).Track(this);
        }

        public virtual void EntityRemoved(object scene)
        {
            Tracker(scene).Untrack(this);
        }

        public virtual void SceneEnd(object scene)
        {
        }

        public virtual void EntityAwake()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void Render(ISourceRenderContext context)
        {
        }

        public virtual void DebugRender(ISourceRenderContext context, object camera)
        {
        }

        public virtual void HandleGraphicsReset()
        {
        }

        public virtual void HandleGraphicsCreate()
        {
        }

        public void RemoveSelf()
        {
            if (Entity != null)
                ((ISourceOwnedComponentList)Entity).OwnedComponents.Remove(this);
        }

        public T SceneAs<T>()
            where T : class
        {
            return Scene as T;
        }

        public T EntityAs<T>()
            where T : class
        {
            return Entity as T;
        }
    }
}
