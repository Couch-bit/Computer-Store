namespace Classes
{
    public class WrongKeyException : Exception
    {
        public WrongKeyException() : base() { }
        public WrongKeyException(string message): base(message) { }
    }

    public class NipValidationException : Exception
    {
        public NipValidationException() : base() { }
        public NipValidationException(string message) : 
            base(message) { }
    }

    public class WrongNameException : Exception
    {
        public WrongNameException() : base() { }
        public WrongNameException(string message) : base(message) { }
    }

    public class CartException : Exception
    {
        public CartException() : base() { }
        public CartException(string message) : base(message) { }
    }

    public class NumericException : Exception 
    {
        public NumericException() : base() { }
        public NumericException(string message) : base(message) { }
    }

    public class ProductException : Exception
    {
        public ProductException() : base() { }
        public ProductException(string message) : base(message) { }
    }

    public class WrongDateException : Exception
    {
        public WrongDateException() : base() { }
        public WrongDateException(string message) : base(message) { }
    }

    public class WrongZipCodeException : Exception 
    {
        public WrongZipCodeException() : base() { }
        public WrongZipCodeException(string message) :
            base(message) { }
    }

    public class PhoneNumberException : Exception
    {
        public PhoneNumberException() : base() { }
        public PhoneNumberException(string message) :
            base(message) { }
    }

    public class WrongEmailException : Exception
    {
        public WrongEmailException() : base() { }
        public WrongEmailException(string message) :
            base(message)
        { }
    }

    public class SerializationException : Exception
    {
        public SerializationException() : base() { }
        public SerializationException(string message) :
            base(message) { }
    }

    public class WrongParameterException : Exception
    {
        public WrongParameterException() : base() { }
        public WrongParameterException(string message) : base(message) { }
    }

    public class DuplicateException : Exception 
    {
        public DuplicateException() : base() { }
        public DuplicateException(string message) : base(message) { }
    }

}