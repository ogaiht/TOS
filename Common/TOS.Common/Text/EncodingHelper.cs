using System.IO;
using System.Text;

namespace TOS.Common.Text
{
    public class EncodingHelper : IEncodingHelper
    {
        public byte[] GetUTF8Bytes(string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }

        public Stream GetUTF8Stream(string text)
        {
            return new MemoryStream(GetUTF8Bytes(text));
        }
    }
}
