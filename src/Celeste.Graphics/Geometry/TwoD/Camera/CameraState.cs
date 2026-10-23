using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.LinearAlgebra;

namespace Celeste.Graphics.Geometry.TwoD.Camera
{
    public class CameraState : global::Celeste.Core.Geometry.ISourceCameraBounds,
        global::Celeste.Core.Rendering.Cameras.ISourceCommandsCamera
    {
        private readonly ISourceVectorArithmetic arithmetic;
        private Matrix4x4 matrix = Matrix4x4.Identity;
        private Matrix4x4 inverse = Matrix4x4.Identity;
        private bool changed;
        private Vector2 position = Vector2.Zero;
        private Vector2 zoom = Vector2.One;
        private Vector2 origin = Vector2.Zero;
        private float angle;
        public CameraViewport Viewport;

        global::Celeste.Core.Geometry.IntRect global::Celeste.Core.Rendering.Cameras.ISourceCommandsCamera.Viewport
            => new global::Celeste.Core.Geometry.IntRect(Viewport.X, Viewport.Y, Viewport.Width, Viewport.Height);

        public Matrix4x4 Matrix
        {
            get
            {
                if (changed) UpdateMatrices();
                return matrix;
            }
        }

        public Matrix4x4 Inverse
        {
            get
            {
                if (changed) UpdateMatrices();
                return inverse;
            }
        }

        public Vector2 Position
        {
            get => position;
            set
            {
                changed = true;
                position = value;
            }
        }

        public Vector2 Origin
        {
            get => origin;
            set
            {
                changed = true;
                origin = value;
            }
        }

        public float X
        {
            get => position.X;
            set
            {
                changed = true;
                position.X = value;
            }
        }

        public float Y
        {
            get => position.Y;
            set
            {
                changed = true;
                position.Y = value;
            }
        }

        public Vector2 ZoomVector => zoom;

        public float Zoom
        {
            get => zoom.X;
            set
            {
                changed = true;
                zoom.X = zoom.Y = value;
            }
        }

        public float Angle
        {
            get => angle;
            set
            {
                changed = true;
                angle = value;
            }
        }

        public float Left
        {
            get
            {
                if (changed) UpdateMatrices();
                return SourceVector2Math.Transform(Vector2.Zero, Inverse).X;
            }
            set
            {
                if (changed) UpdateMatrices();
                X = SourceVector2Math.Transform(Vector2.UnitX * value, Matrix).X;
            }
        }

        public float Right
        {
            get
            {
                if (changed) UpdateMatrices();
                return SourceVector2Math.Transform(Vector2.UnitX * Viewport.Width, Inverse).X;
            }
            set => throw new NotImplementedException();
        }

        public float Top
        {
            get
            {
                if (changed) UpdateMatrices();
                return SourceVector2Math.Transform(Vector2.Zero, Inverse).Y;
            }
            set
            {
                if (changed) UpdateMatrices();
                Y = SourceVector2Math.Transform(Vector2.UnitY * value, Matrix).Y;
            }
        }

        public float Bottom
        {
            get
            {
                if (changed) UpdateMatrices();
                return SourceVector2Math.Transform(Vector2.UnitY * Viewport.Height, Inverse).Y;
            }
            set => throw new NotImplementedException();
        }

        // The parameterless original constructor reads its actual Engine dimensions.
        // A neutral model receives that capability explicitly, never a static host.
        public CameraState(ICameraViewportDimensions engineViewport, ISourceVectorArithmetic arithmetic)
            : this((engineViewport ?? throw new ArgumentNullException(nameof(engineViewport))).Width,
                engineViewport.Height, arithmetic)
        {
        }

        public CameraState(int width, int height, ISourceVectorArithmetic arithmetic)
        {
            this.arithmetic = arithmetic ?? throw new ArgumentNullException(nameof(arithmetic));
            Viewport = default;
            Viewport.Width = width;
            Viewport.Height = height;
            UpdateMatrices();
        }

        public override string ToString()
            => "Camera:\n\tViewport: { " + Viewport.X + ", " + Viewport.Y + ", " + Viewport.Width + ", " +
               Viewport.Height
               + " }\n\tPosition: { " + position.X + ", " + position.Y + " }\n\tOrigin: { " + origin.X + ", " + origin.Y
               + " }\n\tZoom: { " + zoom.X + ", " + zoom.Y + " }\n\tAngle: " + angle;

        public void UpdateMatrices()
        {
            Matrix4x4 identity = Matrix4x4.Identity;
            Vector2 floorPosition = new Vector2((int)Math.Floor(position.X), (int)Math.Floor(position.Y));
            matrix = SourceMatrixMath.Multiply(
                SourceMatrixMath.Multiply(
                    SourceMatrixMath.Multiply(
                        SourceMatrixMath.Multiply(identity,
                            SourceMatrixMath.CreateTranslation(new Vector3(
                                -floorPosition.X, -floorPosition.Y, 0f))),
                        SourceMatrixMath.CreateRotationZ(angle)),
                    SourceMatrixMath.CreateScale(zoom.X, zoom.Y, 1f)),
                SourceMatrixMath.CreateTranslation(new Vector3(
                    new Vector2((int)Math.Floor(origin.X), (int)Math.Floor(origin.Y)), 0f)));
            inverse = SourceMatrixMath.Invert(matrix);
            changed = false;
        }

        public void CopyFrom(CameraState other)
        {
            position = other.position;
            origin = other.origin;
            angle = other.angle;
            zoom = other.zoom;
            changed = true;
        }

        public void CenterOrigin()
        {
            origin = new Vector2((float)Viewport.Width / 2f, (float)Viewport.Height / 2f);
            changed = true;
        }

        public void RoundPosition()
        {
            position.X = (float)Math.Round(position.X);
            position.Y = (float)Math.Round(position.Y);
            changed = true;
        }

        public Vector2 ScreenToCamera(Vector2 value) => SourceVector2Math.Transform(value, Inverse);
        public Vector2 CameraToScreen(Vector2 value) => SourceVector2Math.Transform(value, Matrix);

        public void Approach(Vector2 value, float ease)
            => Position += (value - Position) * ease;

        public void Approach(Vector2 value, float ease, float maxDistance)
        {
            Vector2 vector = (value - Position) * ease;
            if (arithmetic.Length(vector) > maxDistance)
                Position += arithmetic.Normalize(vector) * maxDistance;
            else Position += vector;
        }
    }
}
