using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Graphics.Geometry.ThreeD.Camera;

namespace Celeste.Everest.Content.Maps.Metadata.Mountain
{
    public class MapMetaMountainCamera
    {
        public float[] Position { get; set; }
        public float[] Target { get; set; }

        public MountainCameraState Convert(ISourceVectorArithmetic arithmetic)
        {
            return new(Vector3ArrayConversion.ToVector3(Position) ?? Vector3.Zero,
                Vector3ArrayConversion.ToVector3(Target) ?? Vector3.Zero, arithmetic);
        }
    }
}
