using System.Text;
using System.Text.RegularExpressions;

namespace Classes
{
    /// <summary>
    /// An abstract class for all customers.
    /// </summary>
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
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
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
                if (Regex.IsMatch(value, @"^[A-Z]{1}[a-zA-Z\s]+$"))
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
                if (Regex.IsMatch(value, @"^[A-Z]{1}[a-zA-Z\s]+$"))
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
                if (Regex.IsMatch(value, @"^[A-Z]{1}[a-zA-Z1-9\s]+$"))
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
            init
            {
                if (Regex.IsMatch(value, @"^(\d{3}-){2}\d{3}$"))
                {
                    zipCode = value;
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
                    @"(?:[a-z0-9!#$%&'+/=?^_`{|}" + 
                    @"~-]+(?:.[a-z0-9!#$%&'+/=?^_`{|}~-]+)|""(?:" + 
                    @"[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23" + 
                    @"-\x5b\x5d-\x7f]|\[\x01-\x09\x0b\x0c\x0e-\x7f])" + 
                    @")@(?:(?:[a-z0-9](?:[a-z0-9-][a-z0-9])?.)" + 
                    @"+[a-z0-9](?:[a-z0-9-][a-z0-9])?|[(?:(?:(2(5" +
                    "[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])).)" + 
                    @"{3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]" + 
                    @"?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b" + 
                    @"\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\[\x01-" + 
                    @"\x09\x0b\x0c\x0e-\x7f])+)])"))
                {
                    email = value;
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
            zipCode = string.Empty;
            phoneNumber = new string('0', 9);
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

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append("Orders:");
            foreach(Order order in orders)
            {
                sb.Append($"\n{order}");
            }
            return sb.ToString();
        }
        #endregion Methods
    }
}