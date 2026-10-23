using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;

namespace Celeste.Simulation.Gameplay.Enemies.Seeker
{
    public class SeekerRecoverBlastState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private Sprite sprite;

        public SeekerRecoverBlastState(ISourceEngineContext engine)
            : base(((Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            Depth = -199;
            if (sprite == null)
            {
                OwnedComponents.Add(sprite =
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("seekerShockWave"));
                sprite.OnLastFrame = delegate { RemoveSelf(); };
            }

            sprite.Play("shockwave", restart: true);
        }

        public static void Spawn(ISourceEngineContext engine, Vector2 position)
        {
            var recoverBlast = engine.EntityPools.Create<SeekerRecoverBlastState>();
            recoverBlast.Position = position;
            ((ISourceScene)engine.Frame.Scenes.CurrentScene).SourceScene.QueueSourceEntity(recoverBlast);
        }
    }
}
