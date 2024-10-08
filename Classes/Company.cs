﻿using System.Text.RegularExpressions;

namespace Classes
{
    /// <summary>
    /// A class for Public Customer (Company) that inherits after the abstract class Customer.
    /// </summary>
    /// <seealso cref="Classes.Customer" />
    public class Company : Customer
    {
        #region Fields

        private string name;
        private string nip;
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
        /// Gets or sets the NIP. Setting the NIP is validated by the
        /// <see cref="Supplier.ValidateNip(string, Sumation)" /> method and the <see cref="Regex.IsMatch(string, string)" /> method.
        /// </summary>
        /// <value>
        /// The NIP.
        /// </value>
        /// <exception cref="Classes.NipValidationException">Incorrect NIP</exception>
        public string Nip
        {
            get => nip;
            set
            {
                if (Regex.IsMatch(value, @"^\d{10}$") &&
                    Supplier.ValidateNip(value, Supplier.SumNip))
                {
                    nip = value;
                }
                else
                {
                    throw new 
                        NipValidationException("Incorrect NIP");
                }
            }
        }
        #endregion Properties

        #region Constructors

        public Company() : base()
        {
            name = string.Empty;
            nip = new string('0', 10);
        }

        public Company(string name, string nip,
            string country, string city,
            string street, string zipCode,
            string phoneNumber, string email, 
            string password) : base(country, city, street, zipCode,
                phoneNumber, email, password) 
        {
            this.name = name;
            this.nip = string.Empty;
            Nip = nip;
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
            return $"Company: {Name} (NIP: {Nip})";
        }
        #endregion Methods
    }
}