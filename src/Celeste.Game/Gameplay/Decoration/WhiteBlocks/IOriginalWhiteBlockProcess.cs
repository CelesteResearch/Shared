using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Content;

namespace Celeste.Game.Gameplay.Decoration.WhiteBlocks
{
    public interface IOriginalWhiteBlockProcess : ISourceEngineContext, ISourceGameGraphicsEnvironment
    {
        void PlaySound(string eventName, Vector2 position);
    }
}
