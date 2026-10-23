using System;
using Celeste.Core.Components;
using Celeste.Game.Execution.Levels;
using Celeste.Scene.Components;
using Celeste.Simulation;

namespace Celeste.Game.Components.Switches
{
    public class OriginalSwitchComponent : SourceComponentState
    {
        public bool GroundReset;
        public Action OnActivate;
        public Action OnDeactivate;
        public Action OnFinish;
        public Action OnStartFinished;
        public bool Activated { get; private set; }
        public bool Finished { get; private set; }

        public OriginalSwitchComponent(bool groundReset) : base(true, false)
        {
            GroundReset = groundReset;
        }

        public override void EntityAdded(object scene)
        {
            base.EntityAdded(scene);
            if (CheckLevelFlag((OriginalLevelSceneRoot)Scene)) StartFinished();
        }

        public override void Update()
        {
            base.Update();
            if (!(GroundReset && Activated && !Finished))
                return;
            var players =
                ((OriginalLevelSceneRoot)Scene).SourceScene.Entities.GetTrackedEntities(
                    typeof(RoomPlayerSession).FullName);
            var player = players.Count == 0 ? null : players[0] as RoomPlayerSession;
            if (player != null && player.OnGround()) Deactivate();
        }

        public bool Activate()
        {
            if (!Finished && !Activated)
            {
                Activated = true;
                if (OnActivate != null) OnActivate();
                return FinishedCheck((OriginalLevelSceneRoot)Scene);
            }

            return false;
        }

        public void Deactivate()
        {
            if (!(!Finished && Activated))
                return;
            Activated = false;
            if (OnDeactivate != null) OnDeactivate();
        }

        public void Finish()
        {
            Finished = true;
            if (OnFinish != null) OnFinish();
        }

        public void StartFinished()
        {
            if (!!Finished)
                return;
            var finished = Activated = true;
            Finished = finished;
            if (OnStartFinished != null) OnStartFinished();
        }

        public static bool Check(object scene)
        {
            return ((SceneComponentTracker)((ISourceComponentIndexScene)scene).ComponentIndex)
                .GetTrackedComponent<OriginalSwitchComponent>("Celeste.Switch")?.Finished ?? false;
        }

        private static bool FinishedCheck(OriginalLevelSceneRoot level)
        {
            foreach (OriginalSwitchComponent component in level.SourceScene.Components.GetTrackedComponents(
                         "Celeste.Switch"))
                if (!component.Activated)
                    return false;

            foreach (OriginalSwitchComponent component in level.SourceScene.Components.GetTrackedComponents(
                         "Celeste.Switch"))
                component.Finish();

            return true;
        }

        public static bool CheckLevelFlag(OriginalLevelSceneRoot level)
        {
            return level.Session.GetFlag("switches_" + level.Session.Level);
        }

        public static void SetLevelFlag(OriginalLevelSceneRoot level)
        {
            level.Session.SetFlag("switches_" + level.Session.Level);
        }
    }
}
