using System;
using System.Collections.Generic;
using System.ComponentModel;
using ChallengeOne_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeOneRedo_Tests
{
    [TestClass]
    public class ChallengeOneTest
    {
        private MenuRepository _menuRepo = new MenuRepository();
        [TestMethod]
        public void CreateMenuItemsTest()
        {
            //Arrange
            MenuItem menuItem = new MenuItem(1, "Iced Latte", "This is a latte with ice.", "Coffee, Ice, Milk", 5.99);
            
            //Act
            _menuRepo.AddMenuItems(menuItem);

            //Assert
            int expected = 1;
            int actual = _menuRepo.GetMenuItems().Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DeleteMenuItemsTest()
        {
            //Arrange
            MenuItem menuItem = new MenuItem(1, "Iced Latte", "This is a latte with ice.", "Coffee, Ice, Milk", 5.99);

            //Act
            _menuRepo.AddMenuItems(menuItem);
            _menuRepo.RemoveMenuItems(1);

            //Assert
            int expected = 0;
            int actual = _menuRepo.GetMenuItems().Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ReadMenuItemsTest()
        {
            //Arrange
            MenuItem menuItem1 = new MenuItem(1, "Iced Latte", "This is a latte with ice.", "Coffee, Ice, Milk", 5.99);
            MenuItem menuItem2 = new MenuItem(1, "Iced Latte", "This is a latte with ice.", "Coffee, Ice, Milk", 5.99);
            MenuItem menuItem3 = new MenuItem(1, "Iced Latte", "This is a latte with ice.", "Coffee, Ice, Milk", 5.99);
            //Act
            _menuRepo.AddMenuItems(menuItem1);
            _menuRepo.AddMenuItems(menuItem2);
            _menuRepo.AddMenuItems(menuItem3);
            //Assert
            int expected = 3;
            int actual = _menuRepo.GetMenuItems().Count;
            Assert.AreEqual(expected, actual);
        }
    }
}
