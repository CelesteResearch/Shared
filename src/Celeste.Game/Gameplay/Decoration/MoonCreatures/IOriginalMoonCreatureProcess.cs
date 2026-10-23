using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Graphics.Content;
using Celeste.Game.Execution.Startup;

namespace Celeste.Game.Gameplay.Decoration.MoonCreatures
{
    public interface IOriginalMoonCreatureProcess : ISourceEngineContext, ISourceEntitySourceDataEnvironment,
        ISourceVectorEnvironment, ISourceScalarEnvironment, ISourceExtremaEnvironment,
        ISourceRandomEnvironment, ISourceGameGraphicsEnvironment, IOriginalGameTagsEnvironment
    {
    }
}
