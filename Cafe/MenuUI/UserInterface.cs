using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MenuLibrary;
using MenuUI.Consoles;

namespace MenuUI
{
    public class UserInterface
    {
        // Console
        private readonly IConsole _console;
        // How my UI runs
        private readonly MenuRepository _repo = new MenuRepository();
        //Run method which dictates what runs
        public UserInterface(IConsole console)
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
            while (isRunning)
            {
                _console.WriteLine(
                    "Enter the number of your selection: \n" +
                    "1. Show all menu items \n" +
                    "2. Find menu item by name \n" +
                    "3. Add item to menu \n" +
                    "4. Update menu item \n" +
                    "5. Delete menu item \n" +
                    "6. Exit"
                );
                string userSelection = _console.ReadLine();
                switch (userSelection.ToLower())
                {
                    case "1":
                    case "all":
                        GetMenu();
                        break;
                    case "2":
                    case "find":
                        GetItemByName();
                        break;
                    case "3":
                    case "add":
                        AddItemToMenu();
                        break;
                    case "4":
                    case "update":
                        UpdateMenuItem();
                        break;
                    case "5":
                    case "delete":
                        DeleteMenuItem();
                        break;
                    case "6":
                    case "exit":
                        _console.WriteLine("Exiting the menu...");
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }
        // Display all
        private void GetMenu()
        {
            _console.Clear();
            List<Menu> listOfContent = _repo.GetMenu();
            foreach (Menu content in listOfContent)
            {
                PrintContent(content);
            }
        }
        // Display by name
        private void GetItemByName()
        {
            _console.Clear();
            _console.WriteLine("Enter the name of a menu item: ");
            string targetName = _console.ReadLine();
            Menu content = _repo.GetItemByName(targetName);
            if (content != null)
            {
                PrintContent(content);
            }
            else
            {
                _console.WriteLine("That item is not on the menu.");
            }
            _console.WriteLine("Press any key to continue...");
            _console.ReadKey();
            _console.Clear();
        }
        // Create new menu item
        private void AddItemToMenu()
        {
            _console.Clear();
            Menu content = new Menu();
            _console.WriteLine("Enter the item number: ");
            content.Number = int.Parse(_console.ReadLine());
            _console.WriteLine("Enter the item name: ");
            content.Name = _console.ReadLine();
            _console.WriteLine("Enter the item description: ");
            content.Description = _console.ReadLine();
            _console.WriteLine("Enter the item ingredients: ");
            content.Ingredients = _console.ReadLine();
            _console.WriteLine("Enter the item price: ");
            content.Price = double.Parse(_console.ReadLine());
            bool success =_repo.AddItemToMenu(content);
            if(success)
            {
                _console.WriteLine("You successfully added the item to the menu. Press any key to continue...");
                _console.ReadKey();
            } else
            {
                _console.WriteLine("Something went wrong. Press any key to continue...");
                _console.ReadKey();
            }
        }

        // Update a menu item
        private void UpdateMenuItem()
        {
            _console.Clear();
            // Select item to update
            _console.WriteLine("Select an item to update: ");
            List<Menu> contentList = _repo.GetMenu();
            int counter = 1;
            foreach (Menu content in contentList)
            {
                _console.WriteLine(counter + ". " + content.Name);
                counter++;
            }
            int contentSelection = int.Parse(_console.ReadLine());
            int targetIndex = contentSelection - 1;
            Menu oldContent = contentList[targetIndex];
            // Get content to update with
            Menu updatedContent = new Menu();
            _console.WriteLine("Enter the item number: ");
            updatedContent.Number = int.Parse(_console.ReadLine());
            _console.WriteLine("Enter the item name: ");
            updatedContent.Name = _console.ReadLine();
            _console.WriteLine("Enter the item description: ");
            updatedContent.Description = _console.ReadLine();
            _console.WriteLine("Enter the item ingredients: ");
            updatedContent.Ingredients = _console.ReadLine();
            _console.WriteLine("Enter the item price: ");
            updatedContent.Price = double.Parse(_console.ReadLine());
            _repo.UpdateMenuItem(oldContent.Name, updatedContent);
        }
        // Delete item from menu
        private void DeleteMenuItem()
        {
            _console.Clear();
            _console.WriteLine("Select a menu item to remove: ");
            List<Menu> contentList = _repo.GetMenu();
            int counter = 1;

            foreach (Menu content in contentList)
            {
                _console.WriteLine(counter + ". " + content.Name);
                counter++;
            }

            int contentSelection = int.Parse(_console.ReadLine());
            int targetIndex = contentSelection - 1;

            if (targetIndex >= 0 && targetIndex < contentList.Count)
            {
                Menu targetContent = contentList[targetIndex];
                if(_repo.DeleteMenuItem(targetContent))
                {
                    _console.WriteLine($"{targetContent.Name} was removed from the menu.");
                }
                else
                {
                    _console.WriteLine("Something went wrong.");
                } 
            } 
            else
            {
                _console.WriteLine("Invalid selection.");
            }
            _console.WriteLine("Press any key to continue...");
            _console.Clear();
        }
        // Seed method
        private void SeedContent()
        {
            Menu lasagna = new Menu(1, "Lasagna", "Cheesy and meaty layered pasta dish", "mozzarella, ricotta, ragù, lasagna noodles, parmasean", 12.99);
            Menu shepherdsPie = new Menu(2, "Shepherd's Pie", "Lamb and vegetables in gravy with a topping of mashed potato", "ground lamb, onions, peas, carrots, gravy, potatoes", 10.99);
            Menu scrambledEggs = new Menu(3, "Scrambled Eggs", "Fluffy scrambled eggs", "eggs, butter, salt, pepper", 8.99);
            _repo.AddItemToMenu(lasagna);
            _repo.AddItemToMenu(shepherdsPie);
            _repo.AddItemToMenu(scrambledEggs);
        }
        // Helper method
        private void PrintContent(Menu content)
        {
            _console.WriteLine(
                $"Item number: {content.Number} \n" +
                $"Item name: {content.Name} \n" +
                $"Item description: {content.Description} \n" +
                $"Item ingredients: {content.Ingredients} \n" +
                $"Item price: {content.Price} \n\n"
            );
        }
    }
}