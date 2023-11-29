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
        private int _likeness;
        public List<HackSigns> SideNumbers { get; set; }
        public List<HackChar> HackCharacters { get; set; }
        HackAnswer hackAnswer = new HackAnswer();
        public List<SavedAttempts> saved {  get; set; }

        public Hack()
        {
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
            Check(text, input);
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
            input.Read();
            string guess = input.Answer().ToLower();
            _likeness = CheckAnswer(guess);

            saved.Add(new SavedAttempts(input.Answer().ToUpper(), _likeness));
            //saved.likeness.Add(_likeness);
            //saved.words.Add(input.Answer().ToUpper());

           if (_likeness == 4)
            {
                //dummy
                Console.Clear();
                text.Print("Nice! You hacked it!");
                input.Read();
            }
            else
            {
                WrongGuess();
                Enitiate(text, input);
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

        public void GenerateSideTries(OutputConsole text, InputConsole input)
        {
            int _sideRowPlacement = 21;
            int col = 43;
            //need a backwards loop
            if (_attempts < 4)
            {
                foreach(var answers in saved)
                {
                    text.Print($">Likeness={answers.Likeness}", col, _sideRowPlacement);
                    _sideRowPlacement--;
                    text.Print(">Entry denied.", col, _sideRowPlacement);
                    _sideRowPlacement--;
                    text.Print($">{answers.Word}", col, _sideRowPlacement);
                    _sideRowPlacement--;

                    //text.Print($">{answers.Word}", col, _sideRowPlacement);
                    //_sideRowPlacement++;
                    //text.Print(">Entry denied.", col, _sideRowPlacement);
                    //_sideRowPlacement++;
                    //text.Print($">Likeness={answers.Likeness}", col, _sideRowPlacement);
                    //_sideRowPlacement++;
                }

                if(_attempts == 0)
                {
                    text.Print(">You are locked out...", col, _sideRowPlacement);
                    _sideRowPlacement--;
                    text.Print(">Too many failed attempts.", col, _sideRowPlacement);
                }
            }
    
        }
    }
}
