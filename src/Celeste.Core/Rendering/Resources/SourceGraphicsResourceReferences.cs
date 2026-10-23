using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Celeste.Core.Rendering.Resources
{
    public sealed class SourceGraphicsResourceReferences
    {
        private readonly object _resourcesLock = new();
        private readonly List<GCHandle> _resources = [];

        internal void AddResourceReference(GCHandle resourceReference)
        {
            lock (_resourcesLock)
            {
                _resources.Add(resourceReference);
            }
        }

        internal void RemoveResourceReference(GCHandle resourceReference)
        {
            lock (_resourcesLock)
            {
                var index = 0;
                for (var count = _resources.Count; index < count; index++)
                    if (!(_resources[index] != resourceReference))
                    {
                        _resources[index] = _resources[_resources.Count - 1];
                        _resources.RemoveAt(_resources.Count - 1);
                        break;
                    }
            }
        }

        public void DisposeTrackedResources()
        {
            lock (_resourcesLock)
            {
                var targets = new List<IDisposable>(_resources.Count);
                foreach (var handle in _resources)
                {
                    var target = handle.Target;
                    if (target != null) targets.Add((IDisposable)target);
                }

                foreach (var target in targets) target.Dispose();

                _resources.Clear();
            }
        }
    }
}
