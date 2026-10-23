using Celeste.Graphics.Animation;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Graphics.Content
{
    public interface ISourceGameGraphicsResources
    {
        AtlasData GameAtlas { get; }
        ISpriteFactory SpriteFactory { get; }
    }
}
