namespace Classes
{
    [TestClass]
    public class HardwareTests
    {
        [TestMethod]
        public void DefaultConstructorTest()
        {
            // Arrange

            // Act
            Hardware hardware = new();

            // Assert
            Assert.AreEqual(hardware.Height, 0);
            Assert.AreEqual(hardware.Width, 0);
            Assert.AreEqual(hardware.Length, 0);
            Assert.AreEqual(hardware.Weight, 0);
            Assert.AreEqual(hardware.Type, HardwareType.GPU);
            Assert.AreEqual(hardware.Price, 0);
            Assert.AreEqual(hardware.Discount, 0);
            Assert.AreEqual(hardware.Vat, 0);
            Assert.AreEqual(hardware.Name, string.Empty);
            Assert.AreEqual(hardware.Description, string.Empty);
        }
    }
}
