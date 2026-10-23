using System.Runtime.InteropServices;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Interop;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Rendering.Devices
{
    public partial class SourceGraphicsDevice
    {
        public PackedColor BlendFactor
        {
            get
            {
                PhysicalIO.GetBlendFactor(out var blendFactor);
                return blendFactor;
            }
            set => PhysicalIO.SetBlendFactor(ref value);
        }

        public int MultiSampleMask
        {
            get => PhysicalIO.GetMultiSampleMask();
            set => PhysicalIO.SetMultiSampleMask(value);
        }

        public int ReferenceStencil
        {
            get => PhysicalIO.GetReferenceStencil();
            set => PhysicalIO.SetReferenceStencil(value);
        }

        public void GetBackBufferData<T>(T[] data) where T : struct
        {
            GetBackBufferData(null, data, 0, data.Length);
        }

        public void GetBackBufferData<T>(T[] data, int startIndex, int elementCount) where T : struct
        {
            GetBackBufferData(null, data, startIndex, elementCount);
        }

        public void GetBackBufferData<T>(IntRect? rect, T[] data, int startIndex, int elementCount) where T : struct
        {
            int x;
            int y;
            int w;
            int h;
            if (!rect.HasValue)
            {
                x = 0;
                y = 0;
                PhysicalIO.GetBackbufferSize(out w, out h);
            }
            else
            {
                x = rect.Value.X;
                y = rect.Value.Y;
                w = rect.Value.Width;
                h = rect.Value.Height;
            }

            var num = SourceMarshalHelper.SizeOf<T>();
            SourceTextureResource.ValidateGetDataFormat(PhysicalIO.GetBackbufferSurfaceFormat(), num);
            var gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            PhysicalIO.ReadBackbuffer(x, y, w, h, gCHandle.AddrOfPinnedObject() + startIndex * num, data.Length * num);
            gCHandle.Free();
        }
    }
}
