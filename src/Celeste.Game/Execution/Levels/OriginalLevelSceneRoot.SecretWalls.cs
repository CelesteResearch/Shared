using Celeste.Core.Collections;
using Celeste.Core.Maps;
using Celeste.Graphics.Content.Tiles.Autotiling;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Simulation.Gameplay.Walls.Concealment;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISecretWallScene, ISourceCameraScene
    {
        CameraState ISecretWallScene.Camera => Camera;
        CameraState ISourceCameraScene.Camera => Camera;
        VirtualMap<char> ISecretWallScene.SolidsData => SolidsData;

        Autotiler ISecretWallScene.ForegroundAutotiler
            => ((ISourceAutotilingResources)EngineContext)
                .ForegroundAutotiler;

        public void AddDoNotLoad(MapEntityId entityId)
        {
            Session.DoNotLoad.Add(entityId);
        }
    }
}
