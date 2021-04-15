namespace BorrowMyGameDotNet.Modules.Core.Domain.ValueObjects
{
    public class IsBorrowed
    {
        private readonly bool _value;

        public IsBorrowed(bool value)
        {
            _value = value;
        }

        public static IsBorrowed Of(bool value)
        {
            return new IsBorrowed(value);
        }

        public bool AsBool()
        {
            return _value;
        }
    }
}