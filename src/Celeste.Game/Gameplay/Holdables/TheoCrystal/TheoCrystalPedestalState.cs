using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Player.Collision.Surfaces;

namespace Celeste.Game.Gameplay.Holdables.TheoCrystal
{
    public class TheoCrystalPedestalState : SourceSolidEntityState
    {
        public SpriteImage sprite;
        public bool DroppedTheo;

        public TheoCrystalPedestalState(EntityData data, Vector2 offset,
            ISourceEngineContext engine, ISourceSolidWorldFactory worlds)
            : this(data.Position + offset, engine, worlds)
        {
        }

        private TheoCrystalPedestalState(Vector2 position, ISourceEngineContext engine,
            ISourceSolidWorldFactory worlds)
            : base(position, 32f, 32f, false, worlds.Create(position, false))
        {
            Add(sprite =
                new(
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas[
                        "characters/theoCrystal/pedestal"]));
            EnableAssistModeChecks = false;
            sprite.JustifyOrigin(.5f, 1f);
            Depth = 8998;
            Collider.Position = new(-16f, -64f);
            Collidable = false;
            OnDashCollide = delegate
            {
                var entity =
                    ((ISourceScene)Scene).SourceScene.Entities
                    .GetTrackedEntity<TheoCrystalState>("Celeste.TheoCrystal");
                entity.OnPedestal = false;
                entity.Speed = new(0f, -300f);
                DroppedTheo = true;
                Collidable = false;
                (Scene as OriginalLevelSceneRoot).Flash(PackedColor.White);
                ((ISourceFreezeEnvironment)engine).Freeze(.1f);
                ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Medium,
                    RumbleLength.Short);
                ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                    "event:/game/05_mirror_temple/crystaltheo_break_free", entity.Position);
                return DashCollisionResult.Rebound;
            };
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate.Value;
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            if ((scene as OriginalLevelSceneRoot).Session.GetFlag("foundTheoInCrystal"))
            {
                DroppedTheo = true;
                return;
            }

            var theo = ((ISourceScene)Scene).SourceScene.Entities.FindFirst<TheoCrystalState>();
            if (theo != null)
                theo.Depth = Depth + 1;
        }

        public override void Update()
        {
            var entity =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<TheoCrystalState>("Celeste.TheoCrystal");
            if (entity != null && !DroppedTheo)
            {
                entity.Position = Position + new Vector2(0f, -32f);
                entity.OnPedestal = true;
            }

            base.Update();
        }
    }
}
