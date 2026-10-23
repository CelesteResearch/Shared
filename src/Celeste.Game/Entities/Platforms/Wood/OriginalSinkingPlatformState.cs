using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Scene.Components.Shaking;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Presentation.Lighting;

namespace Celeste.Game.Entities.Platforms.Wood
{
    public class OriginalSinkingPlatformState : SourceJumpThruEntityState
    {
        public const string StartSound = "event:/game/03_resort/platform_vert_start";
        public const string DownLoop = "event:/game/03_resort/platform_vert_down_loop";
        public const string UpLoop = "event:/game/03_resort/platform_vert_up_loop";
        public const string EndSound = "event:/game/03_resort/platform_vert_end";
        private readonly float startY;
        private readonly ShakerComponentState shaker;
        private readonly SoundSourceComponentState downSfx;
        private readonly SoundSourceComponentState upSfx;
        private AtlasEntry[] textures;
        public string OverrideTexture;
        private float speed;
        private float riseTimer;

        public OriginalSinkingPlatformState(Vector2 position, int width, ISourceSolidWorldFactory worlds) : this(
            position,
            width, worlds.CreateJumpThru(position, false))
        {
        }

        private OriginalSinkingPlatformState(Vector2 position, int width, ISourceSolidWorld world)
            : base(position, width, false, world)
        {
            startY = Y;
            Depth = 1;
            SurfaceSoundIndex = 15;
            shaker = new(world.EngineContext, false);
            OwnedComponents.Add(shaker);
            OwnedComponents.Add(new LightOccludeState(.2f));
            downSfx = ((ISourceSoundSourceEnvironment)world.EngineContext).SoundSources.Create();
            OwnedComponents.Add(downSfx);
            upSfx = ((ISourceSoundSourceEnvironment)world.EngineContext).SoundSources.Create();
            OwnedComponents.Add(upSfx);
        }

        public OriginalSinkingPlatformState(EntityData data, Vector2 offset, ISourceSolidWorldFactory worlds)
            : this(data.Position + offset, data.Width, worlds)
        {
        }

        public override void Added(object actualScene)
        {
            var policy = ((IWoodPlatformScene)actualScene).WoodPlatformAddedPolicy;
            var scope = policy.Begin(actualScene, OverrideTexture);
            base.Added(actualScene);
            var texture = ((ISourceGameGraphicsEnvironment)SourceWorld.EngineContext).GameGraphics.GameAtlas.Entries[
                "objects/woodPlatform/" + (actualScene as OriginalLevelSceneRoot).AreaData.WoodPlatform];
            textures = new AtlasEntry[texture.FrameWidth / 8];
            for (var i = 0; i < textures.Length; i++) textures[i] = texture.GetSubtexture(i * 8, 0, 8, 8);
            ((ISourceScene)actualScene).SourceScene.QueueSourceEntity(
                new OriginalSinkingPlatformLineState(SourceWorld.EngineContext,
                    Position + new Vector2(Width / 2f, Height / 2f)));
            policy.End(scope);
        }

        public override void Update()
        {
            base.Update();
            var rider = GetPlayerRider();
            if (rider != null)
            {
                if (riseTimer <= 0f)
                {
                    if (ExactPosition.Y <= startY)
                        ((ISourceSpatialAudioEnvironment)SourceWorld.EngineContext).SpatialAudio.Play(StartSound,
                            Position);
                    shaker.ShakeFor(.15f, false);
                }

                riseTimer = .1f;
                speed = ScalarMath.Approach(speed, rider.Data.Motion.Ducking ? 60f : 30f,
                    400f * SourceWorld.EngineContext.DeltaTime,
                    ((ISourceExtremaEnvironment)SourceWorld.EngineContext).ExtremaArithmetic);
            }
            else if (riseTimer > 0f)
            {
                riseTimer -= SourceWorld.EngineContext.DeltaTime;
                speed = ScalarMath.Approach(speed, 45f, 600f * SourceWorld.EngineContext.DeltaTime,
                    ((ISourceExtremaEnvironment)SourceWorld.EngineContext).ExtremaArithmetic);
            }
            else
            {
                speed = ScalarMath.Approach(speed, -50f, 400f * SourceWorld.EngineContext.DeltaTime,
                    ((ISourceExtremaEnvironment)SourceWorld.EngineContext).ExtremaArithmetic);
            }

            if (speed > 0f)
            {
                if (!downSfx.Playing) downSfx.Play(DownLoop);
                downSfx.Param("ducking", rider != null && rider.Data.Motion.Ducking ? 1 : 0);
                if (upSfx.Playing) upSfx.Stop();
                MoveV(speed * SourceWorld.EngineContext.DeltaTime);
            }
            else if (speed < 0f && ExactPosition.Y > startY)
            {
                if (!upSfx.Playing) upSfx.Play(UpLoop);
                if (downSfx.Playing) downSfx.Stop();
                MoveTowardsY(startY, (0f - speed) * SourceWorld.EngineContext.DeltaTime);
                if (ExactPosition.Y <= startY)
                {
                    upSfx.Stop();
                    ((ISourceSpatialAudioEnvironment)SourceWorld.EngineContext).SpatialAudio.Play(EndSound, Position);
                    shaker.ShakeFor(.1f, false);
                }
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            var shake = shaker.Value;
            Draw(context, textures[0], Position + shake);
            for (var i = 8; i < Width - 8f; i += 8) Draw(context, textures[1], Position + shake + new Vector2(i, 0));
            Draw(context, textures[3], Position + shake + new Vector2(Width - 8f, 0));
            Draw(context, textures[2], Position + shake + new Vector2(Width / 2f - 4f, 0));
        }

        private void Draw(ISourceRenderContext context, AtlasEntry texture, Vector2 position)
        {
            var image = new AtlasTextureDraw(texture, position, Vector2.Zero, PackedColor.White, Vector2.One);
            ((ISourceRenderCommandSink<AtlasTextureDraw>)context).Draw(in image, this);
        }
    }
}
