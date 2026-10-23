using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Scene.Scheduling.ExecutionTags;
using Celeste.Simulation;
using Celeste.Game.Execution.Processes;

namespace Celeste.Game.Gameplay.Enemies.Badeline.Chasers
{
    public class OldSiteChaseMusicHandlerState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;

        public OldSiteChaseMusicHandlerState(ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Tags = ((ISourcePersistentTransitionExecutionTagsEnvironment)engine).PersistentTransitionExecutionTags
                   .TransitionUpdate.Value
                   | ((ISourceGlobalFrozenExecutionTagsEnvironment)engine).GlobalFrozenExecutionTags.Global.Value;
        }

        public override void Update()
        {
            base.Update();
            int num = 1150;
            int num2 = 2832;
            var entity =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

            if (entity != null && ((IOriginalGameplayProcess)engine).AudioSession.CurrentMusic ==
                "event:/music/lvl2/chase")
            {
                float value = (entity.X - num) / (num2 - num);
                ((IOriginalGameplayProcess)engine).AudioSession.SetMusicParam("escape", value);
            }
        }
    }
}
