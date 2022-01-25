namespace TOS.CaseChecker.Application.Utils
{
    public interface ICaseQueryBuilderConfig
    {
        string ExtraParams { get; }
        string Format { get; }
        string Url { get; }
    }
}