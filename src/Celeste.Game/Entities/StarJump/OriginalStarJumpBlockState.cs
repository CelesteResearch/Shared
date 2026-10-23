using Celeste.Core.Display;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Game.Execution.Levels;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Core.Rendering;

namespace Celeste.Game.Entities.StarJump
{
    public class OriginalStarJumpBlockState : SourceSolidEntityState
    {
        private OriginalLevelSceneRoot level;
        private ISourceEngineContext Engine => SourceWorld.EngineContext;
        private readonly StarJumpRuntimeProfile profile;

        private bool sinks;

        private float startY;

        private float yLerp;

        private float sinkTimer;

        public OriginalStarJumpBlockState(Vector2 position, float width, float height, bool sinks,
            ISourceSolidWorld world)
            : base(position, width, height, false, world)
        {
            profile = ((IOriginalStarJumpEnvironment)Engine).StarJumpProfile;
            base.Depth = -10000;
            this.sinks = sinks;
            Add(new LightOccludeState());
            startY = base.Y;
            SurfaceSoundIndex = 32;
        }

        public OriginalStarJumpBlockState(EntityData data, Vector2 offset, ISourceSolidWorldFactory worlds)
            : this(data.Position + offset, data.Width, data.Height,
                EntityAttributeReader.Bool(data.Values, "sinks", false),
                worlds.Create(data.Position + offset, false))
        {
        }

        private void AwakeOriginal(object scene)
        {
            base.Awake(scene);
            level = (OriginalLevelSceneRoot)Scene;
            List<AtlasEntry> atlasSubtextures =
                ((ISourceGameGraphicsEnvironment)Engine).GameGraphics.GameAtlas.GetAtlasSubtextures(
                    "objects/starjumpBlock/leftrailing");
            List<AtlasEntry> atlasSubtextures2 =
                ((ISourceGameGraphicsEnvironment)Engine).GameGraphics.GameAtlas.GetAtlasSubtextures(
                    "objects/starjumpBlock/railing");
            List<AtlasEntry> atlasSubtextures3 =
                ((ISourceGameGraphicsEnvironment)Engine).GameGraphics.GameAtlas.GetAtlasSubtextures(
                    "objects/starjumpBlock/rightrailing");
            List<AtlasEntry> atlasSubtextures4 =
                ((ISourceGameGraphicsEnvironment)Engine).GameGraphics.GameAtlas.GetAtlasSubtextures(
                    "objects/starjumpBlock/edgeH");
            for (int i = 8; (float)i < base.Width - 8f; i += 8)
            {
                if (Open(i, -8f))
                {
                    SpriteImage image = new SpriteImage(Choose(atlasSubtextures4));
                    image.CenterOrigin();
                    image.Position = new Vector2(i + 4, 4f);
                    Add(image);
                    SpriteImage image2 =
                        new SpriteImage(atlasSubtextures2[mod((int)(base.X + (float)i) / 8, atlasSubtextures2.Count)]);
                    image2.Position = new Vector2(i, -8f);
                    Add(image2);
                }

                if (Open(i, base.Height))
                {
                    SpriteImage image3 = new SpriteImage(Choose(atlasSubtextures4));
                    image3.CenterOrigin();
                    image3.Scale.Y = -1f;
                    image3.Position = new Vector2(i + 4, base.Height - 4f);
                    Add(image3);
                }
            }

            List<AtlasEntry> atlasSubtextures5 =
                ((ISourceGameGraphicsEnvironment)Engine).GameGraphics.GameAtlas.GetAtlasSubtextures(
                    "objects/starjumpBlock/edgeV");
            for (int j = 8; (float)j < base.Height - 8f; j += 8)
            {
                if (Open(-8f, j))
                {
                    SpriteImage image4 = new SpriteImage(Choose(atlasSubtextures5));
                    image4.CenterOrigin();
                    image4.Scale.X = -1f;
                    image4.Position = new Vector2(4f, j + 4);
                    Add(image4);
                }

                if (Open(base.Width, j))
                {
                    SpriteImage image5 = new SpriteImage(Choose(atlasSubtextures5));
                    image5.CenterOrigin();
                    image5.Position = new Vector2(base.Width - 4f, j + 4);
                    Add(image5);
                }
            }

            List<AtlasEntry> atlasSubtextures6 =
                ((ISourceGameGraphicsEnvironment)Engine).GameGraphics.GameAtlas.GetAtlasSubtextures(
                    "objects/starjumpBlock/corner");
            SpriteImage image6 = null;
            if (Open(-8f, 0f) && Open(0f, -8f))
            {
                image6 = new SpriteImage(Choose(atlasSubtextures6));
                image6.Scale.X = -1f;
                SpriteImage image7 = new SpriteImage(atlasSubtextures[mod((int)base.X / 8, atlasSubtextures.Count)]);
                image7.Position = new Vector2(0f, -8f);
                Add(image7);
            }
            else if (Open(-8f, 0f))
            {
                image6 = new SpriteImage(Choose(atlasSubtextures5));
                image6.Scale.X = -1f;
            }
            else if (Open(0f, -8f))
            {
                image6 = new SpriteImage(Choose(atlasSubtextures4));
                SpriteImage image8 = new SpriteImage(atlasSubtextures2[mod((int)base.X / 8, atlasSubtextures2.Count)]);
                image8.Position = new Vector2(0f, -8f);
                Add(image8);
            }

            image6.CenterOrigin();
            image6.Position = new Vector2(4f, 4f);
            Add(image6);
            SpriteImage image9 = null;
            if (Open(base.Width, 0f) && Open(base.Width - 8f, -8f))
            {
                image9 = new SpriteImage(Choose(atlasSubtextures6));
                SpriteImage image10 =
                    new SpriteImage(
                        atlasSubtextures3[mod((int)(base.X + base.Width) / 8 - 1, atlasSubtextures3.Count)]);
                image10.Position = new Vector2(base.Width - 8f, -8f);
                Add(image10);
            }
            else if (Open(base.Width, 0f))
            {
                image9 = new SpriteImage(Choose(atlasSubtextures5));
            }
            else if (Open(base.Width - 8f, -8f))
            {
                image9 = new SpriteImage(Choose(atlasSubtextures4));
                SpriteImage image11 =
                    new SpriteImage(
                        atlasSubtextures2[mod((int)(base.X + base.Width) / 8 - 1, atlasSubtextures2.Count)]);
                image11.Position = new Vector2(base.Width - 8f, -8f);
                Add(image11);
            }

            image9.CenterOrigin();
            image9.Position = new Vector2(base.Width - 4f, 4f);
            Add(image9);
            SpriteImage image12 = null;
            if (Open(-8f, base.Height - 8f) && Open(0f, base.Height))
            {
                image12 = new SpriteImage(Choose(atlasSubtextures6));
                image12.Scale.X = -1f;
            }
            else if (Open(-8f, base.Height - 8f))
            {
                image12 = new SpriteImage(Choose(atlasSubtextures5));
                image12.Scale.X = -1f;
            }
            else if (Open(0f, base.Height))
            {
                image12 = new SpriteImage(Choose(atlasSubtextures4));
            }

            image12.Scale.Y = -1f;
            image12.CenterOrigin();
            image12.Position = new Vector2(4f, base.Height - 4f);
            Add(image12);
            SpriteImage image13 = null;
            if (Open(base.Width, base.Height - 8f) && Open(base.Width - 8f, base.Height))
            {
                image13 = new SpriteImage(Choose(atlasSubtextures6));
            }
            else if (Open(base.Width, base.Height - 8f))
            {
                image13 = new SpriteImage(Choose(atlasSubtextures5));
            }
            else if (Open(base.Width - 8f, base.Height))
            {
                image13 = new SpriteImage(Choose(atlasSubtextures4));
            }

            image13.Scale.Y = -1f;
            image13.CenterOrigin();
            image13.Position = new Vector2(base.Width - 4f, base.Height - 4f);
            Add(image13);
        }

        private AtlasEntry Choose(List<AtlasEntry> entries)
            => entries[((ISourceRandomEnvironment)Engine).Random.Next(entries.Count)];

        private int mod(int x, int m)
        {
            return (x % m + m) % m;
        }

        private bool Open(float x, float y)
        {
            foreach (var actual in level.Scheduler.Entities.GetTrackedEntities("Celeste.StarJumpBlock"))
            {
                var entity = (OriginalStarJumpBlockState)actual;
                if (entity.Collidable && entity.Collider != null &&
                    entity.Collider.Collide(new Vector2(base.X + x + 4f, base.Y + y + 4f)))
                    return false;
            }

            return true;
        }

        public override void Update()
        {
            base.Update();
            if (sinks)
            {
                if (HasPlayerRider())
                {
                    sinkTimer = 0.1f;
                }
                else if (sinkTimer > 0f)
                {
                    sinkTimer -= Engine.DeltaTime;
                }

                if (sinkTimer > 0f)
                {
                    yLerp = ScalarMath.Approach(yLerp, 1f, 1f * Engine.DeltaTime,
                        ((ISourceExtremaEnvironment)Engine).ExtremaArithmetic);
                }
                else
                {
                    yLerp = ScalarMath.Approach(yLerp, 0f, 1f * Engine.DeltaTime,
                        ((ISourceExtremaEnvironment)Engine).ExtremaArithmetic);
                }

                float y = ScalarMath.Lerp(startY, startY + 12f,
                    ((ISourceEasingEnvironment)Engine).EasingArithmetic.SineInOut(yLerp),
                    ((ISourceScalarEnvironment)Engine).ScalarArithmetic);
                MoveToY(y);
            }
        }

        private void RenderOriginal(ISourceRenderContext context)
        {
            OriginalStarJumpControllerState entity =
                level.Scheduler.Entities
                    .GetTrackedEntity<OriginalStarJumpControllerState>("Celeste.StarJumpController");
            if (entity != null)
            {
                Vector2 vector = Vector2Geometry.Floor(level.Camera.Position);
                var blockFill = entity.BlockFill;
                ((ISourceDrawScope)context).Draw.SpriteBatch.Draw((SourceTexture2DResource)blockFill.Target, Position,
                    new IntRect((int)(base.X - vector.X), (int)(base.Y - vector.Y), (int)base.Width, (int)base.Height),
                    PackedColor.White.PackedValue);
            }

            base.Render(context);
        }

        private void AwakeInstalled(object scene)
        {
            base.Awake(scene);
            level = (OriginalLevelSceneRoot)Scene;
            List<AtlasEntry> atlasSubtextures =
                ((ISourceGameGraphicsEnvironment)Engine).GameGraphics.GameAtlas.GetAtlasSubtextures(
                    "objects/starjumpBlock/leftrailing");
            List<AtlasEntry> atlasSubtextures2 =
                ((ISourceGameGraphicsEnvironment)Engine).GameGraphics.GameAtlas.GetAtlasSubtextures(
                    "objects/starjumpBlock/railing");
            List<AtlasEntry> atlasSubtextures3 =
                ((ISourceGameGraphicsEnvironment)Engine).GameGraphics.GameAtlas.GetAtlasSubtextures(
                    "objects/starjumpBlock/rightrailing");
            List<AtlasEntry> atlasSubtextures4 =
                ((ISourceGameGraphicsEnvironment)Engine).GameGraphics.GameAtlas.GetAtlasSubtextures(
                    "objects/starjumpBlock/edgeH");
            List<AtlasEntry> atlasSubtextures5 =
                ((ISourceGameGraphicsEnvironment)Engine).GameGraphics.GameAtlas.GetAtlasSubtextures(
                    "objects/starjumpBlock/edgeV");
            List<AtlasEntry> atlasSubtextures6 =
                ((ISourceGameGraphicsEnvironment)Engine).GameGraphics.GameAtlas.GetAtlasSubtextures(
                    "objects/starjumpBlock/corner");
            for (int i = 8; (float)i < base.Width - 8f; i += 8)
            {
                if (Open(i, -8f))
                {
                    SpriteImage image = new SpriteImage(Choose(atlasSubtextures4));
                    image.CenterOrigin();
                    image.Position = new Vector2(i + 4, 4f);
                    Add(image);
                    SpriteImage image2 =
                        new SpriteImage(atlasSubtextures2[mod((int)(base.X + (float)i) / 8, atlasSubtextures2.Count)]);
                    image2.Position = new Vector2(i, -8f);
                    Add(image2);
                }

                if (Open(i, base.Height))
                {
                    SpriteImage image3 = new SpriteImage(Choose(atlasSubtextures4));
                    image3.CenterOrigin();
                    image3.Scale.Y = -1f;
                    image3.Position = new Vector2(i + 4, base.Height - 4f);
                    Add(image3);
                }
            }

            for (int j = 8; (float)j < base.Height - 8f; j += 8)
            {
                if (Open(-8f, j))
                {
                    SpriteImage image4 = new SpriteImage(Choose(atlasSubtextures5));
                    image4.CenterOrigin();
                    image4.Scale.X = -1f;
                    image4.Position = new Vector2(4f, j + 4);
                    Add(image4);
                }

                if (Open(base.Width, j))
                {
                    SpriteImage image5 = new SpriteImage(Choose(atlasSubtextures5));
                    image5.CenterOrigin();
                    image5.Position = new Vector2(base.Width - 4f, j + 4);
                    Add(image5);
                }
            }

            SpriteImage image6 = null;
            if (Open(-8f, 0f) && Open(0f, -8f))
            {
                image6 = new SpriteImage(Choose(atlasSubtextures6));
                image6.Scale.X = -1f;
                SpriteImage image7 = new SpriteImage(atlasSubtextures[mod((int)base.X / 8, atlasSubtextures.Count)]);
                image7.Position = new Vector2(0f, -8f);
                Add(image7);
            }
            else if (Open(-8f, 0f))
            {
                image6 = new SpriteImage(Choose(atlasSubtextures5));
                image6.Scale.X = -1f;
            }
            else if (Open(0f, -8f))
            {
                image6 = new SpriteImage(Choose(atlasSubtextures4));
                SpriteImage image8 = new SpriteImage(atlasSubtextures2[mod((int)base.X / 8, atlasSubtextures2.Count)]);
                image8.Position = new Vector2(0f, -8f);
                Add(image8);
            }

            if (image6 != null)
            {
                image6.CenterOrigin();
                image6.Position = new Vector2(4f, 4f);
                Add(image6);
            }

            image6 = null;
            if (Open(base.Width, 0f) && Open(base.Width - 8f, -8f))
            {
                image6 = new SpriteImage(Choose(atlasSubtextures6));
                SpriteImage image9 =
                    new SpriteImage(
                        atlasSubtextures3[mod((int)(base.X + base.Width) / 8 - 1, atlasSubtextures3.Count)]);
                image9.Position = new Vector2(base.Width - 8f, -8f);
                Add(image9);
            }
            else if (Open(base.Width, 0f))
            {
                image6 = new SpriteImage(Choose(atlasSubtextures5));
            }
            else if (Open(base.Width - 8f, -8f))
            {
                image6 = new SpriteImage(Choose(atlasSubtextures4));
                SpriteImage image10 =
                    new SpriteImage(
                        atlasSubtextures2[mod((int)(base.X + base.Width) / 8 - 1, atlasSubtextures2.Count)]);
                image10.Position = new Vector2(base.Width - 8f, -8f);
                Add(image10);
            }

            if (image6 != null)
            {
                image6.CenterOrigin();
                image6.Position = new Vector2(base.Width - 4f, 4f);
                Add(image6);
            }

            image6 = null;
            if (Open(-8f, base.Height - 8f) && Open(0f, base.Height))
            {
                image6 = new SpriteImage(Choose(atlasSubtextures6));
                image6.Scale.X = -1f;
            }
            else if (Open(-8f, base.Height - 8f))
            {
                image6 = new SpriteImage(Choose(atlasSubtextures5));
                image6.Scale.X = -1f;
            }
            else if (Open(0f, base.Height))
            {
                image6 = new SpriteImage(Choose(atlasSubtextures4));
            }

            if (image6 != null)
            {
                image6.Scale.Y = -1f;
                image6.CenterOrigin();
                image6.Position = new Vector2(4f, base.Height - 4f);
                Add(image6);
            }

            image6 = null;
            if (Open(base.Width, base.Height - 8f) && Open(base.Width - 8f, base.Height))
            {
                image6 = new SpriteImage(Choose(atlasSubtextures6));
            }
            else if (Open(base.Width, base.Height - 8f))
            {
                image6 = new SpriteImage(Choose(atlasSubtextures5));
            }
            else if (Open(base.Width - 8f, base.Height))
            {
                image6 = new SpriteImage(Choose(atlasSubtextures4));
            }

            if (image6 != null)
            {
                image6.Scale.Y = -1f;
                image6.CenterOrigin();
                image6.Position = new Vector2(base.Width - 4f, base.Height - 4f);
                Add(image6);
            }
        }

        private void RenderInstalled(ISourceRenderContext context)
        {
            OriginalStarJumpControllerState entity =
                level.Scheduler.Entities
                    .GetTrackedEntity<OriginalStarJumpControllerState>("Celeste.StarJumpController");
            OriginalStarClimbGraphicsControllerState entity2 =
                level.Scheduler.Entities.GetTrackedEntity<OriginalStarClimbGraphicsControllerState>(
                    "Celeste.Mod.Entities.StarClimbGraphicsController");
            Vector2 vector = Vector2Geometry.Floor(level.Camera.Position);
            global::Celeste.Graphics.Content.VirtualAssets.VirtualRenderTarget virtualRenderTarget = null;
            if (entity2 != null)
            {
                virtualRenderTarget = ((IOriginalStarJumpEnvironment)Engine).StarClimbGraphics.BlockFill;
            }
            else if (entity != null)
            {
                virtualRenderTarget = entity.BlockFill;
            }

            if (virtualRenderTarget != null)
            {
                ((ISourceDrawScope)context).Draw.SpriteBatch.Draw((SourceTexture2DResource)virtualRenderTarget.Target,
                    Position,
                    new IntRect((int)(base.X - vector.X), (int)(base.Y - vector.Y), (int)base.Width, (int)base.Height),
                    PackedColor.White.PackedValue);
            }

            base.Render(context);
        }

        public override void Awake(object scene)
        {
            if (profile == StarJumpRuntimeProfile.Original ||
                ((OriginalLevelSceneRoot)scene).AreaData.LevelSet == "Celeste")
            {
                AwakeOriginal(scene);
                return;
            }

            AwakeInstalled(scene);
        }

        public override void Render(ISourceRenderContext context)
        {
            if (profile == StarJumpRuntimeProfile.Original ||
                ((OriginalLevelSceneRoot)Scene).AreaData.LevelSet == "Celeste")
            {
                RenderOriginal(context);
                return;
            }

            RenderInstalled(context);
        }
    }
}
