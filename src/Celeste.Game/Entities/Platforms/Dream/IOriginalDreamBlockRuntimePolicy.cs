using Celeste.Core.Display;
using Celeste.Core.Randomness;
using Celeste.Graphics.Display;
using System.Numerics;
using Celeste.Core.Components.Animation;

namespace Celeste.Game.Entities.Platforms.Dream
{
    public interface IOriginalDreamBlockRuntimePolicy
    {
        int ChooseLayer(ISourceRandom random);
        PackedColor ChooseColor(ISourceRandom random, PackedColor first, PackedColor second, PackedColor third);
        int GetParticleCount(OriginalDreamBlockState actual);
        Vector2 PutInside(OriginalDreamBlockState actual, Vector2 position);
        void MoveNode(OriginalDreamBlockState actual, Vector2 start, Vector2 end, SourceTweenState tween);
    }
}
