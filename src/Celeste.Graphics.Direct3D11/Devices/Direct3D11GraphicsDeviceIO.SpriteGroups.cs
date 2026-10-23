using System;
using Celeste.Core.Framework.Timing;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Direct3D11.Interop;
using Celeste.Graphics.Rendering.Buffers;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Direct3D11.Devices
{
    public sealed unsafe partial class Direct3D11GraphicsDeviceIO : ISourceSpriteGroupIO
    {
        public IntPtr TryGetSpriteGroupPacket()
        {
            return Direct3D11GraphicsBindings.SourceGpuGetSpriteGroupPacket(device);
        }

        public void RecordSpriteGroups(IntPtr packet, SourceSpriteTextureGroup* groups, int count, int baseSprite,
            IntPtr indices, SourceIndexElementSize indexSize, ref SourceNativeRasterizerState rasterizer,
            ref SourceNativeSamplerState sampler, ref SourceSpriteGroupProgress progress)
        {
            var rasterizerDescription = D3D11Conversions.Rasterizer(ref rasterizer,
                (SourceDepthFormat)Direct3D11GraphicsBindings.SourceGpuGetCurrentDepthFormat(device));
            var samplerDescription = D3D11Conversions.Sampler(ref sampler);
            try
            {
                Direct3D11GraphicsBindings.RequireSuccess(
                    Direct3D11GraphicsBindings.SourceGpuRecordSpriteGroups(device, packet, groups, count, baseSprite,
                        indices, D3D11Conversions.IndexFormat((int)indexSize), ref rasterizerDescription,
                        ref samplerDescription, ref progress));
            }
            finally
            {
                for (var i = 0; i < progress.WriteScopeCount; i++)
                    SourceFrameDiagnostics.Current?.RecordLoadWrite(0);
            }
        }
    }
}
