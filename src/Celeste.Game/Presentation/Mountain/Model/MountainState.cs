using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Content.VirtualAssets;

namespace Celeste.Game.Presentation.Mountain.Model
{
    public class MountainState
    {
        public MountainSkybox Skybox;

        public VirtualTexture TerrainTexture;

        public VirtualTexture BuildingsTexture;

        public PackedColor FogColor;

        public MountainState(ISourceEngineContext engine, VirtualTexture terrainTexture,
            VirtualTexture buildingsTexture,
            VirtualTexture skyboxTexture, PackedColor fogColor)
        {
            TerrainTexture = terrainTexture;
            BuildingsTexture = buildingsTexture;
            Skybox = new(engine, skyboxTexture);
            FogColor = fogColor;
        }
    }
}
