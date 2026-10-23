using Celeste.Game.Execution.Areas;

namespace Celeste.Everest.Content.Maps.Metadata
{
    public partial class EverestMapMetadata
    {
        public static OriginalAreaModeData[] Convert(EverestModeMetadata[] metadata)
        {
            if (metadata == null) return null;
            OriginalAreaModeData[] result = new OriginalAreaModeData[metadata.Length];
            for (int i = 0; i < result.Length; i++) result[i] = metadata[i]?.Convert();
            return result;
        }

        public static OriginalCheckpointData[] Convert(EverestCheckpointMetadata[] metadata)
        {
            if (metadata == null) return null;
            OriginalCheckpointData[] result = new OriginalCheckpointData[metadata.Length];
            for (int i = 0; i < result.Length; i++) result[i] = metadata[i]?.Convert();
            return result;
        }
    }
}
