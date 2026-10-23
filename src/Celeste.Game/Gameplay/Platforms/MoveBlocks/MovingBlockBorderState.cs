using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Graphics.Rendering;
using System.Numerics;
using Celeste.Graphics.Display;

namespace Celeste.Game.Gameplay.Platforms.MoveBlocks
{
    public class MovingBlockBorderState : SceneEntityState
    {
        public MovingBlockState Parent;

        public MovingBlockBorderState(MovingBlockState parent,
            global::Celeste.Core.Components.ISourceEntitySourceDataRegistration sourceData) : base(sourceData)
        {
            Parent = parent;
            Depth = 1;
        }

        public override void Update()
        {
            if (Parent.Scene != Scene) RemoveSelf();
            base.Update();
        }

        public override void Render(ISourceRenderContext context) => SourcePrimitiveDrawing.Rect(context, this,
            Parent.X + Parent.Shake.X - 1f, Parent.Y + Parent.Shake.Y - 1f,
            Parent.Width + 2f, Parent.Height + 2f, PackedColor.Black);
    }
}
