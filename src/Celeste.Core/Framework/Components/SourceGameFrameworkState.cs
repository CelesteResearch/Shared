using System;
using System.Collections.Generic;

namespace Celeste.Core.Framework.Components
{
    public sealed class SourceGameFrameworkState
    {
        private readonly List<ISourceUpdateable> updateableComponents = new();
        private readonly List<ISourceUpdateable> currentlyUpdatingComponents = new();
        private readonly List<ISourceDrawable> drawableComponents = new();
        private readonly List<ISourceDrawable> currentlyDrawingComponents = new();
        public SourceGameComponentCollection Components { get; }

        public SourceGameFrameworkState() : this(new SourceGameComponentCollection())
        {
        }

        public SourceGameFrameworkState(SourceGameComponentCollection actualComponents)
        {
            Components = actualComponents;
        }

        // Original Game.Initialize's CPU part, before its graphics/content work.
        public void InitializeComponents()
        {
            for (int i = 0; i < Components.Count; i++) Components[i].Initialize();
        }

        // Original DoInitialize continues here after the actual Initialize override returns.
        public void CompleteComponentInitialization()
        {
            updateableComponents.Clear();
            drawableComponents.Clear();
            for (int i = 0; i < Components.Count; i++) CategorizeComponent(Components[i]);
            Components.ComponentAdded += OnComponentAdded;
            Components.ComponentRemoved += OnComponentRemoved;
        }

        public void UpdateComponents(SourceGameTime gameTime)
        {
            lock (updateableComponents)
                for (int i = 0; i < updateableComponents.Count; i++)
                    currentlyUpdatingComponents.Add(updateableComponents[i]);
            foreach (ISourceUpdateable component in currentlyUpdatingComponents)
                if (component.Enabled)
                    component.Update(gameTime);
            currentlyUpdatingComponents.Clear();
            // FrameworkDispatcher device work follows in the actual engine boundary.
        }

        public void DrawComponents(SourceGameTime gameTime)
        {
            lock (drawableComponents)
                for (int i = 0; i < drawableComponents.Count; i++)
                    currentlyDrawingComponents.Add(drawableComponents[i]);
            foreach (ISourceDrawable component in currentlyDrawingComponents)
                if (component.Visible)
                    component.Draw(gameTime);
            currentlyDrawingComponents.Clear();
        }

        private void CategorizeComponent(ISourceGameComponent component)
        {
            if (component is ISourceUpdateable updateable)
            {
                lock (updateableComponents) SortUpdateable(updateable);
                updateable.UpdateOrderChanged += OnUpdateOrderChanged;
            }

            if (component is ISourceDrawable drawable)
            {
                lock (drawableComponents) SortDrawable(drawable);
                drawable.DrawOrderChanged += OnDrawOrderChanged;
            }
        }

        private void SortUpdateable(ISourceUpdateable component)
        {
            for (int i = 0; i < updateableComponents.Count; i++)
                if (component.UpdateOrder < updateableComponents[i].UpdateOrder)
                {
                    updateableComponents.Insert(i, component);
                    return;
                }

            updateableComponents.Add(component);
        }

        private void SortDrawable(ISourceDrawable component)
        {
            for (int i = 0; i < drawableComponents.Count; i++)
                if (component.DrawOrder < drawableComponents[i].DrawOrder)
                {
                    drawableComponents.Insert(i, component);
                    return;
                }

            drawableComponents.Add(component);
        }

        private void OnComponentAdded(object sender, SourceGameComponentCollectionEventArgs args)
        {
            args.GameComponent.Initialize();
            CategorizeComponent(args.GameComponent);
        }

        private void OnComponentRemoved(object sender, SourceGameComponentCollectionEventArgs args)
        {
            if (args.GameComponent is ISourceUpdateable updateable)
            {
                lock (updateableComponents) updateableComponents.Remove(updateable);
                updateable.UpdateOrderChanged -= OnUpdateOrderChanged;
            }

            if (args.GameComponent is ISourceDrawable drawable)
            {
                lock (drawableComponents) drawableComponents.Remove(drawable);
                drawable.DrawOrderChanged -= OnDrawOrderChanged;
            }
        }

        private void OnUpdateOrderChanged(object sender, EventArgs args)
        {
            ISourceUpdateable component = sender as ISourceUpdateable;
            lock (updateableComponents)
            {
                updateableComponents.Remove(component);
                SortUpdateable(component);
            }
        }

        private void OnDrawOrderChanged(object sender, EventArgs args)
        {
            ISourceDrawable component = sender as ISourceDrawable;
            lock (drawableComponents)
            {
                drawableComponents.Remove(component);
                SortDrawable(component);
            }
        }
    }
}
