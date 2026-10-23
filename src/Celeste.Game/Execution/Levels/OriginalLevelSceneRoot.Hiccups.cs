using Celeste.Core.Randomness;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public ISourceRandom HiccupRandom;

        private void InitializeSourceHiccupRandom()
        {
            if (HiccupRandom == null)
                HiccupRandom =
                    ((ISourceRandomProcessEnvironment)EngineContext).RandomProcess.Factory.CreateSeeded(
                        Session.AreaID * 77 + Session.Mode * 999);
        }
    }
}
