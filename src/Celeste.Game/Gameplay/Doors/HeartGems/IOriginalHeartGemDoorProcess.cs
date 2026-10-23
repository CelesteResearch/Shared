using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Content;
using Celeste.Input.Gameplay.Feedback;

namespace Celeste.Game.Gameplay.Doors.HeartGems
{
    public interface IOriginalHeartGemDoorProcess : ISourceEngineContext,
        IOriginalGameplayProcess, ISourceGameGraphicsEnvironment, ISourceRandomEnvironment,
        ISourceScalarEnvironment, ISourceExtremaEnvironment, ISourceRumbleEnvironment,
        ISourceFreezeEnvironment, ISourceRenderEnvironment, ISourceEasingEnvironment,
        ISourceEntitySourceDataEnvironment;
}
