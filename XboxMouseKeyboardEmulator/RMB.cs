using SharpDX.XInput;
using WindowsInput;

namespace XboxMouseKeyboardEmulator
{
    internal class RMB : IMouse
    {
        private IMouseSimulator _mouseSimulator;
        private GamepadButtonFlags _flag;

        private bool _wasButtonDown;

        public RMB(GamepadButtonFlags flag)
        {
            _mouseSimulator = new InputSimulator().Mouse;
            _flag = flag;
        }

        public void update(State state)
        {
            var isDown = state.Gamepad.Buttons.HasFlag(_flag);
            if (isDown && !_wasButtonDown) _mouseSimulator.RightButtonDown();
            if (!isDown && _wasButtonDown) _mouseSimulator.RightButtonUp();
            _wasButtonDown = isDown;
        }
    }
}
