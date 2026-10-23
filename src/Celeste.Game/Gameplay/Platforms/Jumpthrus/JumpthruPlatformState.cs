using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using System;
using System.Numerics;
using Celeste.Core.Randomness;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;

namespace Celeste.Game.Gameplay.Platforms.Jumpthrus
{
    public class JumpthruPlatformState : SourceJumpThruEntityState
    {
        private int columns;
        private string overrideTexture;
        private int overrideSoundIndex = -1;

        public JumpthruPlatformState(Vector2 position, int width, string overrideTexture,
            ISourceSolidWorld world, int overrideSoundIndex = -1) : base(position, width, true, world)
        {
            columns = width / 8;
            Depth = -60;
            this.overrideTexture = overrideTexture;
            this.overrideSoundIndex = overrideSoundIndex;
        }

        public JumpthruPlatformState(EntityData data, Vector2 offset, ISourceSolidWorld world)
            : this(SourceVector2Math.Add(data.Position, offset), data.Width,
                EntityAttributeReader.Attr(data.Values, "texture", "default"), world,
                EntityAttributeReader.Int(data.Values, "surfaceIndex", -1))
        {
        }

        public static JumpthruPlatformState CreateFromMapData(EntityData data, Vector2 offset,
            ISourceSolidWorldFactory worlds)
        {
            Vector2 position = SourceVector2Math.Add(data.Position, offset);
            int width = data.Width;
            string texture = EntityAttributeReader.Attr(data.Values, "texture", "default");
            int surfaceIndex = EntityAttributeReader.Int(data.Values, "surfaceIndex", -1);
            var world = worlds.CreateJumpThru(position, true);
            return new JumpthruPlatformState(position, width, texture, world, surfaceIndex);
        }

        public override void Awake(object scene)
        {
            string jumpthru = (scene as OriginalLevelSceneRoot).AreaData.Jumpthru;
            if (!string.IsNullOrEmpty(overrideTexture) && !overrideTexture.Equals("default"))
                jumpthru = overrideTexture;
            if (overrideSoundIndex > 0)
                SurfaceSoundIndex = overrideSoundIndex;
            else
            {
                switch (jumpthru.ToLower())
                {
                    case "dream": SurfaceSoundIndex = 32; break;
                    case "temple":
                    case "templeb": SurfaceSoundIndex = 8; break;
                    case "core": SurfaceSoundIndex = 3; break;
                    default: SurfaceSoundIndex = 5; break;
                }
            }

            var texture = ((ISourceGameGraphicsEnvironment)SourceWorld.EngineContext)
                .GameGraphics.GameAtlas["objects/jumpthru/" + jumpthru];
            int count = texture.FrameWidth / 8;
            for (int i = 0; i < columns; i++)
            {
                int x, y;
                if (i == 0)
                {
                    x = 0;
                    y = !SourceTrackedEntityCollision.CheckAtExcept(((ISourceScene)Scene).SourceScene.Entities,
                        "Celeste.Solid", "Celeste.SwapBlock", "Celeste.ExitBlock", this,
                        SourceVector2Math.Add(Position, new Vector2(-1f, 0f)))
                        ? 1
                        : 0;
                }
                else if (i == columns - 1)
                {
                    x = count - 1;
                    y = !SourceTrackedEntityCollision.CheckAtExcept(((ISourceScene)Scene).SourceScene.Entities,
                        "Celeste.Solid", "Celeste.SwapBlock", "Celeste.ExitBlock", this,
                        SourceVector2Math.Add(Position, new Vector2(1f, 0f)))
                        ? 1
                        : 0;
                }
                else
                {
                    x = 1 + SourceWorld.GameplayRandom.Next(count - 2);
                    y = RandomSelection.Choose(SourceWorld.GameplayRandom, 0, 1);
                }

                var image = new SpriteImage(texture.GetSubtexture(x * 8, y * 8, 8, 8));
                image.Position.X = i * 8;
                OwnedComponents.Add(image);
            }
        }
    }
}
