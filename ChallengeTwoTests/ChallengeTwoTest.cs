using System;
using ChallengeTwo_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeTwoTests
{
    [TestClass]
    public class ChallengeTwoTest
    {
        private ClaimRepository _claimsQ = new ClaimRepository();

        [TestMethod]
        public void ReadClaimsTest()
        {
            //Arrange
            Claims claim1 = new Claims(1, TypeOfClaim.Car, "car crash", 500.00, DateTime.Now, DateTime.Now , true); //used datetime now for testing purposes
            Claims claim2 = new Claims(1, TypeOfClaim.Car, "car crash", 500.00, DateTime.Now, DateTime.Now, true);
            Claims claim3 = new Claims(1, TypeOfClaim.Car, "car crash", 500.00, DateTime.Now, DateTime.Now, true);
            //Act
            _claimsQ.AddClaims(claim1);
            _claimsQ.AddClaims(claim2);
            _claimsQ.AddClaims(claim3);
            //Assert
            int expected = 3;
            int actual = _claimsQ.GetClaims().Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CreateClaimsTest()
        {
            //Arrange
            Claims claim1 = new Claims(1, TypeOfClaim.Car, "car crash", 500.00, DateTime.Now, DateTime.Now, true);
            //Act
            _claimsQ.AddClaims(claim1);
            //Assert
            int expected = 1;
            int actual = _claimsQ.GetClaims().Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DeleteClaimsTest()
        {
            //Arrange
            Claims claim1 = new Claims(1, TypeOfClaim.Car, "car crash", 500.00, DateTime.Now, DateTime.Now, true);
            //Act
            _claimsQ.AddClaims(claim1);
            _claimsQ.DeleteClaims();

            //Assert
            int expected = 0;
            int actual = _claimsQ.GetClaims().Count;
            Assert.AreEqual(expected, actual);
        }
    }
}
