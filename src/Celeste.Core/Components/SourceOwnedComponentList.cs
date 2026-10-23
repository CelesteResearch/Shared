using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.Observation;

namespace Celeste.Core.Components
{
    public class SourceOwnedComponentList : IEnumerable<SourceComponentState>, IEnumerable
    {
        public enum LockModes
        {
            Open,
            Locked,
            Error,
        }

        private readonly List<SourceComponentState> _components;
        private List<SourceComponentState> _toAdd;
        private List<SourceComponentState> _toRemove;
        private readonly HashSet<SourceComponentState> _current;
        private HashSet<SourceComponentState> _adding;
        private HashSet<SourceComponentState> _removing;
        private LockModes _lockMode;
        private static readonly Func<List<SourceComponentState>, int> ReadListVersion = CreateListVersionReader();

        private static Func<List<SourceComponentState>, int> CreateListVersionReader()
        {
            try
            {
                var field = typeof(List<SourceComponentState>).GetField("_version",
                    BindingFlags.Instance | BindingFlags.NonPublic);
                if (field == null || field.FieldType != typeof(int))
                    return null;
                var method = new DynamicMethod("ReadOwnedComponentListVersion", typeof(int),
                    [typeof(List<SourceComponentState>)], typeof(SourceOwnedComponentList), true);
                var il = method.GetILGenerator();
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldfld, field);
                il.Emit(OpCodes.Ret);
                var reader =
                    (Func<List<SourceComponentState>, int>)method.CreateDelegate(
                        typeof(Func<List<SourceComponentState>, int>));
                var probe = new List<SourceComponentState>();
                var version = reader(probe);
                var enumerator = probe.GetEnumerator();
                try
                {
                    probe.Add(null);
                    if (reader(probe) == version)
                        return null;
                    try
                    {
                        enumerator.MoveNext();
                    }
                    catch (InvalidOperationException exception)
                    {
                        return exception.Message == "Collection was modified; enumeration operation may not execute."
                            ? reader
                            : null;
                    }
                }
                finally
                {
                    enumerator.Dispose();
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        public object Entity { get; internal set; }

        public LockModes LockMode
        {
            get => _lockMode;
            set
            {
                _lockMode = value;
                if (_toAdd != null && _toAdd.Count > 0)
                {
                    foreach (var item in _toAdd)
                        if (!_current.Contains(item))
                        {
                            _current.Add(item);
                            _components.Add(item);
                            item.Added(Entity);
                        }

                    _adding.Clear();
                    _toAdd.Clear();
                }

                if (_toRemove == null || _toRemove.Count <= 0)
                    return;
                foreach (var item2 in _toRemove)
                    if (_current.Contains(item2))
                    {
                        _current.Remove(item2);
                        _components.Remove(item2);
                        item2.Removed(Entity);
                    }

                _removing.Clear();
                _toRemove.Clear();
            }
        }

        public int Count => _components.Count;

        public bool IsPendingRemoval(SourceComponentState component)
        {
            return _removing != null && _removing.Contains(component);
        }

        public SourceComponentState this[int index]
        {
            get
            {
                if (index < 0 || index >= _components.Count)
                    throw new IndexOutOfRangeException();
                return _components[index];
            }
        }

        public SourceOwnedComponentList(object entity)
        {
            Entity = entity;
            _components = [];
            _current = [];
        }

        public void Add(SourceComponentState component)
        {
            switch (_lockMode)
            {
                case LockModes.Open:
                    if (!_current.Contains(component))
                    {
                        _current.Add(component);
                        _components.Add(component);
                        component.Added(Entity);
                    }

                    break;
                case LockModes.Locked:
                    if (!_current.Contains(component) && (_adding == null || !_adding.Contains(component)))
                    {
                        _adding ??= [];
                        _toAdd ??= [];
                        _adding.Add(component);
                        _toAdd.Add(component);
                    }

                    break;
                case LockModes.Error:
                    throw new("Cannot add or remove Entities at this time!");
            }
        }

        public void Remove(SourceComponentState component)
        {
            switch (_lockMode)
            {
                case LockModes.Open:
                    if (_current.Contains(component))
                    {
                        _current.Remove(component);
                        _components.Remove(component);
                        component.Removed(Entity);
                    }

                    break;
                case LockModes.Locked:
                    if (_current.Contains(component) && (_removing == null || !_removing.Contains(component)))
                    {
                        _removing ??= [];
                        _toRemove ??= [];
                        _removing.Add(component);
                        _toRemove.Add(component);
                    }

                    break;
                case LockModes.Error:
                    throw new("Cannot add or remove Entities at this time!");
            }
        }

        public void Add(IEnumerable<SourceComponentState> components)
        {
            foreach (var component in components)
                Add(component);
        }

        public void Remove(IEnumerable<SourceComponentState> components)
        {
            foreach (var component in components)
                Remove(component);
        }

        public void RemoveAll<T>()
            where T : SourceComponentState
        {
            Remove(new List<T>(GetAll<T>()));
        }

        public void Add(params SourceComponentState[] components)
        {
            foreach (var component in components)
                Add(component);
        }

        public void Remove(params SourceComponentState[] components)
        {
            foreach (var component in components)
                Remove(component);
        }

        public List<SourceComponentState>.Enumerator GetValueEnumerator()
        {
            return _components.GetEnumerator();
        }

        public IEnumerator<SourceComponentState> GetEnumerator()
        {
            return _components.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public SourceComponentState[] ToArray()
        {
            return Enumerable.ToArray(_components);
        }

        public void Update()
        {
            if (_lockMode == LockModes.Open && _components.Count == 0 && (_toAdd == null || _toAdd.Count == 0) &&
                (_toRemove == null || _toRemove.Count == 0))
                return;
            LockMode = LockModes.Locked;
            var updateComponents = _components;
            var updateVersionReader = ReadListVersion;
            if (updateVersionReader == null)
            {
                foreach (var component in updateComponents)
                    if (component.Active)
                        component.Update();
            }
            else
            {
                for (int index = 0, version = updateVersionReader(updateComponents);; index++)
                {
                    if (version != updateVersionReader(updateComponents))
                        throw new InvalidOperationException(
                            "Collection was modified; enumeration operation may not execute.");
                    if (index >= updateComponents.Count)
                        break;
                    var component = updateComponents[index];
                    if (component.Active)
                        component.Update();
                }
            }

            LockMode = LockModes.Open;
        }

        public void Render(ISourceRenderContext context)
        {
            LockMode = LockModes.Error;
            var observer = (context as ISourceRenderObservationContext)?.RenderObserver;
            if (observer == null)
            {
                var renderComponents = _components;
                var renderVersionReader = ReadListVersion;
                if (renderVersionReader == null)
                {
                    foreach (var component in renderComponents)
                        if (component.Visible)
                            component.Render(context);
                }
                else
                {
                    for (int index = 0, version = renderVersionReader(renderComponents);; index++)
                    {
                        if (version != renderVersionReader(renderComponents))
                            throw new InvalidOperationException(
                                "Collection was modified; enumeration operation may not execute.");
                        if (index >= renderComponents.Count)
                            break;
                        var component = renderComponents[index];
                        if (component.Visible)
                            component.Render(context);
                    }
                }

                LockMode = LockModes.Open;
                return;
            }

            var componentIndex = 0;
            var observedComponents = _components;
            var observedVersionReader = ReadListVersion;
            if (observedVersionReader == null)
                foreach (var component in observedComponents)
                {
                    if (component.Visible)
                    {
                        var previous = observer.EnterComponent(component, componentIndex);
                        try
                        {
                            component.Render(context);
                        }
                        finally
                        {
                            observer.Exit(in previous);
                        }
                    }

                    componentIndex++;
                }
            else
                for (int index = 0, version = observedVersionReader(observedComponents);; index++)
                {
                    if (version != observedVersionReader(observedComponents))
                        throw new InvalidOperationException(
                            "Collection was modified; enumeration operation may not execute.");
                    if (index >= observedComponents.Count)
                        break;
                    var component = observedComponents[index];
                    if (component.Visible)
                    {
                        var previous = observer.EnterComponent(component, componentIndex);
                        try
                        {
                            component.Render(context);
                        }
                        finally
                        {
                            observer.Exit(in previous);
                        }
                    }

                    componentIndex++;
                }

            LockMode = LockModes.Open;
        }

        public void DebugRender(ISourceRenderContext context, object camera)
        {
            LockMode = LockModes.Error;
            foreach (var component in _components)
                component.DebugRender(context, camera);
            LockMode = LockModes.Open;
        }

        public void HandleGraphicsReset()
        {
            LockMode = LockModes.Error;
            foreach (var component in _components)
                component.HandleGraphicsReset();
            LockMode = LockModes.Open;
        }

        public void HandleGraphicsCreate()
        {
            LockMode = LockModes.Error;
            foreach (var component in _components)
                component.HandleGraphicsCreate();
            LockMode = LockModes.Open;
        }

        public T Get<T>()
            where T : SourceComponentState
        {
            foreach (var component in _components)
                if (component is T)
                    return component as T;
            return null;
        }

        public IEnumerable<T> GetAll<T>()
            where T : SourceComponentState
        {
            foreach (var component in _components)
                if (component is T)
                    yield return component as T;
        }
    }
}
