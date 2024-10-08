﻿using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Classes
{
    /// <summary>
    /// The mandatory delegate.
    /// </summary>
    /// <param name="nip">The nip.</param>
    /// <returns></returns>
    public delegate int Sumation(string nip);
    /// <summary>
    /// Class for suppliers.
    /// </summary>
    public class Supplier
    {
        #region Fields

        private static int currentId;
        private readonly int id;
        private string nip;
        private string name;
        private string country;
        private readonly List<Product> products;
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
        public int Id { get => id;
            init => id = value; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get => name;
            set => name = value; }

        /// <summary>
        /// Gets or sets the NIP. Setting the NIP is validated by 
        /// <see cref="ValidateNip(string, Sumation)" /> method and <see cref="Regex.IsMatch(string, string)" /> method.
        /// </summary>
        /// <value>
        /// The NIP.
        /// </value>
        /// <exception cref="Classes.NipValidationException"></exception>
        public string Nip 
        { 
            get => nip; 
            set
            {
                if (Regex.IsMatch(value, @"^\d{10}$") &&
                    ValidateNip(value, SumNip))
                {
                    nip = value;
                }
                else
                {
                    throw new NipValidationException("Nip is invalid");
                }
            } 
        }

        /// <summary>
        /// Gets or sets the country. Setting the country is validated by <see cref="Regex.IsMatch(string, string)" /> method.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        /// <exception cref="Classes.WrongNameException"></exception>
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
                    throw new WrongNameException("Country is invalid");
                }
            }
        }
        public List<Product> Products { get => products;
            init => products = value; }
        #endregion

        #region Constructors

        static Supplier()
        {
            currentId = 1;
        }

        public Supplier()
        {
            id = currentId++;
            name = string.Empty;
            nip = new string('0', 10);
            country = string.Empty;
            products = new();
        }

        public Supplier(string name, string nip,
            string country) : this()
        {
            Name = name;
            Nip = nip;
            Country = country;
        }
        #endregion Properties

        #region Methods        

        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <param name="product">The product.</param>
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        /// <summary>
        /// Removes the product.
        /// </summary>
        /// <param name="product">The product.</param>
        public void RemoveProduct(Product product)
        {
            products.Remove(product);
        }

        /// <summary>
        /// Sorts this instance.
        /// </summary>
        public void Sort()
        {
            products.Sort();
        }

        /// <summary>
        /// Validates the inputed NIP number.
        /// </summary>
        /// <param name="nip">It's a Polish tax identification number, consists of 10 digits,
        /// where the first three digits are codes provided by the tax office, and the last number is a control one.
        /// For further references please click <a href="https://www.justaskpoland.com/nip-number/">here</a>.</param>
        /// <param name="sum"> The function used to calculate the control sum of the nip, </param>
        /// <returns>Boolean value</returns>
        public static bool ValidateNip(string nip, Sumation sum)
        {
            int result = sum(nip);

            if (result % 11 == nip[9] - '0')
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Sums the nip - a base for the famous mandatory delegate.
        /// </summary>
        /// <param name="nip">The nip.</param>
        /// <returns>the sum</returns>
        public static int SumNip(string nip)
        {
            int[] arr = new int[] { 6, 5, 7, 2, 3, 4, 5, 6, 7 };
            int result = 0;
            for (int i = 0; i < nip.Length - 1; ++i)
            {
                result += (nip[i] - '0') * arr[i];
            }
            return result;
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"{Name} ({Nip:000-000-00-00} {Country})";
        }
        #endregion Methods
    }
}