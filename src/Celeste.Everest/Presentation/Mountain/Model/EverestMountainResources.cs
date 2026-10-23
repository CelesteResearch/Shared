using System.Collections.Generic;
using Celeste.Core.Display;
using Celeste.Formats.Graphics.Models;
using Celeste.Game.Presentation.Mountain.Model;
using Celeste.Graphics.Content.VirtualAssets;

namespace Celeste.Everest.Presentation.Mountain.Model
{
    public class EverestMountainResources
    {
        public ObjectModel MountainTerrain;

        public ObjectModel MountainBuildings;

        public ObjectModel MountainCoreWall;

        public ObjectModel MountainMoon;

        public ObjectModel MountainBird;

        public List<ObjectModel> MountainExtraModels = [];

        public VirtualTexture[] MountainTerrainTextures;

        public VirtualTexture[] MountainBuildingTextures;

        public VirtualTexture[] MountainSkyboxTextures;

        public List<VirtualTexture[]> MountainExtraModelTextures = [];

        public VirtualTexture MountainMoonTexture;

        public VirtualTexture MountainFogTexture;

        public VirtualTexture MountainSpaceTexture;

        public VirtualTexture MountainSpaceStarsTexture;

        public VirtualTexture MountainStarStreamTexture;

        public MountainState[] MountainStates = new MountainState[4];

        public PackedColor? StarFogColor;

        public PackedColor[] StarStreamColors;

        public PackedColor[] StarBeltColors1;

        public PackedColor[] StarBeltColors2;
    }
}
