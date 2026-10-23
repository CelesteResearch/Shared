using System;

namespace Celeste.Graphics.Rendering.Effects
{
    public sealed class SourceEffectAnnotationDescription
    {
        public string Name { get; }
        public string Semantic { get; }
        public int RowCount { get; }
        public int ColumnCount { get; }
        public SourceEffectParameterClass ParameterClass { get; }
        public SourceEffectParameterType ParameterType { get; }
        public int ValueOffset { get; }
        public int ValueByteCount { get; }
        public string StringValue { get; }

        public SourceEffectAnnotationDescription(string name, string semantic, int rows, int columns,
            SourceEffectParameterClass parameterClass, SourceEffectParameterType parameterType,
            int valueOffset, int valueByteCount, string stringValue = null)
        {
            if (rows < 0) throw new ArgumentOutOfRangeException(nameof(rows));
            if (columns < 0) throw new ArgumentOutOfRangeException(nameof(columns));
            if (valueOffset < 0) throw new ArgumentOutOfRangeException(nameof(valueOffset));
            if (valueByteCount < 0) throw new ArgumentOutOfRangeException(nameof(valueByteCount));
            Name = name;
            Semantic = semantic;
            RowCount = rows;
            ColumnCount = columns;
            ParameterClass = parameterClass;
            ParameterType = parameterType;
            ValueOffset = valueOffset;
            ValueByteCount = valueByteCount;
            StringValue = stringValue;
        }

        public SourceEffectAnnotation CreateAnnotation(SourceEffectValueBuffer values, int baseOffset = 0)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            return new(this, values, checked(baseOffset + ValueOffset));
        }
    }
}
