using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Graphics;
using Celeste.Graphics.Content;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.Effects.Mirrors;

namespace Celeste.Game.Entities.Npcs.Theo
{
    public class OriginalTempleMirrorTheoState : OriginalNpcState
    {
        private readonly ISourceEngineContext engine;
        private bool started;

        public OriginalTempleMirrorTheoState(ISourceEngineContext engine, Vector2 position)
            : base(engine, position)
        {
            this.engine = engine;
            OwnedComponents.Add(Sprite =
                ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics).SpriteBank
                .Create("theo"));
            IdleAnim = "idle";
            MoveAnim = "walk";
            Visible = false;
            OwnedComponents.Add(new MirrorReflectionState
            {
                IgnoreEntityVisible = true,
            });
            Sprite.Scale.X = 1f;
            Maxspeed = 48f;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if (Session.GetFlag("theoInMirror")) RemoveSelf();
        }

        public override void Update()
        {
            base.Update();
            var entity =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);
            if (!(!started && entity != null && entity.X > X - 64f))
                return;
            started = true;
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(new CS05TheoMirrorState(engine, this, entity));
        }
    }
}
