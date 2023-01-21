using Classes;

namespace UnitTests
{
    [TestClass]
    public class StoreTests
    {
        [TestMethod]
        public void DefaultConstructorTest()
        {
            // Arrange

            // Act
            Store store = new();

            // Assert
            Assert.AreEqual(store.Name, string.Empty);
            Assert.IsFalse(store.Suppliers.Any());
            Assert.IsFalse(store.Customers.Any());
        }

        [TestMethod]
        public void CreationTest()
        {
            // Arrange
            string name = "test";

            // Act
            Store store = new(name);

            // Assert
            Assert.AreEqual(store.Name, name);
            Assert.IsFalse(store.Suppliers.Any());
            Assert.IsFalse(store.Customers.Any());
        }
    }
}
