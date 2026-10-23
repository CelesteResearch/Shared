using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Physics.Collision;
using Celeste.Scene.Components;
using Celeste.Graphics.Content.Tiles;

namespace Celeste.Simulation.Gameplay.Tiles
{
    public class TileInterceptorState : SourceComponentState
    {
        public Action<global::Celeste.Graphics.Content.Atlas.AtlasEntry, Vector2, IntPoint> Intercepter;
        public bool HighPriority;

        public TileInterceptorState(
            Action<global::Celeste.Graphics.Content.Atlas.AtlasEntry, Vector2, IntPoint> intercepter,
            bool highPriority) : base(false, false)
        {
            Intercepter = intercepter;
            HighPriority = highPriority;
        }

        public TileInterceptorState(TileGrid applyToGrid, bool highPriority) : base(false, false)
        {
            Intercepter = (texture, position, point) => applyToGrid.Tiles[point.X, point.Y] = texture;
            HighPriority = highPriority;
        }

        public static bool TileCheck(SceneComponentTracker tracker,
            global::Celeste.Graphics.Content.Atlas.AtlasEntry tile, Vector2 at)
        {
            at += Vector2.One * 4f;
            TileInterceptorState interceptor = null;
            var components = tracker.GetTrackedComponents("Celeste.TileInterceptor");
            for (int index = components.Count - 1; index >= 0; index--)
            {
                var candidate = (TileInterceptorState)components[index];
                if (interceptor == null || candidate.HighPriority)
                {
                    var entity = (ISourceEntityCollider)candidate.Entity;
                    if (entity.Collider != null && entity.Collider.Collide(at))
                    {
                        interceptor = candidate;
                        if (candidate.HighPriority)
                            break;
                    }
                }
            }

            if (interceptor != null)
            {
                var point = new IntPoint((int)((at.X - ((ISourceEntityPosition)interceptor.Entity).Position.X) / 8f),
                    (int)((at.Y - ((ISourceEntityPosition)interceptor.Entity).Position.Y) / 8f));
                interceptor.Intercepter(tile, at, point);
                return true;
            }

            return false;
        }
    }
}
