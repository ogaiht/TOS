namespace TOS.CaseChecker.Application.Utils
{
    public interface ICaseNumberGenerator
    {
        int[] Generate(int count, int startNumber, int increment, out int nextCaseNumber);
    }
}