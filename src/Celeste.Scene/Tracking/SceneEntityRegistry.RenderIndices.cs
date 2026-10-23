using System.Collections.Generic;
using Celeste.Scene.Ownership;

namespace Celeste.Scene.Tracking
{
    public sealed partial class SceneEntityRegistry
    {
        private Dictionary<object, int> committedRenderIndices;
        private bool committedRenderIndicesDirty = true;
        private int committedRenderIndexSortDepth;

        public int FindCommittedRenderIndex(object entity)
        {
            if (committedRenderIndexSortDepth != 0)
            {
                for (int i = 0; i < entities.Count; i++)
                    if (ReferenceEquals(entities[i], entity))
                        return i;
                return -1;
            }

            if (committedRenderIndicesDirty)
            {
                committedRenderIndices ??= new Dictionary<object, int>(entities.Count,
                    SceneObjectIdentityComparer.Instance);
                committedRenderIndices.Clear();
                for (int i = 0; i < entities.Count; i++)
                    committedRenderIndices.TryAdd(entities[i], i);
                committedRenderIndicesDirty = false;
            }

            return committedRenderIndices.TryGetValue(entity, out int index) ? index : -1;
        }

        private void InvalidateCommittedRenderIndices() => committedRenderIndicesDirty = true;

        private void BeginCommittedRenderIndexSort()
        {
            committedRenderIndexSortDepth++;
            InvalidateCommittedRenderIndices();
        }

        private void EndCommittedRenderIndexSort()
        {
            committedRenderIndexSortDepth--;
            InvalidateCommittedRenderIndices();
        }

        private void RemoveCommittedRenderIndex(object entity)
        {
            committedRenderIndices?.Remove(entity);
            InvalidateCommittedRenderIndices();
        }

        private void ClearCommittedRenderIndices()
        {
            committedRenderIndices?.Clear();
            InvalidateCommittedRenderIndices();
        }
    }
}
