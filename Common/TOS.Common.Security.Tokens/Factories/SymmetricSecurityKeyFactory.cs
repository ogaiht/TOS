using Microsoft.IdentityModel.Tokens;
using TOS.Common.Text;

namespace TOS.Common.Security.Tokens.Factories
{
    public class SymmetricSecurityKeyFactory : ISymmetricSecurityKeyFactory
    {
        private readonly IEncodingHelper _encodingHelper;

        public SymmetricSecurityKeyFactory(IEncodingHelper encodingHelper)
        {
            _encodingHelper = encodingHelper;
        }

        public SymmetricSecurityKey CreateSymmetricKey(string key)
        {
            byte[] byteKey = _encodingHelper.GetUTF8Bytes(key);
            return new SymmetricSecurityKey(byteKey);
        }
    }
}
