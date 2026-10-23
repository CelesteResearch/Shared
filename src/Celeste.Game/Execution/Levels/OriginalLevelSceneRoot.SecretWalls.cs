using Celeste.Simulation.Gameplay.Walls.Concealment;
using Celeste.Graphics.Geometry.TwoD.Camera;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISecretWallScene, ISourceCameraScene
    {
        global::Celeste.Graphics.Geometry.TwoD.Camera.CameraState ISecretWallScene.Camera => Camera;
        global::Celeste.Graphics.Geometry.TwoD.Camera.CameraState ISourceCameraScene.Camera => Camera;
        global::Celeste.Core.Collections.VirtualMap<char> ISecretWallScene.SolidsData => SolidsData;

        global::Celeste.Graphics.Content.Tiles.Autotiling.Autotiler ISecretWallScene.ForegroundAutotiler
            => ((global::Celeste.Graphics.Content.Tiles.Autotiling.ISourceAutotilingResources)EngineContext)
                .ForegroundAutotiler;

        public void AddDoNotLoad(global::Celeste.Core.Maps.MapEntityId entityId) => Session.DoNotLoad.Add(entityId);
    }
}
