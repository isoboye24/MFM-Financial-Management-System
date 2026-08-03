using MFMFMS.Domain.Entities;
using MFMFMS.Domain.Exceptions;

namespace MFMFMS.Test.Domain.Entities
{
    [TestClass]
    public class CategoryTests
    {
        [TestMethod]
        public void Constructor_Should_Create_Category_When_Name_Is_Valid()
        {
            var name = "Offering";

            var category = new Category(name);

            Assert.AreEqual(name, category.Name);
            Assert.AreNotEqual(Guid.Empty, category.Id);
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_Name_Is_Null()
        {
            string? name = null;

            var exception = Assert.ThrowsException<BusinessRuleException>(
                () => new Category(name!));

            Assert.AreEqual("Category's name is required.", exception.Message);
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_Name_Is_Empty()
        {
            var name = string.Empty;

            var exception = Assert.ThrowsException<BusinessRuleException>(
                () => new Category(name));

            Assert.AreEqual("Category's name is required.", exception.Message);
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_Name_Is_WhiteSpace()
        {
            var name = "   ";

            var exception = Assert.ThrowsException<BusinessRuleException>(
                () => new Category(name));

            Assert.AreEqual("Category's name is required.", exception.Message);
        }

        [TestMethod]
        public void UpdateName_Should_Update_Name_When_Valid()
        {
            var category = new Category("Offering");

            category.UpdateName("Tithe");

            Assert.AreEqual("Tithe", category.Name);
        }

        [TestMethod]
        public void UpdateName_Should_Throw_When_Name_Is_Null()
        {
            var category = new Category("Offering");

            var exception = Assert.ThrowsException<BusinessRuleException>(
                () => category.UpdateName(null!));

            Assert.AreEqual("Category's name is required.", exception.Message);
        }

        [TestMethod]
        public void UpdateName_Should_Throw_When_Name_Is_Empty()
        {
            var category = new Category("Offering");

            var exception = Assert.ThrowsException<BusinessRuleException>(
                () => category.UpdateName(string.Empty));

            Assert.AreEqual("Category's name is required.", exception.Message);
        }

        [TestMethod]
        public void UpdateName_Should_Throw_When_Name_Is_WhiteSpace()
        {
            var category = new Category("Offering");

            var exception = Assert.ThrowsException<BusinessRuleException>(
                () => category.UpdateName("   "));

            Assert.AreEqual("Category's name is required.", exception.Message);
        }
    }
}