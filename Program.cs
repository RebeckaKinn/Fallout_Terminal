using FalloutTerminal;
var input = new InputConsole();
var controlPanel = new ControlPanel();
var screen = new Screen();
RunProgram();
void RunProgram()
{
    controlPanel.Start();
    screen.Start(input, controlPanel);
}