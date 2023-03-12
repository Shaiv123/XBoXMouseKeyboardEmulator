using SharpDX.XInput;

namespace XboxMouseKeyboardEmulator
{
    public interface IKey
    {
        void Update(State state);
    }
}
