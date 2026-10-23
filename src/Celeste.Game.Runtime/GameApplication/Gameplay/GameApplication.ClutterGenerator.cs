using Celeste.Core.Threading;
using Celeste.Game.Gameplay.Clutter.Generation;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceClutterGeneratorEnvironment,
        ISourceTypeInitializationFactory<ClutterBlockGeneratorState>
    {
        private readonly SourceTypeInitialization<ClutterBlockGeneratorState> sourceClutterGeneratorInitialization;

        public ClutterBlockGeneratorState ClutterGenerator => sourceClutterGeneratorInitialization.Value;

        private SourceTypeInitialization<ClutterBlockGeneratorState> CreateSourceClutterGeneratorInitialization()
        {
            return new("Celeste.ClutterBlockGenerator", this);
        }

        ClutterBlockGeneratorState ISourceTypeInitializationFactory<ClutterBlockGeneratorState>.Allocate()
        {
            return new(this,
                SourceProfile == GameProfile.Original
                    ? ClutterGeneratorInitializationProfile.Original
                    : ClutterGeneratorInitializationProfile.Installed);
        }

        void ISourceTypeInitializationFactory<ClutterBlockGeneratorState>.Initialize(
            ClutterBlockGeneratorState instance)
        {
            // The original static initializer only allocates active and enabled.
            // Those exact field initializers run in Allocate's existing state constructor.
            // Init(level), Add, Generate and Dispose remain at their original Level phases.
        }
    }
}
