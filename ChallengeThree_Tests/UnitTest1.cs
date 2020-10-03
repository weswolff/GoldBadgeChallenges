using System;
using KomodoBadge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeThree_Tests
{
    [TestClass]
    public class UnitTest1
    {
        private BadgeRepository _badgeRepo = new BadgeRepository();
        [TestMethod]
        public void AddBadgeTest()
        {

            //Arrange 
            Badge badge1 = new Badge(12345, "A7", "Badge 1");
            Badge badge2 = new Badge(22345, "A1, A4, B1, B2", "Badge 2");
            Badge badge3 = new Badge(32345, "A4, A5", "Badge 3");
            //Act
            _badgeRepo.AddBadgeToDictionary(badge1);
            _badgeRepo.AddBadgeToDictionary(badge2);
            _badgeRepo.AddBadgeToDictionary(badge3);
            //Assert
            int expected = 3;
            int actual = _badgeRepo.GetBadgeLists().Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ReadBadgeTest()
        {
            //Arrange
            Badge badge = new Badge(12345, "A7", "Badge 1");
            //Act
            _badgeRepo.AddBadgeToList(badge);
            //Assert
            int expected = 1;
            int actual = _badgeRepo.GetBadgeLists().Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DeleteBadgeTest()
        {
            //Arrange
            Badge badge1 = new Badge(12345, "A7", "Badge 1");
            //Act
            _badgeRepo.AddBadgeToDictionary(badge1);
            _badgeRepo.RemoveDoorName(badge1);
            //Assert
            int expected = 0;
            int actual = _badgeRepo.GetBadgeLists().Count;
            Assert.AreEqual(expected, actual);

        }
    }
}
