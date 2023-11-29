using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalloutTerminal
{
    internal class ControlPanel
    {
        private bool _disable { get; set; }
        private int _width { get; set; }
        private int _height { get; set; }

        public ControlPanel(int width = 70, int height = 25)
        {
            _width = width;
            _height = height;
            Console.SetWindowSize(_width, _height);
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
        }

        public void Start()
        {
            _disable = true;
        }

        public void Stop()
        {
            _disable = false;
        }

        public bool Status()
        {
            return _disable;
        }

        public void ControlSenter()
        {

        }

    }
}
