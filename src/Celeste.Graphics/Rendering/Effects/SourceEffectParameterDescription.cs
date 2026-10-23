using System;
using System.Collections.Generic;

namespace Celeste.Graphics.Rendering.Effects
{
    // Offsets/byte counts are source parameter storage, not GPU constant-buffer packing.
    public sealed class SourceEffectParameterDescription
    {
        public string Name { get; }
        public string Semantic { get; }
        public int RowCount { get; }
        public int ColumnCount { get; }
        public int ElementCount { get; }
        public SourceEffectParameterClass ParameterClass { get; }
        public SourceEffectParameterType ParameterType { get; }
        public int ValueOffset { get; }
        public int ValueByteCount { get; }
        public string StringValue { get; }
        public IReadOnlyList<SourceEffectParameterDescription> StructureMembers { get; }
        public IReadOnlyList<SourceEffectAnnotationDescription> Annotations { get; }

        public SourceEffectParameterDescription(string name, string semantic, int rows, int columns, int elements,
            SourceEffectParameterClass parameterClass, SourceEffectParameterType parameterType,
            int valueOffset, int valueByteCount, string stringValue = null,
            IReadOnlyList<SourceEffectParameterDescription> structureMembers = null,
            IReadOnlyList<SourceEffectAnnotationDescription> annotations = null)
        {
            if (rows < 0) throw new ArgumentOutOfRangeException(nameof(rows));
            if (columns < 0) throw new ArgumentOutOfRangeException(nameof(columns));
            if (elements < 0) throw new ArgumentOutOfRangeException(nameof(elements));
            if (valueOffset < 0) throw new ArgumentOutOfRangeException(nameof(valueOffset));
            if (valueByteCount < 0) throw new ArgumentOutOfRangeException(nameof(valueByteCount));
            Name = name;
            Semantic = semantic;
            RowCount = rows;
            ColumnCount = columns;
            ElementCount = elements;
            ParameterClass = parameterClass;
            ParameterType = parameterType;
            ValueOffset = valueOffset;
            ValueByteCount = valueByteCount;
            StringValue = stringValue;
            StructureMembers = structureMembers;
            Annotations = annotations;
        }

        public SourceEffectParameter CreateParameter(SourceEffectValueBuffer values, int baseOffset = 0,
            SourceEffect effect = null)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            return new SourceEffectParameter(this, values, checked(baseOffset + ValueOffset), effect);
        }

        internal SourceEffectParameterCollection ReadStructureMembers(SourceEffectValueBuffer values, int offset,
            SourceEffect effect)
        {
            if (StructureMembers == null || StructureMembers.Count == 0) return null;
            var members = new List<SourceEffectParameter>(StructureMembers.Count);
            for (int i = 0; i < StructureMembers.Count; i++)
                members.Add(StructureMembers[i].CreateParameter(values, offset, effect));
            return new SourceEffectParameterCollection(members);
        }

        internal SourceEffectAnnotationCollection ReadAnnotations(SourceEffectValueBuffer values)
        {
            if (Annotations == null || Annotations.Count == 0) return SourceEffectAnnotationCollection.Empty;
            var annotations = new List<SourceEffectAnnotation>(Annotations.Count);
            for (int i = 0; i < Annotations.Count; i++) annotations.Add(Annotations[i].CreateAnnotation(values));
            return new SourceEffectAnnotationCollection(annotations);
        }
    }
}
