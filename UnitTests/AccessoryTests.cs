namespace Classes
{
    [TestClass]
    public class AccessoryTests
    {
        [TestMethod]
        public void DefaultConstructorTest()
        {
            // Arrange

            // Act
            Accessory accessory = new();

            // Assert
            Assert.AreEqual(accessory.Weight, 0);
            Assert.AreEqual(accessory.Type, AccessoryType.Headphones);
            Assert.AreEqual(accessory.Name, string.Empty);
            Assert.AreEqual(accessory.Description, string.Empty);
            Assert.AreEqual(accessory.Discount, 0);
            Assert.AreEqual(accessory.Price, 0);
            Assert.AreEqual(accessory.Vat, 0);
            Assert.IsTrue(accessory.Technical_info.Count == 0);
            Assert.IsTrue(accessory.Items.Count == 0);
        }

        [TestMethod]
        public void StaticIdTest()
        {
            // Arrange
            int temp = Product.CurrentId;

            // Act
            _ = new Accessory();
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
            Accessory accessory1 = new();
            Accessory accessory2 = new();
            diff = accessory2.Id - accessory1.Id;

            // Assert
            Assert.AreEqual(diff, 1);
        }

        [TestMethod]
        public void CreationTest()
        {
            // Arrange
            double weight = 5;
            AccessoryType type = AccessoryType.Microphone;
            string name = "test";
            string description = "desc";
            decimal discount = 0.5M;
            decimal price = 1;
            decimal vat = 0.23M;

            // Act
            Accessory accessory = new(weight, type,
                name, description,
                discount, price, vat);

            // Assert
            Assert.AreEqual(accessory.Weight, weight);
            Assert.AreEqual(accessory.Type, type);
            Assert.AreEqual(accessory.Name, name);
            Assert.AreEqual(accessory.Description, description);
            Assert.AreEqual(accessory.Discount, discount);
            Assert.AreEqual(accessory.Price, price);
            Assert.AreEqual(accessory.Vat, vat);
            Assert.IsTrue(accessory.Technical_info.Count == 0);
            Assert.IsTrue(accessory.Items.Count == 0);
        }

        [TestMethod]
        public void DiscountTest()
        {
            // Arrange
            double weight = 5;
            AccessoryType type = AccessoryType.Microphone;
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
                Accessory accessory = new(weight, type,
                    name, description,
                    discount, price, vat);
            });
            Assert.ThrowsException<NumericException>(() =>
            {
                Accessory accessory = new(weight, type,
                    name, description,
                    discount2, price, vat);
            });
        }

        [TestMethod]
        public void PriceTest()
        {
            // Arrange
            double weight = 5;
            AccessoryType type = AccessoryType.Microphone;
            string name = "test";
            string description = "desc";
            decimal discount = -0.2M;
            decimal price = -0.1M;
            decimal vat = 0.23M;

            // Act

            // Assert
            Assert.ThrowsException<NumericException>(() =>
            {
                Accessory accessory = new(weight, type,
                    name, description,
                    discount, price, vat);
            });
        }

        [TestMethod]
        public void VatTest()
        {
            // Arrange
            double weight = 5;
            AccessoryType type = AccessoryType.Microphone;
            string name = "test";
            string description = "desc";
            decimal discount = 0;
            decimal price = 0;
            decimal vat = 0.04M;

            // Act

            // Assert
            Assert.ThrowsException<NumericException>(() =>
            {
                Accessory accessory = new(weight, type,
                    name, description,
                    discount, price, vat);
            });
        }
    }
}