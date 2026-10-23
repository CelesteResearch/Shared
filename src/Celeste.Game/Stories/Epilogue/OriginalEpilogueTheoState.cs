using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.Npcs;
using Celeste.Graphics.Content;

namespace Celeste.Game.Stories.Epilogue
{
    public class OriginalEpilogueTheoState : OriginalNpcState
    {
        public OriginalEpilogueTheoState(ISourceEngineContext engine,
            EntityData data, Vector2 position)
            : base(engine, data.Position + position)
        {
            OwnedComponents.Add(Sprite = ((ISourceGameGraphicsEnvironment)engine)
                .GameGraphics.SpriteFactory.Create("theo"));
            Sprite.Scale.X = -1f;
            Sprite.Play("idle");
            IdleAnim = "idle";
            MoveAnim = "walk";
            Maxspeed = 30f;
        }
    }
}
