namespace TOS.Common.Utils
{
    public interface IEqualityChecker
    {
        bool AreEquals(object first, object second);
        bool AreEquals(string first, string second, bool ignoreCase = false);
    }
}