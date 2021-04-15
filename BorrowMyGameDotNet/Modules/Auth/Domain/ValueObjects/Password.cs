namespace BorrowMyGameDotNet.Modules.Auth.Domain.ValueObjects
{
    public class Password
    {
        private readonly string _value;

        public Password(string value)
        {
            _value = value;
        }

        public static Password Of(string value)
        {
            return new Password(value);
        }

        public string AsString()
        {
            return _value;
        }
    }
}