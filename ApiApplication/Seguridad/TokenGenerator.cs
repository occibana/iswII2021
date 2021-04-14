using System;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.Security.Claims;

namespace ApiApplication.Seguridad
{
    /// <summary>
    /// JWT Token generator class using "secret-key"
    /// more info: https://self-issued.info/docs/draft-ietf-oauth-json-web-token.html
    /// </summary>
    internal static class TokenGenerator
    {
        
        public static string GenerateTokenJwt(string username)
        {
            
            // appsetting for Token JWT
            var audienceToken = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"];
            var issuerToken = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"];

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(username.Key));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // create a claimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, username)
            });

            // create token to the user
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(username.Expiracion),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);

            return jwtTokenString;
            
        }
    
    }
}