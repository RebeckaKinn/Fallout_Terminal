using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalloutTerminal
{
    internal class OutputConsole
    {
        public ConsoleColor color { get; set; }
        private int _row { get; set; }
        private int _col { get; set; }

        public OutputConsole(ConsoleColor chosenColor = ConsoleColor.Green)
        {
            color = chosenColor;
            Console.ForegroundColor = color;
            _col = 0;
        }

        public void Column(int y = 3)
        {
            _col = (int)y;
            Console.CursorLeft = _col;
        }
        public void Column(int y, int x)
        {
            _col = (int)y;
            _row = (int)x;
            Console.CursorLeft = _col;
            Console.CursorTop = _row;
        }


        public void Print(string text)
        {
            Column();
            Console.WriteLine(text);
        }

        public void Print(string text, int col, int row)
        {
            Column(col, row);
            Console.WriteLine(text);
        }

        public void PrintOption(string text)
        {
            Column(5);
            Console.WriteLine(">[" + text + "]");
        }
    }
}
