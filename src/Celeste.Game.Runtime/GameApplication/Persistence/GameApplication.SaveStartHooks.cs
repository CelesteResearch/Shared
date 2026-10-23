using System;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.Runtime;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalSaveStartSourceHooksEnvironment
    {
        public event Action<OriginalSaveDataState> SourceSaveStartReturned;

        void IOriginalSaveStartSourceHooksEnvironment.AfterSourceSaveStart(OriginalSaveDataState actualSave)
            => SourceSaveStartReturned?.Invoke(actualSave);
    }
}
