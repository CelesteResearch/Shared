using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Gameplay.Platforms.Rotating
{
    public class OriginalRotatingPlatformState : SourceJumpThruEntityState
    {
        private const float RotateSpeed = (float)Math.PI / 3f;
        private Vector2 center;
        private bool clockwise;
        private float length;
        private float currentAngle;

        public OriginalRotatingPlatformState(Vector2 position, int width, Vector2 center, bool clockwise,
            ISourceSolidWorldFactory worlds)
            : base(position, width, false, worlds.CreateJumpThru(position, false))
        {
            Collider.Position.X = -width / 2;
            Collider.Position.Y = (0f - Height) / 2f;
            this.center = center;
            this.clockwise = clockwise;
            length = ((ISourceVectorEnvironment)SourceWorld.EngineContext).VectorArithmetic.Length(position - center);
            currentAngle = Vector2Geometry.Angle(position - center);
            SurfaceSoundIndex = 5;
            Add(new LightOccludeState(0.2f));
        }

        public override void Update()
        {
            base.Update();
            if (clockwise)
                currentAngle -= RotateSpeed * SourceWorld.EngineContext.DeltaTime;
            else
                currentAngle += RotateSpeed * SourceWorld.EngineContext.DeltaTime;
            currentAngle = ScalarMath.WrapAngle(currentAngle);
            MoveTo(center + Vector2Geometry.AngleToVector(currentAngle, length));
        }

        public override void Render(ISourceRenderContext context)
        {
            base.Render(context);
            SourcePrimitiveDrawing.Rect(context, this, Collider.AbsoluteLeft, Collider.AbsoluteTop,
                Collider.Width, Collider.Height, PackedColor.White);
        }
    }
}
