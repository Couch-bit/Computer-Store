using System.Text;
using System.Text.Json;

namespace Classes
{
    /// <summary>
    /// A class containing all of the store. 
    /// </summary>
    public class Store
    {
        #region Fields

        private string name;
        private readonly List<Supplier> suppliers;
        private readonly List<Customer> customers;
        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// Gets or sets (init) the suppliers.
        /// </summary>
        /// <value>
        /// The suppliers.
        /// </value>
        public List<Supplier> Suppliers { get => suppliers;
            init => suppliers = value; }

        /// <summary>
        /// Gets or sets (init) the customers.
        /// </summary>
        /// <value>
        /// The customers.
        /// </value>
        public List<Customer> Customers { get => customers;
            init => customers = value; }
        #endregion Properties

        #region Constructors

        public Store()
        {
            name = string.Empty;
            suppliers = new();
            customers = new();
        }

        public Store(string name) : this()
        {
            this.name = name;
        }
        #endregion Constructors

        #region Methods

        /// <summary>
        /// Adds the supplier to the known database of suppliers.
        /// </summary>
        /// <param name="supplier">The supplier.</param>
        /// <exception cref="Classes.DuplicateException">Supplier already exists</exception>
        public void AddSupplier(Supplier supplier)
        {
            if (!suppliers.Any(x => x.Nip == supplier.Nip)) {
                suppliers.Add(supplier);
            } else
            {
                throw new DuplicateException
                    ("Supplier already exists");
            }
        }

        /// <summary>
        /// Removes the supplier from the known database of suppliers.
        /// </summary>
        /// <param name="supplier">The supplier.</param>
        /// <exception cref="Classes.WrongKeyException">No such Supplier</exception>
        public void RemoveSupplier(Supplier supplier)
        {
            if(!suppliers.Remove(supplier))
            {
                throw new WrongKeyException("No such Supplier");
            }
        }

        /// <summary>
        /// Adds the customer to the known database of clients.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <exception cref="Classes.DuplicateException">Email is already in use</exception>
        public void AddCustomer(Customer customer)
        {
            if (!customers.Any(x => x.Email == customer.Email)) {
                customers.Add(customer);
            }
            else
            {
                throw new DuplicateException
                    ("Email is already in use");
            }
        }

        /// <summary>
        /// Removes the customer from the known database of clients.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <exception cref="Classes.WrongKeyException">No such Customer</exception>
        public void RemoveCustomer(Customer customer)
        {
            if (!customers.Remove(customer))
            {
                throw new WrongKeyException("No such Customer");
            }
        }

        /// <summary>
        /// Gets all orders of all customers.
        /// </summary>
        /// <returns>
        /// A list of orders.
        /// </returns>
        public List<Order> GetAllOrders()
        {
            List<Order> result = new();
            foreach (Customer customer in customers)
            {
                foreach (Order order in customer.Orders)
                {
                    result.Add(order);
                }
            }
            return result;
        }

        /// <summary>
        /// Gets all products of all suppliers.
        /// </summary>
        /// <returns>
        /// A list of products
        /// </returns>
        public List<Product> GetAllProducts()
        {
            List<Product> result = new();
            foreach (Supplier supplier in suppliers)
            {
                foreach (Product product in supplier.Products)
                {
                    result.Add(product);
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the customer.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>
        /// A customer.
        /// </returns>
        /// <exception cref="Classes.WrongKeyException">No such Order</exception>
        public Customer GetCustomer(Order order)
        {
            foreach(Customer customer in customers)
            {
                foreach (Order o in customer.Orders)
                {
                    if (o == order)
                    {
                        return customer;
                    }
                }
            }
            throw new WrongKeyException("No such Order");
        }

        /// <summary>
        /// Serializes the specified file to JSON format.
        /// </summary>
        /// <param name="fname">The name of the file where the JSON format is going to be stored.</param>
        public void Serialize(string fname)
        {

            using StreamWriter sw = new($"{fname}.json");
            string txt = JsonSerializer.Serialize(this, typeof(Store));
            sw.WriteLine(txt);
        }


        /// <summary>
        /// Deserializes the specified file from JSON format.
        /// </summary>
        /// <param name="fname">The name of the file where the JSON format is stored.</param>
        /// <returns></returns>
        /// <exception cref="System.IO.FileNotFoundException">No such JSON file</exception>
        /// <exception cref="Classes.SerializationException">Failed to Parse File</exception>
        public static Store Deserialize(string fname)
        {
            if (!File.Exists($"{fname}"))
            {
                throw new FileNotFoundException("No such JSON file");
            }
            string txt = File.ReadAllText($"{fname}",
                Encoding.UTF8);
            return JsonSerializer.Deserialize(txt, typeof(Store))
                as Store ?? throw new SerializationException
                ("Failed to Parse File");
        }


        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new($"Name: {Name}");
            sb.Append("Suppliers:");
            foreach (Supplier supplier in Suppliers)
            {
                sb.Append($"\n{supplier}");
            }
            sb.Append("\nCustomers:");
            foreach (Customer customer in Customers)
            {
                sb.Append($"\n{customer}");
            }
            return sb.ToString();
        }
        #endregion Methods
    }
}