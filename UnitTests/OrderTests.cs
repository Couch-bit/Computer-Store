namespace Classes
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void DefaultConstructorTest()
        {
            // Arrange

            // Act
            Order order = new();

            // Assert
            Assert.AreEqual(order.Status, false);
            Assert.IsTrue(order.Cart.Count == 0);
        }

        [TestMethod]
        public void StaticIdTest()
        {
            // Arrange
            int result = Order.CurrentId;

            // Act
            _ = new Order();
            result = Order.CurrentId - result;

            // Assert
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void IdTest() 
        {
            // Arrange
            int diff;

            // Act
            Order order1 = new();
            Order order2 = new();
            diff = order2.Id - order1.Id;

            // Assert
            Assert.AreEqual(diff, 1);
        }

        [TestMethod]
        public void CreationTest()
        {
            // Arrange
            DateTime DeliveryDate = DateTime.Now.AddDays(7);

            // Act
            Order order = new(DeliveryDate);

            // Assert
            Assert.AreEqual(order.Status, false);
            Assert.AreEqual(DeliveryDate, order.DeliveryDate);
            Assert.IsTrue(order.Cart.Count == 0);
        }

        [TestMethod]
        public void DeliveryDateTest()
        {
            // Arrange
            DateTime DeliveryDate1 = DateTime.Now;
            DateTime DeliveryDate2 = DateTime.Now.AddHours(23);

            // Act

            // Assert
            Assert.ThrowsException<WrongDateException>(() =>
            {
                Order order = new(DeliveryDate1);
            });
            Assert.ThrowsException<WrongDateException>(() =>
            {
                Order order = new(DeliveryDate2);
            });
        }
    }
}