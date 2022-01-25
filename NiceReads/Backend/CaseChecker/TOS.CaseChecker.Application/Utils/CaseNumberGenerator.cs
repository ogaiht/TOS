namespace TOS.CaseChecker.Application.Utils
{
    public class CaseNumberGenerator : ICaseNumberGenerator
    {
        public int[] Generate(int count, int startNumber, int increment, out int nextCaseNumber)
        {
            int[] caseNumbers = new int[count];
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    caseNumbers[i] = startNumber;
                }
                else
                {
                    caseNumbers[i] = caseNumbers[i - 1] + increment;
                }
            }
            nextCaseNumber = caseNumbers[caseNumbers.Length - 1] + increment;
            return caseNumbers;
        }
    }
}
