using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.LinearAlgebra;

namespace Celeste.Graphics.Geometry.ThreeD.Camera
{
    public struct MountainCameraState
    {
        public Vector3 Position;
        public Vector3 Target;
        public Quaternion Rotation;

        public MountainCameraState(Vector3 position, Vector3 target, ISourceVectorArithmetic arithmetic)
        {
            Position = position;
            Target = target;
            Rotation = SourceQuaternionMath.LookAt(Position, Target, Vector3.UnitY, arithmetic);
        }

        public void LookAt(Vector3 target, ISourceVectorArithmetic arithmetic)
        {
            Target = target;
            Rotation = SourceQuaternionMath.LookAt(Position, Target, Vector3.UnitY, arithmetic);
        }
    }
}
