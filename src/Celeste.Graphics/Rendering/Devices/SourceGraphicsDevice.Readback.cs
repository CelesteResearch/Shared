using Celeste.Core.Display;
using System;
using System.Runtime.InteropServices;
using Celeste.Core.Geometry;
using Celeste.Core.Interop;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Rendering.Devices
{
    public partial class SourceGraphicsDevice
    {
        public PackedColor BlendFactor
        {
            get
            {
                deviceIO.GetBlendFactor(out var blendFactor);
                return blendFactor;
            }
            set { deviceIO.SetBlendFactor(ref value); }
        }

        public int MultiSampleMask
        {
            get { return deviceIO.GetMultiSampleMask(); }
            set { deviceIO.SetMultiSampleMask(value); }
        }

        public int ReferenceStencil
        {
            get { return deviceIO.GetReferenceStencil(); }
            set { deviceIO.SetReferenceStencil(value); }
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
                deviceIO.GetBackbufferSize(out w, out h);
            }
            else
            {
                x = rect.Value.X;
                y = rect.Value.Y;
                w = rect.Value.Width;
                h = rect.Value.Height;
            }

            int num = SourceMarshalHelper.SizeOf<T>();
            SourceTextureResource.ValidateGetDataFormat(deviceIO.GetBackbufferSurfaceFormat(), num);
            GCHandle gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            deviceIO.ReadBackbuffer(x, y, w, h, gCHandle.AddrOfPinnedObject() + startIndex * num, data.Length * num);
            gCHandle.Free();
        }
    }
}
