using SharpDX.XInput;
using System.Collections.Generic;

namespace XboxMouseKeyboardEmulator
{
    public class Mouse
    {
        private List<IMouse> _mouse;
        public Mouse()
        {
            _mouse = new List<IMouse>();
            _mouse.Add(new LMB(GamepadButtonFlags.LeftShoulder));
            _mouse.Add(new RMB(GamepadButtonFlags.RightShoulder));
            _mouse.Add(new MouseMove(GamepadButtonFlags.RightThumb));
        }

        public void Update(State state)
        {
            foreach (IMouse i in _mouse)
                i.Update(state);
        }
    }
}
