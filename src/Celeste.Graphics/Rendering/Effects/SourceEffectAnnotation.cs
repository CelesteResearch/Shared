using System;
using System.Numerics;

namespace Celeste.Graphics.Rendering.Effects
{
    public sealed class SourceEffectAnnotation
    {
        internal string cachedString = string.Empty;

        private readonly IntPtr values;

        private readonly SourceEffectValueBuffer valueBuffer;
        private readonly int valueOffset;
        private readonly int valueByteCount;

        public string Name { get; private set; }

        public string Semantic { get; private set; }

        public int RowCount { get; private set; }

        public int ColumnCount { get; private set; }

        public SourceEffectParameterClass ParameterClass { get; private set; }

        public SourceEffectParameterType ParameterType { get; private set; }

        internal SourceEffectAnnotation(string name, string semantic, int rowCount, int columnCount,
            SourceEffectParameterClass parameterClass, SourceEffectParameterType parameterType, IntPtr data)
        {
            Name = name;
            Semantic = semantic ?? string.Empty;
            RowCount = rowCount;
            ColumnCount = columnCount;
            ParameterClass = parameterClass;
            ParameterType = parameterType;
            values = data;
        }

        internal SourceEffectAnnotation(SourceEffectAnnotationDescription description, SourceEffectValueBuffer buffer,
            int offset)
            : this(description.Name, description.Semantic, description.RowCount, description.ColumnCount,
                description.ParameterClass, description.ParameterType,
                buffer.GetAddress(offset, description.ValueByteCount))
        {
            valueBuffer = buffer;
            valueOffset = offset;
            valueByteCount = description.ValueByteCount;
            if (description.StringValue != null) cachedString = description.StringValue;
        }

        private void ValidateValueBytes(int count)
        {
            if ((uint)count > (uint)valueByteCount) throw new ArgumentOutOfRangeException(nameof(count));
            valueBuffer.GetAddress(valueOffset, count);
        }

        public unsafe bool GetValueBoolean()
        {
            if (valueBuffer != null) ValidateValueBytes(4);
            var ptr = (int*)(void*)values;
            var result = *ptr != 0;
            GC.KeepAlive(valueBuffer);
            return result;
        }

        public unsafe int GetValueInt32()
        {
            if (valueBuffer != null) ValidateValueBytes(4);
            var ptr = (int*)(void*)values;
            var result = *ptr;
            GC.KeepAlive(valueBuffer);
            return result;
        }

        public unsafe Matrix4x4 GetValueMatrix()
        {
            if (valueBuffer != null) ValidateValueBytes(64);
            var ptr = (float*)(void*)values;
            var result = new Matrix4x4(*ptr, ptr[4], ptr[8], ptr[12], ptr[1], ptr[5], ptr[9], ptr[13], ptr[2], ptr[6],
                ptr[10],
                ptr[14], ptr[3], ptr[7], ptr[11], ptr[15]);
            GC.KeepAlive(valueBuffer);
            return result;
        }

        public unsafe float GetValueSingle()
        {
            if (valueBuffer != null) ValidateValueBytes(4);
            var ptr = (float*)(void*)values;
            var result = *ptr;
            GC.KeepAlive(valueBuffer);
            return result;
        }

        public string GetValueString()
        {
            return cachedString;
        }

        public unsafe Vector2 GetValueVector2()
        {
            if (valueBuffer != null) ValidateValueBytes(8);
            var ptr = (float*)(void*)values;
            var result = new Vector2(*ptr, ptr[1]);
            GC.KeepAlive(valueBuffer);
            return result;
        }

        public unsafe Vector3 GetValueVector3()
        {
            if (valueBuffer != null) ValidateValueBytes(12);
            var ptr = (float*)(void*)values;
            var result = new Vector3(*ptr, ptr[1], ptr[2]);
            GC.KeepAlive(valueBuffer);
            return result;
        }

        public unsafe Vector4 GetValueVector4()
        {
            if (valueBuffer != null) ValidateValueBytes(16);
            var ptr = (float*)(void*)values;
            var result = new Vector4(*ptr, ptr[1], ptr[2], ptr[3]);
            GC.KeepAlive(valueBuffer);
            return result;
        }
    }
}
