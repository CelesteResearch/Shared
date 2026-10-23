using System.Numerics;
using Celeste.Game.Gameplay.Decoration.MoonCreatures;
using Celeste.Game.Gameplay.Decoration.PowerSources;
using Celeste.Game.Gameplay.Decoration.SummitClouds;
using Celeste.Game.Gameplay.Decoration.WhiteBlocks;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalWhiteBlockProcess,
        IOriginalMoonCreatureProcess, IOriginalPowerSourceNumberProcess, IOriginalSummitCloudProcess,
        global::Celeste.Simulation.Gameplay.Tutorial.Replay.IPlayerPlaybackAudio
    {
        void global::Celeste.Simulation.Gameplay.Tutorial.Replay.IPlayerPlaybackAudio.Play(string eventPath,
            Vector2 position)
            => AudioSession.Play(eventPath, position, SaveContext);

        void IOriginalWhiteBlockProcess.PlaySound(string eventName, Vector2 position) =>
            AudioSession.Play(eventName, position, SaveContext);
    }
}
