using Celeste.Graphics.Rendering.Batches;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Text.Fonts;

namespace Celeste.Game.Execution.Graphics.Drawing
{
    public interface IOriginalDrawInitializationResources
    {
        SourceGraphicsDevice GraphicsDevice { get; }
        SourceSpriteBatchProcess SpriteBatchProcess { get; }
        SourceSpriteFont LoadDefaultSpriteFont(string assetName);
    }
}
