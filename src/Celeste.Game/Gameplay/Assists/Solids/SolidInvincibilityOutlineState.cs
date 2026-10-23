using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Components;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Scene.Entities;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Display;
using Celeste.Core.Scheduling;

namespace Celeste.Game.Gameplay.Assists.Solids
{
    public sealed class SolidInvincibilityOutlineState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        public SolidOnInvinciblePlayerState Parent;

        public SolidInvincibilityOutlineState(SolidOnInvinciblePlayerState parent, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Parent = parent;
            Depth = -10;
        }

        public override void Render(ISourceRenderContext context)
        {
            if (Parent != null && Parent.Entity != null)
            {
                var entity = (SceneEntityState)Parent.Entity;
                int left = (int)entity.Left;
                int right = (int)entity.Right;
                int top = (int)entity.Top;
                int bottom = (int)entity.Bottom;
                SourcePrimitiveDrawing.Rect(context, this, left + 4, top + 4,
                    entity.Width - 8f, entity.Height - 8f, PackedColor.White * 0.25f);
                for (float x = left; x < right - 3; x += 3f)
                {
                    SourcePrimitiveDrawing.Line(context, this, new Vector2(x, top), new Vector2(x + 2f, top),
                        PackedColor.White, ((ISourceVectorEnvironment)engine).VectorArithmetic);
                    SourcePrimitiveDrawing.Line(context, this, new Vector2(x, bottom - 1),
                        new Vector2(x + 2f, bottom - 1),
                        PackedColor.White, ((ISourceVectorEnvironment)engine).VectorArithmetic);
                }

                for (float y = top; y < bottom - 3; y += 3f)
                {
                    SourcePrimitiveDrawing.Line(context, this, new Vector2(left + 1, y), new Vector2(left + 1, y + 2f),
                        PackedColor.White, ((ISourceVectorEnvironment)engine).VectorArithmetic);
                    SourcePrimitiveDrawing.Line(context, this, new Vector2(right, y), new Vector2(right, y + 2f),
                        PackedColor.White, ((ISourceVectorEnvironment)engine).VectorArithmetic);
                }

                SourcePrimitiveDrawing.Rect(context, this, left + 1, top, 1f, 2f, PackedColor.White);
                SourcePrimitiveDrawing.Rect(context, this, right - 2, top, 2f, 2f, PackedColor.White);
                SourcePrimitiveDrawing.Rect(context, this, left, bottom - 2, 2f, 2f, PackedColor.White);
                SourcePrimitiveDrawing.Rect(context, this, right - 2, bottom - 2, 2f, 2f, PackedColor.White);
            }
        }
    }
}
