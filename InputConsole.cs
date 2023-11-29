using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalloutTerminal
{
    internal class InputConsole
    {
        private string? _input { get; set; }

        public void Placement()
        {
            Console.SetCursorPosition(3, 23);
        }

        public void Read()
        {
            Placement();
            _input = Console.ReadLine();
            if (isNull()) Read();
        }

        public bool isNull()
        {
            if (_input == null) return true;
            else return false;
        }

        public string Answer()
        {
            return _input.ToLower();
        }
    }
}
