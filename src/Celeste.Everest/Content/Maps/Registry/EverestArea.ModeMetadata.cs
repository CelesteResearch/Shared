using Celeste.Everest.Content.Maps.Metadata;

namespace Celeste.Everest.Content.Maps.Registry
{
    public sealed partial class EverestArea
    {
        public EverestMapMetadata GetModeMeta(int mode)
        {
            var metadata = ((EverestAreaModeData)Mode[mode])?.MapMeta;
            if (metadata != null && mode != 0 && metadata.OverrideASideMeta == true)
                return metadata;
            return Metadata;
        }
    }
}
