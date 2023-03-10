using Classes;

namespace UnitTests
{
    [TestClass]
    public class SupplierTests
    {
        [TestMethod]
        public void DefaultConstructorTest()
        {
            // Arrange

            // Act
            Supplier supplier = new();

            // Assert
            Assert.AreEqual(supplier.Nip, new string('0', 10));
            Assert.AreEqual(supplier.Name, string.Empty);
            Assert.AreEqual(supplier.Country, string.Empty);
        }

        [TestMethod]
        public void StaticIdTest()
        {
            // Arrange
            int temp = Supplier.CurrentId;

            // Act
            _ = new Supplier();
            int result = Supplier.CurrentId - temp;

            // Assert
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void IdTest()
        {
            // Arrange
            int diff;

            // Act
            Supplier supplier1 = new();
            Supplier supplier2 = new();
            diff = supplier2.Id - supplier1.Id;

            // Assert
            Assert.AreEqual(diff, 1);
        }

        [TestMethod]
        public void CreationTest()
        {
            // Arrange
            string name = "PGE";
            string nip = "8130268082";
            string country = "Poland";

            // Act
            Supplier supplier = new(name, nip, country);

            // Assert
            Assert.AreEqual(name, supplier.Name);
            Assert.AreEqual(nip, supplier.Nip);
            Assert.AreEqual(country, supplier.Country);
        }

        [TestMethod]
        public void ValidateNipTest()
        {
            // Arrange
            string nip1 = "0000001000";
            string nip2 = "0000000000";
            Sumation sum = new(Supplier.SumNip);

            // Act
            bool test1 = Supplier.ValidateNip(nip1, sum);
            bool test2 = Supplier.ValidateNip(nip2, sum);

            // Assert
            Assert.IsFalse(test1);
            Assert.IsTrue(test2);
            
        }

        [TestMethod]
        public void NipCreationTest()
        {
            // Arrange
            string name = "test";
            string nip1 = "0000001000";
            string nip2 = "456712";
            string nip3 = "813-026-80-82";
            string country = "Poland";

            // Act

            // Assert
            Assert.ThrowsException<NipValidationException>(() =>
            {
                Supplier supplier = new(name, nip1, country);
            });
            Assert.ThrowsException<NipValidationException>(() =>
            {
                Supplier supplier = new(name, nip2, country);
            });
            Assert.ThrowsException<NipValidationException>(() =>
            {
                Supplier supplier = new(name, nip3, country);
            });
        }

        [TestMethod]
        public void CountryTest()
        {
            // Arrange
            string name = "test";
            string nip = "0000000000";
            string country = "poland";

            // Act

            // Assert
            Assert.ThrowsException<WrongNameException>(() =>
            {
                Supplier supplier = new(name, nip, country);
            });
        }

        [TestMethod]
        public void AddTest()
        {
            // Arrange
            string name = "test";
            string nip = "0000000000";
            string country = "Poland";

            // Act
            Supplier supplier = new(name, nip, country);

            // Assert
            // TODO


        }

        [TestMethod]
        public void ToStringTest()
        {
            // Arrange
            string name = "test";
            string nip = "0000000000";
            string country = "Poland";

            // Act
            Supplier supplier = new(name, nip, country);

            // Assert
            Assert.AreEqual(supplier.ToString(),
                $"{name} ({nip:000-000-00-00} {country})");
        }
    }
}