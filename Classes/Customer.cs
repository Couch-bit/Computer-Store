using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Classes
{
    /// <summary>
    /// An abstract class for all customers.
    /// </summary>
    [JsonDerivedType(typeof(Company), typeDiscriminator: "Company")]
    [JsonDerivedType(typeof(PrivateCustomer), typeDiscriminator: "Customer")]
    public abstract class Customer
    {
        #region Fields

        private static int currentId;
        private readonly int id;
        private string country;
        private string city;
        private string street;
        private string zipCode;
        private string phoneNumber;
        private string email;
        private string password;
        private readonly List<Order> orders;
        #endregion Fields

        #region Properties  

        
        public static int CurrentId { get => currentId; set => currentId = value; }
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonIgnore]
        public int Id { get => id; init => id = value; }

        /// <summary>
        /// Gets or sets the country. Setting the country is validated by the <see cref="Regex.IsMatch(string, string)" /> method.
        /// Country must start with a big letter and contain only letters. Spaces are permitted.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        /// <exception cref="Classes.WrongNameException">Incorrect Country</exception>
        public string Country
        {
            get => country;
            set
            {
                if (Regex.IsMatch(value,
                    @"^[AĄBCĆDEĘFGHIJKLŁMNŃOÓPRSŚTUWYZŹŻ]{1}" + 
                    @"[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMm" + 
                    @"NnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻż\s]+$"))
                {
                    country = value;
                }
                else
                {
                    throw new WrongNameException("Incorrect Country");
                }
            }
        }

        /// <summary>
        /// Gets or sets the city. Setting the city is validated by the <see cref="Regex.IsMatch(string, string)" /> method.
        /// City must start with a big letter and contain only letters. Spaces are permitted.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        /// <exception cref="Classes.WrongNameException">Incorrect City</exception>
        public string City
        {
            get => city;
            set
            {
                if (Regex.IsMatch(value, 
                    @"^[AĄBCĆDEĘFGHIJKLŁMNŃOÓPRSŚTUWYZŹŻ]{1}" + 
                    @"[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃń" + 
                    @"OoÓóPpRrSsŚśTtUuWwYyZzŹźŻż\s]+$"))
                {
                    city = value;
                }
                else
                {
                    throw new WrongNameException("Incorrect City");
                }
            }
        }

        /// <summary>
        /// Gets or sets the street. Setting the street is validated by the <see cref="Regex.IsMatch(string, string)" /> method.
        /// Street must start with a big letter and contain only letters and numbers at the end of the string (ex. apartment number). 
        /// Spaces are permitted.
        /// </summary>
        /// <value>
        /// The street.
        /// </value>
        /// <exception cref="Classes.WrongNameException">Incorrect Street</exception>
        public string Street
        {
            get => street;
            set
            {
                if (Regex.IsMatch(value,
                    @"^[AĄBCĆDEĘFGHIJKLŁMNŃOÓPRSŚTUWYZŹŻ]{1}" +
                    @"[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃń" +
                    @"OoÓóPpRrSsŚśTtUuWwYyZzŹźŻż\s]{1,} \d{1,}(/\d{1,})?$"))
                {
                    street = value;
                }
                else
                {
                    throw new WrongNameException("Incorrect Street");
                }
            }
        }

        /// <summary>
        /// Gets or sets (init) the zip code. Setting the zip code is validated by the <see cref="Regex.IsMatch(string, string)" /> method.
        /// Zip code must be in a Polish format (ex. 12-353).
        /// </summary>
        /// <value>
        /// The zip code.
        /// </value>
        public string ZipCode { get => zipCode;
            init
            {
                if (Regex.IsMatch(value, @"^\d{2}-\d{3}$"))
                {
                    zipCode = value;
                }
                else
                {
                    throw new 
                        WrongZipCodeException("Incorrect ZipCode");
                }
            }
        }

        /// <summary>
        /// Gets or sets (init) the phone number. Setting the phone number is validated by the <see cref="Regex.IsMatch(string, string)" /> method.
        /// Phone number must be in a Polish (European) format (ex. 212-234-124).
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        /// <exception cref="Classes.PhoneNumberException">Incorrect Phone Number</exception>
        public string PhoneNumber { get => phoneNumber;
            set
            {
                if (Regex.IsMatch(value, @"^(\d{3}-){2}\d{3}$"))
                {
                    phoneNumber = value;
                }
                else
                {
                    throw new 
                        PhoneNumberException("Incorrect Phone Number");
                }
            }
        }

        /// <summary>
        /// Gets or sets (init) the email. Setting the e-mail is validated by the <see cref="Regex.IsMatch(string, string)" /> method.
        /// E-mail must be in an internationally accepted format (ex. me@myself.org)
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        /// <exception cref="WrongEmailException">Incorrect Email</exception>
        public string Email { get => email;
            init
            {
                if (Regex.IsMatch(value,
                    @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                    email = value.ToLower();
                }
                else
                {
                    throw new WrongEmailException("Incorrect Email");
                }
            }
        }

        /// <summary>
        /// Gets or sets (init) the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get => password;
            init => password = value; }

        /// <summary>
        /// Gets or sets (init) the orders.
        /// </summary>
        /// <value>
        /// The orders.
        /// </value>
        public List<Order> Orders { get => orders;
            init => orders = value; }
        #endregion Properties

        #region Constructors

        static Customer()
        {
            currentId = 1;
        }

        public Customer()
        {
            id =  currentId++;
            country = string.Empty; 
            city = string.Empty;
            street = string.Empty;
            zipCode = "00-000";
            phoneNumber = "000-000-000";
            email = string.Empty;
            password = string.Empty;
            orders = new();
        }

        public Customer(string country, string city,
            string street, string zipCode, 
            string phoneNumber, string email, string password) : this()
        {
            Country = country;
            City = city;
            Street = street;
            ZipCode = zipCode;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
        }
        #endregion Constructors

        #region Methods

        /// <summary>
        /// Adds the order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns></returns>
        public void AddOrder(Order order)
        {
            orders.Add(order);
        }

        /// <summary>
        /// Removes the order by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public void RemoveOrder(int id)
        {
            foreach (Order order in orders)
            {
                if (order.Id == id)
                {
                    orders.Remove(order);
                    return;
                }
            }
        }
        #endregion Methods
    }
}