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


        public void Placement(int col = 3, int row = 21)
        {
            Console.SetCursorPosition(col, row);
        }

        public void Read()
        {
            Placement();
            _input = Console.ReadLine();
            if (isNull()) Read();
        }

        public void Read(int col, int row)
        {
            Placement(col, row);
            _input = Console.ReadLine();
            if (isNull()) Read();
        }
        public void Click()
        {
            Placement();
            Console.ReadKey();
        }
        public void Click(int col, int row)
        {
            Placement(col, row);
            Console.ReadKey();
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
