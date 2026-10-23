using System.Collections;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Physics.Collision;
using Celeste.Scene.Components.Oscillation;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Clutter;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Player.Collision.Surfaces;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Gameplay.Clutter.Doors
{
    public class ClutterDoorState : SourceSolidEntityState
    {
        public ClutterColor Color;

        private readonly Sprite sprite;

        private readonly WigglerComponent wiggler;

        public ClutterDoorState(EntityData data, Vector2 offset, ChapterCompletionSession session,
            ISourceSolidWorld solidWorld)
            : base(data.Position + offset, data.Width, data.Height, false, solidWorld)
        {
            Color = EntityAttributeReader.Enum(data.Values, "type", ClutterColor.Green);
            SurfaceSoundIndex = 20;
            Tags =
                ((IOriginalGameTagsEnvironment)solidWorld.EngineContext).Tags
                .TransitionUpdate.Value;
            Add(sprite =
                ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)solidWorld.EngineContext).GameGraphics)
                .SpriteFactory.Create("ghost_door"));
            sprite.Position = new Vector2(Width, Height) / 2f;
            sprite.Play("idle");
            OnDashCollide = OnDashed;
            Add(wiggler = ((ISourceWigglerPoolScope)solidWorld.EngineContext).WigglerPool.Create(0.6f, 3f,
                delegate(float f) { sprite.Scale = Vector2.One * (1f - f * 0.2f); }));
            if (!IsLocked(session)) InstantUnlock();
        }

        public override void Update()
        {
            var level = Scene as OriginalLevelSceneRoot;
            if (level.Transitioning && CollidePlayer())
            {
                Visible = false;
                Collidable = false;
            }
            else if (!Collidable && IsLocked(level.Session) && !CollidePlayer())
            {
                Visible = true;
                Collidable = true;
                wiggler.Start();
                PlaySourceSound("event:/game/03_resort/forcefield_bump", Position);
            }

            base.Update();
        }

        public bool IsLocked(ChapterCompletionSession session)
        {
            return session.GetFlag("oshiro_clutter_door_open") ? IsComplete(session) : true;
        }

        public bool IsComplete(ChapterCompletionSession session)
        {
            return session.GetFlag("oshiro_clutter_cleared_" + (int)Color);
        }

        public IEnumerator UnlockRoutine()
        {
            var camera = ((OriginalLevelSceneRoot)Scene).Camera;
            var from = camera.Position;
            var to = CameraTarget();
            if (((ISourceVectorEnvironment)SourceWorld.EngineContext).VectorArithmetic.Length(from - to) > 8f)
                for (var p = 0f; p < 1f; p += SourceWorld.EngineContext.DeltaTime)
                {
                    camera.Position = from + (to - from) *
                        ((ISourceEasingEnvironment)SourceWorld.EngineContext).EasingArithmetic.CubeInOut(p);
                    yield return null;
                }
            else
                yield return 0.2f;

            ((ISourceRumbleEnvironment)SourceWorld.EngineContext).RumbleSession.Rumble(1, 1);
            PlaySourceSound("event:/game/03_resort/forcefield_vanish", Position);
            sprite.Play("open");
            Collidable = false;
            for (var p = 0f; p < 0.4f; p += SourceWorld.EngineContext.DeltaTime)
            {
                camera.Position = CameraTarget();
                yield return null;
            }
        }

        public void InstantUnlock()
        {
            Visible = Collidable = false;
        }

        private Vector2 CameraTarget()
        {
            var level = Scene as OriginalLevelSceneRoot;
            var result = Position - new Vector2(320f, 180f) / 2f;
            result.X = ScalarMath.Clamp(result.X, level.Bounds.Left, level.Bounds.Right - 320);
            result.Y = ScalarMath.Clamp(result.Y, level.Bounds.Top, level.Bounds.Bottom - 180);
            return result;
        }

        private DashCollisionResult OnDashed(RoomPlayerSession player, Vector2 direction)
        {
            wiggler.Start();
            PlaySourceSound("event:/game/03_resort/forcefield_bump", Position);
            return DashCollisionResult.Bounce;
        }

        private void PlaySourceSound(string name, Vector2 position)
        {
            var process = (IOriginalGameplayProcess)SourceWorld.EngineContext;
            process.AudioSession.Play(name, position, process.SaveContext);
        }

        private bool CollidePlayer()
        {
            var players =
                ((OriginalLevelSceneRoot)Scene).Scheduler.Entities.GetTrackedEntities(
                    typeof(RoomPlayerSession).FullName);

            foreach (var player in players)
                if (SourceEntityCollision.Check(this, (ISourceEntityCollider)player))
                    return true;
            return false;
        }
    }
}
