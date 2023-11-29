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
        public List<string> words;
        public List<int> likeness;

        public SavedAttempts()
        {
            words = new List<string>();
            likeness = new List<int>();
        }
    }
}
