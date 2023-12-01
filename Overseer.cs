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
            var controlPanel = new ControlPanel();
            switch (input.Answer())
            {
                case "overseer log":
                    {
                        OverseerLog(text, input, screen, controlPanel);
                        break;
                    }
                case "back":
                    {
                        screen.Start(input, controlPanel, screen);
                        break;
                    }
                default:
                    {
                        StartPage(text, input, screen); 
                        break;
                    }
            }
        }

        public void OverseerLog(OutputConsole text, InputConsole input, Screen screen, ControlPanel controlPanel)
        {
            Console.Clear();
            screen.TopLevelStatements(text);
            screen.OverseerTopLevelStatements(text);
            text.Print("The commonwealth is starting to bloom, I can feel it!");
            text.Print("The people in the Vault is getting lost-tempered, I must");
            text.Print("open the vault... but I am afraid...");
            text.Print("\n");
            text.PrintOption("back");

            input.Read();
            if (input.Answer() == "back") StartPage(text, input, screen);
            else OverseerLog(text, input, screen, controlPanel);
        }
	}
}
