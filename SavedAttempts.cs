using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace FalloutTerminal
{
    public class SavedAttempts
    {
        public string Word;
        public int Likeness;

        public SavedAttempts(string word, int likeness)
        {
            Word = word;
            Likeness = likeness;
        }
    }
}
