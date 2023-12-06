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
            text.PrintOption("2080 - 2123");
            text.Print("Martin Ling       --  Overseer");
            text.Print("Olaf Jhonson      --  Vault Tech Support");
            text.Print("Loreene Klempton  --  Medical Supervisor");
            text.Print("Nora Johnson      --  Vault Tech Support");
            text.Print("John Williams     --  Overseer");
            text.PrintOption("2124 - 2183");
            text.Print("Claus West        --  Medical Supervisor");
            text.Print("Maria Williams    --  Overseer");
            text.PrintOption("2184 -");
            text.Print("The rest of us...");
            text.Print("\n");
            text.PrintOption("back");

            input.Read();
            if (input.Answer().ToLower() == "back") StartPage(text, input);
            else DeathLog(text, input);
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
            if (input.Answer().ToLower() == "back") StartPage(text, input);
            else if (input.Answer() == _turretCommand.ToLower())
            {
                _activated = !_activated;
                TurretControl(text, input);
            }
            else TurretControl(text, input);
        }
		
	}
}
