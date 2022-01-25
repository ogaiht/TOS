namespace TOS.CaseChecker.Application.Utils
{
    public class CaseQueryBuilderConfig : ICaseQueryBuilderConfig
    {
        public string Format { get; set; }
        public string Url { get; set; }
        public string ExtraParams { get; set; }
    }
}
