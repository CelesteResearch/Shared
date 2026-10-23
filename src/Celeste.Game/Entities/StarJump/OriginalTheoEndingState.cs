using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.Npcs;
using Celeste.Graphics.Content;

namespace Celeste.Game.Entities.StarJump
{
    public class OriginalTheoEndingState : OriginalNpcState
    {
        private float speedY;

        public OriginalTheoEndingState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(engine, data.Position + offset)
        {
            OwnedComponents.Add(Sprite =
                ((ISourceGameGraphicsEnvironment)Engine).GameGraphics.SpriteFactory.Create("theo"));
            IdleAnim = "idle";
            MoveAnim = "run";
            Maxspeed = 72f;
            MoveY = false;
            Visible = false;
            OwnedComponents.Add(Light =
                new(Engine, new(0f, -8f), PackedColor.White, 1f, 16, 32));
            SetupTheoSpriteSounds();
        }

        public override void Update()
        {
            base.Update();
            if (!CollideSolidAt(Position + new Vector2(0f, 1f)))
            {
                speedY += 400f * Engine.DeltaTime;
                Y += speedY * Engine.DeltaTime;
            }
            else
            {
                speedY = 0f;
            }
        }
    }
}
