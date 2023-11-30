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
        public SecretPage()
		{

		}

		public void StartPage(OutputConsole text, InputConsole input)
		{
            screen.TopLevelStatements(text);
            screen.TurretControlTopLevelStatements(text);

            text.PrintEnhancedOption("Switch Control");
            text.PrintEnhancedOption("Turret Control");
            input.Read();
        }

		
	}
}
