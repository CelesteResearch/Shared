using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Processes;
using Celeste.Scene.Entities;
using Celeste.Scene.Scheduling.ExecutionTags;
using Celeste.Scene.Tracking;
using Celeste.Simulation;

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
            var num = 1150;
            var num2 = 2832;
            var entity =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);

            if (entity != null && ((IOriginalGameplayProcess)engine).AudioSession.CurrentMusic ==
                "event:/music/lvl2/chase")
            {
                var value = (entity.X - num) / (num2 - num);
                ((IOriginalGameplayProcess)engine).AudioSession.SetMusicParam("escape", value);
            }
        }
    }
}
