using System.Text;

namespace TOS.CaseChecker.Application.Utils
{
    public class CaseUrlQueryBuilder : ICaseUrlQueryBuilder
    {
        private readonly ICaseQueryBuilderConfig _config;
        private readonly string urlFormat = "https://flag.dol.gov/datahub/docs?api-version=2020-06-30&%24format=application%2Fjson%3Bodata.metadata%3Dnone&search={0}$select=visaType%2C%20caseNumber%2C%20employerName%2C%20jobTitle%2C%20submittedDate%2C%20caseStatus&$orderby=submittedDate%20asc";

        public CaseUrlQueryBuilder(ICaseQueryBuilderConfig config)
        {
            _config = config;
        }

        public string Build(int julianDate, params int[] caseNumbers)
        {
            string format = string.Format("P-100-{0}-", julianDate);
            StringBuilder numberBuilder = new StringBuilder();
            foreach (int caseNumber in caseNumbers)
            {
                numberBuilder.Append(format + caseNumber).Append("%20");
            }
            return string.Format(urlFormat, numberBuilder);
        }

        public string Build(params string[] caseNumbers)
        {
            string numbers = string.Join("%20", caseNumbers);
            return string.Format(urlFormat, numbers);
        }
    }
}
