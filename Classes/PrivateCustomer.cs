using System.Text.RegularExpressions;

namespace Classes
{
    /// <summary>
    /// A class for Private Customer that inherits after the abstract class Customer.
    /// </summary>
    /// <seealso cref="Classes.Customer" />
    public class PrivateCustomer : Customer
    {
        #region Fields

        private string firstName;
        private string lastName;
        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the first name. Setting the name is validated by the <see cref="Regex.IsMatch(string, string)" /> method.
        /// Name must start with a Capital letter and contain only letters. Spaces are permitted.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        /// <exception cref="Classes.WrongNameException">Incorrect first name</exception>
        public string FirstName 
        { 
            get => firstName; 
            set 
            { 
                if(Regex.IsMatch(value.Trim(),
                    @"^[AĄBCĆDEĘFGHIJKLŁMNŃOÓPRSŚTUWYZŹŻ]{1}" +
                    @"[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃń" +
                    @"OoÓóPpRrSsŚśTtUuWwYyZzŹźŻż\s]+$"))
                {
                    firstName = value.Trim();
                }
                else
                {
                    throw new
                        WrongNameException("Incorrect First Name");
                }
            } 
        }

        /// <summary>
        /// Gets or sets the last name. Setting the last name is validated by the <see cref="Regex.IsMatch(string, string)" /> method.
        /// Last name must start with a big letter and contain only letters. Spaces are permitted.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        /// <exception cref="Classes.WrongNameException">Incorrect last name</exception>
        public string LastName 
        { 
            get => lastName;
            set 
            {
                if(Regex.IsMatch(value.Trim(),
                    @"^[AĄBCĆDEĘFGHIJKLŁMNŃOÓPRSŚTUWYZŹŻ]{1}" +
                    @"[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃń" +
                    @"OoÓóPpRrSsŚśTtUuWwYyZzŹźŻż\s]+$"))
                {
                    lastName = value.Trim();
                }
                else
                {
                    throw new
                        WrongNameException("Incorrect Last Name");
                }
            } 
        }
        #endregion Properties

        #region Constructors
        
        public PrivateCustomer() : base()
        {
            firstName = string.Empty;
            lastName = string.Empty;
        }
        public PrivateCustomer(string firstName, string lastName,
            string country, string city,
            string street, string zipCode,
            string phoneNumber, string email, string password) : 
            base(country, city, street, zipCode, phoneNumber,
                email, password)
        {
            this.firstName = string.Empty;
            FirstName = firstName;
            this.lastName = string.Empty;
            LastName = lastName;
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
            return $"Private Customer: {FirstName} {LastName}";
        }

        #endregion Methods
    }
}