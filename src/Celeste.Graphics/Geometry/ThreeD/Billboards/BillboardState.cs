using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Graphics.Geometry.ThreeD.Billboards
{
    public class BillboardState : SourceComponentState
    {
        public AtlasEntry Texture;
        public Vector3 Position;
        public PackedColor Color = PackedColor.White;
        public Vector2 Size = Vector2.One;
        public Vector2 Scale = Vector2.One;
        public Action BeforeRender;

        public BillboardState(AtlasEntry texture, Vector3 position, Vector2? size = null,
            PackedColor? color = null, Vector2? scale = null) : base(true, true)
        {
            Texture = texture;
            Position = position;
            Size = size.HasValue ? size.Value : Vector2.One;
            Color = color.HasValue ? color.Value : PackedColor.White;
            Scale = scale.HasValue ? scale.Value : Vector2.One;
        }
    }
}
