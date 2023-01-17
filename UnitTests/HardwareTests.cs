using System.Xml.Linq;

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
            Assert.IsFalse(hardware.Technical_info.Any());
            Assert.IsFalse(hardware.Items.Any());
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

        [TestMethod]
        public void GetTotalPriceTest()
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
            decimal actualPrice;

            // Act
            Hardware hardware = new(weight, length, height, width,
                type, name, description, discount, price, vat);
            actualPrice = hardware.GetTotalPrice();

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
            Hardware hardware = new();
            count = hardware.GetCount();

            // Assert
            Assert.AreEqual(count, 0);
        }

        [TestMethod]
        public void AddItemTest()
        {
            // Arrange
            Item item = new("test", new DateTime(1960, 2, 28));

            // Act
            Hardware hardware = new();
            hardware.AddItem(item);

            // Assert
            Assert.IsTrue(hardware.Items.Contains(item));
        }

        [TestMethod]
        public void AddItemFailTest()
        {
            // Arrange
            Item item = new("test", new DateTime(1960, 2, 28));

            // Act
            Hardware hardware = new();
            hardware.AddItem(item);

            // Assert
            Assert.ThrowsException<DuplicateException>(() => 
            hardware.AddItem(item));
        }

        [TestMethod]
        public void DeleteItemTest()
        {
            // Arrange
            Item item = new("test", new DateTime(1960, 2, 28));
            Item item2 = new("tester", new DateTime(1960, 2, 29));

            // Act
            Hardware hardware = new();
            hardware.AddItem(item);
            hardware.AddItem(item2);
            hardware.RemoveItem(item);

            // Assert
            Assert.IsFalse(hardware.Items.Contains(item));
            Assert.IsTrue(hardware.Items.Contains(item2));
        }

        [TestMethod]
        public void DeleteItemFailTest()
        {
            // Arrange
            Item item = new("test", new DateTime(1960, 2, 28));
            Item item2 = new("tester", new DateTime(1960, 2, 29));

            // Act
            Hardware hardware = new();
            hardware.AddItem(item);

            // Assert
            Assert.ThrowsException<WrongKeyException>(() =>
            {
                hardware.RemoveItem(item2);
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
            Hardware hardware = new();
            hardware.AddItem(item);
            hardware.AddItem(item2);
            hardware.RemoveItem(item);
            count = hardware.GetCount();

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
            Hardware hardware = new();
            hardware.AddTechnicalInfo(key, value);
            hardware.AddTechnicalInfo(key2, value2);

            // Assert
            Assert.AreEqual(hardware.Technical_info[key], value);
            Assert.AreEqual(hardware.Technical_info[key2], value2);
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
            Hardware hardware = new();
            hardware.AddTechnicalInfo(key, value);


            // Assert
            Assert.ThrowsException<WrongKeyException>(() =>
            {
                hardware.AddTechnicalInfo(key2, value2);
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
            Hardware hardware = new();
            hardware.AddTechnicalInfo(key, value);
            hardware.EditTechnicalInfo(key, value2);

            // Assert
            Assert.AreEqual(hardware.Technical_info[key], value2);
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
            Hardware hardware = new();
            hardware.AddTechnicalInfo(key, value);

            // Assert
            Assert.ThrowsException<WrongKeyException>(() =>
            {
                hardware.EditTechnicalInfo(key2, value2);
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
            Hardware hardware = new();
            hardware.AddTechnicalInfo(key, value);
            hardware.AddTechnicalInfo(key2, value2);
            hardware.AddTechnicalInfo(key3, value3);
            hardware.DeleteTechnicalInfo(key2);

            // Assert
            Assert.IsFalse(hardware.Technical_info.ContainsKey(key2));
        }

        [TestMethod]
        public void DeleteTechnicalInfoFailTest()
        {
            // Arrange
            string key = "type";
            string value = "test";
            string key2 = "foo";

            // Act
            Hardware hardware = new();
            hardware.AddTechnicalInfo(key, value);

            // Assert
            Assert.ThrowsException<WrongKeyException>(() =>
            {
                hardware.DeleteTechnicalInfo(key2);
            });
        }

        [TestMethod]
        public void ToStringTest()
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
            string text;
            string result;

            // Act
            Hardware hardware = new(weight, length, height, width,
                type, name, description, discount, price, vat);
            text = $"{name} (Id : {hardware.Id}), " +
                $"price: {hardware.GetTotalPrice():c}";
            text += $" <-{discount:P} OFF!>";
            text += $" ({type})";
            result = hardware.ToString();

            // Assert
            Assert.AreEqual(result, text);   
        }
    }
}