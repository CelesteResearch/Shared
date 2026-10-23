using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Player.Collision.Components;

namespace Celeste.Simulation.Gameplay.Hazards.Lightning
{
    public abstract class LightningHazardState : SceneEntityState
    {
        public float ToggleOffset;
        public int VisualWidth, VisualHeight;
        public readonly PlayerColliderComponentState PlayerColliderComponent;

        protected LightningHazardState(Vector2 position, int width, int height, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            VisualWidth = width;
            VisualHeight = height;
            Collider = new HitboxColliderGeometry(width - 2, height - 2, 1f, 1f);
            PlayerColliderComponent = new(OnPlayer);
            OwnedComponents.Add(PlayerColliderComponent);
        }

        protected abstract void OnPlayer(RoomPlayerSession player);

        public override void Update()
        {
            if (Collidable && OnInterval(.25f, ToggleOffset)) ToggleCheck();
            if (!Collidable && OnInterval(.05f, ToggleOffset)) ToggleCheck();
            base.Update();
        }

        private bool OnInterval(float interval, float offset)
        {
            var sourceScene = ((ISourceScene)Scene).SourceScene;
            return sourceScene.Clock.OnInterval(interval, offset, ((ISourceEngineContextScene)Scene).EngineContext);
        }

        public void ToggleCheck()
        {
            Collidable = Visible = InView();
        }

        public bool InView()
        {
            var camera = ((ISourceCameraScene)Scene).Camera;
            if (X + Width > camera.Position.X - 16f && Y + Height > camera.Position.Y - 16f
                                                    && X < camera.Position.X + 320f + 16f)
                return Y < camera.Position.Y + 180f + 16f;
            return false;
        }
    }
}
