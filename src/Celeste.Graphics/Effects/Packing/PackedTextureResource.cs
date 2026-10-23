using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Batches;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Effects.Packing
{
    public sealed class PackedTextureResource : IDisposable
    {
        private readonly VirtualContent content;
        private readonly SourceGraphicsDevice device;
        private readonly SourceSpriteBatch batch;
        private readonly List<AtlasEntry> input;
        private readonly PackingDrawScope drawScope;
        private readonly VirtualRenderTarget target;
        private readonly PackedVirtualTexture texture;
        public List<AtlasEntry> Entries { get; }

        internal PackedTextureResource(VirtualContent content, SourceGraphicsDevice device, SourceSpriteBatch batch,
            List<AtlasEntry> input, string name, int width, int height)
        {
            this.content = content;
            this.device = device;
            this.batch = batch;
            this.input = input;
            drawScope = new PackingDrawScope(batch);
            target = content.CreateRenderTarget(name, width, height, false, true);
            texture = new PackedVirtualTexture(content, this, name, width, height);
            // The target is registered first. On device/content reload it is recreated before this redraw.
            content.Assets.Add(texture);
            Entries = new List<AtlasEntry>(input.Count);
            Bake();
        }

        private void Bake()
        {
            texture.Texture = target.Target;
            device.SetRenderTarget(target.Target);
            device.Clear(PackedColor.Transparent);
            batch.Begin();
            int x = 0;
            var full = new AtlasEntry(texture);
            bool createEntries = Entries.Count == 0;
            foreach (var entry in input)
            {
                SourceAtlasDrawing.Draw(drawScope, entry, new Vector2(x, 0), Vector2.Zero, PackedColor.White);
                if (createEntries) Entries.Add(new AtlasEntry(full, x, 0, entry.FrameWidth, entry.FrameHeight));
                x += entry.FrameWidth + (int)Math.Abs(entry.DrawOffset.X);
            }

            batch.End();
            device.SetRenderTarget(null);
        }

        public void Dispose()
        {
            content.Assets.Remove(texture);
            texture.Texture = null;
            target.Dispose();
        }

        private sealed class PackingDrawScope : ISourceDrawScope
        {
            public SourceDrawState Draw { get; }
            public PackingDrawScope(SourceSpriteBatch batch) => Draw = new SourceDrawState { SpriteBatch = batch };
        }

        private sealed class PackedVirtualTexture : VirtualTexture
        {
            private readonly PackedTextureResource owner;

            public PackedVirtualTexture(VirtualContent content, PackedTextureResource owner, string name,
                int width, int height) : base(content)
            {
                this.owner = owner;
                Name = Path = name;
                Width = width;
                Height = height;
            }

            public override void Unload() => Texture = null;
            public override void Reload() => owner.Bake();
            public override void Dispose() => owner.Dispose();
        }
    }
}
