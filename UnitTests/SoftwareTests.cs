using Classes;

namespace UnitTests
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

        [TestMethod]
        public void GetTotalPriceTest()
        {
            // Arrange
            string version = "standard";
            TimeSpan license = TimeSpan.FromDays(365);
            Architecture targetArchitecture = Architecture.Bit32;
            string name = "test";
            string description = "desc";
            decimal discount = 0.2M;
            decimal price = 1;
            decimal vat = 0.23M;
            decimal actualPrice;

            // Act
            Software software = new(version, license,
                targetArchitecture,
                name, description, discount, price, vat);
            actualPrice = software.GetTotalPrice();

            // Assert
            Assert.AreEqual(actualPrice, (1 - discount) *
                price * (1 + vat));
        }

        [TestMethod]
        public void GetCountBaseTest()
        {
            // Arrange
            int count;

            // Act
            Software software = new();
            count = software.GetCount();

            // Assert
            Assert.AreEqual(count, 0);
        }

        [TestMethod]
        public void AddItemTest()
        {
            // Arrange
            Item item = new("test", new DateTime(1960, 2, 28));

            // Act
            Software software = new();
            software.AddItem(item);

            // Assert
            Assert.IsTrue(software.Items.Contains(item));
        }

        [TestMethod]
        public void AddItemFailTest()
        {
            // Arrange
            Item item = new("test", new DateTime(1960, 2, 28));

            // Act
            Software software = new();
            software.AddItem(item);

            // Assert
            Assert.ThrowsException<DuplicateException>(() =>
            software.AddItem(item));
        }

        [TestMethod]
        public void DeleteItemTest()
        {
            // Arrange
            Item item = new("test", new DateTime(1960, 2, 28));
            Item item2 = new("tester", new DateTime(1960, 2, 29));

            // Act
            Software software = new();
            software.AddItem(item);
            software.AddItem(item2);
            software.RemoveItem(item);

            // Assert
            Assert.IsFalse(software.Items.Contains(item));
            Assert.IsTrue(software.Items.Contains(item2));
        }

        [TestMethod]
        public void DeleteItemFailTest()
        {
            // Arrange
            Item item = new("test", new DateTime(1960, 2, 28));
            Item item2 = new("tester", new DateTime(1960, 2, 29));

            // Act
            Software software = new();
            software.AddItem(item);

            // Assert
            Assert.ThrowsException<WrongKeyException>(() =>
            {
                software.RemoveItem(item2);
            });
        }

        [TestMethod]
        public void GetCountTest()
        {
            // Arrange
            Item item = new("test", new DateTime(1960, 2, 28));
            Item item2 = new("tester", new DateTime(1960, 2, 29));
            int count;

            // Act
            Software software = new();
            software.AddItem(item);
            software.AddItem(item2);
            software.RemoveItem(item);
            count = software.GetCount();

            // Assert
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void AddTechnicalInfoTest()
        {
            // Arrange
            string key = "type";
            string value = "test";
            string key2 = "assertion";
            string value2 = "testing";

            // Act
            Software software = new();
            software.AddTechnicalInfo(key, value);
            software.AddTechnicalInfo(key2, value2);

            // Assert
            Assert.AreEqual(software.Technical_info[key], value);
            Assert.AreEqual(software.Technical_info[key2], value2);
        }

        [TestMethod]
        public void AddTechnicalInfoFailTest()
        {
            // Arrange
            string key = "type";
            string value = "test";
            string key2 = "type";
            string value2 = "testing";

            // Act
            Software software = new();
            software.AddTechnicalInfo(key, value);


            // Assert
            Assert.ThrowsException<WrongKeyException>(() =>
            {
                software.AddTechnicalInfo(key2, value2);
            });
        }

        [TestMethod]
        public void EditTechnicalInfoTest()
        {
            // Arrange
            string key = "type";
            string value = "test";
            string value2 = "testing";

            // Act
            Software software = new();
            software.AddTechnicalInfo(key, value);
            software.EditTechnicalInfo(key, value2);

            // Assert
            Assert.AreEqual(software.Technical_info[key], value2);
        }

        [TestMethod]
        public void EditTechnicalInfoFailTest()
        {
            // Arrange
            string key = "type";
            string value = "test";
            string key2 = "type2";
            string value2 = "testing";

            // Act
            Software software = new();
            software.AddTechnicalInfo(key, value);

            // Assert
            Assert.ThrowsException<WrongKeyException>(() =>
            {
                software.EditTechnicalInfo(key2, value2);
            });
        }

        [TestMethod]
        public void DeleteTechnicalInfoTest()
        {
            // Arrange
            string key = "type";
            string value = "test";
            string key2 = "typer";
            string value2 = "nottest";
            string key3 = "typest";
            string value3 = "hmmm";

            // Act
            Software software = new();
            software.AddTechnicalInfo(key, value);
            software.AddTechnicalInfo(key2, value2);
            software.AddTechnicalInfo(key3, value3);
            software.DeleteTechnicalInfo(key2);

            // Assert
            Assert.IsFalse(software.Technical_info.ContainsKey(key2));
        }

        [TestMethod]
        public void DeleteTechnicalInfoFailTest()
        {
            // Arrange
            string key = "type";
            string value = "test";
            string key2 = "foo";

            // Act
            Software software = new();
            software.AddTechnicalInfo(key, value);

            // Assert
            Assert.ThrowsException<WrongKeyException>(() =>
            {
                software.DeleteTechnicalInfo(key2);
            });
        }

        [TestMethod]
        public void ToStringTest()
        {
            // Arrange
            string version = "standard";
            TimeSpan license = TimeSpan.FromDays(365);
            Architecture targetArchitecture = Architecture.Bit32;
            string name = "test";
            string description = "desc";
            decimal discount = 0.2M;
            decimal price = 1;
            decimal vat = 0.23M;
            string text;
            string result;

            // Act
            Software software = new(version, license,
                targetArchitecture, name, description,
                discount, price, vat);
            text = $"{name}, {software.GetCount()} " +
                $"price: {software.GetTotalPrice():c}";
            text += $" <-{discount:P} OFF!>";
            text += $" ({version} " +
                $"{targetArchitecture}, license: {license.TotalDays} days)";
            result = software.ToString();

            // Assert
            Assert.AreEqual(result, text);
        }
    }
}