using System;
using Celeste.Core.Framework.Timing;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Rendering.Devices
{
    public partial class SourceGraphicsDevice
    {
        internal unsafe bool TryDrawSpriteGroups(SourceTexture2DResource[] textures, int start, int count,
            int baseSprite)
        {
            if (GetType() != typeof(SourceGraphicsDevice) || PhysicalIO is not ISourceSpriteGroupIO bulk ||
                textures == null || start < 0 || count < 2 || count > 2048 || start > textures.Length - count)
                return false;

            var groupCount = 1;
            for (var i = 1; i < count; i++)
                if (!ReferenceEquals(textures[start + i - 1], textures[start + i]))
                    groupCount++;
            if (groupCount < 2) return false;

            var packet = bulk.TryGetSpriteGroupPacket();
            if (packet == IntPtr.Zero) return false;
            Span<SourceSpriteTextureGroup> groups = stackalloc SourceSpriteTextureGroup[groupCount];
            int first = 0, destination = 0;
            for (var i = 1; i <= count; i++)
            {
                if (i != count && ReferenceEquals(textures[start + first], textures[start + i])) continue;
                var texture = textures[start + first];
                groups[destination++] = new()
                {
                    Texture = texture == null ? IntPtr.Zero : texture.texture,
                    FirstSprite = first,
                    SpriteCount = i - first,
                };
                first = i;
            }

            SourceFrameDiagnostics.Current?.RecordSpriteBatchGroup(groups[0].SpriteCount);
            Textures[0] = textures[start];
            ApplyState();
            PrepareVertexBindingArray(unchecked(baseSprite * 4));
            var progress = new SourceSpriteGroupProgress { AttemptedGroup = 0, SamplerConsumed = 1 };
            try
            {
                fixed (SourceSpriteTextureGroup* pointer = groups)
                {
                    bulk.RecordSpriteGroups(packet, pointer, groupCount, baseSprite, Indices.buffer,
                        Indices.IndexElementSize, ref RasterizerState.NativeState, ref SamplerStates[0].NativeState,
                        ref progress);
                }
            }
            finally
            {
                // The native call reports the attempted prefix even when a later group fails.
                // Never replay that prefix through the fallback path.
                if (progress.AttemptedGroup > 0)
                {
                    Textures[0] = textures[start + groups[progress.AttemptedGroup].FirstSprite];
                    modifiedSamplers[0] = progress.SamplerConsumed == 0;
                    for (var i = 1; i <= progress.AttemptedGroup; i++)
                        SourceFrameDiagnostics.Current?.RecordSpriteBatchGroup(groups[i].SpriteCount);
                }

                GC.KeepAlive(textures);
            }

            return true;
        }
    }
}
