using TOS.Security.Models;

namespace TOS.Application.Security.Utils
{
    public interface IPasswordUtils
    {
        bool ValidatedPassword(string password, PasswordHash passwordHash);
    }
}
