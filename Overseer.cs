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
            text.PrintOption("December - 2199");
            text.Print("My name is Laney Williams, the third Overseer from the Williams ");
            text.Print("Family. The traider had taken with him some kind of illness, ");
            text.Print("which has taken us down one by one. We have sendt several out ");
            text.Print("to find help, but they have not returned. \n");
            text.PrintOption("July - 2201");
            text.Print("I send the last one out. I am alone now, waiting for help. ");
            text.Print("I haven't been outside myself, but as Overseer I have to wait for ");
            text.Print("them to return. I hope it will be soon...");
            text.Print("\n");
            text.PrintOption("back");

            input.Read();
            if (input.Answer() == "back") StartPage(text, input, screen);
            else OverseerLog(text, input, screen, controlPanel);
        }
	}
}
