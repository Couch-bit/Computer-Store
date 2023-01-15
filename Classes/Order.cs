using System.Text;

namespace Classes
{
    /// <summary>
    /// A class for all Orders from Customers.
    /// </summary>
    public class Order
    {
        #region Fields
        
        private static int currentId;
        private readonly int id;
        private bool status;
        private DateTime deliveryDate;
        private readonly Dictionary<Product, int> cart;
        #endregion

        #region Properties

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get => id; init => id = value; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Order"/> is realized or not.
        /// </summary>
        /// <value>
        /// <c>true</c> if the order is realized; otherwise, <c>false</c>.
        /// </value>
        public bool Status { get => status;
            set => status = value; }

        /// <summary>
        /// Gets or sets the desired delivery date.
        /// </summary>
        /// <value>
        /// The delivery date.
        /// </value>
        /// <exception cref="Classes.WrongDateException">Incorrect date</exception>
        public DateTime DeliveryDate 
        { 
            get => deliveryDate;
            set 
            {
                DateTime now = DateTime.Now;
                if (value.Subtract(now).TotalDays < 1)
                {
                    throw new WrongDateException("Incorrect date");
                }
                else
                {
                    deliveryDate = now;
                }
            } 
        }

        /// <summary>
        /// Gets or sets (init) the cart.
        /// </summary>
        /// <value>
        /// The cart.
        /// </value>
        public Dictionary<Product, int> Cart { get => cart;
            init => cart = value; }
        #endregion

        #region Constructors

        static Order()
        {
            currentId = 1;
        }

        public Order()
        {
            id = currentId++;
            Status = false;
            DeliveryDate = DateTime.Now;
            cart = new();

        }

        public Order(DateTime deliveryDate) : this()
        {
            DeliveryDate = deliveryDate;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Adds the specified product to the order.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="amount">The amount.</param>
        /// <exception cref="Classes.CartException">
        /// Product is already in the cart.
        /// or
        /// Insufficient Items
        /// </exception>
        public void Add(Product product, int amount)
        {
            if (cart.ContainsKey(product))
            {
                throw new CartException
                    ("Product is already in the cart.");
            }
            else if (amount >= product.GetCount())
            {
                throw new CartException("Insufficient Items");
            }
            else
            {
                cart.Add((Product)product.Clone(), amount);
            }
        }

        /// <summary>
        /// Deletes the specified product from the order.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <exception cref="Classes.CartException">There is no such Item</exception>
        public void Delete(Product product)
        {
            if (!cart.Remove(product))
            {
                throw new CartException("There is no such Item");
            }
        }

        /// <summary>
        /// Calculates the order cost (doesn't include the shipping cost).
        /// </summary>
        /// <returns>
        /// A decimal containing said cost.
        /// </returns>
        public decimal CalculateOrderCost()
        {
            return cart.Sum(p => p.Key.GetTotalPrice() * p.Value);
        }

        /// <summary>
        /// Calculates the extra fee of fast shipping. The earlier customer wants the product, the more expensive is the shipping.
        /// </summary>
        /// <returns>
        /// A decimal containing said fee.
        /// </returns>
        public decimal CalculateFee()
        {
            double days = DateTime.Now.Subtract(DeliveryDate).TotalDays;
            if (days < 7)
            {
                return (decimal)(7 - days) * 3.0M;
            }
            return 0M;
        }

        /// <summary>
        /// Calculates the shipping cost (base fee + extra fee).
        /// </summary>
        /// <returns>
        /// A decimal containing said shipping cost.
        /// </returns>
        public decimal CalculateShippingCost()
        {
            return 20M + CalculateFee();
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Order id: {Id}");
            if (Status)
            {
                sb.AppendLine("(realized)");
            }
            else
            {
                sb.AppendLine("(not realized)");
            }
            sb.AppendLine($"Delivery date: {DeliveryDate:dd-MM-yyyy})");
            sb.Append($"Order cost: {CalculateOrderCost():c},");
            sb.Append($"Shipping cost: {CalculateShippingCost():c}");
            sb.Append($" (Fee: {CalculateFee():c}),");
            sb.Append($" Total: " +
                $"{CalculateOrderCost() + CalculateShippingCost():c}");
            return sb.ToString();
        }
        #endregion
    }
}