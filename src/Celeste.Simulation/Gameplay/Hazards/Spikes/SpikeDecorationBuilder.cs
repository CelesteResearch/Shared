using System;
using System.Numerics;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Scene.Entities;

namespace Celeste.Simulation.Gameplay.Hazards.Spikes
{
    public static class SpikeDecorationBuilder
    {
        public static void Add(ISourceEngineContext engine, SceneEntityState entity, int size, SpikeDirection direction,
            string spikeType, Func<string, string> getTexturePrefix, ISourceRandom random,
            Action<SpriteImage> onImageAdded = null, Action<float> addTentacle = null)
        {
            var text = direction.ToString().ToLower();
            if (spikeType == "tentacles")
            {
                for (var i = 0; i < size / 16; i++)
                    if (addTentacle != null) addTentacle(i);
                    else AddTentacle(engine, entity, size, direction, random, i);

                if (size / 8 % 2 == 1)
                {
                    var i = size / 16 - 0.5f;
                    if (addTentacle != null) addTentacle(i);
                    else AddTentacle(engine, entity, size, direction, random, i);
                }

                return;
            }

            var graphics = ((ISourceGameGraphicsEnvironment)engine).GameGraphics;
            var textures = graphics.GameAtlas.GetAtlasSubtextures(getTexturePrefix(spikeType) + "_" + text);
            for (var j = 0; j < size / 8; j++)
            {
                var image = new SpriteImage(textures[random.Next(textures.Count)]);
                switch (direction)
                {
                    case SpikeDirection.Up:
                        image.JustifyOrigin(0.5f, 1f);
                        image.Position = Vector2.UnitX * (j + 0.5f) * 8f + Vector2.UnitY;
                        break;
                    case SpikeDirection.Down:
                        image.JustifyOrigin(0.5f, 0f);
                        image.Position = Vector2.UnitX * (j + 0.5f) * 8f - Vector2.UnitY;
                        break;
                    case SpikeDirection.Right:
                        image.JustifyOrigin(0f, 0.5f);
                        image.Position = Vector2.UnitY * (j + 0.5f) * 8f - Vector2.UnitX;
                        break;
                    case SpikeDirection.Left:
                        image.JustifyOrigin(1f, 0.5f);
                        image.Position = Vector2.UnitY * (j + 0.5f) * 8f + Vector2.UnitX;
                        break;
                }

                entity.OwnedComponents.Add(image);
                onImageAdded?.Invoke(image);
            }
        }

        public static void AddTentacle(ISourceEngineContext engine, SceneEntityState entity, int size,
            SpikeDirection direction, ISourceRandom random, float i)
        {
            var graphics = ((ISourceGameGraphicsEnvironment)engine).GameGraphics;
            var sprite = graphics.SpriteFactory.Create("tentacles");
            sprite.Play(random.Next(3).ToString(), true, true);
            sprite.Position =
                (direction == SpikeDirection.Up || direction == SpikeDirection.Down ? Vector2.UnitX : Vector2.UnitY) *
                (i + 0.5f) * 16f;
            sprite.Scale.X = random.Next(2) == 0 ? -1 : 1;
            sprite.SetAnimationFrame(random.Next(sprite.CurrentAnimationTotalFrames));
            if (direction == SpikeDirection.Up)
            {
                sprite.Rotation = -(float)Math.PI / 2f;
                sprite.Position.Y++;
            }
            else if (direction == SpikeDirection.Right)
            {
                sprite.Rotation = 0f;
                sprite.Position.X--;
            }
            else if (direction == SpikeDirection.Left)
            {
                sprite.Rotation = (float)Math.PI;
                sprite.Position.X++;
            }
            else if (direction == SpikeDirection.Down)
            {
                sprite.Rotation = (float)Math.PI / 2f;
                sprite.Position.Y--;
            }

            sprite.Rotation += (float)Math.PI / 2f;
            entity.OwnedComponents.Add(sprite);
        }
    }
}
