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
        private string _turretCommand = "Activate";
        private bool _activated = false;

        public void StartPage(OutputConsole text, InputConsole input)
		{
            Console.Clear();
            screen.TopLevelStatements(text);

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
                case "turret control":
                    {
                        TurretControl(text, input);
                        break;
                    }
                case "death log":
                    {
                        DeathLog(text, input);
                        break;
                    }
                default:
                    {
                        StartPage(text, input); 
                        break;
                    }
            } 
        }

        private void DeathLog(OutputConsole text, InputConsole input)
        {
            Console.Clear();
            screen.TopLevelStatements(text);

            input.Read();
        }

        private void TurretControl(OutputConsole text, InputConsole input)
        {
            _turretCommand = _activated == true ? "Deactivate" : "Activate";
            Console.Clear();
            screen.TopLevelStatements(text);
            screen.TurretControlTopLevelStatements(text);
            text.Print("\n");
            text.PrintOption(_turretCommand);

            input.Read();
            if (input.Answer() == "back") StartPage(text, input);
            else if (input.Answer() == _turretCommand.ToLower())
            {
                _activated = !_activated;
                TurretControl(text, input);
            }
            else TurretControl(text, input);
        }
		
	}
}
