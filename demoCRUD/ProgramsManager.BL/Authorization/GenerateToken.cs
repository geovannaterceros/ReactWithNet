
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProgramsManager.BL.Authorization
{
    public static class GenerateToken
    {
        public static string GetToken(string key, DateTime timeExpiration, string email, string name, string issuer, string audience) 
        {
            //Create signing for credential
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, 
                                                                           SecurityAlgorithms.HmacSha256);
            //Additional information
            List<Claim> claims = new List<Claim>(){
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Name, name)
            };


            JwtSecurityToken tokenOptions = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: timeExpiration,
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}
