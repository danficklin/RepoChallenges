using System;
using MenuUI.Consoles;

namespace MenuUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Where we will build the UI
            IConsole console = new RealConsole();
            UserInterface ui = new UserInterface(console);
            ui.Run();
        }
    }
}
