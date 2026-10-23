using Celeste.Everest.UI.Controls;
using Celeste.Game.Menus.Controls;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalControlConfigEnvironment
    {
        private readonly IOriginalControlConfigFactory controlConfigs;

        IOriginalControlConfigFactory IOriginalControlConfigEnvironment.ControlConfigs => controlConfigs;

        private static IOriginalControlConfigFactory CreateControlConfigs(GameProfile profile) =>
            profile == GameProfile.Original
                ? new OriginalControlConfigFactory()
                : new EverestControlConfigFactory();
    }
}
