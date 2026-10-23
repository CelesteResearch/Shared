using System.Collections.Generic;

namespace Celeste.Everest.Content.Maps.Metadata.Mountain
{
    public class MapMetaMountain
    {
        public string MountainModelDirectory { get; set; }

        public string MountainTextureDirectory { get; set; }

        public string BackgroundMusic { get; set; }

        public string BackgroundAmbience { get; set; }

        public Dictionary<string, float> BackgroundMusicParams { get; set; }

        public string[] FogColors { get; set; }

        public string StarFogColor { get; set; }

        public string[] StarStreamColors { get; set; }

        public string[] StarBeltColors1 { get; set; }

        public string[] StarBeltColors2 { get; set; }

        public MapMetaMountainCamera Idle { get; set; }

        public MapMetaMountainCamera Select { get; set; }

        public MapMetaMountainCamera Zoom { get; set; }

        public float[] Cursor { get; set; }

        public int State { get; set; }

        public bool Rotate { get; set; }

        public bool ShowCore { get; set; }

        public bool ShowSnow { get; set; } = true;

        public string MarkerTexture { get; set; }
    }
}
