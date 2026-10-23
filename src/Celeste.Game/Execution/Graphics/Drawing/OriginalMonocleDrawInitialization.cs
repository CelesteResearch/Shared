using System;
using Celeste.Core.Display;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering.Drawing;

namespace Celeste.Game.Execution.Graphics.Drawing
{
    public sealed class OriginalMonocleDrawInitialization
    {
        private readonly SourceDrawState draw;
        private readonly VirtualContent virtualContent;
        private readonly IOriginalDrawInitializationResources resources;

        public OriginalMonocleDrawInitialization(SourceDrawState actualDraw,
            VirtualContent actualVirtualContent,
            IOriginalDrawInitializationResources actualResources)
        {
            draw = actualDraw ?? throw new ArgumentNullException(nameof(actualDraw));
            virtualContent = actualVirtualContent ?? throw new ArgumentNullException(nameof(actualVirtualContent));
            resources = actualResources ?? throw new ArgumentNullException(nameof(actualResources));
        }

        public void Initialize()
        {
            draw.SpriteBatch =
                new(resources.GraphicsDevice,
                    resources.SpriteBatchProcess);
            draw.DefaultFont = resources.LoadDefaultSpriteFont("Monocle\\MonocleDefault");
            UseDebugPixelTexture();
        }

        public void UseDebugPixelTexture()
        {
            var parent = new AtlasEntry(virtualContent.CreateTexture("debug-pixel", 3, 3, PackedColor.White));
            draw.Pixel = parent.GetSubtexture(1, 1, 1, 1);
            draw.Particle = parent.GetSubtexture(1, 1, 1, 1);
        }
    }
}
