using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XboxMouseKeyboardEmulator
{
    public interface IMouse
    {
        void update(State state);
    }
}
