using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Hazards.Spinners.Dust;

namespace Celeste.Game.Credits
{
    public sealed partial class CreditsChapterSequence
    {
        private IEnumerator DustyRoutine(SceneEntityState oshiro)
        {
            var dusty = new List<SceneEntityState>();
            var timer = 0f;
            var offset = oshiro.Position + new Vector2(220f, -24f);
            var start = offset;
            for (var i = 0; i < 3; i++)
            {
                var entity =
                    new SceneEntityState(
                        ((ISourceEntitySourceDataEnvironment)engine)
                        .EntitySourceDataRegistration, offset + new Vector2(i * 24, 0f));
                entity.Depth = -50;
                entity.OwnedComponents.Add(new DustGraphicState(engine,
                    true, false, true));
                var image = new SpriteImage(((ISourceGameGraphicsEnvironment)engine).GameGraphics
                    .GameAtlas["decals/3-resort/brokenbox_" + (char)(97 + i)]);
                image.JustifyOrigin(.5f, 1f);
                image.Position = new(0f, -4f);
                entity.OwnedComponents.Add(image);
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(entity);
                dusty.Add(entity);
            }

            yield return 3.8f;
            while (true)
            {
                for (var j = 0; j < dusty.Count; j++)
                {
                    var entity = dusty[j];
                    entity.Position = new(offset.X + j * 24,
                        offset.Y + (float)Math.Sin(timer * 4f + j * .8f) * 4f);
                }

                if (offset.X < Level.Bounds.Left + 120)
                    offset.Y = ScalarMath.Approach(offset.Y, start.Y + 16f,
                        engine.Frame.DeltaTime * 16f, Extrema);
                offset.X -= 26f * engine.Frame.DeltaTime;
                timer += engine.Frame.DeltaTime;
                yield return null;
            }
        }
    }
}
