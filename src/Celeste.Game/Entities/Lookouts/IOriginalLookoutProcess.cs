using System.Numerics;
using Celeste.Game.Components.Talking;
using Celeste.Graphics.Animation;
using Celeste.Core.Mathematics;

namespace Celeste.Game.Entities.Lookouts
{
    public interface IOriginalLookoutProcess : IOriginalTalkProcess
    {
        ISourceScalarArithmetic ScalarArithmetic { get; }
        ISourceVectorArithmetic VectorArithmetic { get; }
        ISourceCurveArithmetic CurveArithmetic { get; }
        ISpriteFactory SpriteBank { get; }
        void PlaySound(string eventName, Vector2 position);
        void SetMusicParam(string name, float value);
    }
}
