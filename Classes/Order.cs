using System.Text;
using System.Text.Json.Serialization;

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
        private readonly List<CartItem> cart;
        #endregion Fields

        #region Properties

        public static int CurrentId { get => currentId;
            set => currentId = value; }
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonIgnore]
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
                    deliveryDate = value;
                }
            } 
        }

        /// <summary>
        /// Gets or sets (init) the cart.
        /// </summary>
        /// <value>
        /// The cart.
        /// </value>
        public List<CartItem> Cart { get => cart;
            init => cart = value; }
        #endregion Properties

        #region Constructors

        static Order()
        {
            currentId = 1;
        }

        public Order()
        {
            id = currentId++;
            Status = false;
            DeliveryDate = DateTime.Now.AddDays(7);
            cart = new();
        }

        public Order(DateTime deliveryDate) : this()
        {
            DeliveryDate = deliveryDate;
        }
        #endregion Constructors

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
            if (cart.Any(p => p.Item1.Equals(product)))
            {
                throw new CartException
                    ("Product is already in the cart.");
            }
            else if (amount > product.GetCount())
            {
                throw new CartException("Insufficient Items");
            }
            else
            {
                cart.Add(new CartItem(product, amount));
            }
        }

        /// <summary>
        /// Deletes the specified product from the order.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <exception cref="Classes.CartException">There is no such Item</exception>
        public void Delete(CartItem product)
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
            return cart.Sum(p => p.Item1.GetTotalPrice() * p.Item2);
        }

        /// <summary>
        /// Calculates the extra fee of fast shipping. The earlier customer wants the product, the more expensive is the shipping.
        /// </summary>
        /// <returns>
        /// A decimal containing said fee.
        /// </returns>
        public decimal CalculateFee()
        {
            double days = Math.Round(DeliveryDate.Date.Subtract(DateTime.Now).TotalDays, 0);
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
        /// Calculates the total cost (order cost + shipping cost).
        /// </summary>
        /// <returns>
        /// A decimal containing said total cost.
        /// </returns>
        public decimal CalculateTotalCost()
        {
            return CalculateOrderCost() + CalculateShippingCost();
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
            sb.AppendLine
                ($"Delivery date: {DeliveryDate:dd-MM-yyyy})");
            sb.AppendLine($"Order cost: {CalculateOrderCost():c2},");
            sb.Append($"Shipping cost: {CalculateShippingCost():c2}");
            sb.AppendLine($" (Fee: {CalculateFee():c2}),");
            sb.Append($" Total: " +
                $"{CalculateTotalCost():c2}");
            return sb.ToString();
        }
        #endregion Methods
    }


    /// <summary>
    /// A class converging the type of dictionary to make it JSON friendly. Otherwise JSON won't work. Perhaps in .NET 8.0 it won't be needed. 
    /// </summary>
    public class CartItem
    {
        #region Properties

        /// <summary>
        /// Gets or sets the item1 (as the name in the original dictionary).
        /// </summary>
        /// <value>
        /// The item1.
        /// </value>
        public Product Item1 { get; set; }

        /// <summary>
        /// Gets or sets the item2 (as the name in the original dictionary).
        /// </summary>
        /// <value>
        /// The item2.
        /// </value>
        public int Item2 { get; set; }
        #endregion Properties

        #region Contructors

        public CartItem()
        {
            Item1 = new Hardware();
            --Product.CurrentId;
            Item2 = 1;
        }

        public CartItem(Product product, int amount)
        {
            Item1 = product;
            Item2 = amount;
        }
        #endregion Constructors

        #region Methods

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"({Item1} , {Item2})";
        }
        #endregion Methods
    }
}