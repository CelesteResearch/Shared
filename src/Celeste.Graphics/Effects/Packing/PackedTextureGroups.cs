using System;
using System.Collections.Generic;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering.Batches;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Graphics.Effects.Packing
{
    public static class PackedTextureGroups
    {
        public static List<List<AtlasEntry>> CreateGroups(VirtualContent content, SourceGraphicsDevice device,
            SourceSpriteBatch batch, List<List<AtlasEntry>> groups, string name, out PackedTextureResource resource)
        {
            var input = new List<AtlasEntry>();
            foreach (var group in groups) input.AddRange(group);
            var packed = Create(content, device, batch, input, name, out resource);
            var output = new List<List<AtlasEntry>>(groups.Count);
            var index = 0;
            foreach (var group in groups)
            {
                output.Add(packed.GetRange(index, group.Count));
                index += group.Count;
            }

            return output;
        }

        public static List<AtlasEntry> Create(VirtualContent content, SourceGraphicsDevice device,
            SourceSpriteBatch batch, List<AtlasEntry> input, string name, out PackedTextureResource resource)
        {
            resource = null;
            if (input.Count == 0 || input.Count == 1) return input;
            int width = 0, height = 0;
            foreach (var entry in input)
            {
                width += entry.FrameWidth + (int)Math.Abs(entry.DrawOffset.X);
                height = Math.Max(height, entry.FrameHeight);
            }

            if (width > 4096 || height > 4096) return input;
            resource = new(content, device, batch, input, name, width, height);
            return resource.Entries;
        }
    }
}
