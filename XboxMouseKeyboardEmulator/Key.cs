using SharpDX.XInput;
using WindowsInput;

namespace XboxMouseKeyboardEmulator
{
    public class Key : IKey
    {

        private bool _wasKeyDown;
        private IKeyboardSimulator _keyboardSimulator;
        private WindowsInput.Native.VirtualKeyCode _key;
        private GamepadButtonFlags _flag;

        public Key(GamepadButtonFlags flag, WindowsInput.Native.VirtualKeyCode key)
        {
            _keyboardSimulator = new InputSimulator().Keyboard;
            _flag = flag;
            _key = key;
        }

        public void Update(State state)
        {
            var isDown = state.Gamepad.Buttons.HasFlag(_flag);
            if (isDown && !_wasKeyDown) _keyboardSimulator.KeyDown(_key);
            if (!isDown && _wasKeyDown) _keyboardSimulator.KeyUp(_key);
            _wasKeyDown = isDown;
        }
    }
}
