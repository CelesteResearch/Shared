using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Graphics.Rendering;
using Celeste.Physics.Collision;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Presentation.Effects.Mirrors;
using Celeste.Simulation.Presentation.Lighting;

namespace Celeste.Game.Gameplay.Walls.Solids
{
    public class GlassBlockState : SourceSolidEntityState
    {
        public readonly bool Sinks;
        public readonly float StartY;
        public readonly List<(Vector2 A, Vector2 B)> Lines = [];
        public PackedColor LineColor = PackedColor.White;


        public GlassBlockState(Vector2 position, float width, float height, bool sinks, ISourceSolidWorld world)
            : base(position, width, height, false, world)
        {
            Sinks = sinks;
            StartY = Y;
            Depth = -10000;
            OwnedComponents.Add(new LightOccludeState());
            OwnedComponents.Add(
                new MirrorSurfaceState(((ISourceExtremaEnvironment)SourceWorld.EngineContext).ExtremaArithmetic));
            SurfaceSoundIndex = 32;
        }

        private float Mod(float x, float m)
        {
            return (x % m + m) % m;
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            ComputeLines();
        }

        protected void ComputeLines()
        {
            int width = (int)Width / 8, height = (int)Height / 8;
            AddSide(Vector2.Zero, new(0, -1), width);
            AddSide(new(width - 1, 0), Vector2.UnitX, height);
            AddSide(new(width - 1, height - 1), Vector2.UnitY, width);
            AddSide(new(0, height - 1), -Vector2.UnitX, height);
        }

        private bool CollidePoint(string trackedType, Vector2 point)
        {
            var entities = ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(trackedType);
            for (var i = 0; i < entities.Count; i++)
            {
                var entity = (ISourceEntityCollider)entities[i];
                if (entity.Collidable && entity.Collider != null && entity.Collider.Collide(point)) return true;
            }

            return false;
        }

        protected virtual bool Open(Vector2 tile)
        {
            var point = new Vector2(X + tile.X * 8f + 4f, Y + tile.Y * 8f + 4f);
            if (!CollidePoint("Celeste.SolidTiles", point)) return !CollidePoint("Celeste.GlassBlock", point);
            return false;
        }

        protected virtual Vector2 OutlineOffset(Vector2 normal)
        {
            return normal;
        }

        private void AddSide(Vector2 start, Vector2 normal, int tiles)
        {
            var along = new Vector2(-normal.Y, normal.X);
            for (var i = 0; i < tiles; i++)
            {
                if (!Open(start + along * i + normal)) continue;
                var from = (start + along * i) * 8f + new Vector2(4f) - along * 4f + normal * 4f;
                if (!Open(start + along * (i - 1))) from -= along;
                while (i < tiles && Open(start + along * i + normal)) i++;
                var to = (start + along * i) * 8f + new Vector2(4f) - along * 4f + normal * 4f;
                if (!Open(start + along * i)) to += along;
                var outlineOffset = OutlineOffset(normal);
                Lines.Add((from + outlineOffset, to + outlineOffset));
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            foreach (var line in Lines)
                SourcePrimitiveDrawing.Line(context, this, Position + line.A, Position + line.B, LineColor,
                    ((ISourceVectorEnvironment)SourceWorld.EngineContext).VectorArithmetic);
        }
    }
}
