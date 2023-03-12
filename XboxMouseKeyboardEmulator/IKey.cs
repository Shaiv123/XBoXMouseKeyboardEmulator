using SharpDX.XInput;

namespace XboxMouseKeyboardEmulator
{
    public interface IKey
    {
        void update(State state);
    }
}
