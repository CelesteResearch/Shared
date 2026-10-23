using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Celeste.Core.Components
{
    public class SourceOwnedComponentList : IEnumerable<SourceComponentState>, IEnumerable
    {
        public enum LockModes
        {
            Open,
            Locked,
            Error
        }

        private List<SourceComponentState> components;

        private List<SourceComponentState> toAdd;

        private List<SourceComponentState> toRemove;

        private HashSet<SourceComponentState> current;

        private HashSet<SourceComponentState> adding;

        private HashSet<SourceComponentState> removing;

        private LockModes lockMode;

        private static readonly Func<List<SourceComponentState>, int> readListVersion = CreateListVersionReader();

        private static Func<List<SourceComponentState>, int> CreateListVersionReader()
        {
            try
            {
                var field = typeof(List<SourceComponentState>).GetField("_version",
                    System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                if (field == null || field.FieldType != typeof(int)) return null;
                var method = new System.Reflection.Emit.DynamicMethod("ReadOwnedComponentListVersion", typeof(int),
                    new[] { typeof(List<SourceComponentState>) }, typeof(SourceOwnedComponentList), true);
                var il = method.GetILGenerator();
                il.Emit(System.Reflection.Emit.OpCodes.Ldarg_0);
                il.Emit(System.Reflection.Emit.OpCodes.Ldfld, field);
                il.Emit(System.Reflection.Emit.OpCodes.Ret);
                var reader =
                    (Func<List<SourceComponentState>, int>)method.CreateDelegate(
                        typeof(Func<List<SourceComponentState>, int>));
                var probe = new List<SourceComponentState>();
                int version = reader(probe);
                var enumerator = probe.GetEnumerator();
                try
                {
                    probe.Add(null);
                    if (reader(probe) == version) return null;
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
            get { return lockMode; }
            set
            {
                lockMode = value;
                if (toAdd != null && toAdd.Count > 0)
                {
                    foreach (SourceComponentState item in toAdd)
                    {
                        if (!current.Contains(item))
                        {
                            current.Add(item);
                            components.Add(item);
                            item.Added(Entity);
                        }
                    }

                    adding.Clear();
                    toAdd.Clear();
                }

                if (toRemove == null || toRemove.Count <= 0)
                {
                    return;
                }

                foreach (SourceComponentState item2 in toRemove)
                {
                    if (current.Contains(item2))
                    {
                        current.Remove(item2);
                        components.Remove(item2);
                        item2.Removed(Entity);
                    }
                }

                removing.Clear();
                toRemove.Clear();
            }
        }

        public int Count => components.Count;

        public bool IsPendingRemoval(SourceComponentState component) =>
            removing != null && removing.Contains(component);

        public SourceComponentState this[int index]
        {
            get
            {
                if (index < 0 || index >= components.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return components[index];
            }
        }

        public SourceOwnedComponentList(object entity)
        {
            Entity = entity;
            components = new List<SourceComponentState>();
            current = new HashSet<SourceComponentState>();
        }

        public void Add(SourceComponentState component)
        {
            switch (lockMode)
            {
                case LockModes.Open:
                    if (!current.Contains(component))
                    {
                        current.Add(component);
                        components.Add(component);
                        component.Added(Entity);
                    }

                    break;
                case LockModes.Locked:
                    if (!current.Contains(component) && (adding == null || !adding.Contains(component)))
                    {
                        adding ??= new HashSet<SourceComponentState>();
                        toAdd ??= new List<SourceComponentState>();
                        adding.Add(component);
                        toAdd.Add(component);
                    }

                    break;
                case LockModes.Error:
                    throw new Exception("Cannot add or remove Entities at this time!");
            }
        }

        public void Remove(SourceComponentState component)
        {
            switch (lockMode)
            {
                case LockModes.Open:
                    if (current.Contains(component))
                    {
                        current.Remove(component);
                        components.Remove(component);
                        component.Removed(Entity);
                    }

                    break;
                case LockModes.Locked:
                    if (current.Contains(component) && (removing == null || !removing.Contains(component)))
                    {
                        removing ??= new HashSet<SourceComponentState>();
                        toRemove ??= new List<SourceComponentState>();
                        removing.Add(component);
                        toRemove.Add(component);
                    }

                    break;
                case LockModes.Error:
                    throw new Exception("Cannot add or remove Entities at this time!");
            }
        }

        public void Add(IEnumerable<SourceComponentState> components)
        {
            foreach (SourceComponentState component in components)
            {
                Add(component);
            }
        }

        public void Remove(IEnumerable<SourceComponentState> components)
        {
            foreach (SourceComponentState component in components)
            {
                Remove(component);
            }
        }

        public void RemoveAll<T>() where T : SourceComponentState
        {
            Remove(new List<T>(GetAll<T>()));
        }

        public void Add(params SourceComponentState[] components)
        {
            foreach (SourceComponentState component in components)
            {
                Add(component);
            }
        }

        public void Remove(params SourceComponentState[] components)
        {
            foreach (SourceComponentState component in components)
            {
                Remove(component);
            }
        }

        public List<SourceComponentState>.Enumerator GetValueEnumerator() => components.GetEnumerator();

        public IEnumerator<SourceComponentState> GetEnumerator()
        {
            return components.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public SourceComponentState[] ToArray()
        {
            return Enumerable.ToArray(components);
        }

        public void Update()
        {
            if (lockMode == LockModes.Open && components.Count == 0 && (toAdd == null || toAdd.Count == 0) &&
                (toRemove == null || toRemove.Count == 0))
                return;
            LockMode = LockModes.Locked;
            var updateComponents = components;
            var updateVersionReader = readListVersion;
            if (updateVersionReader == null)
            {
                foreach (SourceComponentState component in updateComponents)
                {
                    if (component.Active)
                    {
                        component.Update();
                    }
                }
            }
            else
            {
                for (int index = 0, version = updateVersionReader(updateComponents);; index++)
                {
                    if (version != updateVersionReader(updateComponents))
                        throw new InvalidOperationException(
                            "Collection was modified; enumeration operation may not execute.");
                    if (index >= updateComponents.Count) break;
                    SourceComponentState component = updateComponents[index];
                    if (component.Active)
                    {
                        component.Update();
                    }
                }
            }

            LockMode = LockModes.Open;
        }

        public void Render(Celeste.Core.Rendering.ISourceRenderContext context)
        {
            LockMode = LockModes.Error;
            var observer = (context as Celeste.Core.Rendering.Observation.ISourceRenderObservationContext)
                ?.RenderObserver;
            if (observer == null)
            {
                var renderComponents = components;
                var renderVersionReader = readListVersion;
                if (renderVersionReader == null)
                {
                    foreach (SourceComponentState component in renderComponents)
                    {
                        if (component.Visible)
                        {
                            component.Render(context);
                        }
                    }
                }
                else
                {
                    for (int index = 0, version = renderVersionReader(renderComponents);; index++)
                    {
                        if (version != renderVersionReader(renderComponents))
                            throw new InvalidOperationException(
                                "Collection was modified; enumeration operation may not execute.");
                        if (index >= renderComponents.Count) break;
                        SourceComponentState component = renderComponents[index];
                        if (component.Visible)
                        {
                            component.Render(context);
                        }
                    }
                }

                LockMode = LockModes.Open;
                return;
            }

            int componentIndex = 0;
            var observedComponents = components;
            var observedVersionReader = readListVersion;
            if (observedVersionReader == null)
            {
                foreach (SourceComponentState component in observedComponents)
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
            }
            else
            {
                for (int index = 0, version = observedVersionReader(observedComponents);; index++)
                {
                    if (version != observedVersionReader(observedComponents))
                        throw new InvalidOperationException(
                            "Collection was modified; enumeration operation may not execute.");
                    if (index >= observedComponents.Count) break;
                    SourceComponentState component = observedComponents[index];
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
            }

            LockMode = LockModes.Open;
        }

        public void DebugRender(Celeste.Core.Rendering.ISourceRenderContext context, object camera)
        {
            LockMode = LockModes.Error;
            foreach (SourceComponentState component in components)
            {
                component.DebugRender(context, camera);
            }

            LockMode = LockModes.Open;
        }

        public void HandleGraphicsReset()
        {
            LockMode = LockModes.Error;
            foreach (SourceComponentState component in components)
            {
                component.HandleGraphicsReset();
            }

            LockMode = LockModes.Open;
        }

        public void HandleGraphicsCreate()
        {
            LockMode = LockModes.Error;
            foreach (SourceComponentState component in components)
            {
                component.HandleGraphicsCreate();
            }

            LockMode = LockModes.Open;
        }

        public T Get<T>() where T : SourceComponentState
        {
            foreach (SourceComponentState component in components)
            {
                if (component is T)
                {
                    return component as T;
                }
            }

            return null;
        }

        public IEnumerable<T> GetAll<T>() where T : SourceComponentState
        {
            foreach (SourceComponentState component in components)
            {
                if (component is T)
                {
                    yield return component as T;
                }
            }
        }
    }
}
