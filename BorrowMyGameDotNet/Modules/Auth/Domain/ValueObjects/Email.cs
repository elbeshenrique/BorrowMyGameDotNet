namespace BorrowMyGameDotNet.Modules.Auth.Domain.ValueObjects
{
    public class Email
    {
        private readonly string _value;

        public Email(string value)
        {
            _value = value;
        }

        public static Email Of(string value)
        {
            return new Email(value);
        }

        public string AsString()
        {
            return _value;
        }
    }
}