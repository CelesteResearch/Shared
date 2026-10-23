using System;
using System.Collections.Generic;
using System.Reflection;

namespace Celeste.Savestates
{
    // Native owners are retained/remapped explicitly; only their selected managed
    // fields enter the graph. This never shallow-clones a native engine object.
    public sealed class SnapshotRoot
    {
        public readonly object Owner;
        public readonly FieldInfo[] Fields;

        public SnapshotRoot(object owner, Func<FieldInfo, bool> include = null)
        {
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
            var fields = new List<FieldInfo>();
            for (var type = owner.GetType(); type != null; type = type.BaseType)
                foreach (var field in type.GetFields(BindingFlags.Instance | BindingFlags.Public
                                                                           | BindingFlags.NonPublic |
                                                                           BindingFlags.DeclaredOnly))
                    if (include == null || include(field))
                        fields.Add(field);
            Fields = [.. fields];
        }
    }
}
