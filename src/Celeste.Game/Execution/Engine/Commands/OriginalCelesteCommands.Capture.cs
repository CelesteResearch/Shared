using Celeste.Framework.Diagnostics.Commands;
using Celeste.Game.Gameplay.Tutorials.Playback;
using Celeste.Simulation;

namespace Celeste.Game.Execution.Engine.Commands
{
    public static partial class OriginalCelesteCommands
    {
        [SourceCommand("capture", "capture the last ~200 frames of player movement to a file")]
        private static void CmdCapture(string filename)
        {
            var player =
                Scene.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);

            if (player != null)
                OriginalPlaybackData.Export(player.ChaserStates, filename + ".bin");
        }
    }
}
