using System;
using System.Configuration;
using System.Security.Claims;
using DataNC;
using LogicaNC;
using Microsoft.IdentityModel.Tokens;
using Utilitarios;

namespace ApiServiciosNC.Security
{
    /// <summary>
    /// JWT Token generator class using "secret-key"
    /// more info: https://self-issued.info/docs/draft-ietf-oauth-json-web-token.html
    /// </summary>
    internal static class TokenGenerator
    {
        public static string GenerateTokenJwt(URegistro user, string secretKey, string audienceToken, string issuerToken, string expira, Mapeo _context)
        {
            //TODO: appsetting for Demo JWT - protect correctly this settings

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // create a claimsIdentity 
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, user.Usuario),
                new Claim(ClaimTypes.Role, user.Idestado.ToString())

            });

            // create token to the user 

            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);

            LoginToken token = new LoginToken();
            token.FechaGenerado = DateTime.Now;
            token.FechaVigencia = DateTime.Now.AddMinutes(15);
            token.User_id = user.Id;
            token.Token = jwtTokenString;
            new LLogin(_context).guardarToken(token);
            return jwtTokenString;
        }
    }
}
