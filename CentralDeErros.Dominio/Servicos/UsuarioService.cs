using CentralDeErros.Dominio.Modelos;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CentralDeErros.Dominio.Servicos
{
    public class UsuarioService : IUsuarioService
    {
        private readonly Token _token;

        public UsuarioService(IOptions<Token> token)
        {
            _token = token?.Value;
        }

        public string GerarToken(IdentityUser usuario)
        {
            if (usuario == null) return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_token.Secret);

            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = _token.Emissor,
                Audience = _token.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(_token.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(descriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
