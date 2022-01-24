using System.Collections.Generic;
using BadgeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadgeTests
{
    [TestClass]
    public class BadgeRepositoryTests
    {

    private Badge _content;
    private BadgeRepository _repo;
    [TestInitialize]
    public void Arrange()
    {
        _content = new Badge(12345, List<"A7">, "Bob");
        _repo = new BadgeRepository();
        _repo.AddBadge(_content);
    }
        [TestMethod]
        public void CreateBadge_ShouldGetTrue()
        {
            bool result = _repo.AddBadge(_content);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ListBadges_ShouldReturnCorrectList()
        {
            Dictionary<1, 2> result = _repo.ListBadges();
            Assert.AreEqual(1, result.Count);
        }

        public void UpdateBadgeDoors_Should

    }
}
