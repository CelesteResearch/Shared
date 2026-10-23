namespace Celeste.Input.Devices.Keyboard
{
    public class SourceKeyboardData : ISourceCommandsKeyboard
    {
        private readonly SourceFnaKeyboardStateProcess keyboard;
        private readonly ISourceKeyboardDisabledEnvironment environment;

        SourceKeyboardState ISourceCommandsKeyboard.CurrentState
        {
            get => CurrentState;
            set => CurrentState = value;
        }

        public SourceKeyboardState PreviousState;

        public SourceKeyboardState CurrentState;

        public SourceKeyboardData(SourceFnaKeyboardStateProcess keyboard,
            ISourceKeyboardDisabledEnvironment environment)
        {
            this.keyboard = keyboard;
            this.environment = environment;
        }

        public void Update()
        {
            PreviousState = CurrentState;
            CurrentState = keyboard.GetState();
        }

        public void UpdateNull()
        {
            PreviousState = CurrentState;
            CurrentState = default;
            CurrentState.GetPressedKeys();
        }

        public bool HasAnyInput()
        {
            return CurrentState.GetPressedKeys().Length != 0;
        }

        public virtual bool Check(SourceKeys key)
        {
            if (environment.Disabled) return false;

            if (key != SourceKeys.None) return CurrentState.IsKeyDown(key);

            return false;
        }

        public virtual bool Pressed(SourceKeys key)
        {
            if (environment.Disabled) return false;

            if (key != SourceKeys.None && CurrentState.IsKeyDown(key)) return !PreviousState.IsKeyDown(key);

            return false;
        }

        public virtual bool Released(SourceKeys key)
        {
            if (environment.Disabled) return false;

            if (key != SourceKeys.None && !CurrentState.IsKeyDown(key)) return PreviousState.IsKeyDown(key);

            return false;
        }

        public bool Check(SourceKeys keyA, SourceKeys keyB)
        {
            if (!Check(keyA)) return Check(keyB);

            return true;
        }

        public bool Pressed(SourceKeys keyA, SourceKeys keyB)
        {
            if (!Pressed(keyA)) return Pressed(keyB);

            return true;
        }

        public bool Released(SourceKeys keyA, SourceKeys keyB)
        {
            if (!Released(keyA)) return Released(keyB);

            return true;
        }

        public bool Check(SourceKeys keyA, SourceKeys keyB, SourceKeys keyC)
        {
            if (!Check(keyA) && !Check(keyB)) return Check(keyC);

            return true;
        }

        public bool Pressed(SourceKeys keyA, SourceKeys keyB, SourceKeys keyC)
        {
            if (!Pressed(keyA) && !Pressed(keyB)) return Pressed(keyC);

            return true;
        }

        public bool Released(SourceKeys keyA, SourceKeys keyB, SourceKeys keyC)
        {
            if (!Released(keyA) && !Released(keyB)) return Released(keyC);

            return true;
        }

        public int AxisCheck(SourceKeys negative, SourceKeys positive)
        {
            if (Check(negative))
            {
                if (Check(positive)) return 0;

                return -1;
            }

            if (Check(positive)) return 1;

            return 0;
        }

        public int AxisCheck(SourceKeys negative, SourceKeys positive, int both)
        {
            if (Check(negative))
            {
                if (Check(positive)) return both;

                return -1;
            }

            if (Check(positive)) return 1;

            return 0;
        }
    }
}
