using Celeste.Input;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Input.Gameplay
{
    public sealed class GameInput
    {
        private readonly List<VirtualInput> orderedInputs = new List<VirtualInput>();
        private readonly Dictionary<GameAction, VirtualButton> buttons = new Dictionary<GameAction, VirtualButton>();
        private bool grabToggle;
        public readonly InputContext Context;
        public VirtualIntegerAxis MoveX { get; private set; }
        public VirtualIntegerAxis MoveY { get; private set; }
        public VirtualIntegerAxis GliderMoveY { get; private set; }
        public VirtualJoystick Aim { get; private set; }
        public VirtualJoystick Feather { get; private set; }
        public VirtualJoystick MountainAim { get; private set; }
        public readonly AimResolver AimResolver = new AimResolver();
        public GrabMode GrabMode;
        public CrouchDashMode CrouchDashMode;
        public VirtualButton this[GameAction action] => buttons[action];
        public VirtualButton Jump => this[GameAction.Jump];
        public VirtualButton Dash => this[GameAction.Dash];
        public VirtualButton CrouchDash => this[GameAction.CrouchDash];
        public VirtualButton Grab => this[GameAction.Grab];

        public bool GrabCheck => GrabMode == GrabMode.Invert ? !Grab.Check :
            GrabMode == GrabMode.Toggle ? grabToggle : Grab.Check;

        public bool DashPressed =>
            CrouchDashMode == CrouchDashMode.Hold ? Dash.Pressed && !CrouchDash.Check : Dash.Pressed;

        public bool CrouchDashPressed => CrouchDashMode == CrouchDashMode.Hold
            ? Dash.Pressed && CrouchDash.Check
            : CrouchDash.Pressed;

        public GameInput(InputContext context,
            IReadOnlyDictionary<GameAction, IInputBinding> bindings, int gamepadIndex = 0)
        {
            Context = context ?? throw new System.ArgumentNullException(nameof(context));
            Initialize(bindings, gamepadIndex);
        }

        // Original Input.Initialize replaces virtual inputs but retains static
        // grab-toggle/LastAim state and derives all horizontal inversion from MoveX.
        public void Initialize(IReadOnlyDictionary<GameAction, IInputBinding> bindings, int gamepadIndex = 0)
        {
            bool inverted = MoveX?.Inverted ?? false;
            orderedInputs.Clear();
            buttons.Clear();
            var empty = new DigitalBinding();
            IInputBinding B(GameAction action) => bindings.TryGetValue(action, out var value) ? value : empty;

            T Register<T>(T input) where T : VirtualInput
            {
                input.Context = Context;
                orderedInputs.Add(input);
                return input;
            }

            MoveX = Register(new VirtualIntegerAxis(B(GameAction.Left), B(GameAction.LeftMoveOnly), B(GameAction.Right),
                B(GameAction.RightMoveOnly), gamepadIndex, .3f));
            MoveY = Register(new VirtualIntegerAxis(B(GameAction.Up), B(GameAction.UpMoveOnly), B(GameAction.Down),
                B(GameAction.DownMoveOnly), gamepadIndex, .7f));
            GliderMoveY = Register(new VirtualIntegerAxis(B(GameAction.Up), B(GameAction.UpMoveOnly),
                B(GameAction.Down), B(GameAction.DownMoveOnly), gamepadIndex, .3f));
            Aim = Register(new VirtualJoystick(B(GameAction.Up), B(GameAction.UpDashOnly), B(GameAction.Down),
                B(GameAction.DownDashOnly), B(GameAction.Left), B(GameAction.LeftDashOnly), B(GameAction.Right),
                B(GameAction.RightDashOnly), gamepadIndex, .25f));
            Feather = Register(new VirtualJoystick(B(GameAction.Up), B(GameAction.UpMoveOnly), B(GameAction.Down),
                B(GameAction.DownMoveOnly), B(GameAction.Left), B(GameAction.LeftMoveOnly), B(GameAction.Right),
                B(GameAction.RightMoveOnly), gamepadIndex, .25f));
            MoveX.Inverted = inverted;
            Aim.InvertedX = inverted;
            Feather.InvertedX = inverted;

            void Button(GameAction action, float buffer, float threshold)
            {
                buttons.Add(action, Register(new VirtualButton(B(action), gamepadIndex, buffer, threshold)));
            }

            Button(GameAction.Jump, .08f, .2f);
            Button(GameAction.Dash, .08f, .2f);
            Button(GameAction.Talk, .08f, .2f);
            Button(GameAction.Grab, 0, .2f);
            Button(GameAction.CrouchDash, .08f, .2f);
            MountainAim = Register(new VirtualJoystick(B(GameAction.MountainUp), B(GameAction.MountainDown),
                B(GameAction.MountainLeft), B(GameAction.MountainRight), gamepadIndex, .1f));
            Button(GameAction.Escape, .1f, .2f);
            Button(GameAction.Pause, .1f, .2f);
            Button(GameAction.QuickRestart, .1f, .2f);
            foreach (var action in new[]
                         { GameAction.MenuLeft, GameAction.MenuRight, GameAction.MenuUp, GameAction.MenuDown })
            {
                Button(action, 0, .4f);
                buttons[action].SetRepeat(.4f, .1f);
            }

            Button(GameAction.MenuJournal, 0, .2f);
            Button(GameAction.MenuConfirm, 0, .2f);
            Button(GameAction.MenuCancel, 0, .2f);
        }

        // Everest Input.Initialize replaces the vanilla MountainAim after every
        // module's OnInputInitialize, retaining the existing virtual-input order.
        public void OverrideMountainAim(IInputBinding up, IInputBinding down,
            IInputBinding left, IInputBinding right, int gamepadIndex)
        {
            var joystick = new VirtualJoystick(up, down, left, right, gamepadIndex, .1f);
            joystick.Context = Context;
            orderedInputs.Add(joystick);
            MountainAim = joystick;
        }

        public void Update(float deltaTime, bool disabled = false)
        {
            Context.DeltaTime = deltaTime;
            Context.Disabled = disabled;
            foreach (var input in orderedInputs) input.Update();
        }

        // Celeste.Update calls UpdateGrab after Engine.Update has finished updating the scene.
        public void EndFrame(GrabMode currentGrabMode)
        {
            if (currentGrabMode == GrabMode.Toggle && Grab.Pressed) grabToggle = !grabToggle;
        }

        public void ResetGrab() => grabToggle = false;

        public Vector2 GetAimVector(int facing = 1, bool dashAssist = false, bool fullCircle = false) =>
            AimResolver.Resolve(Aim.Value, facing, dashAssist, fullCircle);
    }
}
