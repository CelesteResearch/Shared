using Celeste.Core.Display;
using System;
using Celeste.Core.Components;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;

namespace Celeste.Scene.Entities
{
    // Actual plain source Entity, never a host token or a component wrapper.
    public partial class SceneEntityState : SceneEntityDepthState, IEnumerable<SourceComponentState>,
        ISourceMutableEntityPosition, ISourceEntityUpdate, ISourceEntityScene, ISourceMutableEntityState,
        global::Celeste.Core.Rendering.ISourceEntityGraphicsLifecycle, ISceneEntityAssociation, ISceneEntityDepth,
        ISceneEntityTagFields, ISourceOwnedComponentList, ISourceEntityVisibility, ISourceEntityPosition,
        ISourceEntityRender, ISourceEntityDebugRender, global::Celeste.Physics.Collision.ISourceEntityCollider
    {
        public object Scene { get; private set; }

        object ISceneEntityAssociation.Scene
        {
            get => Scene;
            set => Scene = value;
        }

        private Vector2 position;

        public virtual Vector2 Position
        {
            get => position;
            set => position = value;
        }

        public SceneEntityDepthState DepthState => this;

        public int Depth
        {
            get => this.RawDepth;
            set
            {
                if (this.RawDepth == value) return;
                this.SetDepth(value, Scene, this);
            }
        }

        private SceneTagSet tags;

        public SceneTagSet Tags
        {
            get => tags;
            set
            {
                if (tags == value) return;
                if (Scene != null)
                {
                    if (!(Scene is ISceneEntityTagScene sourceScene))
                        throw new InvalidOperationException("The actual source Scene has no tag capability.");
                    sourceScene.SetEntityTags(this, value);
                }

                tags = value;
            }
        }

        public bool Active { get; set; } = true;
        public bool Visible { get; set; } = true;
        public bool Collidable { get; set; } = true;
        private global::Celeste.Physics.Collision.Shapes.ColliderGeometry collider;

        public global::Celeste.Physics.Collision.Shapes.ColliderGeometry Collider
        {
            get => collider;
            set
            {
                if (ReferenceEquals(collider, value)) return;
                collider?.Removed();
                collider = value;
                collider?.Added(this);
            }
        }

        public SourceOwnedComponentList OwnedComponents { get; private set; }
        public SourceOwnedComponentList Components => OwnedComponents;

        public SceneEntityState(ISourceEntitySourceDataRegistration requiredSourceDataRegistration)
            : this(requiredSourceDataRegistration, Vector2.Zero)
        {
        }

        public SceneEntityState(ISourceEntitySourceDataRegistration requiredSourceDataRegistration, Vector2 position)
        {
            sourceDataRegistration = requiredSourceDataRegistration;
            this.position = position;
            OwnedComponents = new SourceOwnedComponentList(this);
        }

        public void Add(SourceComponentState component) => Components.Add(component);
        public void Remove(SourceComponentState component) => Components.Remove(component);
        public void Add(params SourceComponentState[] components) => Components.Add(components);
        public void Remove(params SourceComponentState[] components) => Components.Remove(components);
        public T Get<T>() where T : SourceComponentState => Components.Get<T>();
        public IEnumerator<SourceComponentState> GetEnumerator() => Components.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public virtual void SceneBegin(object scene)
        {
        }

        public virtual void SceneEnd(object scene)
        {
            if (Components == null) return;
            foreach (var component in Components) component.SceneEnd(scene);
        }

        public virtual void Awake(object scene)
        {
            if (Components == null) return;
            foreach (var component in Components) component.EntityAwake();
        }

        public virtual void Added(object scene)
        {
            Scene = scene;
            if (Components != null)
                foreach (var component in Components)
                    component.EntityAdded(scene);
            ((ISceneEntityDepthScene)Scene).SetEntityActualDepth(this, this);
        }

        public virtual void Removed(object scene)
        {
            if (Components != null)
                foreach (var component in Components)
                    component.EntityRemoved(scene);
            Scene = null;
        }

        public virtual void Update() => OwnedComponents.Update();

        public virtual void Render(global::Celeste.Core.Rendering.ISourceRenderContext context) =>
            OwnedComponents.Render(context);

        public virtual void HandleGraphicsReset() => OwnedComponents.HandleGraphicsReset();
        public virtual void HandleGraphicsCreate() => OwnedComponents.HandleGraphicsCreate();

        public virtual void DebugRender(global::Celeste.Core.Rendering.ISourceRenderContext context,
            object actualCamera)
        {
            if (Collider != null)
                Collider.Render(actualCamera, Collidable
                    ? global::Celeste.Core.Display.PackedColor.Red
                    : global::Celeste.Core.Display.PackedColor.DarkRed, context);
            Components.DebugRender(context, actualCamera);
        }

        public void RemoveSelf()
        {
            if (Scene == null) return;
            if (!(Scene is ISceneEntityRemovalScene sourceScene))
                throw new InvalidOperationException("The actual source Scene has no EntityList removal capability.");
            sourceScene.RemoveEntity(this);
        }

        public bool TagFullCheck(int tag) => (tags.Bits & tag) == tag;
        public bool TagCheck(int tag) => (tags.Bits & tag) != 0;
        public void AddTag(int tag) => Tags |= tag;
        public void RemoveTag(int tag) => Tags &= ~tag;

        public void SetRawDepth(int value) => this.RawDepth = value;
        public void SetRawTags(SceneTagSet value) => tags = value;
    }
}
