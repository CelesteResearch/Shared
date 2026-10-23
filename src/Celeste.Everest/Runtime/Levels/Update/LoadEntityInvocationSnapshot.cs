using System;

namespace Celeste.Everest.Runtime.Levels.Update
{
    internal sealed class LoadEntityInvocationSnapshot
    {
        internal readonly EverestLevelUpdateEvents.LoadEntityHandler Handler;
        internal readonly Delegate[] InvocationList;

        internal LoadEntityInvocationSnapshot(EverestLevelUpdateEvents.LoadEntityHandler handler)
        {
            Handler = handler;
            InvocationList = handler.GetInvocationList();
        }
    }
}
