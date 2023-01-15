﻿using static System.Net.WebRequestMethods;

namespace Classes
{
    /// <summary>
    /// Enum for basic computer architectures in the store.
    /// </summary>
    public enum Architecture
    {
        /// <summary>
        /// The bit32. For further references see <a href="https://en.wikipedia.org/wiki/32-bit_computing">this</a>.
        /// </summary>
        Bit32,
        /// <summary>
        /// The bit64. For further references see <a href="https://en.wikipedia.org/wiki/64-bit_computing">this</a>.
        /// </summary>
        Bit64
    }

    /// <summary>
    /// A class for Software that inherits after the abstract class Product.
    /// </summary>
    /// <seealso cref="Classes.Product" />
    public class Software : Product
    {
        #region Fields
        private string version;
        private float license;
        private Architecture targetArchitecture;
        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public string Version { get => version;
            set => version = value; }

        /// <summary>
        /// Gets or sets the license.
        /// </summary>
        /// <value>
        /// The license.
        /// </value>
        public float License { get => license;
            set => license = value; }

        /// <summary>
        /// Gets or sets the target architecture.
        /// </summary>
        /// <value>
        /// The target architecture.
        /// </value>
        public Architecture TargetArchitecture {
            get => targetArchitecture;
            set => targetArchitecture = value; }
        #endregion Properties

        #region Constructors

        public Software() : base()
        {
            version = string.Empty;
            license = 0;
            targetArchitecture = Architecture.Bit64;
        }

        public Software(string version, float license,
            Architecture targetArchitecture, 
            string name, string description,
            decimal discount, decimal price, decimal vat) : 
            base(name, description, discount, price, vat)
        {
            this.version = version;
            this.license = license;
            this.targetArchitecture = targetArchitecture;
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
            return base.ToString() + $"({Version} " +
                $"{TargetArchitecture}, license: {License})";
        }
        #endregion Methods
    }
}