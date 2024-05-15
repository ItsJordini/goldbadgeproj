using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CafeMenuRepo;

public class CafeMenuTest
{
    [TestFixture]
    public class MenuItemRepositoryTests
    {
        [Test]
        public void AddMenuItem_Should_Add_Item_To_Repository_()
        {
            //Arrange
            var repository = new MenuItemRepository();
            var item = new MenuItemRepository(
                1,
                "Burger",
                "Delicious burger",
                new List<string> { "Beef", "Cheese" },
                9.99m
            );

            //Act
            repository.AddMenuItem(item);

            //Assert
            Assert.AreEqual(1, repository.GetAllMenuItems().Count);
        }
    }
}
