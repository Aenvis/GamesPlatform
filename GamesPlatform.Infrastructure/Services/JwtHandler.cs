using GamesPlatform.Infrastructure.DTOs;
using GamesPlatform.Infrastructure.Extensions;
using GamesPlatform.Infrastructure.Settings;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GamesPlatform.Infrastructure.Services
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSettings _jwtSettigs;

        public JwtHandler(JwtSettings jwtSettigs)
        {
            _jwtSettigs = jwtSettigs;
        }

        public JwtDto CreateToken(string email, string role)
        {
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToTimestamp().ToString(), ClaimValueTypes.Integer64)
            };

            var expires = now.AddMinutes(_jwtSettigs.ExpiryMinutes);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettigs.Key));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: _jwtSettigs.Issuer,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: signingCredentials
                );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtDto(token:   token,
                              expires: expires.ToTimestamp());
        }
    }
}
