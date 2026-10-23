using Celeste.Core.Scheduling;
using Celeste.Game.Profiles;
using Celeste.Graphics.Content;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;

namespace Celeste.Game.Presentation.Effects.MagicGlow
{
    public interface ISourceMagicGlowEnvironment : ISourceEngineContext,
        IGameProfileEnvironment, ISourceGameGraphicsEnvironment,
        ISourceGraphicsDeviceEnvironment, ISourceDrawScope
    {
    }
}
