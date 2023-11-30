using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalloutTerminal
{
    internal class Screen
    {
        public void Start(InputConsole input, ControlPanel controlPanel, Screen screen)
        {
            Console.Clear();
            var text = new OutputConsole();
            TopLevelStatements(text);


            text.PrintOption("Turret");
            text.PrintOption("Overseer");

            input.Read();
            switch (input.Answer())
            {
                case "turret":
                    var hack = new Hack();
                    hack.Enitiate(text, input);
                    break;
                case "overseer":
                    var overseer = new Overseer();
                    overseer.StartPage(text, input, screen);
                    break;


                default:
                    Start(input, controlPanel, screen);
                    break;
            }
        }
        public void TopLevelStatements(OutputConsole text)
        {
            text.Print("Welcome to ROBCO Industries (TM) Termlink");
            text.Print("Terminal Mainframe Intercace\n");
        }

        public void OverseerTopLevelStatements(OutputConsole text)
        {
            //havner i bunn?
            text.Print("Property of Vault-Tec");
            text.Print("Clerance: Overseer Eyes Only\n");
        }

        public void TurretControlTopLevelStatements(OutputConsole text)
        {
            text.Print("Standarized Turret Control Firmware v0.13");
            text.Print("STATUS: ERROR, All Clear");
            text.Print("ADMIN: Turret Defense System");
            text.Print("UNITS CONNECTED: 1\n");
            text.Print("Please exercise caution around turrets. Users");
            text.Print("should always assume that turrets are loaded and");
            text.Print("capable of live-fire.\n");
            text.Print("Please choose an option:");
        }
    }
}
