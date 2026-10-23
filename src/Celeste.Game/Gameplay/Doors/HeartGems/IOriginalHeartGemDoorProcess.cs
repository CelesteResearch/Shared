using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Graphics.Content;
using Celeste.Game.Execution.Processes;

namespace Celeste.Game.Gameplay.Doors.HeartGems
{
    public interface IOriginalHeartGemDoorProcess : ISourceEngineContext,
        IOriginalGameplayProcess, ISourceGameGraphicsEnvironment, ISourceRandomEnvironment,
        ISourceScalarEnvironment, ISourceExtremaEnvironment, ISourceRumbleEnvironment,
        ISourceFreezeEnvironment, ISourceRenderEnvironment, ISourceEasingEnvironment, ISourceEntitySourceDataEnvironment
    {
    }
}
