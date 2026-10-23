using System;

namespace Celeste.Savestates
{
    public sealed class ObjectGraphSnapshot
    {
        private readonly SnapshotRoot[] roots;
        private readonly object[][] saved;

        public ObjectGraphSnapshot(SnapshotRoot[] roots, Func<object, object> external = null)
        {
            this.roots = (SnapshotRoot[])roots.Clone();
            var clone = new StateClone(external);
            foreach (var root in roots) clone.Map(root.Owner, root.Owner);
            saved = new object[roots.Length][];
            for (var i = 0; i < roots.Length; i++)
            {
                saved[i] = new object[roots[i].Fields.Length];
                for (var j = 0; j < saved[i].Length; j++)
                    saved[i][j] = clone.Clone(roots[i].Fields[j].GetValue(roots[i].Owner));
            }
        }

        public void Restore(object[] owners, Func<object, object> external = null)
        {
            PrepareRestore(owners, external)();
        }

        public Action PrepareRestore(object[] owners, Func<object, object> external = null)
        {
            if (owners.Length != roots.Length) throw new ArgumentException("Snapshot root count changed.");
            var clone = new StateClone(external);
            for (var i = 0; i < roots.Length; i++) clone.Map(roots[i].Owner, owners[i]);
            // Clone everything before changing live roots. A failed clone leaves the
            // running world intact, and loading the same snapshot never mutates it.
            var restored = clone.Clone(saved);
            return () =>
            {
                for (var i = 0; i < roots.Length; i++)
                for (var j = 0; j < roots[i].Fields.Length; j++)
                    roots[i].Fields[j].SetValue(owners[i], restored[i][j]);
            };
        }
    }
}
