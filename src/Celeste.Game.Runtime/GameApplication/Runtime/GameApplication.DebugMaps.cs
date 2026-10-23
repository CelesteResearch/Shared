using Celeste.Everest.Editor;
using Celeste.Game.Editor;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalMapEditorEnvironment,
        IOriginalMapEditorConstructionEnvironment
    {
        private MapEditorProcessState sourceMapEditorProcess;
        private IOriginalMapEditorConstruction sourceMapEditors;

        public MapEditorProcessState MapEditorProcess => sourceMapEditorProcess ??=
            SourceProfile == GameProfile.Original
                ? new OriginalMapEditorProcessState(this)
                : new EverestMapEditorProcessState(this);

        public IOriginalMapEditorConstruction MapEditors => sourceMapEditors ??=
            SourceProfile == GameProfile.Original
                ? new OriginalMapEditorConstruction()
                : new EverestMapEditorConstruction();
    }
}
