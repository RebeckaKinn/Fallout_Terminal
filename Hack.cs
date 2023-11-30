using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FalloutTerminal
{
    internal class Hack
    {
        private int _colInput = 43;
        private int _rowInput = 21;

        public bool HackEnitiated { get; set; }
        private int _attempts = 4;
        private int _likeness;
        public List<HackSigns> SideNumbers { get; set; }
        public List<HackChar> HackCharacters { get; set; }
        HackAnswer hackAnswer = new HackAnswer();
        public List<SavedAttempts> saved {  get; set; }

        public Hack()
        {
            HackEnitiated = true;
            SideNumbers = new List<HackSigns>();
            HackCharacters = new List<HackChar>();
            saved = new List<SavedAttempts>();
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
            GenerateSideTries(text, input);
            if (HackEnitiated) Check(text, input);
            else input.Click(_colInput, _rowInput);

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

        public void Check(OutputConsole text, InputConsole input)
        {
            input.Read(_colInput, _rowInput);
            string guess = input.Answer().ToUpper();
            _likeness = hackAnswer.CheckAnswer(guess);

            saved.Add(new SavedAttempts(guess, _likeness));

           if (_likeness == 4)
            {
                //dummy. Need to create an instans of a new class
                Console.Clear();
                text.Print("Nice! You hacked it!");
                input.Click(_colInput, _rowInput);
            }
            else
            {
                WrongGuess();
                Enitiate(text, input);
            }
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

        public void GenerateSideTries(OutputConsole text, InputConsole input)
        {
            //shows your input to the hack, how many is correct and the endgame. 
            int _sideRowPlacement = _rowInput - 1;
            int col = 43;
            int timesPrinted = 0;
            //SHOWS THE ANSWER FOR DEBUGGING PURPOSES
            Console.WriteLine(hackAnswer.Answer());
            //

            if (_attempts < 4)
            {
               if(saved.Count == 4)
               {
                  _sideRowPlacement = _rowInput - 3;
               }
                for(int i = saved.Count-1; i >= 0; i--)
                {
                    text.Print($">Likeness={Convert.ToInt32(saved[i].Likeness)}", col, _sideRowPlacement);
                    _sideRowPlacement--;
                    text.Print(">Entry denied.", col, _sideRowPlacement);
                    _sideRowPlacement--;
                    text.Print($">{saved[i].Word}", col, _sideRowPlacement);
                    _sideRowPlacement--;
                    timesPrinted++;

                    if(_attempts == 0 && timesPrinted == 4)
                    {
                        _sideRowPlacement = _rowInput - 1;
                        text.Print(">You are locked out...", col, _sideRowPlacement);
                        _sideRowPlacement--;
                        text.Print(">Too many failed attempts.", col, _sideRowPlacement);
                        HackEnitiated = false;
                    }
                }
            } 
        }
    }
}
