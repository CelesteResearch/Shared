using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Celeste.Core.Rendering.Resources
{
    public sealed class SourceGraphicsResourceReferences
    {
        private readonly object resourcesLock = new object();
        private readonly List<GCHandle> resources = new List<GCHandle>();

        internal void AddResourceReference(GCHandle resourceReference)
        {
            lock (resourcesLock)
            {
                resources.Add(resourceReference);
            }
        }

        internal void RemoveResourceReference(GCHandle resourceReference)
        {
            lock (resourcesLock)
            {
                int index = 0;
                for (int count = resources.Count; index < count; index++)
                {
                    if (!(resources[index] != resourceReference))
                    {
                        resources[index] = resources[resources.Count - 1];
                        resources.RemoveAt(resources.Count - 1);
                        break;
                    }
                }
            }
        }

        public void DisposeTrackedResources()
        {
            lock (resourcesLock)
            {
                var targets = new List<IDisposable>(resources.Count);
                foreach (GCHandle handle in resources)
                {
                    object target = handle.Target;
                    if (target != null)
                    {
                        targets.Add((IDisposable)target);
                    }
                }

                foreach (IDisposable target in targets)
                {
                    target.Dispose();
                }

                resources.Clear();
            }
        }
    }
}
