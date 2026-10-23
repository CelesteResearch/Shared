using System.Numerics;
using Celeste.Game.Entities.Lookouts;
using Celeste.Graphics.Animation;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalLookoutProcess
    {
        ISpriteFactory IOriginalLookoutProcess.SpriteBank => GraphicsResources.SpriteFactory;

        void IOriginalLookoutProcess.PlaySound(string eventName, Vector2 position)
        {
            AudioSession.Play(eventName, position, SaveContext);
        }

        void IOriginalLookoutProcess.SetMusicParam(string name, float value)
        {
            AudioSession.SetMusicParam(name, value);
        }
    }
}
