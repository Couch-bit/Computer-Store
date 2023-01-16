namespace Classes
{
    /// <summary>
    /// A public class for the items - which are specified copies of the main product
    /// </summary>
    public class Item : IEquatable<Item>
    {
        #region Fields

        private readonly string serialNumber;
        private readonly DateTime dateOfArrival;
        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets (init) the serial number.
        /// </summary>
        /// <value>
        /// The serial number.
        /// </value>
        public string SerialNumber
        {
            get => serialNumber;
            init => serialNumber = value;
        }

        /// <summary>
        /// Gets or sets (init) the date of arrival.
        /// </summary>
        /// <value>
        /// The date of arrival.
        /// </value>
        public DateTime DateofArrival
        {
            get => dateOfArrival;
            init => dateOfArrival = value;
        }
        #endregion Properties

        #region Constructors

        public Item()
        {
            serialNumber = string.Empty;
            dateOfArrival = DateTime.Now;
        }

        public Item(string serialNumber, DateTime dateofArrival) :
            this()
        {
            SerialNumber = serialNumber;
            DateofArrival = dateofArrival;
        }
        #endregion Constructors

        #region Methods

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(Item? other)
        {
            if (other is null)
            {
                return false;
            }
            return serialNumber.Equals(other.serialNumber);
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"{SerialNumber} ({DateofArrival:yyyy-MM-dd})";
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
            return Equals(obj as Item);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(serialNumber, dateOfArrival);
        }
        #endregion Methods
    }
}