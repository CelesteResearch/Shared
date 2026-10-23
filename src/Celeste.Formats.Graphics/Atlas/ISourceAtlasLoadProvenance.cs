using Celeste.Graphics.Content.Atlas;

namespace Celeste.Formats.Graphics.Atlas
{
    public interface ISourceAtlasLoadProvenance
    {
        void PublishProvenance(AtlasData atlas, string method, string path, string[] paths, AtlasDataFormat? format);
    }
}
