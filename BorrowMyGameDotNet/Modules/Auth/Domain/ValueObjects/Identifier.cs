namespace BorrowMyGameDotNet.Modules.Auth.Domain.ValueObjects
{
    public class Identifier
    {
        private readonly int _value;

        public Identifier(int value)
        {
            _value = value;
        }

        public static Identifier Of(int value)
        {
            return new Identifier(value);
        }

        public int AsInt()
        {
            return _value;
        }
    }
}