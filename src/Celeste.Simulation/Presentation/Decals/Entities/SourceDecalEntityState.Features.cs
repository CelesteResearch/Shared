using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Components.Events;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Platforms.Collision;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Platforms.StaticMovers;
using Celeste.Simulation.Presentation.Effects.Mirrors;

namespace Celeste.Simulation.Presentation.Decals.Entities
{
    public partial class SourceDecalEntityState
    {
        private readonly List<SourceSolidEntityState> solids = [];
        public SourceStaticMoverState StaticMover { get; private set; }

        public void MakeSolid(float x, float y, float width, float height, int surfaceSoundIndex,
            bool blockWaterfalls = true, bool safe = true)
        {
            MakeSolid(x, y, width, height, surfaceSoundIndex, 0, blockWaterfalls, safe);
        }

        public void MakeSolid(float x, float y, float width, float height, int surfaceSoundIndex,
            int surfaceSoundPriority, bool blockWaterfalls = true, bool safe = true)
        {
            var at = Position + new Vector2(x, y);
            var world = ((ISourcePlatformCollisionScene)Scene).SolidWorldFactory.Create(at, safe);
            var solid = new SourceSolidEntityState(at, width, height, safe, world)
            {
                BlockWaterfalls = blockWaterfalls,
                SurfaceSoundIndex = surfaceSoundIndex,
                SurfaceSoundPriority = surfaceSoundPriority,
            };
            solids.Add(solid);
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(solid);
        }

        public void MakeStaticMover(int x, int y, int width, int height,
            Action<ISourcePlatformEntity> onAttach, bool jumpThrus = false)
        {
            StaticMover = new()
            {
                SolidChecker = solid => !solids.Contains(solid) && solid.Collider != null &&
                                        solid.Collider.Collide(new IntRect((int)Position.X + x, (int)Position.Y + y,
                                            width,
                                            height)),
                OnDestroy = RemoveWithSolids,
                OnDisable = () =>
                {
                    Active = Visible = Collidable = false;
                    foreach (var solid in solids) solid.Collidable = false;
                },
                OnEnable = () =>
                {
                    Active = Visible = Collidable = true;
                    foreach (var solid in solids) solid.Collidable = true;
                },
                OnMove = amount =>
                {
                    Position += amount;
                    var liftSpeed = StaticMover.Platform.LiftSpeed;
                    foreach (var solid in solids)
                    {
                        solid.MoveH(amount.X, liftSpeed.X);
                        solid.MoveV(amount.Y, liftSpeed.Y);
                    }
                },
                OnShake = amount => Position += amount,
                OnAttach = platform =>
                {
                    ((ISourceOwnedComponentList)platform).OwnedComponents.Add(
                        new SourceEntityRemovedListener(RemoveWithSolids));
                    onAttach(platform);
                },
            };
            if (jumpThrus)
                StaticMover.JumpThruChecker = platform => platform.Collider != null &&
                                                          platform.Collider.Collide(new IntRect((int)Position.X + x,
                                                              (int)Position.X + y, width, height));
            OwnedComponents.Add(StaticMover);
        }

        private void RemoveWithSolids()
        {
            RemoveSelf();
            foreach (var solid in solids) solid.RemoveSelf();
        }

        public void AddMirrorMasks(IReadOnlyList<AtlasEntry> masks, bool keepOffsetsClose, ISourceRandom random,
            ISourceRenderEnvironment renderEnvironment)
        {
            if (keepOffsetsClose)
            {
                AddMirrorMasks(masks, GetMirrorOffset(random), random, renderEnvironment);
                return;
            }

            foreach (var mask in masks)
            {
                var surface = new MirrorSurfaceState(((ISourceExtremaEnvironment)renderEnvironment).ExtremaArithmetic)
                    { ReflectionOffset = GetMirrorOffset(random) };
                surface.OnRender = () => RenderMirrorMask(mask, surface, renderEnvironment);
                OwnedComponents.Add(surface);
            }
        }

        public void AddMirrorMasks(IReadOnlyList<AtlasEntry> masks, Vector2 offset, ISourceRandom random,
            ISourceRenderEnvironment renderEnvironment)
        {
            foreach (var mask in masks)
            {
                var surface = new MirrorSurfaceState(((ISourceExtremaEnvironment)renderEnvironment).ExtremaArithmetic)
                {
                    ReflectionOffset = offset + new Vector2(-2f + (float)random.NextDouble() * 4f,
                        -2f + (float)random.NextDouble() * 4f),
                };
                surface.OnRender = () => RenderMirrorMask(mask, surface, renderEnvironment);
                OwnedComponents.Add(surface);
            }
        }

        public void AddSpecialMirrorMasks(IReadOnlyList<AtlasEntry> masks, Vector2 offset, ISourceRandom random,
            ISourceRenderEnvironment renderEnvironment)
        {
            for (var i = 0; i < masks.Count; i++)
            {
                var jitter = new Vector2(-2f + (float)random.NextDouble() * 4f,
                    -2f + (float)random.NextDouble() * 4f);
                switch (i)
                {
                    case 2: jitter = new(4f, 2f); break;
                    case 6: jitter = new(-2f, 0f); break;
                }

                var mask = masks[i];
                var surface = new MirrorSurfaceState(((ISourceExtremaEnvironment)renderEnvironment).ExtremaArithmetic)
                    { ReflectionOffset = offset + jitter };
                surface.OnRender = () => RenderMirrorMask(mask, surface, renderEnvironment);
                OwnedComponents.Add(surface);
            }
        }

        public static Vector2 GetMirrorOffset(ISourceRandom random)
        {
            return new(
                random.Next(5, 14) * (random.Next(2) == 0 ? 1 : -1),
                random.Next(2, 6) * (random.Next(2) == 0 ? 1 : -1));
        }

        private void RenderMirrorMask(AtlasEntry mask, MirrorSurfaceState surface,
            ISourceRenderEnvironment renderEnvironment)
        {
            SourceAtlasDrawing.Draw(renderEnvironment.CurrentContext, this, mask,
                Position,
                new Vector2(mask.FrameWidth, mask.FrameHeight) * .5f, surface.ReflectionColor, Scale, Rotation);
        }
    }
}
