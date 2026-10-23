using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Scene;
using Celeste.Game.Gameplay.Tutorials.Playback;
using Celeste.Framework.Diagnostics.Commands;

namespace Celeste.Game.Execution.Engine.Commands
{
    public static partial class OriginalCelesteCommands
    {
        [SourceCommandAttribute("capture", "capture the last ~200 frames of player movement to a file")]
        private static void CmdCapture(string filename)
        {
            var player =
                Scene.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

            if (player != null)
                OriginalPlaybackData.Export(player.ChaserStates, filename + ".bin");
        }
    }
}
