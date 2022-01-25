namespace TOS.Common.Utils
{
    public class EqualityChecker : IEqualityChecker
    {
        public bool AreEquals(object first, object second)
        {
            return EqualityHelper.AreEquals(first, second);
        }

        public bool AreEquals(string first, string second, bool ignoreCase = false)
        {
            return EqualityHelper.AreEquals(first, second, ignoreCase);
        }
    }
}
