namespace TOS.Common.Security.Tokens
{
    public interface ISecurityTokenCreator
    {        
        TokenResult CreateSecurityToken(TokenCreationInfo tokenCreationInfo);
        
        TokenResult IssueNewToken(TokenUpdateInfo tokenUpdateInfo);
    }
}
