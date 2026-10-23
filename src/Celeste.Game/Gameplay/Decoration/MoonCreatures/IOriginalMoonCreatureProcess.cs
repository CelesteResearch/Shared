using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Content;

namespace Celeste.Game.Gameplay.Decoration.MoonCreatures
{
    public interface IOriginalMoonCreatureProcess : ISourceEngineContext, ISourceEntitySourceDataEnvironment,
        ISourceVectorEnvironment, ISourceScalarEnvironment, ISourceExtremaEnvironment,
        ISourceRandomEnvironment, ISourceGameGraphicsEnvironment, IOriginalGameTagsEnvironment;
}
