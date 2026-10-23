using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Graphics;
using Celeste.Graphics.Content;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities.Npcs.Theo
{
    public class OriginalTempleEntranceTheoState : OriginalNpcState
    {
        private readonly ISourceEngineContext engine;

        public OriginalTempleEntranceTheoState(ISourceEngineContext engine, Vector2 position)
            : base(engine, position)
        {
            this.engine = engine;
            OwnedComponents.Add(Sprite =
                ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics).SpriteBank
                .Create("theo"));
            IdleAnim = "idle";
            MoveAnim = "walk";
            Maxspeed = 48f;
            OwnedComponents.Add(Light =
                new(engine, -Vector2.UnitY * 12f, PackedColor.White, 1f, 32, 64));
            SetupTheoSpriteSounds();
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if (Session.GetFlag("entrance"))
                RemoveSelf();
            else
                ((ISourceScene)scene).SourceScene.QueueSourceEntity(new CS05TheoEntranceState(engine, this));
        }
    }
}
