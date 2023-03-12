using SharpDX.XInput;
using System.Collections.Generic;

namespace XboxMouseKeyboardEmulator
{
    public class Keyboard
    {

        private List<IKey> _keys;

        public Keyboard()
        {
            _keys = new List<IKey>();
            _keys.Add(new LTrigger(WindowsInput.Native.VirtualKeyCode.CONTROL));
            _keys.Add(new RTrigger(WindowsInput.Native.VirtualKeyCode.MENU));
            _keys.Add(new LTUP(WindowsInput.Native.VirtualKeyCode.VK_W));
            _keys.Add(new LTDOWN(WindowsInput.Native.VirtualKeyCode.VK_S));
            _keys.Add(new LTLEFT(WindowsInput.Native.VirtualKeyCode.VK_A));
            _keys.Add(new LTRIGHT(WindowsInput.Native.VirtualKeyCode.VK_D));
            _keys.Add(new Key(GamepadButtonFlags.LeftThumb, WindowsInput.Native.VirtualKeyCode.SPACE));
            _keys.Add(new Key(GamepadButtonFlags.Back, WindowsInput.Native.VirtualKeyCode.TAB));
            _keys.Add(new Key(GamepadButtonFlags.A, WindowsInput.Native.VirtualKeyCode.VK_1));
            _keys.Add(new Key(GamepadButtonFlags.B, WindowsInput.Native.VirtualKeyCode.VK_2));
            _keys.Add(new Key(GamepadButtonFlags.X, WindowsInput.Native.VirtualKeyCode.VK_3));
            _keys.Add(new Key(GamepadButtonFlags.Y, WindowsInput.Native.VirtualKeyCode.VK_4));
            _keys.Add(new Key(GamepadButtonFlags.DPadDown, WindowsInput.Native.VirtualKeyCode.VK_5));
            _keys.Add(new Key(GamepadButtonFlags.DPadRight, WindowsInput.Native.VirtualKeyCode.VK_6));
            _keys.Add(new Key(GamepadButtonFlags.DPadLeft, WindowsInput.Native.VirtualKeyCode.VK_7));
            _keys.Add(new Key(GamepadButtonFlags.DPadUp, WindowsInput.Native.VirtualKeyCode.VK_8));
        }

        public void update(State state)
        {
            foreach(IKey i in _keys)
                i.update(state);
        }
    }
}
