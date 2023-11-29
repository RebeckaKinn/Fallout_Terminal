using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalloutTerminal
{
    internal class Hack
    {
        private int _attempts = 4;
        public List<HackSigns> SideNumbers { get; set; }
        public List<HackChar> HackCharacters { get; set; }
        HackAnswer hackAnswer = new HackAnswer();
        public Hack()
        {
            SideNumbers = new List<HackSigns>();
            HackCharacters = new List<HackChar>();
            CreateNumberList(32);
        }

        public void CreateNumberList(int index)
        {
            for (int i = 0; i < index; i++)
            {
                HackSigns numbers = new HackSigns(4);
                SideNumbers.Add(numbers);

                HackChar character = new HackChar(12, hackAnswer);
                HackCharacters.Add(character);
            }
            hackAnswer.CreateAnswer();
        }

        public void Enitiate(OutputConsole text, InputConsole input)
        {
            Console.Clear();
            var screen = new Screen();

            screen.TopLevelStatements(text);
            text.Print("Password Required");
            text.Print("Attempts Remaining:  " + PrintAttempts() + "\n");

            Generate(text);
            Check(input);
        }

        public string PrintAttempts()
        {
            string rectangle = "";
            for (int i = 0; i < _attempts; i++)
            {
                rectangle += "█ ";
            }
            return rectangle;
        }

        public void Check(InputConsole input)
        {
            input.Read();
            string guess = input.Answer().ToString().ToLower();

           if (CheckAnswer(guess) == 4)
            {
                //if right
            }
            else
            {
                WrongGuess();

            }
        }
        public int CheckAnswer(string guess)
        {
            return hackAnswer.CheckAnswer(guess);
        }

        private void WrongGuess()
        {
            _attempts--;
        }

        public void Generate(OutputConsole text)
        {
            //Prints the signs and letters in between the rows
            int rowNumber = 6;
            for (int i = 0; i < SideNumbers.Count; i++)
            {
                if (i > 15)
                {
                    text.Print(SideNumbers[i].Show(), 23, rowNumber);
                    text.Print(HackCharacters[i].Show(), 30, rowNumber);
                    rowNumber++;
                }
                else
                {
                    text.Print(SideNumbers[i].Show());
                    text.Print(HackCharacters[i].Show(), 10, rowNumber + i);
                }
            }

        }
    }
}
