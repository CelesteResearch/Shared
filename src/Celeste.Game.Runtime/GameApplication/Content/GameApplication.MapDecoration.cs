using System.Numerics;
using Celeste.Game.Gameplay.Decoration.MoonCreatures;
using Celeste.Game.Gameplay.Decoration.PowerSources;
using Celeste.Game.Gameplay.Decoration.SummitClouds;
using Celeste.Game.Gameplay.Decoration.WhiteBlocks;
using Celeste.Simulation.Gameplay.Tutorial.Replay;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalWhiteBlockProcess,
        IOriginalMoonCreatureProcess, IOriginalPowerSourceNumberProcess, IOriginalSummitCloudProcess,
        IPlayerPlaybackAudio
    {
        void IPlayerPlaybackAudio.Play(string eventPath,
            Vector2 position)
        {
            AudioSession.Play(eventPath, position, SaveContext);
        }

        void IOriginalWhiteBlockProcess.PlaySound(string eventName, Vector2 position)
        {
            AudioSession.Play(eventName, position, SaveContext);
        }
    }
}
