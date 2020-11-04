using System.IO;

namespace TOS.Common.Text
{
    public interface IEncodingHelper
    {
        byte[] GetUTF8Bytes(string text);
        Stream GetUTF8Stream(string text);
    }
}
