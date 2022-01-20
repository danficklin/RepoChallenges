using System;
using ClaimsUI.Consoles;
namespace ClaimsUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IConsole console = new RealConsole();
            UserInterface ui = new UserInterface(console);
            ui.Run();
        }
    }
}
