using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BadgeLibrary;
using BadgeUI.Consoles;

namespace BadgeUI
{
    public class BadgesUserInterface
    {
        private readonly IConsole _console;
        private readonly BadgeRepository _repo = new BadgeRepository();
        public BadgesUserInterface(IConsole console)
        {
            _console = console;
        }
        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        private void RunMenu()
        {
            bool isRunning = true;
            while(isRunning)
            {
                string menu = string.Format("{0, -20}", "Menu");    
                string greeting = string.Format
                (
                    "{0, 20}", "Hello Security Admin, What would you like to do?\n" +
                    "{0, 20}", "1. Add a badge\n" +
                    "{0, 20}", "2. Edit a badge" +
                    "{0, 20}", "3. List all badges"
                ); 
                _console.WriteLine(menu);
                _console.WriteLine(greeting); 
                string userSelection = _console.ReadLine();
                switch(userSelection.ToLower())
                {
                    case "1":
                    case "add":
                        _console.WriteLine("Enter the number of the badge: ");
                        string newBadgeID = _console.ReadLine();

                        _console.WriteLine("Enter a door that the badge should open: ");
                        string newDoor = _console.ReadLine();

                        _console.WriteLine("Any other doors (y/n) ?");
                        string moreDoors = _console.ReadKey();
                        if(moreDoors == "y")
                        {
                            AddDoor();
                        } else { break; }
                    
                        break;
                    case "2":
                    case "edit":
                        EditBadge();
                        break;
                    case "3":
                    case "list":
                        ListBadges();
                        break;
                    default:
                        break;
                }           
            }
        }
    }
}