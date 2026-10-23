using System;
using System.Collections.Generic;

namespace Celeste.Core.Framework.Components
{
    public sealed class SourceGameFrameworkState(SourceGameComponentCollection actualComponents)
    {
        private readonly List<ISourceUpdateable> _updateableComponents = [];
        private readonly List<ISourceUpdateable> _currentlyUpdatingComponents = [];
        private readonly List<ISourceDrawable> _drawableComponents = [];
        private readonly List<ISourceDrawable> _currentlyDrawingComponents = [];
        public SourceGameComponentCollection Components { get; } = actualComponents;

        public SourceGameFrameworkState() : this([])
        {
        }

        // Original Game.Initialize's CPU part, before its graphics/content work.
        public void InitializeComponents()
        {
            for (var i = 0; i < Components.Count; i++)
                Components[i].Initialize();
        }

        // Original DoInitialize continues here after the actual Initialize override returns.
        public void CompleteComponentInitialization()
        {
            _updateableComponents.Clear();
            _drawableComponents.Clear();
            for (var i = 0; i < Components.Count; i++)
                CategorizeComponent(Components[i]);
            Components.ComponentAdded += OnComponentAdded;
            Components.ComponentRemoved += OnComponentRemoved;
        }

        public void UpdateComponents(SourceGameTime gameTime)
        {
            lock (_updateableComponents)
            {
                for (var i = 0; i < _updateableComponents.Count; i++)
                    _currentlyUpdatingComponents.Add(_updateableComponents[i]);
            }

            foreach (var component in _currentlyUpdatingComponents)
                if (component.Enabled)
                    component.Update(gameTime);
            _currentlyUpdatingComponents.Clear();
            // FrameworkDispatcher device work follows in the actual engine boundary.
        }

        public void DrawComponents(SourceGameTime gameTime)
        {
            lock (_drawableComponents)
            {
                for (var i = 0; i < _drawableComponents.Count; i++)
                    _currentlyDrawingComponents.Add(_drawableComponents[i]);
            }

            foreach (var component in _currentlyDrawingComponents)
                if (component.Visible)
                    component.Draw(gameTime);
            _currentlyDrawingComponents.Clear();
        }

        private void CategorizeComponent(ISourceGameComponent component)
        {
            if (component is ISourceUpdateable updateable)
            {
                lock (_updateableComponents)
                {
                    SortUpdateable(updateable);
                }

                updateable.UpdateOrderChanged += OnUpdateOrderChanged;
            }

            if (component is ISourceDrawable drawable)
            {
                lock (_drawableComponents)
                {
                    SortDrawable(drawable);
                }

                drawable.DrawOrderChanged += OnDrawOrderChanged;
            }
        }

        private void SortUpdateable(ISourceUpdateable component)
        {
            for (var i = 0; i < _updateableComponents.Count; i++)
                if (component.UpdateOrder < _updateableComponents[i].UpdateOrder)
                {
                    _updateableComponents.Insert(i, component);
                    return;
                }

            _updateableComponents.Add(component);
        }

        private void SortDrawable(ISourceDrawable component)
        {
            for (var i = 0; i < _drawableComponents.Count; i++)
                if (component.DrawOrder < _drawableComponents[i].DrawOrder)
                {
                    _drawableComponents.Insert(i, component);
                    return;
                }

            _drawableComponents.Add(component);
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
                lock (_updateableComponents)
                {
                    _updateableComponents.Remove(updateable);
                }

                updateable.UpdateOrderChanged -= OnUpdateOrderChanged;
            }

            if (args.GameComponent is ISourceDrawable drawable)
            {
                lock (_drawableComponents)
                {
                    _drawableComponents.Remove(drawable);
                }

                drawable.DrawOrderChanged -= OnDrawOrderChanged;
            }
        }

        private void OnUpdateOrderChanged(object sender, EventArgs args)
        {
            var component = sender as ISourceUpdateable;
            lock (_updateableComponents)
            {
                _updateableComponents.Remove(component);
                SortUpdateable(component);
            }
        }

        private void OnDrawOrderChanged(object sender, EventArgs args)
        {
            var component = sender as ISourceDrawable;
            lock (_drawableComponents)
            {
                _drawableComponents.Remove(component);
                SortDrawable(component);
            }
        }
    }
}
