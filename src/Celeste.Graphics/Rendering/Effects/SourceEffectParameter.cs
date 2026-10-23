using Celeste.Graphics.Rendering.Textures;
using System.Numerics;
using Celeste.Core.Rendering.Resources;
using Celeste.Core.Rendering.States;
using Celeste.Core.Rendering;
using Celeste.Graphics.Display;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Rendering.Effects
{
    public sealed class SourceEffectParameter : global::Celeste.Core.Scheduling.ISourceDistortionParameter
    {
        internal SourceTextureResource texture;

        internal string cachedString = string.Empty;

        internal IntPtr values;

        internal uint valuesSizeBytes;

        internal IntPtr mojoType;

        internal int elementCount;

        internal SourceEffectParameterCollection elements;

        internal SourceEffectParameterCollection members;

        private SourceEffect outer;

        private SourceEffectValueBuffer valueBuffer;
        private SourceEffectParameterDescription description;
        private int valueOffset;
        private int valueByteCount;

        public string Name { get; private set; }

        public string Semantic { get; private set; }

        public int RowCount { get; private set; }

        public int ColumnCount { get; private set; }

        public SourceEffectParameterClass ParameterClass { get; private set; }

        public SourceEffectParameterType ParameterType { get; private set; }

        public SourceEffectParameterCollection Elements
        {
            get
            {
                if (elementCount > 0 && elements == null)
                {
                    BuildElementList();
                }

                return elements;
            }
        }

        public SourceEffectParameterCollection StructureMembers
        {
            get
            {
                if (mojoType != IntPtr.Zero && members == null)
                {
                    BuildMemberList();
                }
                else if (description != null && members == null)
                {
                    members = description.ReadStructureMembers(valueBuffer, valueOffset, outer);
                }

                return members;
            }
        }

        public SourceEffectAnnotationCollection Annotations { get; private set; }

        internal SourceEffectParameter(string name, string semantic, int rowCount, int columnCount, int elementCount,
            SourceEffectParameterClass parameterClass, SourceEffectParameterType parameterType, IntPtr mojoType,
            SourceEffectAnnotationCollection annotations, IntPtr data, uint dataSizeBytes, SourceEffect effect)
        {
            if (data == IntPtr.Zero)
            {
                throw new ArgumentNullException("data");
            }

            Name = name;
            Semantic = semantic ?? string.Empty;
            RowCount = rowCount;
            ColumnCount = columnCount;
            this.elementCount = elementCount;
            ParameterClass = parameterClass;
            ParameterType = parameterType;
            this.mojoType = mojoType;
            Annotations = annotations;
            values = data;
            valuesSizeBytes = dataSizeBytes;
            outer = effect;
        }

        internal SourceEffectParameter(string name, string semantic, int rowCount, int columnCount, int elementCount,
            SourceEffectParameterClass parameterClass, SourceEffectParameterType parameterType,
            SourceEffectParameterCollection structureMembers, SourceEffectAnnotationCollection annotations, IntPtr data,
            uint dataSizeBytes, SourceEffect effect)
        {
            if (data == IntPtr.Zero)
            {
                throw new ArgumentNullException("data");
            }

            Name = name;
            Semantic = semantic ?? string.Empty;
            RowCount = rowCount;
            ColumnCount = columnCount;
            this.elementCount = elementCount;
            ParameterClass = parameterClass;
            ParameterType = parameterType;
            members = structureMembers;
            Annotations = annotations;
            values = data;
            valuesSizeBytes = dataSizeBytes;
            outer = effect;
        }

        internal void BuildMemberList()
        {
            members = SourceEffect.INTERNAL_readEffectParameterStructureMembers(this, mojoType, outer);
        }

        internal SourceEffectParameter(SourceEffectParameterDescription description, SourceEffectValueBuffer values,
            int valueOffset, SourceEffect effect)
            : this(description.Name, description.Semantic, description.RowCount, description.ColumnCount,
                description.ElementCount, description.ParameterClass, description.ParameterType, IntPtr.Zero,
                description.ReadAnnotations(values), values.GetAddress(valueOffset, description.ValueByteCount),
                (uint)description.ValueByteCount, effect)
        {
            this.description = description;
            valueBuffer = values;
            this.valueOffset = valueOffset;
            valueByteCount = description.ValueByteCount;
            if (description.StringValue != null) cachedString = description.StringValue;
        }

        internal void BuildElementList()
        {
            if (elementCount <= 0)
            {
                return;
            }

            int num = 0;
            List<SourceEffectParameter> list = new List<SourceEffectParameter>(elementCount);
            SourceEffectParameterCollection structureMembers = StructureMembers;
            for (int i = 0; i < elementCount; i++)
            {
                SourceEffectParameterCollection structureMembers2 = null;
                if (structureMembers != null)
                {
                    List<SourceEffectParameter> list2 = new List<SourceEffectParameter>();
                    for (int j = 0; j < structureMembers.Count; j++)
                    {
                        int num2 = 0;
                        if (structureMembers[j].Elements != null)
                        {
                            num2 = structureMembers[j].Elements.Count;
                        }

                        int num3 = structureMembers[j].RowCount * 4;
                        if (num2 > 0)
                        {
                            num3 *= num2;
                        }

                        var member = new SourceEffectParameter(structureMembers[j].Name, structureMembers[j].Semantic,
                            structureMembers[j].RowCount, structureMembers[j].ColumnCount, num2,
                            structureMembers[j].ParameterClass, structureMembers[j].ParameterType, IntPtr.Zero,
                            structureMembers[j].Annotations, new IntPtr(values.ToInt64() + num), (uint)(num3 * 4),
                            outer);
                        RetainValueBuffer(member, num);
                        list2.Add(member);
                        num += num3 * 4;
                    }

                    structureMembers2 = new SourceEffectParameterCollection(list2);
                }

                var element = new SourceEffectParameter(null, null, RowCount, ColumnCount, 0, ParameterClass,
                    ParameterType,
                    structureMembers2, null, new IntPtr(values.ToInt64() + i * RowCount * 16), 0u, outer);
                RetainValueBuffer(element, i * RowCount * 16);
                list.Add(element);
            }

            elements = new SourceEffectParameterCollection(list);
        }

        private void RetainValueBuffer(SourceEffectParameter parameter, int offset)
        {
            if (valueBuffer == null) return;
            ValidateValueBytes(offset);
            parameter.valueBuffer = valueBuffer;
            parameter.valueOffset = checked(valueOffset + offset);
            parameter.valueByteCount = valueByteCount - offset;
        }

        private void ValidateValueBytes(int count)
        {
            if ((uint)count > (uint)valueByteCount) throw new ArgumentOutOfRangeException(nameof(count));
            valueBuffer.GetAddress(valueOffset, count);
        }

        private int ScalarArrayBytes(int count)
            => count == 0 ? 0 : checked((count - 1) / ColumnCount * 16 + ColumnCount * 4);

        private int VectorArrayBytes(int count, int size)
            => count == 0 ? 0 : checked((count - 1) * 16 + size);

        private int MatrixBytes(int count, bool transpose)
        {
            if (count == 0) return 0;
            int size, stride;
            if (ColumnCount == 4 && RowCount == 4)
            {
                size = stride = 64;
            }
            else if (ColumnCount == 3 && RowCount == 3)
            {
                size = 44;
                stride = 48;
            }
            else if (ColumnCount == 4 && RowCount == 3)
            {
                size = transpose ? 60 : 48;
                stride = transpose ? 64 : 48;
            }
            else if (ColumnCount == 3 && RowCount == 4)
            {
                size = transpose ? 48 : 60;
                stride = transpose ? 48 : 64;
            }
            else if (ColumnCount == 2 && RowCount == 2)
            {
                size = 24;
                stride = 32;
            }
            else return 0; // The original matrix setter reports unsupported dimensions.

            return checked((count - 1) * stride + size);
        }

        public unsafe bool GetValueBoolean()
        {
            if (valueBuffer != null) ValidateValueBytes(4);
            int* ptr = (int*)(void*)values;
            var result = *ptr != 0;
            GC.KeepAlive(valueBuffer);
            return result;
        }

        public unsafe bool[] GetValueBooleanArray(int count)
        {
            if (valueBuffer != null) ValidateValueBytes(ScalarArrayBytes(count));
            bool[] array = new bool[count];
            int* ptr = (int*)(void*)values;
            int num = 0;
            while (num < array.Length)
            {
                int num2 = 0;
                while (num2 < ColumnCount)
                {
                    array[num] = ptr[num2] != 0;
                    num2++;
                    num++;
                }

                ptr += 4;
            }

            var result = array;
            GC.KeepAlive(valueBuffer);
            return result;
        }

        public unsafe int GetValueInt32()
        {
            if (valueBuffer != null) ValidateValueBytes(4);
            int* ptr = (int*)(void*)values;
            var result = *ptr;
            GC.KeepAlive(valueBuffer);
            return result;
        }

        public int[] GetValueInt32Array(int count)
        {
            if (valueBuffer != null) ValidateValueBytes(ScalarArrayBytes(count));
            int[] array = new int[count];
            int num = 0;
            int num2 = 0;
            while (num < array.Length)
            {
                Marshal.Copy(values + num2, array, num, ColumnCount);
                num += ColumnCount;
                num2 += 16;
            }

            var result = array;
            GC.KeepAlive(valueBuffer);
            return result;
        }

        public unsafe Matrix4x4 GetValueMatrixTranspose()
        {
            if (valueBuffer != null) ValidateValueBytes(64);
            float* ptr = (float*)(void*)values;
            var result = new Matrix4x4(*ptr, ptr[1], ptr[2], ptr[3], ptr[4], ptr[5], ptr[6], ptr[7], ptr[8], ptr[9],
                ptr[10],
                ptr[11], ptr[12], ptr[13], ptr[14], ptr[15]);
            GC.KeepAlive(valueBuffer);
            return result;
        }

        public unsafe Matrix4x4[] GetValueMatrixTransposeArray(int count)
        {
            if (valueBuffer != null) ValidateValueBytes(checked(count * 64));
            Matrix4x4[] array = new Matrix4x4[count];
            float* ptr = (float*)(void*)values;
            int num = 0;
            while (num < count)
            {
                array[num] = new Matrix4x4(*ptr, ptr[1], ptr[2], ptr[3], ptr[4], ptr[5], ptr[6], ptr[7], ptr[8], ptr[9],
                    ptr[10], ptr[11], ptr[12], ptr[13], ptr[14], ptr[15]);
                num++;
                ptr += 16;
            }

            var result = array;
            GC.KeepAlive(valueBuffer);
            return result;
        }

        public unsafe Matrix4x4 GetValueMatrix()
        {
            if (valueBuffer != null) ValidateValueBytes(64);
            float* ptr = (float*)(void*)values;
            var result = new Matrix4x4(*ptr, ptr[4], ptr[8], ptr[12], ptr[1], ptr[5], ptr[9], ptr[13], ptr[2], ptr[6],
                ptr[10],
                ptr[14], ptr[3], ptr[7], ptr[11], ptr[15]);
            GC.KeepAlive(valueBuffer);
            return result;
        }

        public unsafe Matrix4x4[] GetValueMatrixArray(int count)
        {
            if (valueBuffer != null) ValidateValueBytes(checked(count * 64));
            Matrix4x4[] array = new Matrix4x4[count];
            float* ptr = (float*)(void*)values;
            int num = 0;
            while (num < count)
            {
                array[num] = new Matrix4x4(*ptr, ptr[4], ptr[8], ptr[12], ptr[1], ptr[5], ptr[9], ptr[13], ptr[2],
                    ptr[6],
                    ptr[10], ptr[14], ptr[3], ptr[7], ptr[11], ptr[15]);
                num++;
                ptr += 16;
            }

            var result = array;
            GC.KeepAlive(valueBuffer);
            return result;
        }

        public unsafe Quaternion GetValueQuaternion()
        {
            if (valueBuffer != null) ValidateValueBytes(16);
            float* ptr = (float*)(void*)values;
            var result = new Quaternion(*ptr, ptr[1], ptr[2], ptr[3]);
            GC.KeepAlive(valueBuffer);
            return result;
        }

        public unsafe Quaternion[] GetValueQuaternionArray(int count)
        {
            if (valueBuffer != null) ValidateValueBytes(VectorArrayBytes(count, 16));
            Quaternion[] array = new Quaternion[count];
            float* ptr = (float*)(void*)values;
            int num = 0;
            while (num < count)
            {
                array[num] = new Quaternion(*ptr, ptr[1], ptr[2], ptr[3]);
                num++;
                ptr += 4;
            }

            var result = array;
            GC.KeepAlive(valueBuffer);
            return result;
        }

        public unsafe float GetValueSingle()
        {
            if (valueBuffer != null) ValidateValueBytes(4);
            float* ptr = (float*)(void*)values;
            var result = *ptr;
            GC.KeepAlive(valueBuffer);
            return result;
        }

        public float[] GetValueSingleArray(int count)
        {
            if (valueBuffer != null) ValidateValueBytes(ScalarArrayBytes(count));
            float[] array = new float[count];
            int num = 0;
            int num2 = 0;
            while (num < array.Length)
            {
                Marshal.Copy(values + num2, array, num, ColumnCount);
                num += ColumnCount;
                num2 += 16;
            }

            var result = array;
            GC.KeepAlive(valueBuffer);
            return result;
        }

        public string GetValueString()
        {
            return cachedString;
        }

        public SourceTexture2DResource GetValueTexture2D()
        {
            return (SourceTexture2DResource)texture;
        }

        public SourceTexture3DResource GetValueTexture3D()
        {
            return (SourceTexture3DResource)texture;
        }

        public SourceTextureCubeResource GetValueTextureCube()
        {
            return (SourceTextureCubeResource)texture;
        }

        public unsafe Vector2 GetValueVector2()
        {
            if (valueBuffer != null) ValidateValueBytes(8);
            float* ptr = (float*)(void*)values;
            var result = new Vector2(*ptr, ptr[1]);
            GC.KeepAlive(valueBuffer);
            return result;
        }

        public unsafe Vector2[] GetValueVector2Array(int count)
        {
            if (valueBuffer != null) ValidateValueBytes(VectorArrayBytes(count, 8));
            Vector2[] array = new Vector2[count];
            float* ptr = (float*)(void*)values;
            int num = 0;
            while (num < count)
            {
                array[num] = new Vector2(*ptr, ptr[1]);
                num++;
                ptr += 4;
            }

            var result = array;
            GC.KeepAlive(valueBuffer);
            return result;
        }

        public unsafe Vector3 GetValueVector3()
        {
            if (valueBuffer != null) ValidateValueBytes(12);
            float* ptr = (float*)(void*)values;
            var result = new Vector3(*ptr, ptr[1], ptr[2]);
            GC.KeepAlive(valueBuffer);
            return result;
        }

        public unsafe Vector3[] GetValueVector3Array(int count)
        {
            if (valueBuffer != null) ValidateValueBytes(VectorArrayBytes(count, 12));
            Vector3[] array = new Vector3[count];
            float* ptr = (float*)(void*)values;
            int num = 0;
            while (num < count)
            {
                array[num] = new Vector3(*ptr, ptr[1], ptr[2]);
                num++;
                ptr += 4;
            }

            var result = array;
            GC.KeepAlive(valueBuffer);
            return result;
        }

        public unsafe Vector4 GetValueVector4()
        {
            if (valueBuffer != null) ValidateValueBytes(16);
            float* ptr = (float*)(void*)values;
            var result = new Vector4(*ptr, ptr[1], ptr[2], ptr[3]);
            GC.KeepAlive(valueBuffer);
            return result;
        }

        public unsafe Vector4[] GetValueVector4Array(int count)
        {
            if (valueBuffer != null) ValidateValueBytes(VectorArrayBytes(count, 16));
            Vector4[] array = new Vector4[count];
            float* ptr = (float*)(void*)values;
            int num = 0;
            while (num < count)
            {
                array[num] = new Vector4(*ptr, ptr[1], ptr[2], ptr[3]);
                num++;
                ptr += 4;
            }

            var result = array;
            GC.KeepAlive(valueBuffer);
            return result;
        }

        public unsafe void SetValue(bool value)
        {
            if (valueBuffer != null) ValidateValueBytes(4);
            int* ptr = (int*)(void*)values;
            *ptr = (value ? 1 : 0);

            GC.KeepAlive(valueBuffer);
        }

        public unsafe void SetValue(bool[] value)
        {
            if (valueBuffer != null) ValidateValueBytes(ScalarArrayBytes(value.Length));
            int* ptr = (int*)(void*)values;
            int num = 0;
            while (num < value.Length)
            {
                int num2 = 0;
                while (num2 < ColumnCount)
                {
                    ptr[num2] = (value[num] ? 1 : 0);
                    num2++;
                    num++;
                }

                ptr += 4;
            }

            GC.KeepAlive(valueBuffer);
        }

        public unsafe void SetValue(int value)
        {
            if (valueBuffer != null) ValidateValueBytes(4);
            if (ParameterType == SourceEffectParameterType.Single)
            {
                float* ptr = (float*)(void*)values;
                *ptr = value;
            }
            else
            {
                int* ptr2 = (int*)(void*)values;
                *ptr2 = value;
            }

            GC.KeepAlive(valueBuffer);
        }

        public void SetValue(int[] value)
        {
            if (valueBuffer != null) ValidateValueBytes(ScalarArrayBytes(value.Length));
            int num = 0;
            int num2 = 0;
            while (num < value.Length)
            {
                Marshal.Copy(value, num, values + num2, ColumnCount);
                num += ColumnCount;
                num2 += 16;
            }

            GC.KeepAlive(valueBuffer);
        }

        public unsafe void SetValueTranspose(Matrix4x4 value)
        {
            if (valueBuffer != null) ValidateValueBytes(MatrixBytes(1, true));
            float* ptr = (float*)(void*)values;
            if (ColumnCount == 4 && RowCount == 4)
            {
                *ptr = value.M11;
                ptr[1] = value.M12;
                ptr[2] = value.M13;
                ptr[3] = value.M14;
                ptr[4] = value.M21;
                ptr[5] = value.M22;
                ptr[6] = value.M23;
                ptr[7] = value.M24;
                ptr[8] = value.M31;
                ptr[9] = value.M32;
                ptr[10] = value.M33;
                ptr[11] = value.M34;
                ptr[12] = value.M41;
                ptr[13] = value.M42;
                ptr[14] = value.M43;
                ptr[15] = value.M44;
            }
            else if (ColumnCount == 3 && RowCount == 3)
            {
                *ptr = value.M11;
                ptr[1] = value.M12;
                ptr[2] = value.M13;
                ptr[4] = value.M21;
                ptr[5] = value.M22;
                ptr[6] = value.M23;
                ptr[8] = value.M31;
                ptr[9] = value.M32;
                ptr[10] = value.M33;
            }
            else if (ColumnCount == 4 && RowCount == 3)
            {
                *ptr = value.M11;
                ptr[1] = value.M12;
                ptr[2] = value.M13;
                ptr[4] = value.M21;
                ptr[5] = value.M22;
                ptr[6] = value.M23;
                ptr[8] = value.M31;
                ptr[9] = value.M32;
                ptr[10] = value.M33;
                ptr[12] = value.M41;
                ptr[13] = value.M42;
                ptr[14] = value.M43;
            }
            else if (ColumnCount == 3 && RowCount == 4)
            {
                *ptr = value.M11;
                ptr[1] = value.M12;
                ptr[2] = value.M13;
                ptr[3] = value.M14;
                ptr[4] = value.M21;
                ptr[5] = value.M22;
                ptr[6] = value.M23;
                ptr[7] = value.M24;
                ptr[8] = value.M31;
                ptr[9] = value.M32;
                ptr[10] = value.M33;
                ptr[11] = value.M34;
            }
            else
            {
                if (ColumnCount != 2 || RowCount != 2)
                {
                    throw new NotImplementedException("Matrix4x4 Size: " + RowCount + " " + ColumnCount);
                }

                *ptr = value.M11;
                ptr[1] = value.M12;
                ptr[4] = value.M21;
                ptr[5] = value.M22;
            }

            GC.KeepAlive(valueBuffer);
        }

        public unsafe void SetValueTranspose(Matrix4x4[] value)
        {
            if (valueBuffer != null) ValidateValueBytes(MatrixBytes(value.Length, true));
            float* ptr = (float*)(void*)values;
            if (ColumnCount == 4 && RowCount == 4)
            {
                int num = 0;
                while (num < value.Length)
                {
                    *ptr = value[num].M11;
                    ptr[1] = value[num].M12;
                    ptr[2] = value[num].M13;
                    ptr[3] = value[num].M14;
                    ptr[4] = value[num].M21;
                    ptr[5] = value[num].M22;
                    ptr[6] = value[num].M23;
                    ptr[7] = value[num].M24;
                    ptr[8] = value[num].M31;
                    ptr[9] = value[num].M32;
                    ptr[10] = value[num].M33;
                    ptr[11] = value[num].M34;
                    ptr[12] = value[num].M41;
                    ptr[13] = value[num].M42;
                    ptr[14] = value[num].M43;
                    ptr[15] = value[num].M44;
                    num++;
                    ptr += 16;
                }
            }
            else if (ColumnCount == 3 && RowCount == 3)
            {
                int num2 = 0;
                while (num2 < value.Length)
                {
                    *ptr = value[num2].M11;
                    ptr[1] = value[num2].M12;
                    ptr[2] = value[num2].M13;
                    ptr[4] = value[num2].M21;
                    ptr[5] = value[num2].M22;
                    ptr[6] = value[num2].M23;
                    ptr[8] = value[num2].M31;
                    ptr[9] = value[num2].M32;
                    ptr[10] = value[num2].M33;
                    num2++;
                    ptr += 12;
                }
            }
            else if (ColumnCount == 4 && RowCount == 3)
            {
                int num3 = 0;
                while (num3 < value.Length)
                {
                    *ptr = value[num3].M11;
                    ptr[1] = value[num3].M12;
                    ptr[2] = value[num3].M13;
                    ptr[4] = value[num3].M21;
                    ptr[5] = value[num3].M22;
                    ptr[6] = value[num3].M23;
                    ptr[8] = value[num3].M31;
                    ptr[9] = value[num3].M32;
                    ptr[10] = value[num3].M33;
                    ptr[12] = value[num3].M41;
                    ptr[13] = value[num3].M42;
                    ptr[14] = value[num3].M43;
                    num3++;
                    ptr += 16;
                }
            }
            else if (ColumnCount == 3 && RowCount == 4)
            {
                int num4 = 0;
                while (num4 < value.Length)
                {
                    *ptr = value[num4].M11;
                    ptr[1] = value[num4].M12;
                    ptr[2] = value[num4].M13;
                    ptr[3] = value[num4].M14;
                    ptr[4] = value[num4].M21;
                    ptr[5] = value[num4].M22;
                    ptr[6] = value[num4].M23;
                    ptr[7] = value[num4].M24;
                    ptr[8] = value[num4].M31;
                    ptr[9] = value[num4].M32;
                    ptr[10] = value[num4].M33;
                    ptr[11] = value[num4].M34;
                    num4++;
                    ptr += 12;
                }
            }
            else
            {
                if (ColumnCount != 2 || RowCount != 2)
                {
                    throw new NotImplementedException("Matrix4x4 Size: " + RowCount + " " + ColumnCount);
                }

                int num5 = 0;
                while (num5 < value.Length)
                {
                    *ptr = value[num5].M11;
                    ptr[1] = value[num5].M12;
                    ptr[4] = value[num5].M21;
                    ptr[5] = value[num5].M22;
                    num5++;
                    ptr += 8;
                }
            }

            GC.KeepAlive(valueBuffer);
        }

        public unsafe void SetValue(Matrix4x4 value)
        {
            if (valueBuffer != null) ValidateValueBytes(MatrixBytes(1, false));
            float* ptr = (float*)(void*)values;
            if (ColumnCount == 4 && RowCount == 4)
            {
                *ptr = value.M11;
                ptr[1] = value.M21;
                ptr[2] = value.M31;
                ptr[3] = value.M41;
                ptr[4] = value.M12;
                ptr[5] = value.M22;
                ptr[6] = value.M32;
                ptr[7] = value.M42;
                ptr[8] = value.M13;
                ptr[9] = value.M23;
                ptr[10] = value.M33;
                ptr[11] = value.M43;
                ptr[12] = value.M14;
                ptr[13] = value.M24;
                ptr[14] = value.M34;
                ptr[15] = value.M44;
            }
            else if (ColumnCount == 3 && RowCount == 3)
            {
                *ptr = value.M11;
                ptr[1] = value.M21;
                ptr[2] = value.M31;
                ptr[4] = value.M12;
                ptr[5] = value.M22;
                ptr[6] = value.M32;
                ptr[8] = value.M13;
                ptr[9] = value.M23;
                ptr[10] = value.M33;
            }
            else if (ColumnCount == 4 && RowCount == 3)
            {
                *ptr = value.M11;
                ptr[1] = value.M21;
                ptr[2] = value.M31;
                ptr[3] = value.M41;
                ptr[4] = value.M12;
                ptr[5] = value.M22;
                ptr[6] = value.M32;
                ptr[7] = value.M42;
                ptr[8] = value.M13;
                ptr[9] = value.M23;
                ptr[10] = value.M33;
                ptr[11] = value.M43;
            }
            else if (ColumnCount == 3 && RowCount == 4)
            {
                *ptr = value.M11;
                ptr[1] = value.M21;
                ptr[2] = value.M31;
                ptr[4] = value.M12;
                ptr[5] = value.M22;
                ptr[6] = value.M32;
                ptr[8] = value.M13;
                ptr[9] = value.M23;
                ptr[10] = value.M33;
                ptr[12] = value.M14;
                ptr[13] = value.M24;
                ptr[14] = value.M34;
            }
            else
            {
                if (ColumnCount != 2 || RowCount != 2)
                {
                    throw new NotImplementedException("Matrix4x4 Size: " + RowCount + " " + ColumnCount);
                }

                *ptr = value.M11;
                ptr[1] = value.M21;
                ptr[4] = value.M12;
                ptr[5] = value.M22;
            }

            GC.KeepAlive(valueBuffer);
        }

        public unsafe void SetValue(Matrix4x4[] value)
        {
            if (valueBuffer != null) ValidateValueBytes(MatrixBytes(value.Length, false));
            float* ptr = (float*)(void*)values;
            if (ColumnCount == 4 && RowCount == 4)
            {
                int num = 0;
                while (num < value.Length)
                {
                    *ptr = value[num].M11;
                    ptr[1] = value[num].M21;
                    ptr[2] = value[num].M31;
                    ptr[3] = value[num].M41;
                    ptr[4] = value[num].M12;
                    ptr[5] = value[num].M22;
                    ptr[6] = value[num].M32;
                    ptr[7] = value[num].M42;
                    ptr[8] = value[num].M13;
                    ptr[9] = value[num].M23;
                    ptr[10] = value[num].M33;
                    ptr[11] = value[num].M43;
                    ptr[12] = value[num].M14;
                    ptr[13] = value[num].M24;
                    ptr[14] = value[num].M34;
                    ptr[15] = value[num].M44;
                    num++;
                    ptr += 16;
                }
            }
            else if (ColumnCount == 3 && RowCount == 3)
            {
                int num2 = 0;
                while (num2 < value.Length)
                {
                    *ptr = value[num2].M11;
                    ptr[1] = value[num2].M21;
                    ptr[2] = value[num2].M31;
                    ptr[4] = value[num2].M12;
                    ptr[5] = value[num2].M22;
                    ptr[6] = value[num2].M32;
                    ptr[8] = value[num2].M13;
                    ptr[9] = value[num2].M23;
                    ptr[10] = value[num2].M33;
                    num2++;
                    ptr += 12;
                }
            }
            else if (ColumnCount == 4 && RowCount == 3)
            {
                int num3 = 0;
                while (num3 < value.Length)
                {
                    *ptr = value[num3].M11;
                    ptr[1] = value[num3].M21;
                    ptr[2] = value[num3].M31;
                    ptr[3] = value[num3].M41;
                    ptr[4] = value[num3].M12;
                    ptr[5] = value[num3].M22;
                    ptr[6] = value[num3].M32;
                    ptr[7] = value[num3].M42;
                    ptr[8] = value[num3].M13;
                    ptr[9] = value[num3].M23;
                    ptr[10] = value[num3].M33;
                    ptr[11] = value[num3].M43;
                    num3++;
                    ptr += 12;
                }
            }
            else if (ColumnCount == 3 && RowCount == 4)
            {
                int num4 = 0;
                while (num4 < value.Length)
                {
                    *ptr = value[num4].M11;
                    ptr[1] = value[num4].M21;
                    ptr[2] = value[num4].M31;
                    ptr[4] = value[num4].M12;
                    ptr[5] = value[num4].M22;
                    ptr[6] = value[num4].M32;
                    ptr[8] = value[num4].M13;
                    ptr[9] = value[num4].M23;
                    ptr[10] = value[num4].M33;
                    ptr[12] = value[num4].M14;
                    ptr[13] = value[num4].M24;
                    ptr[14] = value[num4].M34;
                    num4++;
                    ptr += 16;
                }
            }
            else
            {
                if (ColumnCount != 2 || RowCount != 2)
                {
                    throw new NotImplementedException("Matrix4x4 Size: " + RowCount + " " + ColumnCount);
                }

                int num5 = 0;
                while (num5 < value.Length)
                {
                    *ptr = value[num5].M11;
                    ptr[1] = value[num5].M21;
                    ptr[4] = value[num5].M12;
                    ptr[5] = value[num5].M22;
                    num5++;
                    ptr += 8;
                }
            }

            GC.KeepAlive(valueBuffer);
        }

        public unsafe void SetValue(Quaternion value)
        {
            if (valueBuffer != null) ValidateValueBytes(16);
            float* ptr = (float*)(void*)values;
            *ptr = value.X;
            ptr[1] = value.Y;
            ptr[2] = value.Z;
            ptr[3] = value.W;

            GC.KeepAlive(valueBuffer);
        }

        public unsafe void SetValue(Quaternion[] value)
        {
            if (valueBuffer != null) ValidateValueBytes(VectorArrayBytes(value.Length, 16));
            float* ptr = (float*)(void*)values;
            int num = 0;
            while (num < value.Length)
            {
                *ptr = value[num].X;
                ptr[1] = value[num].Y;
                ptr[2] = value[num].Z;
                ptr[3] = value[num].W;
                num++;
                ptr += 4;
            }

            GC.KeepAlive(valueBuffer);
        }

        public unsafe void SetValue(float value)
        {
            if (valueBuffer != null) ValidateValueBytes(4);
            float* ptr = (float*)(void*)values;
            *ptr = value;

            GC.KeepAlive(valueBuffer);
        }

        public void SetValue(float[] value)
        {
            if (valueBuffer != null) ValidateValueBytes(ScalarArrayBytes(value.Length));
            int num = 0;
            int num2 = 0;
            while (num < value.Length)
            {
                Marshal.Copy(value, num, values + num2, ColumnCount);
                num += ColumnCount;
                num2 += 16;
            }

            GC.KeepAlive(valueBuffer);
        }

        public void SetValue(string value)
        {
            throw new NotImplementedException("effect->objects[?]");
        }

        public void SetValue(SourceTextureResource value)
        {
            texture = value;
        }

        public unsafe void SetValue(Vector2 value)
        {
            if (valueBuffer != null) ValidateValueBytes(8);
            float* ptr = (float*)(void*)values;
            *ptr = value.X;
            ptr[1] = value.Y;

            GC.KeepAlive(valueBuffer);
        }

        public unsafe void SetValue(Vector2[] value)
        {
            if (valueBuffer != null) ValidateValueBytes(VectorArrayBytes(value.Length, 8));
            float* ptr = (float*)(void*)values;
            int num = 0;
            while (num < value.Length)
            {
                *ptr = value[num].X;
                ptr[1] = value[num].Y;
                num++;
                ptr += 4;
            }

            GC.KeepAlive(valueBuffer);
        }

        public unsafe void SetValue(Vector3 value)
        {
            if (valueBuffer != null) ValidateValueBytes(12);
            float* ptr = (float*)(void*)values;
            *ptr = value.X;
            ptr[1] = value.Y;
            ptr[2] = value.Z;

            GC.KeepAlive(valueBuffer);
        }

        public unsafe void SetValue(Vector3[] value)
        {
            if (valueBuffer != null) ValidateValueBytes(VectorArrayBytes(value.Length, 12));
            float* ptr = (float*)(void*)values;
            int num = 0;
            while (num < value.Length)
            {
                *ptr = value[num].X;
                ptr[1] = value[num].Y;
                ptr[2] = value[num].Z;
                num++;
                ptr += 4;
            }

            GC.KeepAlive(valueBuffer);
        }

        public unsafe void SetValue(Vector4 value)
        {
            if (valueBuffer != null) ValidateValueBytes(16);
            float* ptr = (float*)(void*)values;
            *ptr = value.X;
            ptr[1] = value.Y;
            ptr[2] = value.Z;
            ptr[3] = value.W;

            GC.KeepAlive(valueBuffer);
        }

        public unsafe void SetValue(Vector4[] value)
        {
            if (valueBuffer != null) ValidateValueBytes(VectorArrayBytes(value.Length, 16));
            float* ptr = (float*)(void*)values;
            int num = 0;
            while (num < value.Length)
            {
                *ptr = value[num].X;
                ptr[1] = value[num].Y;
                ptr[2] = value[num].Z;
                ptr[3] = value[num].W;
                num++;
                ptr += 4;
            }

            GC.KeepAlive(valueBuffer);
        }
    }
}
