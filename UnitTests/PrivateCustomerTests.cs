namespace Classes
{
    [TestClass]
    public class PrivateCustomerTests
    {
        [TestMethod]
        public void DefautlConstructorTest()
        {
            // Arrange

            // Act
            PrivateCustomer privateCustomer = new();

            // Assert
            Assert.AreEqual(privateCustomer.FirstName, string.Empty);
            Assert.AreEqual(privateCustomer.LastName, string.Empty);
            Assert.AreEqual(privateCustomer.Country, string.Empty);
            Assert.AreEqual(privateCustomer.City, string.Empty);
            Assert.AreEqual(privateCustomer.Street, string.Empty);
            Assert.AreEqual(privateCustomer.ZipCode, "00-000");
            Assert.AreEqual(privateCustomer.PhoneNumber,
                new string('0', 9));
            Assert.AreEqual(privateCustomer.Email, string.Empty);
            Assert.IsTrue(privateCustomer.Orders.Count == 0);
        }

        [TestMethod]
        public void StaticIdTest()
        {
            // Arrange
            int temp = Customer.CurrentId;
            int result;

            // Act
            _ = new PrivateCustomer();
            result = Customer.CurrentId - temp;

            // Assert
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void IdTest()
        {
            // Arrange
            int diff;

            // Act
            PrivateCustomer privateCustomer1 = new();
            PrivateCustomer privateCustomer2 = new();
            diff = privateCustomer1.Id - privateCustomer2.Id;

            // Assert
            Assert.AreEqual(diff, 1);
        }

        [TestMethod]
        public void CreationTest()
        {
            // Arrange
            string firstName = "Cezary";
            string lastName = "Moskal";
            string country = "Polandia bruh";
            string city = "Łódź";
            string street = "Słowiańska";
            string zipCode = "26-086";
            string phoneNumber = "652548943";
            string email = "xd@gmail.com";
            string password = "samolot123";

            // Act
            PrivateCustomer privateCustomer = new(firstName, lastName,
                country, city, street, zipCode, phoneNumber,
                email, password);

            // Assert
            Assert.AreEqual(privateCustomer.FirstName, firstName);
            Assert.AreEqual(privateCustomer.LastName, lastName);
            Assert.AreEqual(privateCustomer.Country, country);
            Assert.AreEqual(privateCustomer.City, city);
            Assert.AreEqual(privateCustomer.Street, street);
            Assert.AreEqual(privateCustomer.ZipCode, zipCode);
            Assert.AreEqual(privateCustomer.PhoneNumber, phoneNumber);
            Assert.AreEqual(privateCustomer.Email, email);
            Assert.AreEqual(privateCustomer.Password, password);
            Assert.IsTrue(privateCustomer.Orders.Count == 0);
        }

        [TestMethod]
        public void FirstNameTest()
        {
            // Arrange
            string firstName = "cezary";
            string firstName2 = "Cez4";
            string lastName = "Moskal";
            string country = "Polandia bruh";
            string city = "Łódź";
            string street = "Słowiańska";
            string zipCode = "26-086";
            string phoneNumber = "652548943";
            string email = "xd@gmail.com";
            string password = "samolot123";

            // Act

            // Assert
            Assert.ThrowsException<WrongNameException>(() =>
            {
                PrivateCustomer privateCustomer = new(firstName,
                    lastName, country, city, street, zipCode,
                    phoneNumber, email, password);
            });
            Assert.ThrowsException<WrongNameException>(() =>
            {
                PrivateCustomer privateCustomer = new(firstName2,
                    lastName, country, city, street, zipCode,
                    phoneNumber, email, password);
            });
        }

        [TestMethod]
        public void LastNameTest()
        {
            // Arrange
            string firstName = "Cezary";
            string lastName = "moskal";
            string lastName2 = "mos4t";
            string country = "Polandia bruh";
            string city = "Łódź";
            string street = "Słowiańska";
            string zipCode = "26-086";
            string phoneNumber = "652548943";
            string email = "xd@gmail.com";
            string password = "samolot123";

            // Act

            // Assert
            Assert.ThrowsException<WrongNameException>(() =>
            {
                PrivateCustomer privateCustomer = new(firstName,
                    lastName, country, city, street, zipCode,
                    phoneNumber, email, password);
            });
            Assert.ThrowsException<WrongNameException>(() =>
            {
                PrivateCustomer privateCustomer = new(firstName,
                    lastName2, country, city, street, zipCode,
                    phoneNumber, email, password);
            });
        }
    }
}
