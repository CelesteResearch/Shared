using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Entities;

namespace Celeste.Game.Gameplay.Platforms.MoveBlocks
{
    public class MovingBlockBorderState : SceneEntityState
    {
        public MovingBlockState Parent;

        public MovingBlockBorderState(MovingBlockState parent,
            ISourceEntitySourceDataRegistration sourceData) : base(sourceData)
        {
            Parent = parent;
            Depth = 1;
        }

        public override void Update()
        {
            if (Parent.Scene != Scene) RemoveSelf();
            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            SourcePrimitiveDrawing.Rect(context, this,
                Parent.X + Parent.Shake.X - 1f, Parent.Y + Parent.Shake.Y - 1f,
                Parent.Width + 2f, Parent.Height + 2f, PackedColor.Black);
        }
    }
}
