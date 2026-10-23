using Celeste.Scene.Entities;
using Celeste.Scene.Geometry;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Simulation.Gameplay.Player.Runtime;
using Celeste.Simulation.Gameplay.Triggers.Respawn;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public object Level { get; private set; }
        private bool startHairCalled;

        public override void Added(object actualScene)
        {
            ((ISourcePlayerRuntimeEnvironment)EngineContext)
                .PlayerRuntimePolicy.Added(this, actualScene);
        }

        public override void SceneBegin(object actualScene)
        {
            base.SceneBegin(actualScene);
            ((ISourcePlayerRuntimeEnvironment)EngineContext)
                .PlayerRuntimePolicy.SceneBegin(this, actualScene);
        }

        public void AddedSourceBody(object actualScene)
        {
            base.Added(actualScene);
            Level = Scene;
            Appearance.LastDashes = Data.Dashes = Motor.BeforeState.MaxDashes;
            var spawnFacing = SourceTrackedEntityCollision
                .First<ISourceSpawnFacingEntity>(
                    ((ISourceScene)Scene).SourceScene.Entities, "Celeste.SpawnFacingTrigger", this);
            if (spawnFacing != null)
            {
                Data.Facing = spawnFacing.Facing;
            }
            else
            {
                var bounds = ((ISourceSceneBounds)Level).Bounds;
                var centerX = unchecked(bounds.X + bounds.Width / 2);
                if (Position.X > centerX && IntroType != PlayerIntroType.None) Data.Facing = -1;
            }

            LastIntroType = IntroType;
            switch (IntroType)
            {
                case PlayerIntroType.Respawn:
                    Machine.State = 14;
                    JustRespawned = true;
                    break;
                case PlayerIntroType.WalkInRight:
                    Intro.WalkDirection = 1;
                    Machine.State = 12;
                    break;
                case PlayerIntroType.WalkInLeft:
                    Intro.WalkDirection = -1;
                    Machine.State = 12;
                    break;
                case PlayerIntroType.Jump: Machine.State = 13; break;
                case PlayerIntroType.WakeUp:
                    Sprite.Play("asleep");
                    Data.Facing = 1;
                    Machine.State = 15;
                    break;
                case PlayerIntroType.None: Machine.State = 0; break;
                case PlayerIntroType.Fall: Machine.State = 18; break;
                case PlayerIntroType.TempleMirrorVoid: Dummy.StartTempleMirrorVoidSleep(); break;
                case PlayerIntroType.ThinkForABit: Machine.State = 25; break;
            }

            IntroType = PlayerIntroType.Transition;
            StartHair();
            Data.PreviousPosition = Position;
        }

        private void StartHair()
        {
            if (!startHairCalled)
            {
                startHairCalled = true;
                Hair.Facing = Data.Facing;
                Hair.Start();
                UpdateHair(true);
            }
        }

        public override void Removed(object actualScene)
        {
            base.Removed(actualScene);
            Level = null;
            StopConveyorAudio();
            PlayerTriggers.PlayerRemoved(this);
        }

        public override void SceneEnd(object actualScene)
        {
            base.SceneEnd(actualScene);
            StopConveyorAudio();
        }
    }
}
