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

        public void AddSupplier(Supplier supplier)
        {
            if (suppliers.Any(x => x.Nip == supplier.Nip)) {
                suppliers.Add(supplier);
            } else
            {
                throw new DuplicateException
                    ("Supplier already exists");
            }
        }

        public void RemoveSupplier(Supplier supplier)
        {
            if(!suppliers.Remove(supplier))
            {
                throw new WrongKeyException("No such Supplier");
            }
        }

        public void AddCustomer(Customer customer)
        {
            if (customers.Any(x => x.Email == customer.Email)) {
                customers.Add(customer);
            }
            else
            {
                throw new DuplicateException
                    ("Customer already exists");
            }
        }

        public void RemoveCustomer(Customer customer)
        {
            if (!customers.Remove(customer))
            {
                throw new WrongKeyException("No such Customer");
            }
        }
        /// <summary>
        /// Serializes the specified file to JSON format.
        /// </summary>
        /// <param name="fname">The name of the file where the JSON format is going to be stored.</param>
        public void Serialize(string fname)
        {
            using StreamWriter sw = new(fname);
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
            if (!File.Exists($"{fname}.json"))
            {
                throw new FileNotFoundException("No such JSON file");
            }
            using StreamReader sw = new($"{fname}.json");
            string txt = File.ReadAllText($"{fname}.json",
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