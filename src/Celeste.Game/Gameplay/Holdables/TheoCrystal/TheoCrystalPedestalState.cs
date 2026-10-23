using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Controls.Source;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Player.Collision.Surfaces;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;

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
                new SpriteImage(
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas[
                        "characters/theoCrystal/pedestal"]));
            EnableAssistModeChecks = false;
            sprite.JustifyOrigin(.5f, 1f);
            Depth = 8998;
            Collider.Position = new Vector2(-16f, -64f);
            Collidable = false;
            OnDashCollide = delegate
            {
                TheoCrystalState entity =
                    ((ISourceScene)Scene).SourceScene.Entities
                    .GetTrackedEntity<TheoCrystalState>("Celeste.TheoCrystal");
                entity.OnPedestal = false;
                entity.Speed = new Vector2(0f, -300f);
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

            TheoCrystalState theo = ((ISourceScene)Scene).SourceScene.Entities.FindFirst<TheoCrystalState>();
            if (theo != null)
                theo.Depth = Depth + 1;
        }

        public override void Update()
        {
            TheoCrystalState entity =
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
