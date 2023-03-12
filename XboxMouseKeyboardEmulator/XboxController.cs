using System.Threading;
using SharpDX.XInput;

namespace XboxMouseKeyboardEmulator
{
    public class XboxController
    {
        private const int RefreshRate = 60;
        
        private Timer _timer;
        private Controller _controller;
        private Mouse _mouse;
        private Keyboard _keyboard;
        
        public XboxController()
        {
            _controller = new Controller(UserIndex.One);
            _mouse = new Mouse();
            _keyboard = new Keyboard();
            _timer = new Timer(obj => Update());
        }

        public void Start()
        {
            _timer.Change(0, 1000 / RefreshRate);
        }

        private void Update()
        {
            _controller.GetState(out var state);
            _mouse.update(state);
            _keyboard.update(state);
        }
    }
}
