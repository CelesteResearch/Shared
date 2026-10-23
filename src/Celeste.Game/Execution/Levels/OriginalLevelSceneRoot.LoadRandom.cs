using Celeste.Core.Randomness;
using Celeste.Game.Content.Maps.Levels;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        private void PushSourceRoomRandom()
        {
            ((ISourceRandomProcessEnvironment)EngineContext).RandomProcess.PushRandom(
                ((OriginalLevelRoomData)Session.LevelData).LoadSeed);
        }

        private void PopSourceRoomRandom()
        {
            ((ISourceRandomProcessEnvironment)EngineContext).RandomProcess.PopRandom();
        }
    }
}
