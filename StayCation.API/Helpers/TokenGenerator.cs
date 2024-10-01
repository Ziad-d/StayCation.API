using Microsoft.IdentityModel.Tokens;
using StayCation.API.Constants;
using StayCation.API.DTOs.UserDTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StayCation.API.Helpers
{
    public static class TokenGenerator
    {
        public static string GenerateToken(UserDTO userDTO)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtSettings.Key);

            var claims = new List<Claim>
            {
                new Claim(CustomClaimTypes.Id, userDTO.Id.ToString()),
                new Claim(CustomClaimTypes.UserName, userDTO.UserName)
            };

            if (userDTO.RoleIds != null && userDTO.RoleIds.Any())
            {
                foreach (var roleId in userDTO.RoleIds)
                {
                    claims.Add(new Claim(CustomClaimTypes.RoleId, roleId.ToString()));
                }
            }
            else
            {
                Console.WriteLine("RoleIds are null or empty");
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(JwtSettings.DurationInMinutes),
                Issuer = JwtSettings.Issuer,
                Audience = JwtSettings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
