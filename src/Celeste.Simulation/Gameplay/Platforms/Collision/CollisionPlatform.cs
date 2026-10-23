using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Maps;
using Celeste.Physics.Collision;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Platforms.Movement;
using Celeste.Simulation.Gameplay.Platforms.StaticMovers;
using Celeste.Simulation.Gameplay.Player.Collision.Surfaces;
using Celeste.Simulation.Gameplay.Player.State;

namespace Celeste.Simulation.Gameplay.Platforms.Collision
{
    // Celeste-specific platform state. Collision geometry and hit identity live in Physics.
    public sealed class CollisionPlatform : PixelPlatform,
        IMovingSolid,
        ISceneEntityAssociation, ISceneEntityDepth
    {
        // Used only when this actual Platform is published as an Entity identity.
        public object Scene { get; private set; }

        object ISceneEntityAssociation.Scene
        {
            get => Scene;
            set => Scene = value;
        }

        public SceneEntityDepthState DepthState { get; } = new(-9000);

        public int Depth
        {
            get => DepthState.RawDepth;
            set => DepthState.SetDepth(value, Scene, this);
        }

        public Action TriggerFallingBlock;

        public readonly List<PlatformStaticAttachment>
            StaticAttachments = [];

        public void MoveStaticAttachments(Vector2 amount)
        {
            if (SourceEntityOwner is ISourcePlatformEntity
                source)
            {
                source.MoveStaticMovers(amount);
                return;
            }

            foreach (var attachment in StaticAttachments) attachment.Move?.Invoke(amount);
        }

        public void ShakeStaticAttachments(Vector2 amount)
        {
            if (SourceEntityOwner is ISourcePlatformEntity
                source)
            {
                source.ShakeStaticMovers(amount);
                return;
            }

            foreach (var attachment in StaticAttachments) attachment.Shake?.Invoke(amount);
        }

        public void DestroyStaticAttachments()
        {
            if (SourceEntityOwner is ISourcePlatformEntity
                source)
            {
                source.DestroyStaticMovers();
                return;
            }

            foreach (var attachment in StaticAttachments) attachment.Destroy?.Invoke();
            StaticAttachments.Clear();
        }

        public void EnableStaticAttachments()
        {
            if (SourceEntityOwner is ISourcePlatformEntity
                source)
            {
                source.EnableStaticMovers();
                return;
            }

            foreach (var attachment in StaticAttachments) attachment.Enable?.Invoke();
        }

        public void DisableStaticAttachments()
        {
            if (SourceEntityOwner is ISourcePlatformEntity
                source)
            {
                source.DisableStaticMovers();
                return;
            }

            foreach (var attachment in StaticAttachments) attachment.Disable?.Invoke();
        }

        public bool DisableLightsInside { get; set; } = true;
        public bool BlockWaterfalls { get; set; } = true;
        public bool Safe { get; set; }
        public bool IsSolidTiles { get; set; }
        public bool AllowStaticMovers { get; set; } = true;
        public bool EnableAssistModeChecks { get; set; } = true;
        public bool PathfinderHitbox { get; set; } = true;
        public bool SquishEvenInAssistMode { get; set; }
        public bool StopPlayerRunIntoAnimation { get; set; } = true;
        public int SurfaceSoundIndex = 8, SurfaceSoundPriority;
        public Func<PlayerState, int, int> GetWallSoundIndex;
        public Action<Vector2, Vector2> BreakDashBlock;
        public MapElement Source { get; set; }

        public PlayerCollisionSurface Surface { get; } =
            new();

        public CollisionPlatform(Vector2 position, bool isJumpThru = false, bool safe = true)
            : base(position, isJumpThru)
        {
            TileWidth = TileHeight = 8;
            EmptyTile = '0';
            Safe = safe;
            Surface.GetLandSoundIndex = _ => SurfaceSoundIndex;
        }
    }
}
