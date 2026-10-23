using System;
using System.Numerics;
using Celeste.Core.Components.Animation;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Presentation.Platforms.Wood;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Platforms.StaticMovers;
using Celeste.Simulation.Presentation.Lighting;

namespace Celeste.Game.Entities.Platforms.Wood
{
    public class OriginalMovingPlatformState : SourceJumpThruEntityState
    {
        public const string SfxLeft = "event:/game/03_resort/platform_horiz_left";
        public const string SfxRight = "event:/game/03_resort/platform_horiz_right";
        private readonly Vector2 start;
        private readonly Vector2 end;
        protected SoundSourceComponentState SourceMovementSound { get; }

        private AtlasEntry[] textures;
        public string OverrideTexture;
        private float addY;
        private float sinkTimer;
        private string lastSfx;

        public OriginalMovingPlatformState(Vector2 position, int width, Vector2 node,
            ISourceSolidWorldFactory worlds) : this(position, width, node, worlds.CreateJumpThru(position, false))
        {
        }

        private OriginalMovingPlatformState(Vector2 position, int width, Vector2 node, ISourceSolidWorld world)
            : base(position, width, false, world)
        {
            start = Position;
            end = node;
            SourceMovementSound = ((ISourceSoundSourceEnvironment)world.EngineContext).SoundSources.Create();
            OwnedComponents.Add(SourceMovementSound);
            SurfaceSoundIndex = 5;
            lastSfx = Math.Sign(start.X - end.X) > 0 || Math.Sign(start.Y - end.Y) > 0 ? SfxLeft : SfxRight;
            var tween = SourceTweenState.Create(world.EngineContext.TweenPool,
                SourceTweenState.TweenMode.YoyoLooping,
                ((ISourceEasingEnvironment)world.EngineContext).EasingArithmetic.SineInOut, 2f);
            tween.OnUpdate = t =>
                MoveTo(Vector2Interpolation.Lerp(start, end, t.Eased,
                    ((ISourceScalarEnvironment)SourceWorld.EngineContext).ScalarArithmetic) + Vector2.UnitY * addY);
            tween.OnStart = _ =>
            {
                if (lastSfx == SfxLeft) SourceMovementSound.Play(lastSfx = SfxRight);
                else SourceMovementSound.Play(lastSfx = SfxLeft);
            };
            OwnedComponents.Add(tween);
            tween.Start(false);
            OwnedComponents.Add(new LightOccludeState(.2f));
        }

        public OriginalMovingPlatformState(EntityData data, Vector2 offset, ISourceSolidWorldFactory worlds)
            : this(data.Position + offset, data.Width, data.Nodes[0] + offset, worlds)
        {
        }

        public override void Added(object actualScene)
        {
            var policy = ((IWoodPlatformScene)actualScene).WoodPlatformAddedPolicy;
            var scope = policy.Begin(actualScene, OverrideTexture);
            base.Added(actualScene);
            var currentLevel = Scene as OriginalLevelSceneRoot;
            var session = currentLevel.Session;
            var texture = session.AreaID != 7 || !session.Level.StartsWith("e-")
                ? ((ISourceGameGraphicsEnvironment)SourceWorld.EngineContext).GameGraphics.GameAtlas.Entries[
                    "objects/woodPlatform/" + (actualScene as OriginalLevelSceneRoot).AreaData.WoodPlatform]
                : ((ISourceGameGraphicsEnvironment)SourceWorld.EngineContext).GameGraphics.GameAtlas.Entries[
                    "objects/woodPlatform/" + ((IOriginalAreaKeyEnvironment)SourceWorld.EngineContext).AreaKeys
                    .GetAreaById(4).WoodPlatform];
            textures = new AtlasEntry[texture.FrameWidth / 8];
            for (var i = 0; i < textures.Length; i++) textures[i] = texture.GetSubtexture(i * 8, 0, 8, 8);
            var offset =
                ((ISourceVectorEnvironment)SourceWorld.EngineContext).VectorArithmetic.Divide(
                    new Vector2(Width, Height + 4f), 2f);
            ((ISourceScene)actualScene).SourceScene.QueueSourceEntity(
                new OriginalMovingPlatformLineState(SourceWorld.EngineContext, start + offset, end + offset));
            policy.End(scope);
        }

        public override void OnStaticMoverTrigger(SourceStaticMoverState mover)
        {
            sinkTimer = .4f;
        }

        public override void Update()
        {
            base.Update();
            if (HasPlayerRider())
            {
                sinkTimer = .2f;
                addY = ScalarMath.Approach(addY, 3f, 50f * SourceWorld.EngineContext.DeltaTime,
                    ((ISourceExtremaEnvironment)SourceWorld.EngineContext).ExtremaArithmetic);
            }
            else if (sinkTimer > 0f)
            {
                sinkTimer -= SourceWorld.EngineContext.DeltaTime;
                addY = ScalarMath.Approach(addY, 3f, 50f * SourceWorld.EngineContext.DeltaTime,
                    ((ISourceExtremaEnvironment)SourceWorld.EngineContext).ExtremaArithmetic);
            }
            else
            {
                addY = ScalarMath.Approach(addY, 0f, 20f * SourceWorld.EngineContext.DeltaTime,
                    ((ISourceExtremaEnvironment)SourceWorld.EngineContext).ExtremaArithmetic);
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            WoodPlatformDrawing.Render(context, this, textures);
        }
    }
}
