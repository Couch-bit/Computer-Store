namespace Classes
{
    [TestClass]
    public class SoftwareTests
    {
        [TestMethod]
        public void DefaultConstructorTest()
        {
            // Arrange

            // Act
            Software software = new();

            // Assert
            Assert.AreEqual(software.Version, string.Empty);
            Assert.AreEqual(software.License, TimeSpan.Zero);
            Assert.AreEqual(software.TargetArchitecture,
                Architecture.Bit64);
            Assert.AreEqual(software.Name, string.Empty);
            Assert.AreEqual(software.Description, string.Empty);
            Assert.AreEqual(software.Discount, 0);
            Assert.AreEqual(software.Price, 0);
            Assert.AreEqual(software.Vat, 0);
            Assert.IsTrue(software.Technical_info.Count == 0);
            Assert.IsTrue(software.Items.Count == 0);
        }

        [TestMethod]
        public void StaticIdTest()
        {
            // Arrange
            int temp = Product.CurrentId;
            int result;

            // Act
            _ = new Software();
            result = Product.CurrentId - temp;

            // Assert
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void IdTest()
        {
            // Arrange
            int diff;

            // Act
            Software software1 = new();
            Software software2 = new();
            diff = software2.Id - software1.Id;

            // Assert
            Assert.AreEqual(diff, 1);
        }

        [TestMethod]
        public void CreationTest()
        {
            // Arrange
            string version = "standard";
            TimeSpan license = TimeSpan.FromDays(365);
            Architecture targetArchitecture = Architecture.Bit32;
            string name = "test";
            string description = "desc";
            decimal discount = 0.5M;
            decimal price = 1;
            decimal vat = 0.23M;

            // Act
            Software software = new(version, license,
                targetArchitecture, name, description,
                discount, price, vat);

            // Assert
            Assert.AreEqual(software.Version, version);
            Assert.AreEqual(software.License, license);
            Assert.AreEqual(software.TargetArchitecture,
                targetArchitecture);
            Assert.AreEqual(software.Name, name);
            Assert.AreEqual(software.Description, description);
            Assert.AreEqual(software.Discount, discount);
            Assert.AreEqual(software.Price, price);
            Assert.AreEqual(software.Vat, vat);
            Assert.IsTrue(software.Technical_info.Count == 0);
            Assert.IsTrue(software.Items.Count == 0);
        }

        [TestMethod]
        public void DiscountTest()
        {
            // Arrange
            string version = "standard";
            TimeSpan license = TimeSpan.FromDays(365);
            Architecture targetArchitecture = Architecture.Bit32;
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
                Software software = new(version, license,
                    targetArchitecture, name, description,
                    discount, price, vat);
            });
            Assert.ThrowsException<NumericException>(() =>
            {
                Software software = new(version, license,
                    targetArchitecture, name, description,
                    discount2, price, vat);
            });
        }

        [TestMethod]
        public void PriceTest()
        {
            // Arrange
            string version = "standard";
            TimeSpan license = TimeSpan.FromDays(365);
            Architecture targetArchitecture = Architecture.Bit32;
            string name = "test";
            string description = "desc";
            decimal discount = -0.2M;
            decimal price = -0.1M;
            decimal vat = 0.23M;

            // Act

            // Assert
            Assert.ThrowsException<NumericException>(() =>
            {
                Software software = new(version, license,
                    targetArchitecture, name, description,
                    discount, price, vat);
            });
        }

        [TestMethod]
        public void VatTest()
        {
            // Arrange
            string version = "standard";
            TimeSpan license = TimeSpan.FromDays(365);
            Architecture targetArchitecture = Architecture.Bit32;
            string name = "test";
            string description = "desc";
            decimal discount = 0;
            decimal price = 0;
            decimal vat = 0.04M;

            // Act

            // Assert
            Assert.ThrowsException<NumericException>(() =>
            {
                Software soffware = new(version, license,
                    targetArchitecture, name, description,
                    discount, price, vat);
            });
        }
    }
}