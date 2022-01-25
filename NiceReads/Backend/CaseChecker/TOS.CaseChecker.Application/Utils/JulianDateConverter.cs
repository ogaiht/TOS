using System;

namespace TOS.CaseChecker.Application.Utils
{
    public class JulianDateConverter : IJulianDateConverter
    {
        private const double GregorianStartDate = 2415018.5;
        public double ToJulian(DateTime gregorianDate)
        {
            return (gregorianDate.Year - 2000) * 1000 + gregorianDate.DayOfYear;
            //return gregorianDate.ToOADate() + GregorianStartDate;
        }
    }
}
