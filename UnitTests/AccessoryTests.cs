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

        [TestMethod]
        public void GetTotalPriceTest()
        {
            // Arrange
            double weight = 5;
            AccessoryType type = AccessoryType.Microphone;
            string name = "test";
            string description = "desc";
            decimal discount = 0.5M;
            decimal price = 1;
            decimal vat = 0.23M;
            decimal actualPrice;

            // Act
            Accessory accessory = new(weight, type, 
                name, description, discount, price, vat);
            actualPrice = accessory.GetTotalPrice();

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
            Accessory accessory = new();
            count = accessory.GetCount();

            // Assert
            Assert.AreEqual(count, 0);
        }

        [TestMethod]
        public void AddItemTest()
        {
            // Arrange
            Item item = new("test", new DateTime(1960, 2, 28));

            // Act
            Accessory accessory = new();
            accessory.AddItem(item);

            // Assert
            Assert.IsTrue(accessory.Items.Contains(item));
        }

        [TestMethod]
        public void AddItemFailTest()
        {
            // Arrange
            Item item = new("test", new DateTime(1960, 2, 28));

            // Act
            Accessory accessory = new();
            accessory.AddItem(item);

            // Assert
            Assert.ThrowsException<DuplicateException>(() =>
            accessory.AddItem(item));
        }

        [TestMethod]
        public void DeleteItemTest()
        {
            // Arrange
            Item item = new("test", new DateTime(1960, 2, 28));
            Item item2 = new("tester", new DateTime(1960, 2, 29));

            // Act
            Accessory accessory = new();
            accessory.AddItem(item);
            accessory.AddItem(item2);
            accessory.RemoveItem(item);

            // Assert
            Assert.IsFalse(accessory.Items.Contains(item));
            Assert.IsTrue(accessory.Items.Contains(item2));
        }

        [TestMethod]
        public void DeleteItemFailTest()
        {
            // Arrange
            Item item = new("test", new DateTime(1960, 2, 28));
            Item item2 = new("tester", new DateTime(1960, 2, 29));

            // Act
            Accessory accessory = new();
            accessory.AddItem(item);

            // Assert
            Assert.ThrowsException<WrongKeyException>(() =>
            {
                accessory.RemoveItem(item2);
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
            Accessory accessory = new();
            accessory.AddItem(item);
            accessory.AddItem(item2);
            accessory.RemoveItem(item);
            count = accessory.GetCount();

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
            Accessory accessory = new();
            accessory.AddTechnicalInfo(key, value);
            accessory.AddTechnicalInfo(key2, value2);

            // Assert
            Assert.AreEqual(accessory.Technical_info[key], value);
            Assert.AreEqual(accessory.Technical_info[key2], value2);
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
            Accessory accessory = new();
            accessory.AddTechnicalInfo(key, value);


            // Assert
            Assert.ThrowsException<WrongKeyException>(() =>
            {
                accessory.AddTechnicalInfo(key2, value2);
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
            Accessory accessory = new();
            accessory.AddTechnicalInfo(key, value);
            accessory.EditTechnicalInfo(key, value2);

            // Assert
            Assert.AreEqual(accessory.Technical_info[key], value2);
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
            Accessory accessory = new();
            accessory.AddTechnicalInfo(key, value);

            // Assert
            Assert.ThrowsException<WrongKeyException>(() =>
            {
                accessory.EditTechnicalInfo(key2, value2);
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
            Accessory accessory = new();
            accessory.AddTechnicalInfo(key, value);
            accessory.AddTechnicalInfo(key2, value2);
            accessory.AddTechnicalInfo(key3, value3);
            accessory.DeleteTechnicalInfo(key2);

            // Assert
            Assert.IsFalse(accessory.Technical_info.ContainsKey(key2));
        }

        [TestMethod]
        public void DeleteTechnicalInfoFailTest()
        {
            // Arrange
            string key = "type";
            string value = "test";
            string key2 = "foo";

            // Act
            Accessory accessory = new();
            accessory.AddTechnicalInfo(key, value);

            // Assert
            Assert.ThrowsException<WrongKeyException>(() =>
            {
                accessory.DeleteTechnicalInfo(key2);
            });
        }

        [TestMethod]
        public void ToStringTest()
        {
            // Arrange
            double weight = 5;
            AccessoryType type = AccessoryType.Microphone;
            string name = "test";
            string description = "desc";
            decimal discount = 0.5M;
            decimal price = 1;
            decimal vat = 0.23M;
            string text;
            string result;

            // Act
            Accessory accessory = new(weight, type,
                name, description, discount, price, vat);
            text = $"{name} (Id : {accessory.Id}), " +
                $"price: {accessory.GetTotalPrice():c}";
            text += $" <-{discount:P} OFF!>";
            text += $" ({type})";
            result = accessory.ToString();

            // Assert
            Assert.AreEqual(result, text);
        }
    }
}