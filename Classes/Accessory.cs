namespace Classes
{
    /// <summary>
    /// Enum for basic Accesory types in the store.
    /// </summary>
    public enum AccessoryType
    {
        Headphones,
        Microphone,
        Mouse,
        Keyboard,
        Screen,
        Cable,
        Other
    }

    /// <summary>
    /// A class for Accessories that inherits after the abstract class Product.
    /// </summary>
    /// <seealso cref="Classes.Product" />
    public class Accessory : Product
    {
        #region Fields

        private double weight;
        private AccessoryType type;
        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the weight. Setting the weight is validated, as weight cannot be smaller or
        /// equal to 0.
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        public double Weight 
        { 
            get => weight;
            set 
            {
                if(value <= 0)
                {
                    throw new WrongParameterException("Weight cannot be smaller or equal to 0.");
                }
                else
                {
                    weight = value;
                }
            } 
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public AccessoryType Type { get => type; set => type = value; }
        #endregion Properties

        #region Constructors

        public Accessory() : base()
        {
            weight = 0;
            type = AccessoryType.Headphones;
        }

        public Accessory(double weight, AccessoryType type,
            string name, string description,
            decimal discount, decimal price, decimal vat) : 
            base(name, description, discount, price, vat)
        {
            this.weight = weight;
            this.type = type;
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
            return base.ToString() + $"({Type})";
        }
        #endregion Methods
    }
}