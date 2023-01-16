namespace Classes
{

    /// <summary>
    /// Enum for basic Hardware types in the store.
    /// </summary>
    public enum HardwareType 
    { 
        GPU, 
        CPU, 
        RAM, 
        Motherboard, 
        PowerSupply, 
        Drive, 
        Other
    }


    /// <summary>
    /// A class for Hardware that inherits after the abstract class Product.
    /// </summary>
    /// <seealso cref="Classes.Product" />
    public class Hardware : Product
    {
        #region Fields

        private double weight;
        private double length;
        private double height;
        private double width;
        HardwareType type;
        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the weight. Setting the weight is validated, as weight cannot be smaller or
        /// equal to 0.
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        /// <exception cref="Classes.WrongParameterException">Weight cannot be smaller or equal to 0.</exception>
        public double Weight 
        { 
            get => weight;
            set 
            {
                if(value <= 0)
                {
                    throw new 
                        WrongParameterException
                        ("Weight cannot be smaller or equal to 0.");
                }
                else
                {
                    weight = value;
                }
            } 
        }

        /// <summary>
        /// Gets or sets the length. Setting the length is validated, as length cannot be smaller or
        /// equal to 0.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        /// <exception cref="Classes.WrongParameterException">Length cannot be smaller or equal to 0.</exception>
        public double Length 
        { 
            get => length; 
            set 
            {
                if(value <= 0)
                {
                    throw new 
                        WrongParameterException
                        ("Length cannot be smaller or equal to 0.");
                }
                else
                {
                    length = value;
                }
            } 
        }

        /// <summary>
        /// Gets or sets the height. Setting the height is validated, as height cannot be smaller or
        /// equal to 0.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public double Height 
        { 
            get => height; 
            set 
            {
                if (value <= 0)
                {
                    throw new 
                        WrongParameterException
                        ("Height cannot be smaller or equal to 0.");
                }
                else
                {
                    height = value;
                }
            } 
        }

        /// <summary>
        /// Gets or sets the width. Setting the width is validated, as width cannot be smaller or
        /// equal to 0.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public double Width 
        { 
            get => width; 
            set 
            {
                if(value <= 0)
                {
                    throw new 
                        WrongParameterException
                        ("Width cannot be samller or equal to 0.");
                }
                else
                {
                    width = value;
                }
            } 
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public HardwareType Type { get => type; set => type = value; }
        #endregion Properties

        #region Constructors

        public Hardware() : base()
        {
            width = 0;
            length = 0;
            height = 0;
            width = 0;
            type = HardwareType.GPU;
        }

        public Hardware(double weight, double length, double height,
            double width, HardwareType type,
            string name, string description,
            decimal discount, decimal price, decimal vat) :
            base(name, description, discount, price, vat) 
        {
            this.width = 0;
            this.length = 0;
            this.height = 0;
            this.width = 0;
            this.type = type;
            Weight = weight;
            Length = length;
            Height = height;
            Width = width;
        }
        #endregion Constructors

        #region Methods

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return base.ToString() + $"({Type})";
        }

        #endregion Methods
    }
}