using Celeste.Everest.Gameplay.Mathematics.Platforms;
using Celeste.Game.Gameplay.Mathematics.Platforms;
using Celeste.Game.Profiles;
using Celeste.Simulation.Gameplay.Platforms.FloatySpaceBlock;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceFloatySpaceEnvironment
    {
        private IFloatySpaceArithmetic sourceFloatySpaceArithmetic;

        public IFloatySpaceArithmetic FloatySpaceArithmetic => sourceFloatySpaceArithmetic ??=
            SourceProfile == GameProfile.Original
                ? (IFloatySpaceArithmetic)new OriginalFloatySpaceArithmetic()
                : new EverestFloatySpaceArithmetic();
    }
}
