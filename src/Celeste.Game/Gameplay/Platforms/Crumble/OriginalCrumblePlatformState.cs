using Celeste.Core.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Randomness;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Scene.Components.Oscillation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Display;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Game.Gameplay.Platforms.Crumble
{
    public partial class OriginalCrumblePlatformState : SourceSolidEntityState
    {
        protected readonly IOriginalCrumbleProcess process;

        private List<SpriteImage> images;

        private List<SpriteImage> outline;

        private List<SimulationCoroutine> falls;

        private List<int> fallOrder;

        private ShakerListComponent shaker;

        private LightOccludeState occluder;

        private SimulationCoroutine outlineFader;

        public OriginalCrumblePlatformState(Vector2 position, float width, IOriginalCrumbleProcess process,
            ISourceSolidWorldFactory worlds)
            : base(position, width, 8f, false, worlds.Create(position, false))
        {
            this.process = process;
            EnableAssistModeChecks = false;
        }

        public OriginalCrumblePlatformState(EntityData data, Vector2 offset, IOriginalCrumbleProcess process,
            ISourceSolidWorldFactory worlds)
            : this(data.Position + offset, data.Width, process, worlds)
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            AtlasEntry mTexture = process.GameGraphics.GameAtlas.Entries["objects/crumbleBlock/outline"];
            outline = new List<SpriteImage>();
            if (base.Width <= 8f)
            {
                SpriteImage image = new SpriteImage(mTexture.GetSubtexture(24, 0, 8, 8));
                image.Color = PackedColor.White * 0f;
                OwnedComponents.Add(image);
                outline.Add(image);
            }
            else
            {
                for (int i = 0; (float)i < base.Width; i += 8)
                {
                    int num = ((i != 0) ? ((i > 0 && (float)i < base.Width - 8f) ? 1 : 2) : 0);
                    SpriteImage image2 = new SpriteImage(mTexture.GetSubtexture(num * 8, 0, 8, 8));
                    image2.Position = new Vector2(i, 0f);
                    image2.Color = PackedColor.White * 0f;
                    OwnedComponents.Add(image2);
                    outline.Add(image2);
                }
            }

            OwnedComponents.Add(outlineFader = new SimulationCoroutine(process));
            outlineFader.RemoveOnComplete = false;
            images = new List<SpriteImage>();
            falls = new List<SimulationCoroutine>();
            fallOrder = new List<int>();
            AtlasEntry mTexture2 = process.GameGraphics.GameAtlas.Entries[
                "objects/crumbleBlock/" + ((IOriginalAreaKeyEnvironment)process).AreaKeys
                .GetArea(((IOriginalAreaKeyEnvironment)process).AreaKeys.GetSessionArea(((OriginalLevelSceneRoot)scene)
                    .Session)).CrumbleBlock];
            for (int j = 0; (float)j < base.Width; j += 8)
            {
                int num2 = (int)((Math.Abs(base.X) + (float)j) / 8f) % 4;
                SpriteImage image3 = new SpriteImage(mTexture2.GetSubtexture(num2 * 8, 0, 8, 8));
                image3.Position = new Vector2(4 + j, 4f);
                image3.CenterOrigin();
                OwnedComponents.Add(image3);
                images.Add(image3);
                SimulationCoroutine coroutine = new SimulationCoroutine(process);
                coroutine.RemoveOnComplete = false;
                falls.Add(coroutine);
                OwnedComponents.Add(coroutine);
                fallOrder.Add(j / 8);
            }

            fallOrder.Shuffle(process.Random);
            OwnedComponents.Add(new SimulationCoroutine(process, Sequence()));
            OwnedComponents.Add(shaker = new ShakerListComponent(images.Count, process, false, delegate(Vector2[] v)
            {
                for (int k = 0; k < images.Count; k++)
                {
                    images[k].Position = new Vector2(4 + k * 8, 4f) + v[k];
                }
            }));
            OwnedComponents.Add(occluder = new LightOccludeState(0.2f));
        }

        private IEnumerator Sequence()
        {
            while (true)
            {
                bool onTop;
                if (GetPlayerOnTop() != null)
                {
                    onTop = true;
                    process.InputSource.Rumble(RumbleStrength.Medium, RumbleLength.Medium);
                }
                else
                {
                    if (GetPlayerClimbing() == null)
                    {
                        yield return null;
                        continue;
                    }

                    onTop = false;
                    process.InputSource.Rumble(RumbleStrength.Medium, RumbleLength.Medium);
                }

                process.AudioSession.Play("event:/game/general/platform_disintegrate", base.Center,
                    process.SaveContext);
                shaker.ShakeFor(onTop ? 0.6f : 1f, removeOnFinish: false);
                foreach (SpriteImage image in images)
                {
                    ((OriginalLevelSceneRoot)Scene).Particles.Emit(process.ParticleTypes.CrumblePlatform.P_Crumble, 2,
                        Position + image.Position + new Vector2(0f, 2f), Vector2.One * 3f);
                }

                for (int i = 0; i < (onTop ? 1 : 3); i++)
                {
                    yield return 0.2f;
                    foreach (SpriteImage image2 in images)
                    {
                        ((OriginalLevelSceneRoot)Scene).Particles.Emit(process.ParticleTypes.CrumblePlatform.P_Crumble,
                            2,
                            Position + image2.Position + new Vector2(0f, 2f), Vector2.One * 3f);
                    }
                }

                float timer = 0.4f;
                if (onTop)
                {
                    while (timer > 0f && GetPlayerOnTop() != null)
                    {
                        yield return null;
                        timer -= process.DeltaTime;
                    }
                }
                else
                {
                    while (timer > 0f)
                    {
                        yield return null;
                        timer -= process.DeltaTime;
                    }
                }

                outlineFader.Replace(OutlineFade(1f));
                occluder.Visible = false;
                Collidable = false;
                float num = 0.05f;
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < images.Count; k++)
                    {
                        if (k % 4 - j == 0)
                        {
                            falls[k].Replace(TileOut(images[fallOrder[k]], num * (float)j));
                        }
                    }
                }

                yield return 2f;
                while (SourceTrackedEntityCollision.Check(((ISourceScene)Scene).SourceScene.Entities,
                           typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState)
                               .FullName,
                           this) || SourceTrackedEntityCollision.Check(((ISourceScene)Scene).SourceScene.Entities,
                           "Celeste.Solid", this))
                {
                    yield return null;
                }

                outlineFader.Replace(OutlineFade(0f));
                occluder.Visible = true;
                Collidable = true;
                for (int l = 0; l < 4; l++)
                {
                    for (int m = 0; m < images.Count; m++)
                    {
                        if (m % 4 - l == 0)
                        {
                            falls[m].Replace(TileIn(m, images[fallOrder[m]], 0.05f * (float)l));
                        }
                    }
                }
            }
        }

        private IEnumerator OutlineFade(float to)
        {
            float from = 1f - to;
            for (float t = 0f; t < 1f; t += process.DeltaTime * 2f)
            {
                PackedColor color = PackedColor.White * (from + (to - from) * process.EasingArithmetic.CubeInOut(t));
                foreach (SpriteImage item in outline)
                {
                    item.Color = color;
                }

                yield return null;
            }
        }

        private IEnumerator TileOut(SpriteImage img, float delay)
        {
            img.Color = PackedColor.Gray;
            yield return delay;
            float distance = (img.Position.X * 7f % 3f + 1f) * 12f;
            Vector2 from = img.Position;
            for (float time = 0f; time < 1f; time += process.DeltaTime / 0.4f)
            {
                yield return null;
                img.Position = from + Vector2.UnitY * process.EasingArithmetic.CubeIn(time) * distance;
                img.Color = PackedColor.Gray * (1f - time);
                img.Scale = Vector2.One * (1f - time * 0.5f);
            }

            img.Visible = false;
        }

        private IEnumerator TileIn(int index, SpriteImage img, float delay)
        {
            var animation = CrumbleTileReturn(index, img, delay, true);
            while (animation.MoveNext()) yield return animation.Current;
        }
    }
}
