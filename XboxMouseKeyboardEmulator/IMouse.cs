using SharpDX.XInput;

namespace XboxMouseKeyboardEmulator
{
    public interface IMouse
    {
        void update(State state);
    }
}
