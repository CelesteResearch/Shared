using System.Numerics;
using Celeste.Core.Collections;
using Celeste.Core.Geometry;
using Celeste.Core.Maps;
using Celeste.Graphics.Content.Tiles.Autotiling;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Scene.Tracking;

namespace Celeste.Simulation.Gameplay.Walls.Concealment
{
    public interface ISecretWallScene : ISourceScene
    {
        IntRect Bounds { get; }
        IntRect? PreviousBounds { get; }
        Vector2 ShakeVector { get; }
        CameraState Camera { get; }
        IntRect TileBounds { get; }
        VirtualMap<char> SolidsData { get; }
        Autotiler ForegroundAutotiler { get; }
        void AddDoNotLoad(MapEntityId entityId);
    }
}
