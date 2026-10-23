using System.Numerics;
using Celeste.Core.Randomness;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation.Gameplay.Hazards.Spikes;
using Celeste.Simulation.Gameplay.Hazards.Spinners.Dust;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourceSpikeScene
    {
        string ISourceSpikeScene.SpikeType
        {
            get
            {
                var keys = ((IOriginalAreaKeyEnvironment)EngineContext).AreaKeys;
                return keys.GetArea(keys.GetSessionArea(Session)).Spike;
            }
        }

        Vector3[] ISourceSpikeScene.DustEdgeColors
            => ((ISourceDustStyleEnvironment)EngineContext).DustStyles.GetStyle(
                ((IOriginalAreaKeyEnvironment)EngineContext).AreaKeys.GetSessionArea(Session).ID).EdgeColors;

        ISourceRandom ISourceSpikeScene.SpikeRandom => ((ISourceRandomEnvironment)EngineContext).Random;

        void ISourceSpikeScene.PlaySpikeSound(string path, Vector2 position)
        {
            var process = (IOriginalGameplayProcess)EngineContext;
            process.AudioSession.Play(path, position, process.SaveContext);
        }
    }
}
