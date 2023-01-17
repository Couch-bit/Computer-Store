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

        [TestMethod]
        public void EqualsTest()
        {
            // Arrange
            string serialNumber = "test";
            DateTime dateOfArrival = new(1960, 12, 28);
            DateTime dateOfArrival2 = new(1965, 11, 29);

            // Act
            Item item1 = new(serialNumber, dateOfArrival);
            Item item2 = new(serialNumber, dateOfArrival2);

            // Assert
            Assert.IsTrue(item1.Equals(item2));
        }

        [TestMethod]
        public void ToStringTest()
        {
            // Assert
            string serialNumber = "test";
            DateTime dateOfArrival = new(1960, 12, 28);

            // Act
            Item item = new(serialNumber, dateOfArrival);

            // Assert
            Assert.AreEqual(item.ToString(),
                $"{serialNumber} ({dateOfArrival:yyyy-MM-dd})");
        }

        [TestMethod]
        public void EqualsOverrideTest()
        {
            // Arrange
            string serialNumber = "test";
            DateTime dateOfArrival = new(1960, 12, 28);
            DateTime dateOfArrival2 = new(1965, 11, 29);

            // Act
            Item item1 = new(serialNumber, dateOfArrival);
            Item item2 = new(serialNumber, dateOfArrival2);

            // Assert
            Assert.AreEqual(item1, item2);
        }

        [TestMethod]
        public void GetHashOverrideTest()
        {
            // Arrange
            string serialNumber = "test";
            DateTime dateOfArrival = new(1960, 12, 28);
            DateTime dateOfArrival2 = new(1965, 11, 29);

            // Act
            Item item1 = new(serialNumber, dateOfArrival);
            Item item2 = new(serialNumber, dateOfArrival2);

            // Assert
            Assert.AreEqual(item1.GetHashCode(), item2.GetHashCode());
        }
    }
}
