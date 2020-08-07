using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WS_TexasSales.Models;
using WS_TexasSales.Models.Common;
using WS_TexasSales.Models.Request;
using WS_TexasSales.Models.Response;
using WS_TexasSales.Tools;

namespace WS_TexasSales.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appsettings) 
        {
            _appSettings = appsettings.Value;
        }

        public UserResponse Response (AuthRequest auth)
        {
            UserResponse userResponse = new UserResponse();
            using (var db = new texas_salesdbContext())
            {
                string sPass = Encrypt.GetSHA256(auth.Pass);

                var user = db.Users.Where(db => db.Username == auth.Username && db.Pass == sPass).FirstOrDefault();

                if (user == null) return null;
                userResponse.Username = user.Username;
                userResponse.Token = GetToken(user);
            }
            return userResponse;
        }

        private string GetToken(Users users)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[] 
                    {
                        new Claim(ClaimTypes.NameIdentifier, users.Id.ToString()),
                        new Claim(ClaimTypes.Name, users.Username)
                    }),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
