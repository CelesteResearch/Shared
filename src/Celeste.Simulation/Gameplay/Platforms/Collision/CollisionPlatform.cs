using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Physics.Collision;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Platforms.Collision
{
    // Celeste-specific platform state. Collision geometry and hit identity live in Physics.
    public sealed class CollisionPlatform : PixelPlatform,
        global::Celeste.Simulation.Gameplay.Platforms.Movement.IMovingSolid,
        global::Celeste.Scene.Tracking.ISceneEntityAssociation, global::Celeste.Scene.Tracking.ISceneEntityDepth
    {
        // Used only when this actual Platform is published as an Entity identity.
        public object Scene { get; private set; }

        object global::Celeste.Scene.Tracking.ISceneEntityAssociation.Scene
        {
            get => Scene;
            set => Scene = value;
        }

        private readonly global::Celeste.Scene.Tracking.SceneEntityDepthState depthFields =
            new global::Celeste.Scene.Tracking.SceneEntityDepthState(-9000);

        public global::Celeste.Scene.Tracking.SceneEntityDepthState DepthState => depthFields;

        public int Depth
        {
            get => depthFields.RawDepth;
            set => depthFields.SetDepth(value, Scene, this);
        }

        public Action TriggerFallingBlock;

        public readonly List<global::Celeste.Simulation.Gameplay.Platforms.StaticMovers.PlatformStaticAttachment>
            StaticAttachments =
                new List<global::Celeste.Simulation.Gameplay.Platforms.StaticMovers.PlatformStaticAttachment>();

        public void MoveStaticAttachments(Vector2 amount)
        {
            if (SourceEntityOwner is global::Celeste.Simulation.Gameplay.Platforms.Foundation.ISourcePlatformEntity
                source)
            {
                source.MoveStaticMovers(amount);
                return;
            }

            foreach (var attachment in StaticAttachments) attachment.Move?.Invoke(amount);
        }

        public void ShakeStaticAttachments(Vector2 amount)
        {
            if (SourceEntityOwner is global::Celeste.Simulation.Gameplay.Platforms.Foundation.ISourcePlatformEntity
                source)
            {
                source.ShakeStaticMovers(amount);
                return;
            }

            foreach (var attachment in StaticAttachments) attachment.Shake?.Invoke(amount);
        }

        public void DestroyStaticAttachments()
        {
            if (SourceEntityOwner is global::Celeste.Simulation.Gameplay.Platforms.Foundation.ISourcePlatformEntity
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
            if (SourceEntityOwner is global::Celeste.Simulation.Gameplay.Platforms.Foundation.ISourcePlatformEntity
                source)
            {
                source.EnableStaticMovers();
                return;
            }

            foreach (var attachment in StaticAttachments) attachment.Enable?.Invoke();
        }

        public void DisableStaticAttachments()
        {
            if (SourceEntityOwner is global::Celeste.Simulation.Gameplay.Platforms.Foundation.ISourcePlatformEntity
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
        public Func<global::Celeste.Simulation.Gameplay.Player.State.PlayerState, int, int> GetWallSoundIndex;
        public Action<Vector2, Vector2> BreakDashBlock;
        public global::Celeste.Core.Maps.MapElement Source { get; set; }

        public global::Celeste.Simulation.Gameplay.Player.Collision.Surfaces.PlayerCollisionSurface Surface { get; }
            = new global::Celeste.Simulation.Gameplay.Player.Collision.Surfaces.PlayerCollisionSurface();

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
