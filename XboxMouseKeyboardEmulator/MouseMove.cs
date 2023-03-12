using SharpDX.XInput;
using WindowsInput;

namespace XboxMouseKeyboardEmulator
{
    public class MouseMove : IMouse
    {
        private IMouseSimulator _mouseSimulator;
        private GamepadButtonFlags _flag;

        private const int MovementDivider = 1_000;
        private const int ScrollDivider = 10_000;

        public MouseMove(GamepadButtonFlags flag)
        {
            _mouseSimulator = new InputSimulator().Mouse;
            _flag = flag;
        }

        public void Update(State state)
        {
            if (state.Gamepad.Buttons.HasFlag(_flag))
            {
                var x = state.Gamepad.RightThumbX / ScrollDivider;
                var y = state.Gamepad.RightThumbY / ScrollDivider;
                _mouseSimulator.HorizontalScroll(x);
                _mouseSimulator.VerticalScroll(y);
            }
            else
            {
                var x = state.Gamepad.RightThumbX / MovementDivider;
                var y = state.Gamepad.RightThumbY / MovementDivider;
                _mouseSimulator.MoveMouseBy(x, -y);
            }
        }
    }
}
