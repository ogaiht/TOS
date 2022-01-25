using System;

namespace TOS.CaseChecker.Application.Utils
{
    public interface IJulianDateConverter
    {
        double ToJulian(DateTime gregorianDate);
    }
}