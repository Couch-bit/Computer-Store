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
            Assert.AreEqual(hardware.Weight, 0);
            Assert.AreEqual(hardware.Length, 0);
            Assert.AreEqual(hardware.Height, 0);
            Assert.AreEqual(hardware.Width, 0);
            Assert.AreEqual(hardware.Type, HardwareType.GPU);
            Assert.AreEqual(hardware.Name, string.Empty);
            Assert.AreEqual(hardware.Description, string.Empty);
            Assert.AreEqual(hardware.Discount, 0);
            Assert.AreEqual(hardware.Price, 0);
            Assert.AreEqual(hardware.Vat, 0);
            Assert.IsTrue(hardware.Technical_info.Count == 0);
            Assert.IsTrue(hardware.Items.Count == 0);
        }

        [TestMethod]
        public void StaticIdTest()
        {
            // Arrange
            int temp = Product.CurrentId;

            // Act
            _ = new Hardware();
            int result = Product.CurrentId - temp;

            // Assert
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void IdTest()
        {
            // Arrange
            int diff;

            // Act
            Hardware hardware1 = new();
            Hardware hardware2 = new();
            diff = hardware2.Id - hardware1.Id;

            // Assert
            Assert.AreEqual(diff, 1);
        }

        [TestMethod]
        public void CreationTest()
        {
            // Arrange
            double weight = 1;
            double length = 1;
            double height = 1;
            double width = 1;
            HardwareType type = HardwareType.CPU;
            string name = "test";
            string description = "desc";
            decimal discount = 0.5M;
            decimal price = 1;
            decimal vat = 0.23M;

            // Act
            Hardware hardware = new(weight, length, height, width,
                type, name, description, discount, price, vat);

            // Assert
            Assert.AreEqual(hardware.Weight, weight);
            Assert.AreEqual(hardware.Length, length);
            Assert.AreEqual(hardware.Height, height);
            Assert.AreEqual(hardware.Width, width);
            Assert.AreEqual(hardware.Type, type);
            Assert.AreEqual(hardware.Name, name);
            Assert.AreEqual(hardware.Description, description);
            Assert.AreEqual(hardware.Discount, discount);
            Assert.AreEqual(hardware.Price, price);
            Assert.AreEqual(hardware.Vat, vat);
            Assert.IsTrue(hardware.Technical_info.Count == 0);
            Assert.IsTrue(hardware.Items.Count == 0);
        }

        [TestMethod]
        public void DiscountTest()
        {
            // Arrange
            double weight = 1;
            double length = 1;
            double height = 1;
            double width = 1;
            HardwareType type = HardwareType.CPU;
            string name = "test";
            string description = "desc";
            decimal discount = -0.2M;
            decimal discount2 = 2;
            decimal price = 1;
            decimal vat = 0.23M;

            // Act

            // Assert
            Assert.ThrowsException<NumericException>(() =>
            {
                Hardware hardware = new(weight, length,
                    height, width, type, name, description,
                    discount, price, vat);
            });
            Assert.ThrowsException<NumericException>(() =>
            {
                Hardware hardware = new(weight, length,
                    height, width, type, name, description,
                    discount2, price, vat);
            });
        }

        [TestMethod]
        public void PriceTest()
        {
            // Arrange
            double weight = 1;
            double length = 1;
            double height = 1;
            double width = 1;
            HardwareType type = HardwareType.CPU;
            string name = "test";
            string description = "desc";
            decimal discount = 0;
            decimal price = -0.1M;
            decimal vat = 0.23M;

            // Act

            // Assert
            Assert.ThrowsException<NumericException>(() =>
            {
                Hardware hardware = new(weight, length,
                    height, width, type, name, description,
                    discount, price, vat);
            });
        }

        [TestMethod]
        public void VatTest()
        {
            // Arrange
            double weight = 1;
            double length = 1;
            double height = 1;
            double width = 1;
            HardwareType type = HardwareType.CPU;
            string name = "test";
            string description = "desc";
            decimal discount = 0;
            decimal price = 0;
            decimal vat = 0.04M;

            // Act

            // Assert
            Assert.ThrowsException<NumericException>(() =>
            {
                Hardware hardware = new(weight, length,
                    height, width, type, name, description,
                    discount, price, vat);
            });
        }

        [TestMethod]
        public void WeightTest()
        {
            // Arrange
            double weight = -1;
            double length = 1;
            double height = 1;
            double width = 1;
            HardwareType type = HardwareType.CPU;
            string name = "test";
            string description = "desc";
            decimal discount = 0.5M;
            decimal price = 1;
            decimal vat = 0.23M;

            // Act

            // Assert
            Assert.ThrowsException<WrongParameterException>(() =>
                {
                    Hardware hardware = new(weight, length,
                        height, width, type, name, description,
                        discount, price, vat);
                });
        }

        [TestMethod]
        public void LengthTest()
        {
            // Arrange
            double weight = 1;
            double length = -1;
            double height = 1;
            double width = 1;
            HardwareType type = HardwareType.CPU;
            string name = "test";
            string description = "desc";
            decimal discount = 0.5M;
            decimal price = 1;
            decimal vat = 0.23M;

            // Act

            // Assert
            Assert.ThrowsException<WrongParameterException>(() =>
            {
                Hardware hardware = new(weight, length,
                    height, width, type, name, description,
                    discount, price, vat);
            });
        }

        [TestMethod]
        public void HeightTest()
        {
            // Arrange
            double weight = 1;
            double length = 1;
            double height = -1;
            double width = 1;
            HardwareType type = HardwareType.CPU;
            string name = "test";
            string description = "desc";
            decimal discount = 0.5M;
            decimal price = 1;
            decimal vat = 0.23M;

            // Act

            // Assert
            Assert.ThrowsException<WrongParameterException>(() =>
            {
                Hardware hardware = new(weight, length,
                    height, width, type, name, description,
                    discount, price, vat);
            });
        }

        [TestMethod]
        public void WidthTest()
        {
            // Arrange
            double weight = 1;
            double length = 1;
            double height = 1;
            double width = -1;
            HardwareType type = HardwareType.CPU;
            string name = "test";
            string description = "desc";
            decimal discount = 0.5M;
            decimal price = 1;
            decimal vat = 0.23M;

            // Act

            // Assert
            Assert.ThrowsException<WrongParameterException>(() =>
            {
                Hardware hardware = new(weight, length,
                    height, width, type, name, description,
                    discount, price, vat);
            });
        }
    }
}
