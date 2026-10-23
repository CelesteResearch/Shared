using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Graphics.Rendering;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;

namespace Celeste.Game.Gameplay.Enemies.Badeline.Chasers
{
    public class ChaserBarrierState : SceneEntityState
    {
        public ChaserBarrierState(ISourceEngineContext engine, Vector2 position, int width, int height)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            Collider = new HitboxColliderGeometry(width, height);
        }

        public ChaserBarrierState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : this(engine, data.Position + offset, data.Width, data.Height)
        {
        }

        public override void Render(ISourceRenderContext context)
        {
            base.Render(context);
            SourcePrimitiveDrawing.Rect(context, this, Collider.AbsoluteLeft, Collider.AbsoluteTop,
                Collider.Width, Collider.Height, PackedColor.Red * .3f);
        }
    }
}
