namespace TOS.CaseChecker.Application.Utils
{
    public interface ICaseUrlQueryBuilder
    {
        string Build(int julianDate, params int[] caseNumbers);
        string Build(params string[] caseNumbers);
    }
}