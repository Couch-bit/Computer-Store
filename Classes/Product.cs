using System.Text.Json.Serialization;

namespace Classes
{
    /// <summary>
    /// An abstract class for the Products.
    /// </summary>
    /// <seealso cref="System.IComparable" />
    /// <seealso cref="System.ICloneable" />
    [JsonDerivedType(typeof(Hardware), typeDiscriminator: "Hardware")]
    [JsonDerivedType(typeof(Software), typeDiscriminator: "Software")]
    [JsonDerivedType(typeof(Accessory), typeDiscriminator: "Accessory")]
    public abstract class Product : IComparable<Product>,
        IEquatable<Product>, ICloneable
    {
        #region Fields

        private static int currentId;
        private readonly int id;
        private string name;
        private string description;
        private decimal discount;
        private decimal price;
        private decimal vat;
        private readonly Dictionary<string, string> technicalInfo;
        private readonly List<Item> items;
        #endregion Fields

        #region Properties

        public static int CurrentId { get => currentId; set => currentId = value; }
        /// <summary>
        /// Gets or sets (init) the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonIgnore]
        public int Id { get => id; init => id = value; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get => description;
            set => description = value; }

        /// <summary>
        /// Gets or sets the discount. Setting the discount is validated, as discount must be in range (0,1).
        /// </summary>
        /// <value>
        /// The discount.
        /// </value>
        /// <exception cref="Classes.NumericException">Illegal discount</exception>
        public decimal Discount
        {
            get => discount;
            set
            {
                if (value >= 0 && value < 1)
                {
                    discount = value;
                }
                else
                {
                    throw new NumericException("Illegal discount");
                }
            }
        }

        /// <summary>
        /// Gets or sets the price. Setting the price is validated, as price cannot be negative.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        /// <exception cref="Classes.NumericException">Illegal price</exception>
        public decimal Price
        {
            get => price;
            set
            {
                if (value < 0)
                {
                    throw new NumericException("Illegal price");
                }
                else
                {
                    price = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the vat. Setting the VAT is validated, as VAT can assume only certain levels.
        /// </summary>
        /// <value>
        /// The <a href="https://en.wikipedia.org/wiki/Value-added_tax">vat</a>.
        /// </value>
        /// <exception cref="Classes.NumericException">Illegal vat</exception>
        public decimal Vat {
            get => vat;
            set
            {
                if (!(new decimal[]
                {0, 0.05M, 0.08M ,0.23M}).Contains(value))
                {
                    throw new NumericException("Illegal vat");
                }
                else
                {
                    vat = value;
                }
            }
        }

        /// <summary>
        /// Gets the or sets (init) technical information.
        /// </summary>
        /// <value>
        /// The technical information.
        /// </value>
        public Dictionary<string, string> Technical_info { 
            get => technicalInfo;
            init => technicalInfo = value;
        }

        /// <summary>
        /// Gets or sets (init) the items. This list contains all the copies of the product - each with individual serial number, etc.
        /// </summary>
        /// <value>
        /// The items (copies).
        /// </value>
        public List<Item> Items { get => items;
            init => items = value; }
        #endregion Properties

        #region Constructors

        static Product()
        {
            currentId = 1;
        }

        public Product()
        {
            id = currentId++;
            name = string.Empty;
            description = string.Empty;
            Discount = 0;
            Price = 0;
            vat = 0;
            technicalInfo = new Dictionary<string, string>();
            items = new();
        }

        public Product(string name, string description,
            decimal discount, decimal price, decimal vat) : this()
        {
            this.name = name;
            this.description = description;
            Discount = discount;
            Price = price;
            Vat = vat;
        }
        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets the total price.
        /// </summary>
        /// <returns>
        /// A decimal containing price.
        /// </returns>
        public decimal GetTotalPrice()
        {
            return price * (1 - discount) * (1 + vat);
        }

        /// <summary>
        /// Gets the count of all the items of this product.
        /// </summary>
        /// <returns>
        /// An integer containing the count.
        /// </returns>
        public int GetCount()
        {
            return items.Count;
        }

        public void AddItem(Item item)
        {
            if (items.Contains(item))
            {
                throw new DuplicateException
                    ("This Item is already added");
            }
            items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            if (!items.Contains(item))
            {
                throw new WrongKeyException("There is no such item");
            }
            items.Remove(item);
        }

        /// <summary>
        /// Adds the technical information.
        /// </summary>
        /// <param name="key">The key - here it is the technical parameter.</param>
        /// <param name="value">The value - here it is the technical value.</param>
        /// <example>
        /// object.AddTechnicalInfo("Chipset", "Geforce RTX 3060");
        /// </example>
        /// <exception cref="Classes.WrongKeyException">Key already exists</exception>
        public void AddTechnicalInfo(string key, string value)
        {
            if (technicalInfo.ContainsKey(key))
            {
                throw new WrongKeyException("Key already exists");
            }
            else
            {
                technicalInfo.Add(key, value);
            }
        }

        /// <summary>
        /// Edits the technical information.
        /// </summary>
        /// <param name="key">The key - here it is the technical parameter.</param>
        /// <param name="value">The value - here it is the technical value.</param>
        /// <exception cref="Classes.WrongKeyException">Key doesn't exist</exception>
        public void EditTechnicalInfo(string key, string value)
        {
            if (technicalInfo.ContainsKey(key))
            {
                technicalInfo[key] = value;
            }
            else
            {
                throw new WrongKeyException("Key doesn't exist");
            }
        }

        /// <summary>
        /// Deletes the technical information.
        /// </summary>
        /// <param name="key">The key - here it is the technical parameter.</param>
        /// <exception cref="Classes.WrongKeyException">Key does not exist</exception>
        public void DeleteTechnicalInfo(string key)
        {
            if (!technicalInfo.Remove(key))
            {
                throw new WrongKeyException("Key does not exist");
            }
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings:
        /// <list type="table"><listheader><term> Value</term><description> Meaning</description></listheader><item><term> Less than zero</term><description> This instance precedes <paramref name="other" /> in the sort order.</description></item><item><term> Zero</term><description> This instance occurs in the same position in the sort order as <paramref name="other" />.</description></item><item><term> Greater than zero</term><description> This instance follows <paramref name="other" /> in the sort order.</description></item></list>
        /// </returns>
        public int CompareTo(Product? other)
        {
            if (other is null)
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(Product? other)
        {
            if (other is null)
            {
                return false;
            }
            return Id.Equals(other.Id);
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            string text = $"{name}, {GetCount()} " +
                $"price: {GetTotalPrice():c}";
            if (Discount != 0)
            {
                text += $" <-{Discount:P} OFF!>";
            }
            return text;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>
        ///   <see langword="true" /> if the specified object  is equal to the current object; otherwise, <see langword="false" />.
        /// </returns>
        public override bool Equals(object? obj)
        {
            return Equals(obj as Product);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(id);
        }
        #endregion Methods
    }
}