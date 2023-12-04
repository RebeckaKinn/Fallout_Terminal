using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FalloutTerminal
{
    internal class SecretPage
	{
        Screen screen = new Screen();
        ControlPanel controlPanel = new ControlPanel();

		public void StartPage(OutputConsole text, InputConsole input)
		{
            Console.Clear();
            screen.TopLevelStatements(text);
            screen.TurretControlTopLevelStatements(text);

            text.PrintEnhancedOption("Switch Control");
            text.PrintEnhancedOption("Turret Control");
            text.PrintOption("Death Log");
            text.Print("\n");
            text.PrintOption("Back");
            input.Read();

            switch (input.Answer())
            {
                case "back":
                    {
                        screen.Start(input, controlPanel, screen);
                        break;
                    }
                case "switch control":
                    {
                        
                        break;
                    }
                case "turret control":
                    {
                        TurretControl(text, input);
                        break;
                    }
                case "death log":
                    {

                        break;
                    }
                default:
                    {
                        StartPage(text, input); 
                        break;
                    }
            }
            //create deathlog, turret, control and switch. 
        }

        public void TurretControl(OutputConsole text, InputConsole input)
        {
            Console.Clear();
            screen.TopLevelStatements(text);
            screen.TurretControlTopLevelStatements(text);
        }

		
	}
}
