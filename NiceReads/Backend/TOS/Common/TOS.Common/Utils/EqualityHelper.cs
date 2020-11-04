using System;

namespace TOS.Common.Utils
{
    public static class EqualityHelper
    {
        public static bool AreEquals(object first, object second)
        {
            return !((first == null && second != null) || (first != null && !first.Equals(second)));
        }

        public static bool AreEquals(string first, string second, bool ignoreCase = false)
        {
            return string.Equals(first, second, ignoreCase ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture);
        }
    }
}
