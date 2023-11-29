using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FalloutTerminal
{
    internal class HackAnswer
    {
        private string _answer;
        List<string> wordList { get; set; }
        public HackAnswer()
        {
            wordList = new List<string>();
        }

        public void AddToList(string word)
        {
            wordList.Add(word);
        }

        public void CreateAnswer()
        {
            _answer = wordList[GetRandomNumFromList()];
        }

        public int GetRandomNumFromList()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, wordList.Count);
            return randomNumber;
        }

        public string Answer()
        {
            return _answer;
        }

        public int CheckAnswer(string guessWord)
        {
            int correctHits = 0;
            char lastGuess = '_';
            if (_answer == guessWord) correctHits = 4;

            for (int i = 0; i < _answer.Length; i++)
            {
                for (int l = 0; l < guessWord.Length; l++)
                {
                    if (_answer[i] == guessWord[l] && lastGuess != _answer[i])
                    {
                        lastGuess = guessWord[l];
                        correctHits++;
                    }
                }
            }
            return correctHits;
        }
    }
}
