namespace BorrowMyGameDotNet.Modules.Core.Domain.ValueObjects
{
    public class Title
    {
        private readonly string _value;

        public Title(string value)
        {
            _value = value;
        }

        public static Title Of(string value)
        {
            return new Title(value);
        }

        public string AsString()
        {
            return _value;
        }
    }
}