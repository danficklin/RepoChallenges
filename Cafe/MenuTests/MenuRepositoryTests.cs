using System.Collections.Generic;
using MenuLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MenuTests
{
    [TestClass]
    public class MenuRepositoryTests
    {
        [TestMethod] // Add item to menu
        public void AddItemToMenu_ShouldGetTrue()
        {
            // Arrange
            Menu content = new Menu();
            MenuRepository repository = new MenuRepository();
            // Act
            bool result = repository.AddItemToMenu(content);
            // Assert
            Assert.IsTrue(result);

        }
        [TestMethod] // Get list of menu items
        public void GetMenu_ShouldReturnCorrectList()
        {
            // Arrange
            Menu taco = new Menu();
            MenuRepository repository = new MenuRepository();
            Menu burger = new Menu();
            repository.AddItemToMenu(taco);
            repository.AddItemToMenu(burger);
            // Act
            List<Menu> result = repository.GetMenu();
            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains(burger));
        }

        [TestMethod] // Get menu item by name
        public void GetItemByName_ShouldReturnCorrectItem()
        {
            // Arrange
            Menu content = new Menu();
            content.Name = "content";
            Menu lasagna = new Menu(1, "Lasagna", "Cheesy and meaty layered pasta dish", "mozzarella, ricotta, ragù, lasagna noodles, parmasean", 12.99);
            MenuRepository repo = new MenuRepository();
            repo.AddItemToMenu(content);
            repo.AddItemToMenu(lasagna);
            // Act
            Menu result = repo.GetItemByName("Lasagna");
            // Assert
            Assert.AreEqual(12.99, result.Price);
        }

        // Test Intialize

        private Menu _content;
        private MenuRepository _repo;

        [TestInitialize] // Setting up an arrange method to use in the update and delete tests
        public void Arrange()
        {
            // Creating content and a repository
            _content = new Menu(2, "Shepherd's Pie", "Lamb and vegetables in gravy with a topping of mashed potato", "ground lamb, onions, peas, carrots, gravy, potatoes", 10.99);
            _repo = new MenuRepository();
            // Add item to repository
            _repo.AddItemToMenu(_content);
        }

        [TestMethod] // Update a menu item
        public void UpdateMenuItem_ShouldGetTrue()

        {
            // Arrange --- handled by test initialization

            // Act
            Menu newContent =new Menu(2, "Cottage Pie", "Lamb and vegetables in gravy with a topping of mashed potato", "ground lamb, onions, peas, carrots, gravy, potatoes", 10.99);
            bool result =_repo.UpdateMenuItem(_content.Name, newContent);
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod] // Delete item from menu
        public void DeleteMenuItem_ShouldRemoveItem()
        {
            // Arrange is handled by the test intialization
            // Act
            bool result = _repo.DeleteMenuItem(_content);
            // Assert
            Assert.IsTrue(result);
        }
    }
}
