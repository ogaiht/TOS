using TOS.NiceReads.Models;

namespace TOS.NiceReads.Application.Utils
{
    public interface IPasswordUtils
    {
        bool ValidatedPassword(string password, PasswordHash passwordHash);
        PasswordHash CreatePasswordHash(string password);
    }
}
