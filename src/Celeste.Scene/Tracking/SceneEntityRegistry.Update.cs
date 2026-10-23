using Celeste.Core.Components;
using Celeste.Core.Framework.Timing;
using Celeste.Core.Scheduling;

namespace Celeste.Scene.Tracking
{
    public sealed partial class SceneEntityRegistry
    {
        public void Update(ISourceEngineContext engine)
        {
            var diagnostics = SourceFrameDiagnostics.Current;
            long updateStarted = 0;
            var measuringUpdate = diagnostics?.BeginSceneEntityUpdate(out updateStarted) ?? false;
            var measuringTypes = diagnostics?.BeginEntityUpdateTypePass() ?? false;
            try
            {
                var events = trackerScene != null && trackerScene.Policy.EntityUpdateEvents;
                foreach (var entity in entities)
                {
                    if (events) ((ISourceEntityUpdate)entity).BeforeEntityUpdate();
                    if (((ISourceEntityUpdate)entity).Active)
                    {
                        if (!measuringTypes)
                        {
                            ((ISourceEntityUpdate)entity).Update();
                        }
                        else
                        {
                            var slot = -1;
                            long entityStarted = 0;
                            var measuringEntity = diagnostics.BeginEntityUpdateType(entity,
                                out slot, out entityStarted);
                            try
                            {
                                ((ISourceEntityUpdate)entity).Update();
                            }
                            finally
                            {
                                if (measuringEntity) diagnostics.EndEntityUpdateType(slot, entityStarted);
                            }
                        }
                    }

                    if (events) ((ISourceEntityUpdate)entity).AfterEntityUpdate();
                }
            }
            finally
            {
                if (measuringTypes) diagnostics.EndEntityUpdateTypePass();
                if (measuringUpdate) diagnostics.EndSceneEntityUpdate(updateStarted);
            }
        }
    }
}
