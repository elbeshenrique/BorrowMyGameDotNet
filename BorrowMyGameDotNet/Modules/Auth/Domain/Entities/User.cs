using BorrowMyGameDotNet.Modules.Auth.Domain.ValueObjects;

namespace BorrowMyGameDotNet.Modules.Auth.Domain.Entities
{
    public class User
    {
        public readonly Identifier Id;
        public readonly Email Email;
        public readonly Password Password;
    }
}