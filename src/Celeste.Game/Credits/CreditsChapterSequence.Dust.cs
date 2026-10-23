using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Hazards.Spinners.Dust;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;

namespace Celeste.Game.Credits
{
    public sealed partial class CreditsChapterSequence
    {
        private IEnumerator DustyRoutine(SceneEntityState oshiro)
        {
            var dusty = new List<SceneEntityState>();
            float timer = 0f;
            Vector2 offset = oshiro.Position + new Vector2(220f, -24f);
            Vector2 start = offset;
            for (int i = 0; i < 3; i++)
            {
                var entity =
                    new SceneEntityState(
                        ((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine)
                        .EntitySourceDataRegistration, offset + new Vector2(i * 24, 0f));
                entity.Depth = -50;
                entity.OwnedComponents.Add(new DustGraphicState(engine,
                    ignoreSolids: true, autoControlEyes: false, autoExpandDust: true));
                var image = new SpriteImage(((ISourceGameGraphicsEnvironment)engine).GameGraphics
                    .GameAtlas["decals/3-resort/brokenbox_" + (char)(97 + i)]);
                image.JustifyOrigin(.5f, 1f);
                image.Position = new Vector2(0f, -4f);
                entity.OwnedComponents.Add(image);
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(entity);
                dusty.Add(entity);
            }

            yield return 3.8f;
            while (true)
            {
                for (int j = 0; j < dusty.Count; j++)
                {
                    SceneEntityState entity = dusty[j];
                    entity.Position = new Vector2(offset.X + j * 24,
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
