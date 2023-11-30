using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalloutTerminal
{
	internal class Overseer
	{
        //new
		public void StartPage(OutputConsole text, InputConsole input, Screen screen)
		{
            Console.Clear();
            screen.TopLevelStatements(text);
            screen.OverseerTopLevelStatements(text);
			text.PrintOption("Overseer Log");
            text.Print("\n");
            text.PrintOption("Back");
            input.Read();
            HandleOptions(text, input, screen);
        }
        public void HandleOptions(OutputConsole text, InputConsole input, Screen screen)
        {
            switch (input.Answer())
            {
                case "overseer log":
                    {
                        OverseerLog(text, input, screen)
                        break;
                    }
                case "back":
                    {
                        screen.Start(text, input, screen);
                        break;
                    }
                default:
                    {
                        StartPage(text, input, screen); 
                        break;
                    }
            }
        }

        public void OverseerLog(OutputConsole text, InputConsole input, Screen screen)
        {
            Console.Clear();
            screen.TopLevelStatements(text);
            screen.OverseerTopLevelStatements(text);

            //in the meantime
            input.Click();
        }
	}
}
