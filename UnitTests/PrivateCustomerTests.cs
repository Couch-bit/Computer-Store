using Classes;

namespace UnitTests
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
                "000-000-000");
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
            diff = privateCustomer2.Id - privateCustomer1.Id;

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
            string street = "Słowiańska 8";
            string zipCode = "26-086";
            string phoneNumber = "652-548-943";
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
            string street = "Słowiańska 7";
            string zipCode = "26-086";
            string phoneNumber = "652-548-943";
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
            string street = "Słowiańska 6";
            string zipCode = "26-086";
            string phoneNumber = "652-548-943";
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

        [TestMethod]
        public void CountryTest()
        {
            // Arrange
            string firstName = "Cezary";
            string lastName = "Moskal";
            string country = "USA3";
            string country2 = "kongo";
            string city = "Łódź";
            string street = "Słowiańska 7";
            string zipCode = "26-086";
            string phoneNumber = "652-548-943";
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
                    lastName, country2, city, street, zipCode,
                    phoneNumber, email, password);
            });
        }

        [TestMethod]
        public void CityTest()
        {
            // Arrange
            string firstName = "Cezary";
            string lastName = "Moskal";
            string country = "Polandia";
            string city = "łódź";
            string city2 = "Op0le";
            string street = "Słowiańska 4";
            string zipCode = "26-086";
            string phoneNumber = "652-548-943";
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
                    lastName, country, city2, street, zipCode,
                    phoneNumber, email, password);
            });
        }

        [TestMethod]
        public void StreetTest()
        {
            // Arrange
            string firstName = "Cezary";
            string lastName = "Moskal";
            string country = "Polandia";
            string city = "Łódź";
            string street = "słowiańska 1";
            string street2 = "Słow1ańska 5";
            string zipCode = "26-086";
            string phoneNumber = "652-548-943";
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
                    lastName, country, city, street2, zipCode,
                    phoneNumber, email, password);
            });
        }

        [TestMethod]
        public void ZipCodeTest()
        {
            // Arrange
            string firstName = "Cezary";
            string lastName = "Moskal";
            string country = "Polandia";
            string city = "Łódź";
            string street = "Słowiańska 3";
            string zipCode = "26-0860";
            string zipCode2 = "245-89";
            string zipCode3 = "24R-56";
            string phoneNumber = "652-548-943";
            string email = "xd@gmail.com";
            string password = "samolot123";

            // Act

            // Assert
            Assert.ThrowsException<WrongZipCodeException>(() =>
            {
                PrivateCustomer privateCustomer = new(firstName,
                    lastName, country, city, street, zipCode,
                    phoneNumber, email, password);
            });
            Assert.ThrowsException<WrongZipCodeException>(() =>
            {
                PrivateCustomer privateCustomer = new(firstName,
                    lastName, country, city, street, zipCode2,
                    phoneNumber, email, password);
            });
            Assert.ThrowsException<WrongZipCodeException>(() =>
            {
                PrivateCustomer privateCustomer = new(firstName,
                    lastName, country, city, street, zipCode3,
                    phoneNumber, email, password);
            });
        }

        [TestMethod]
        public void PhoneNumberTest()
        {
            // Arrange
            string firstName = "Cezary";
            string lastName = "Moskal";
            string country = "Polandia";
            string city = "Łódź";
            string street = "Słowiańska 5";
            string zipCode = "26-086";
            string phoneNumber = "652-548-9434";
            string phoneNumber2 = "652548943";
            string phoneNumber3 = "652-548-9t4";
            string email = "xd@gmail.com";
            string password = "samolot123";

            // Act

            // Assert
            Assert.ThrowsException<PhoneNumberException>(() =>
            {
                PrivateCustomer privateCustomer = new(firstName,
                    lastName, country, city, street, zipCode,
                    phoneNumber, email, password);
            });
            Assert.ThrowsException<PhoneNumberException>(() =>
            {
                PrivateCustomer privateCustomer = new(firstName,
                    lastName, country, city, street, zipCode,
                    phoneNumber2, email, password);
            });
            Assert.ThrowsException<PhoneNumberException>(() =>
            {
                PrivateCustomer privateCustomer = new(firstName,
                    lastName, country, city, street, zipCode,
                    phoneNumber3, email, password);
            });
        }

        [TestMethod]
        public void EmailTest()
        {
            // Arrange
            string firstName = "Cezary";
            string lastName = "Moskal";
            string country = "Polandia";
            string city = "Łódź";
            string street = "Słowiańska 6";
            string zipCode = "26-086";
            string phoneNumber = "652-548-943";
            string email = "xdgmail.com";
            string email2 = "@gmail.com";
            string email3 = "xd@gmailcom";
            string password = "samolot123";

            // Act

            // Assert
            Assert.ThrowsException<WrongEmailException>(() =>
            {
                PrivateCustomer privateCustomer = new(firstName,
                    lastName, country, city, street, zipCode,
                    phoneNumber, email, password);
            });
            Assert.ThrowsException<WrongEmailException>(() =>
            {
                PrivateCustomer privateCustomer = new(firstName,
                    lastName, country, city, street, zipCode,
                    phoneNumber, email2, password);
            });
            Assert.ThrowsException<WrongEmailException>(() =>
            {
                PrivateCustomer privateCustomer = new(firstName,
                    lastName, country, city, street, zipCode,
                    phoneNumber, email3, password);
            });
        }

        [TestMethod]
        public void ToStringTest()
        {
            // Arrange
            string firstName = "Cezary";
            string lastName = "Moskal";
            string country = "Polandia bruh";
            string city = "Łódź";
            string street = "Słowiańska 8";
            string zipCode = "26-086";
            string phoneNumber = "652-548-943";
            string email = "xd@gmail.com";
            string password = "samolot123";

            // Act
            PrivateCustomer privateCustomer = new(firstName, lastName,
                country, city, street, zipCode, phoneNumber,
                email, password);

            // Assert
            Assert.AreEqual($"Private Customer: " +
                $"{firstName} {lastName}", privateCustomer.ToString());
        }
    }
}