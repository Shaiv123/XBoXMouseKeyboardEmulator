using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;

namespace XboxMouseKeyboardEmulator
{
    public class Mouse
    {
        private const int MovementDivider = 1_000;
        private const int ScrollDivider = 10_000;

        private IMouseSimulator _mouseSimulator;

        private bool _wasLMBDown;
        private bool _wasRMBDown;

        public Mouse()
        {
            _mouseSimulator = new InputSimulator().Mouse;
        }

        public void update(State state)
        {
            MouseMove(state);
            MouseLeftButton(state);
            MouseRightButton(state);
        }

        private void MouseRightButton(State state)
        {
            var isDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightShoulder);
            if (isDown && !_wasRMBDown) _mouseSimulator.RightButtonDown();
            if (!isDown && _wasRMBDown) _mouseSimulator.RightButtonUp();
            _wasRMBDown = isDown;
        }

        private void MouseLeftButton(State state)
        {
            var isDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftShoulder);
            if (isDown && !_wasLMBDown) _mouseSimulator.LeftButtonDown();
            if (!isDown && _wasLMBDown) _mouseSimulator.LeftButtonUp();
            _wasLMBDown = isDown;
        }

        private void MouseMove(State state)
        {
            var isDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightThumb);
            if (isDown)
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
