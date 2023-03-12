using SharpDX.XInput;
using WindowsInput;

namespace XboxMouseKeyboardEmulator
{
    internal class RTrigger : IKey
    {
        private bool _wasKeyDown;
        private IKeyboardSimulator _keyboardSimulator;
        private WindowsInput.Native.VirtualKeyCode _key;

        public RTrigger(WindowsInput.Native.VirtualKeyCode key)
        {
            _keyboardSimulator = new InputSimulator().Keyboard;
            _key = key;
        }

        public void update(State state)
        {
            var isDown = (state.Gamepad.RightTrigger > 10);
            if (isDown && !_wasKeyDown) _keyboardSimulator.KeyDown(_key);
            if (!isDown && _wasKeyDown) _keyboardSimulator.KeyUp(_key);
            _wasKeyDown = isDown;
        }
    }
}
