using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalloutTerminal
{
    internal class HackSigns
    {
        private string _row = "0x";

        public HackSigns(int _rowLength)
        {
            //creating the 0x numbers on the side
            for (int i = 0; i < _rowLength; i++)
            {
                string newChar = i < 2 ? Numbers(RandomIndex(10)) : Letters(RandomIndex(26));
                _row += newChar;
            }

        }

        private int RandomIndex(int number)
        {
            //random number from 0 to whatever you want
            Random random = new Random();
            int randomNumber = random.Next(0, number);
            return randomNumber;
        }

        public string Show()
        {
            return _row;
        }

        private string Numbers(int index)
        {
            string[] _numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            return _numbers[index];
        }

        private string Letters(int index)
        {
            string[] _letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            return _letters[index];
        }
    }
}
