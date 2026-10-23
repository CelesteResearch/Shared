using System;
using System.Runtime.InteropServices;
using Celeste.Core.Rendering.Resources;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Graphics.Rendering.Vertices
{
    public class SourceVertexDeclaration : SourceGraphicsResource
    {
        internal SourceVertexElement[] elements;

        internal IntPtr elementsPin;

        private GCHandle handle;

        public int VertexStride { get; private set; }

        protected override bool IsHarmlessToLeakInstance => true;

        public SourceVertexDeclaration(params SourceVertexElement[] elements)
            : this(GetVertexStride(elements), elements)
        {
        }

        public SourceVertexDeclaration(int vertexStride, params SourceVertexElement[] elements)
        {
            if (elements == null || elements.Length == 0)
                throw new ArgumentNullException("elements", "Elements cannot be empty");

            this.elements = (SourceVertexElement[])elements.Clone();
            handle = GCHandle.Alloc(this.elements, GCHandleType.Pinned);
            elementsPin = handle.AddrOfPinnedObject();
            VertexStride = vertexStride;
        }

        ~SourceVertexDeclaration()
        {
            handle.Free();
        }

        public SourceVertexElement[] GetVertexElements()
        {
            return (SourceVertexElement[])elements.Clone();
        }

        internal void AssignSourceGraphicsDevice(SourceGraphicsDevice device)
        {
            GraphicsDevice = device;
        }

        internal static SourceVertexDeclaration FromType(Type vertexType)
        {
            if (vertexType == null) throw new ArgumentNullException("vertexType", "Cannot be null");

            if (!vertexType.IsValueType) throw new ArgumentException("vertexType", "Must be value type");

            return (Activator.CreateInstance(vertexType) as ISourceVertexType ??
                    throw new ArgumentException("vertexData does not inherit IVertexType")).VertexDeclaration ??
                   throw new ArgumentException("vertexType's VertexDeclaration cannot be null");
        }

        private static int GetVertexStride(SourceVertexElement[] elements)
        {
            var num = 0;
            for (var i = 0; i < elements.Length; i++)
            {
                var num2 = elements[i].Offset + GetTypeSize(elements[i].VertexElementFormat);
                if (num < num2) num = num2;
            }

            return num;
        }

        private static int GetTypeSize(SourceVertexElementFormat elementFormat)
        {
            return elementFormat switch
            {
                SourceVertexElementFormat.Single => 4,
                SourceVertexElementFormat.Vector2 => 8,
                SourceVertexElementFormat.Vector3 => 12,
                SourceVertexElementFormat.Vector4 => 16,
                SourceVertexElementFormat.Color => 4,
                SourceVertexElementFormat.Byte4 => 4,
                SourceVertexElementFormat.Short2 => 4,
                SourceVertexElementFormat.Short4 => 8,
                SourceVertexElementFormat.NormalizedShort2 => 4,
                SourceVertexElementFormat.NormalizedShort4 => 8,
                SourceVertexElementFormat.HalfVector2 => 4,
                SourceVertexElementFormat.HalfVector4 => 8,
                _ => 0,
            };
        }
    }
}
