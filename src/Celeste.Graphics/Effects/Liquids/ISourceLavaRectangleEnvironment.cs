using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Primitives;

namespace Celeste.Graphics.Effects.Liquids
{
    public interface ISourceLavaRectangleEnvironment : ISourceEngineContext,
        ISourceRandomEnvironment, ISourceScalarEnvironment, ISourceVectorEnvironment,
        ISourceExtremaEnvironment, ISourceGameplayBatchScopeEnvironment
    {
        ILiquidWavePresentationPolicy LiquidWavePolicy { get; }
        ISourceLavaRectangleSizeArithmetic LavaRectangleSizeArithmetic { get; }
        AtlasData LiquidAtlas { get; }
        ISourcePrimitiveGraphicsDevice PrimitiveGraphics { get; }
    }
}
