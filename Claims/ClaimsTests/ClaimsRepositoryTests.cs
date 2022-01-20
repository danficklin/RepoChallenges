using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClaimsLibrary;
using System;

namespace ClaimsTests
{
    [TestClass]
    public class ClaimsRepositoryTests
    {
        private Claim _content;
        private ClaimsRepository _repo;

        [TestInitialize]

        public void Arrange() // Contains all the code we want to run in every arrange
        {
            _content = new Claim(5, ClaimType.Theft, "Mona Lisa stolen", 85000000000, new DateTime(20220119), new DateTime(20220120), true); // Creating content
            _repo = new ClaimsRepository(); // Creating repository
            _repo.EnterClaim(_content); // Adding content to repository
        }

        [TestMethod] // Test EnterClaim
        public void EnterClaim_ShouldGetTrue()
        {
            bool result = _repo.EnterClaim(_content); // Act
            Assert.IsTrue(result); // Assert
        }
        [TestMethod] // Test GetClaims
        public void GetClaims_ShouldReturnCorrectList()
        {
            Queue<Claim> result = _repo.GetClaims(); // Act
            Assert.AreEqual(1, result.Count); // Assert
            Assert.IsTrue(result.Contains(_content)); // Alternate assert
        }
        [TestMethod] // Test GetClaimByID
        public void GetClaimByID_ShouldReturnCorrectClaim()
        {
            Claim result = _repo.GetClaimByID(5); // Act
            Assert.AreEqual(ClaimType.Theft, result.ClaimType); // Assert
        }

        [TestMethod] // Test NextClaim
        public void NextClaim_ShouldReturnTopItemInQueue()
        {
            Claim result = _repo.NextClaim(); // Act
            Assert.AreEqual(result, _content); // Assert
        }
    }
}
