using System.Numerics;
using Celeste.Core.Collections;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Simulation.Gameplay.Environment.Core;

namespace Celeste.Simulation.Presentation.Environment.Ice
{
    public interface IIceTileOverlayScene
    {
        CameraState Camera { get; }
        RoomCoreMode CoreMode { get; }
        Vector2 SolidTilesPosition { get; }
        VirtualMap<char> SolidsData { get; }
    }
}
