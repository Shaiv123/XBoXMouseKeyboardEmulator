using SharpDX.XInput;
using WindowsInput;

namespace XboxMouseKeyboardEmulator
{
    internal class LMB : IMouse
    {
        private IMouseSimulator _mouseSimulator;
        private GamepadButtonFlags _flag;

        private bool _wasButtonDown;

        public LMB(GamepadButtonFlags flag)
        {
            _mouseSimulator = new InputSimulator().Mouse;
            _flag = flag;
        }

        public void Update(State state)
        {
            var isDown = state.Gamepad.Buttons.HasFlag(_flag);
            if (isDown && !_wasButtonDown) _mouseSimulator.LeftButtonDown();
            if (!isDown && _wasButtonDown) _mouseSimulator.LeftButtonUp();
            _wasButtonDown = isDown;
        }
    }
}
