using System;
using System.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Utilitarios;
using Logica;

namespace ApiApplication.Seguridad
{
    /// <summary>
    /// JWT Token generator class using "secret-key"
    /// more info: https://self-issued.info/docs/draft-ietf-oauth-json-web-token.html
    /// </summary>
    internal static class TokenGenerator
    {
        
        public static string GenerateTokenJwt(URegistro usuario_login)
        {
            
            // appsetting for Token JWT
            var audienceToken = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"];
            var issuerToken = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"];

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes("generartokenlogin"));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // create a claimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Role, usuario_login.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario_login.Usuario),
                new Claim(ClaimTypes.Rsa, usuario_login.Contrasena)
            });

            // create token to the user
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);

            LoginToken token = new LoginToken();
            token.Userer_id = usuario_login.Id;
            token.FechaGenerado = DateTime.Now;
            token.FechaVigencia = DateTime.Now.AddMinutes(15);
            token.Token = jwtTokenString;
            new LLogin().guardarToken(token);

            return jwtTokenString;
            
        }
    
    }
}