using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalloutTerminal
{
    internal class Screen
    {
        public void Start(InputConsole input, ControlPanel controlPanel)
        {
            Console.Clear();
            var text = new OutputConsole();
            TopLevelStatements(text);


            text.PrintOption("Hack");
            text.PrintOption("Log");

            input.Read();
            switch (input.Answer())
            {
                case "hack":
                    var hack = new Hack();
                    hack.Enitiate(text, input);
                    break;

                default:
                    Start(input, controlPanel);
                    break;
            }
        }
        public void TopLevelStatements(OutputConsole text)
        {
            text.Print("Welcome to ROBCO Industries (TM) Termlink");
            text.Print("Terminal Mainframe Intercace\n");
        }
    }
}
