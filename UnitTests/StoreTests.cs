using Classes;
using System;
using System.Xml.Linq;

namespace UnitTests
{
    [TestClass]
    public class StoreTests
    {
        [TestMethod]
        public void DefaultConstructorTest()
        {
            // Arrange

            // Act
            Store store = new();

            // Assert
            Assert.AreEqual(store.Name, string.Empty);
            Assert.IsFalse(store.Suppliers.Any());
            Assert.IsFalse(store.Customers.Any());
        }

        [TestMethod]
        public void CreationTest()
        {
            // Arrange
            string name = "test";

            // Act
            Store store = new(name);

            // Assert
            Assert.AreEqual(store.Name, name);
            Assert.IsFalse(store.Suppliers.Any());
            Assert.IsFalse(store.Customers.Any());
        }

        [TestMethod]
        public void RemoveSupplierTest()
        {
            // Arrange
            Supplier supplier = new();

            // Act
            Store store = new();
            store.AddSupplier(supplier);
            store.RemoveSupplier(supplier);

            // Assert
            Assert.IsFalse(store.Suppliers.Any());
        }

        [TestMethod]
        public void RemoveSupplierTestFail()
        {
            // Arrange
            Supplier supplier = new();

            // Act
            Store store = new();


            // Assert
            Assert.ThrowsException<WrongKeyException>(() =>
            {
                store.RemoveSupplier(supplier);
            });
        }

        [TestMethod]
        public void RemoveCustomerTest()
        {
            // Arrange
            Company company = new();

            // Act
            Store store = new();
            store.AddCustomer(company);
            store.RemoveCustomer(company);

            // Assert
            Assert.IsFalse(store.Suppliers.Any());
        }

        [TestMethod]
        public void RemoveCustomerTestFail()
        {
            // Arrange
            Company company = new();

            // Act
            Store store = new();

            // Assert
            Assert.ThrowsException<WrongKeyException>(() =>
            {
                store.RemoveCustomer(company);
            });
        }

        [TestMethod]
        public void ToStringTest()
        {
            // Arrange
            string name = "test";
            
            // Act
            Store store = new("test");

            // Assert
            Assert.AreEqual($"Name: {name}\nSuppliers:\nCustomers:",
                store.ToString());
        }
    }
}
