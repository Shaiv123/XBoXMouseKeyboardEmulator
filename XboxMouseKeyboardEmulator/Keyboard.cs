using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;

namespace XboxMouseKeyboardEmulator
{
    public class Keyboard
    {
        private const int StickSensivity = 5000;

        private IKeyboardSimulator _keyboardSimulator;

        private bool _wasSpaceDown;

        private bool _wasWDown;
        private bool _wasADown;
        private bool _wasSDown;
        private bool _wasDDown;

        private bool _wasAltDown;
        private bool _wasCTRLDown;
        private bool _wasTabDown;

        private bool _was1Down;
        private bool _was2Down;
        private bool _was3Down;
        private bool _was4Down;
        private bool _was5Down;
        private bool _was6Down;
        private bool _was7Down;
        private bool _was8Down;

        public Keyboard()
        {
            _keyboardSimulator = new InputSimulator().Keyboard;
        }

        public void update(State state)
        {
            WASDMovement(state);
            KeyCTRL(state);
            KeyALT(state);
            KeyBindA(state);
            KeyBindB(state);
            KeyBindX(state);
            KeyBindY(state);
            KeyBindDD(state);
            KeyBindDR(state);
            KeyBindDL(state);
            KeyBindDU(state);
            KeyTab(state);
            KeySpace(state);
        }

        private void KeyTab(State state)
        {
            var isDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Back);
            if (isDown && !_wasTabDown) _keyboardSimulator.KeyDown(WindowsInput.Native.VirtualKeyCode.TAB);
            if (!isDown && _wasTabDown) _keyboardSimulator.KeyUp(WindowsInput.Native.VirtualKeyCode.TAB);
            _wasTabDown = isDown;
        }

        private void KeyBindA(State state)
        {
            var isDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.A);
            if (isDown && !_was1Down) _keyboardSimulator.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_1);
            if (!isDown && _was1Down) _keyboardSimulator.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_1);
            _was1Down = isDown;
        }

        private void KeyBindB(State state)
        {
            var isDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.B);
            if (isDown && !_was2Down) _keyboardSimulator.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_2);
            if (!isDown && _was2Down) _keyboardSimulator.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_2);
            _was2Down = isDown;
        }

        private void KeyBindX(State state)
        {
            var isDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.X);
            if (isDown && !_was3Down) _keyboardSimulator.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_3);
            if (!isDown && _was3Down) _keyboardSimulator.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_3);
            _was3Down = isDown;
        }

        private void KeyBindY(State state)
        {
            var isDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Y);
            if (isDown && !_was4Down) _keyboardSimulator.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_4);
            if (!isDown && _was4Down) _keyboardSimulator.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_4);
            _was4Down = isDown;
        }

        private void KeyBindDD(State state)
        {
            var isDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown);
            if (isDown && !_was5Down) _keyboardSimulator.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_5);
            if (!isDown && _was5Down) _keyboardSimulator.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_5);
            _was5Down = isDown;
        }

        private void KeyBindDR(State state)
        {
            var isDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight);
            if (isDown && !_was6Down) _keyboardSimulator.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_6);
            if (!isDown && _was6Down) _keyboardSimulator.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_6);
            _was6Down = isDown;
        }

        private void KeyBindDL(State state)
        {
            var isDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft);
            if (isDown && !_was7Down) _keyboardSimulator.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_7);
            if (!isDown && _was7Down) _keyboardSimulator.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_7);
            _was7Down = isDown;
        }

        private void KeyBindDU(State state)
        {
            var isDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp);
            if (isDown && !_was8Down) _keyboardSimulator.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_8);
            if (!isDown && _was8Down) _keyboardSimulator.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_8);
            _was8Down = isDown;
        }


        private void KeyALT(State state)
        {
            var isDown = (state.Gamepad.RightTrigger > 10);
            if (isDown && !_wasAltDown) _keyboardSimulator.KeyDown(WindowsInput.Native.VirtualKeyCode.MENU);
            if (!isDown && _wasAltDown) _keyboardSimulator.KeyUp(WindowsInput.Native.VirtualKeyCode.MENU);
            _wasAltDown = isDown;
        }
        private void KeyCTRL(State state)
        {
            var isDown = (state.Gamepad.LeftTrigger > 10);
            if (isDown && !_wasCTRLDown) _keyboardSimulator.KeyDown(WindowsInput.Native.VirtualKeyCode.CONTROL);
            if (!isDown && _wasCTRLDown) _keyboardSimulator.KeyUp(WindowsInput.Native.VirtualKeyCode.CONTROL);
            _wasCTRLDown = isDown;
        }

        private void KeySpace(State state)
        {
            var isDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftThumb);
            if (isDown && !_wasSpaceDown) _keyboardSimulator.KeyDown(WindowsInput.Native.VirtualKeyCode.SPACE);
            if (!isDown && _wasSpaceDown) _keyboardSimulator.KeyUp(WindowsInput.Native.VirtualKeyCode.SPACE);
            _wasSpaceDown = isDown;
        }

        private void WASDMovement(State state)
        {
            var x = state.Gamepad.LeftThumbX;
            var y = state.Gamepad.LeftThumbY;
            

            if (x > StickSensivity)
            {
                if (_wasADown)
                {
                    _keyboardSimulator.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_A);
                    _wasADown = false;
                }

                if (!_wasDDown)
                {
                    _keyboardSimulator.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_D);
                    _wasDDown = true;
                }
            }
            if (x < StickSensivity && x > -StickSensivity)
            {
                if (_wasADown)
                {
                    _keyboardSimulator.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_A);
                    _wasADown = false;
                }
                if (_wasDDown)
                {
                    _keyboardSimulator.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_D);
                    _wasDDown = false;
                }
            }
            if (x < -StickSensivity)
            {
                if (_wasDDown)
                {
                    _keyboardSimulator.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_D);
                    _wasDDown = false;
                }

                if (!_wasADown)
                {
                    _keyboardSimulator.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_A);
                    _wasADown = true;
                }


            }

            if (y > StickSensivity)
            {
                if (_wasSDown)
                {
                    _keyboardSimulator.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_S);
                    _wasSDown = false;
                }

                if (!_wasWDown)
                {
                    _keyboardSimulator.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_W);
                    _wasWDown = true;
                }
            }
            if (y < StickSensivity && y > -StickSensivity)
            {
                if (_wasSDown)
                {
                    _keyboardSimulator.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_S);
                    _wasSDown = false;
                }
                if (_wasWDown)
                {
                    _keyboardSimulator.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_W);
                    _wasWDown = false;
                }
            }
            if (y < -StickSensivity)
            {
                if (!_wasSDown)
                {
                    _keyboardSimulator.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_S);
                    _wasSDown = true;
                }

                if (_wasWDown)
                {
                    _keyboardSimulator.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_W);
                    _wasWDown = false;
                }
            }


        }
    }
}
