namespace Classes
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void DefaultConstructorTest()
        {
            // Arrange

            // Act
            Item item = new();

            // Assert
            Assert.AreEqual(item.SerialNumber, string.Empty);
        }

        [TestMethod]
        public void CreationTest()
        {
            // Arrange
            string serialNumber = "test";
            DateTime dateOfArrival = new(1960, 12, 28);

            // Act
            Item item = new(serialNumber, dateOfArrival);

            // Assert
            Assert.AreEqual(item.SerialNumber, serialNumber);
            Assert.AreEqual(item.DateofArrival, dateOfArrival);
        }
    }
}
