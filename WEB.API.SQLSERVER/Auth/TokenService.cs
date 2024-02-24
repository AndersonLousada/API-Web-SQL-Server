using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WEB.API.SQLSERVER.DOMINIO.Entidades;

namespace WEB.API.SQLSERVER.Auth
{
    public class TokenService
    {
        public string? GetToken(User user)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var secretKey = Environment.GetEnvironmentVariable("SECRET_KEY") ?? throw new Exception("Variável de ambiente (SECRET_KEY) não foi encontrada.");
                var key = Encoding.ASCII.GetBytes(secretKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Role, user.Role!),
                    }),
                    Expires = DateTime.UtcNow.AddHours(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao gerar o token: " + ex.Message, ex);
            }
        }
    }
}