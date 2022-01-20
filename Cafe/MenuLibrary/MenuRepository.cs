using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuLibrary
{
    public class MenuRepository
    {
        private readonly List<Menu> _repo = new List<Menu>();

        // CRUD

        // Create --- Add an item to the menu
        public bool AddItemToMenu(Menu content)
        {
            int startingCount = _repo.Count;
            _repo.Add(content);
            return _repo.Count > startingCount;
        }

        // Read --- Get a list of the items on the menu

        public List<Menu> GetMenu()
        {
            return _repo;
        }

        // --- Get a menu item by name

        public Menu GetItemByName(string name)
        {
            // Look through the menu
            foreach(Menu target in _repo)
            // If we find the named item, return it
            {
                if(target.Name.ToLower() == name.ToLower())
                {
                    return target;
                }
            }
            // If the named item is not on the menu, return null
            return null;
        }

        // Update --- Change properties of a menu item

        public bool UpdateMenuItem(string originalName, Menu newContent)
        {
            // Find the original menu item by name
            Menu oldContent = GetItemByName(originalName);

            // If we find the menu item, replace the content

            if(oldContent != null)
            {
                oldContent.Name = newContent.Name;
                oldContent.Number = newContent.Number;
                oldContent.Description = newContent.Description;
                oldContent.Ingredients = newContent.Ingredients;
                oldContent.Price = newContent.Price;

                return true;
            }

            // If we cannot find it, return false

            return false;
        }

        // Delete --- remove an item from the menu

        public bool DeleteMenuItem(Menu existingItem)
        {
            return _repo.Remove(existingItem);
        }
    }
}