using System;
using BadgeUI.Consoles;

namespace BadgeUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IConsole console = new RealConsole();
            BadgesUserInterface ui = new BadgesUserInterface(console);
            ui.Run();
        }
    }
}
