using System;
using System.Runtime.InteropServices;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Rendering.Buffers;

namespace Celeste.Graphics.Rendering.Devices
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SourceSpriteTextureGroup
    {
        public IntPtr Texture;
        public int FirstSprite;
        public int SpriteCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SourceSpriteGroupProgress
    {
        public int AttemptedGroup;
        public int SamplerConsumed;
        public int WriteScopeCount;
    }

    // Optional closed-backend path. Other physical IO implementations retain every original call.
    public unsafe interface ISourceSpriteGroupIO
    {
        IntPtr TryGetSpriteGroupPacket();

        void RecordSpriteGroups(IntPtr packet, SourceSpriteTextureGroup* groups, int count, int baseSprite,
            IntPtr indices, SourceIndexElementSize indexSize, ref SourceNativeRasterizerState rasterizer,
            ref SourceNativeSamplerState sampler, ref SourceSpriteGroupProgress progress);
    }
}
