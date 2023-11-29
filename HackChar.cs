using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalloutTerminal
{
    internal class HackChar
    {
        private string _lines = "";
        string[] _specialCharacters = {
                "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "_", "+", "-", "=", "{", "}", "[", "]", "|", "\\",
                ";", ":", "'", "\"", ",", ".", "/", "<", ">", "?", "`", "~", "(", ")", "_", "+", "-", "=", "{", "}",
                "[", "]", "|", ";", ":", "'", "\"", ",", ".", "/", "<", ">", "?"
                };
        string[] _fourLetterWords = {
                "WORD", "DATA", "CODE", "TEXT", "VIEW", "TASK", "FILE", "FONT", "MENU", "LINK",
                "HELP", "USER", "TIME", "VIEW", "LOCK", "ZONE", "FORK", "LAMP", "WAVE", "JUMP",
                "VOID", "SYNC", "HIDE", "SAFE", "MINT", "ECHO", "FUEL", "WIRE", "NOVA", "ZERO",
                "SNOW", "NEON", "FROG", "LIME", "ZOOM", "GLOW", "FLIP", "TIDE", "VAST", "DART",
                "BOLD", "HUSH", "TANK", "PEAK", "MUTE", "SOLO", "HINT", "JAZZ", "FIRM", "VIBE",
                "GIFT", "HALL", "MARS", "CANE", "KICK", "ROSE", "COOL", "JAWS", "FAME", "EYES"
            };
       //HackAnswer hackAnswer = new HackAnswer();//flytta
        //putte lagring av ordene i en annen klasse
        //List<string> wordList {get; set;} //flytta

        public HackChar(int length, HackAnswer hackAnswer)
        {
            
            for (int i = 0; i < length; i++)
            {
                if (RandomIndex(15) == 4 && _lines.Length < length - 4)
                {
                    string word = Words(RandomIndex(_fourLetterWords.Length));
                    _lines += word;
                    hackAnswer.AddToList(word);
                }
                _lines += Characters(RandomIndex(_specialCharacters.Length));
                if (_lines.Length == length) i = length;
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
            return _lines;
        }

        private string Characters(int index)
        {

            return _specialCharacters[index];
        }

        private string Words(int index)
        {
            return _fourLetterWords[index];
        }
    }
}
