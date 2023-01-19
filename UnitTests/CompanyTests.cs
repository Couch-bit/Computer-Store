namespace Classes
{
    [TestClass]
    public class CompanyTests
    {
        [TestMethod]
        public void DefaultConstructorTest()
        {
            // Arrange

            // Act
            Company company = new();

            // Assert
            Assert.AreEqual(company.Name, string.Empty);
            Assert.AreEqual(company.Nip, new string('0', 10));
            Assert.AreEqual(company.Country, string.Empty);
            Assert.AreEqual(company.City, string.Empty);
            Assert.AreEqual(company.Street, string.Empty);
            Assert.AreEqual(company.ZipCode, "00-000");
            Assert.AreEqual(company.PhoneNumber,
                "000-000-000");
            Assert.AreEqual(company.Email, string.Empty);
            Assert.IsTrue(company.Orders.Count == 0);
        }

        [TestMethod]
        public void StaticIdTest()
        {
            // Arrange
            int temp = Customer.CurrentId;
            int result;

            // Act
            _ = new Company();
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
            Company company1 = new();
            Company company2 = new();
            diff = company2.Id - company1.Id;

            // Assert
            Assert.AreEqual(diff, 1);
        }

        [TestMethod]
        public void CreationTest()
        {
            // Arrange
            string name = "PGE";
            string nip = "0000000000";
            string country = "Polandia bruh";
            string city = "Łódź";
            string street = "Słowiańska 9";
            string zipCode = "26-086";
            string phoneNumber = "652-548-943";
            string email = "xd@gmail.com";
            string password = "samolot123";

            // Act
            Company company = new(name, nip,
                country, city, street, zipCode, phoneNumber,
                email, password);

            // Assert
            Assert.AreEqual(company.Name, name);
            Assert.AreEqual(company.Nip, nip);
            Assert.AreEqual(company.Country, country);
            Assert.AreEqual(company.City, city);
            Assert.AreEqual(company.Street, street);
            Assert.AreEqual(company.ZipCode, zipCode);
            Assert.AreEqual(company.PhoneNumber, phoneNumber);
            Assert.AreEqual(company.Email, email);
            Assert.AreEqual(company.Password, password);
            Assert.IsTrue(company.Orders.Count == 0);
        }

        [TestMethod]
        public void NipTest()
        {
            // Arrange
            string name = "Cezary";
            string nip = "0000010000";
            string nip2 = "12345678901";
            string nip3 = "045-467-24-12";
            string country = "Polandia bruh";
            string city = "Łódź";
            string street = "Słowiańska 7";
            string zipCode = "26-086";
            string phoneNumber = "652-548-943";
            string email = "xd@gmail.com";
            string password = "samolot123";

            // Act

            // Assert
            Assert.ThrowsException<NipValidationException>(() =>
            {
                Company company = new(name, nip,
                    country, city, street, zipCode,
                    phoneNumber, email, password);
            });
            Assert.ThrowsException<NipValidationException>(() =>
            {
                Company company = new(name, nip2,
                    country, city, street, zipCode,
                    phoneNumber, email, password);
            });
            Assert.ThrowsException<NipValidationException>(() =>
            {
                Company company = new(name, nip3,
                    country, city, street, zipCode,
                    phoneNumber, email, password);
            });
        }

        [TestMethod]
        public void CountryTest()
        {
            // Arrange
            string name = "PGE";
            string nip = "0000000000";
            string country = "USA3";
            string country2 = "kongo";
            string city = "Łódź";
            string street = "Słowiańska 5";
            string zipCode = "26-086";
            string phoneNumber = "652-548-943";
            string email = "xd@gmail.com";
            string password = "samolot123";

            // Act

            // Assert
            Assert.ThrowsException<WrongNameException>(() =>
            {
                Company company = new(name, nip,
                    country, city, street, zipCode,
                    phoneNumber, email, password);
            });
            Assert.ThrowsException<WrongNameException>(() =>
            {
                Company company = new(name, nip,
                    country2, city, street, zipCode,
                    phoneNumber, email, password);
            });
        }

        [TestMethod]
        public void CityTest()
        {
            // Arrange
            string name = "PGE";
            string nip = "0000000000";
            string country = "Polandia";
            string city = "łódź";
            string city2 = "Op0le";
            string street = "Słowiańska 3";
            string zipCode = "26-086";
            string phoneNumber = "652-548-943";
            string email = "xd@gmail.com";
            string password = "samolot123";

            // Act

            // Assert
            Assert.ThrowsException<WrongNameException>(() =>
            {
                Company company = new(name, nip,
                    country, city, street, zipCode,
                    phoneNumber, email, password);
            });
            Assert.ThrowsException<WrongNameException>(() =>
            {
                Company company = new(name, nip,
                    country, city2, street, zipCode,
                    phoneNumber, email, password);
            });
        }

        [TestMethod]
        public void StreetTest()
        {
            // Arrange
            string name = "PGE";
            string nip = "0000000000";
            string country = "Polandia";
            string city = "Łódź";
            string street = "słowiańska 1";
            string street2 = "Słow1ańska 2";
            string zipCode = "26-086";
            string phoneNumber = "652-548-943";
            string email = "xd@gmail.com";
            string password = "samolot123";

            // Act

            // Assert
            Assert.ThrowsException<WrongNameException>(() =>
            {
                Company company = new(name, nip,
                    country, city, street, zipCode,
                    phoneNumber, email, password);
            });
            Assert.ThrowsException<WrongNameException>(() =>
            {
                Company company = new(name, nip,
                    country, city, street2, zipCode,
                    phoneNumber, email, password);
            });
        }

        [TestMethod]
        public void ZipCodeTest()
        {
            // Arrange
            string name = "PGE";
            string nip = "0000000000";
            string country = "Polandia";
            string city = "Łódź";
            string street = "Słowiańska 1";
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
                Company company = new(name,
                    nip, country, city, street, zipCode,
                    phoneNumber, email, password);
            });
            Assert.ThrowsException<WrongZipCodeException>(() =>
            {
                Company company = new(name,
                    nip, country, city, street, zipCode2,
                    phoneNumber, email, password);
            });
            Assert.ThrowsException<WrongZipCodeException>(() =>
            {
                Company company = new(name, nip,
                    country, city, street, zipCode3,
                    phoneNumber, email, password);
            });
        }

        [TestMethod]
        public void PhoneNumberTest()
        {
            // Arrange
            string name = "PGE";
            string nip = "0000000000";
            string country = "Polandia";
            string city = "Łódź";
            string street = "Słowiańska 1";
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
                Company company = new(name, nip,
                    country, city, street, zipCode,
                    phoneNumber, email, password);
            });
            Assert.ThrowsException<PhoneNumberException>(() =>
            {
                Company company = new(name, nip,
                    country, city, street, zipCode,
                    phoneNumber2, email, password);
            });
            Assert.ThrowsException<PhoneNumberException>(() =>
            {
                Company company = new(name, nip,
                    country, city, street, zipCode,
                    phoneNumber3, email, password);
            });
        }

        [TestMethod]
        public void EmailTest()
        {
            // Arrange
            string name = "PGE";
            string nip = "0000000000";
            string country = "Polandia";
            string city = "Łódź";
            string street = "Słowiańska 1";
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
                Company company = new(name, nip,
                    country, city, street, zipCode,
                    phoneNumber, email, password);
            });
            Assert.ThrowsException<WrongEmailException>(() =>
            {
                Company company = new(name, nip,
                    country, city, street, zipCode,
                    phoneNumber, email2, password);
            });
            Assert.ThrowsException<WrongEmailException>(() =>
            {
                Company company = new(name, nip,
                    country, city, street, zipCode,
                    phoneNumber, email3, password);
            });
        }
    }
}