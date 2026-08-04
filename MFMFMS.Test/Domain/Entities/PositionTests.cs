using MFMFMS.Domain.Entities;
using MFMFMS.Domain.Exceptions;

namespace MFMFMS.Test.Domain.Entities
{
    [TestClass]
    public class PositionTests
    {
        [TestMethod]
        public void Constructor_Should_Create_Position_When_Name_Is_Valid()
        {
            var name = "Pastor";

            var position = new Position(name);

            Assert.AreEqual(name, position.Name);
            Assert.AreNotEqual(Guid.Empty, position.Id);
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_Name_Is_Null()
        {
            string? name = null;

            var exception = Assert.ThrowsException<BusinessRuleException>(
                () => new Position(name!));

            Assert.AreEqual("Position's name is required.", exception.Message);
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_Name_Is_Empty()
        {
            var name = string.Empty;

            var exception = Assert.ThrowsException<BusinessRuleException>(
                () => new Position(name));

            Assert.AreEqual("Position's name is required.", exception.Message);
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_Name_Is_WhiteSpace()
        {
            var name = "   ";

            var exception = Assert.ThrowsException<BusinessRuleException>(
                () => new Position(name));

            Assert.AreEqual("Position's name is required.", exception.Message);
        }

        [TestMethod]
        public void UpdateName_Should_Update_Name_When_Valid()
        {
            var position = new Position("Pastor");

            position.UpdateName("Usher");

            Assert.AreEqual("Usher", position.Name);
        }

        [TestMethod]
        public void UpdateName_Should_Throw_When_Name_Is_Null()
        {
            var position = new Position("Pastor");

            var exception = Assert.ThrowsException<BusinessRuleException>(
                () => position.UpdateName(null!));

            Assert.AreEqual("Position's name is required.", exception.Message);
        }

        [TestMethod]
        public void UpdateName_Should_Throw_When_Name_Is_Empty()
        {
            var position = new Position("Pastor");

            var exception = Assert.ThrowsException<BusinessRuleException>(
                () => position.UpdateName(string.Empty));

            Assert.AreEqual("Position's name is required.", exception.Message);
        }

        [TestMethod]
        public void UpdateName_Should_Throw_When_Name_Is_WhiteSpace()
        {
            var position = new Position("Pastor");

            var exception = Assert.ThrowsException<BusinessRuleException>(
                () => position.UpdateName("   "));

            Assert.AreEqual("Position's name is required.", exception.Message);
        }
    }
}
