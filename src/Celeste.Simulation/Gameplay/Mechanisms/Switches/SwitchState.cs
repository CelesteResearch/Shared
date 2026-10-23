using System;

namespace Celeste.Simulation.Gameplay.Mechanisms.Switches
{
    public sealed class SwitchState
    {
        public readonly SwitchGroupState Group;
        public bool GroundReset;
        public Action OnActivate, OnDeactivate, OnFinish, OnStartFinished;
        public bool Activated { get; private set; }
        public bool Finished { get; private set; }

        public SwitchState(SwitchGroupState group,
            bool groundReset)
        {
            Group = group;
            GroundReset = groundReset;
        }

        public void Attach()
        {
            Group.Switches.Add(this);
            if (Group.CheckLevelFlag()) StartFinished();
        }

        public void Detach()
        {
            Group.Switches.Remove(this);
        }

        public void Update()
        {
            if (GroundReset && Activated && !Finished && (Group.PlayerOnGround?.Invoke() ?? false)) Deactivate();
        }

        public bool Activate()
        {
            if (!Finished && !Activated)
            {
                Activated = true;
                OnActivate?.Invoke();
                return Group.FinishedCheck();
            }

            return false;
        }

        public void Deactivate()
        {
            if (!Finished && Activated)
            {
                Activated = false;
                OnDeactivate?.Invoke();
            }
        }

        public void Finish()
        {
            Finished = true;
            OnFinish?.Invoke();
        }

        public void StartFinished()
        {
            if (!Finished)
            {
                Activated = Finished = true;
                OnStartFinished?.Invoke();
            }
        }
    }
}
