using Microsoft.IdentityModel.Tokens;

namespace BorrowMyGameDotNet.Modules.Auth.Security
{
    public class JwtSecurityInfo
    {
        public const string Algorithm = SecurityAlgorithms.HmacSha256;
        public const string SecurityKey = "borrowmygame_is_awesome!";

        public const string Issuer = "Gordon Freeman";
        public const string Audience = "registered_users";

        public const string UserRole = "User";
        public const string AdminRole = "Admin";

        public const int DaysToExpire = 30;
    }
}