using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SalesWS.Models;
using SalesWS.Models.Common;
using SalesWS.Models.Response;
using SalesWS.Models.ViewModels;
using SalesWS.Tools;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SalesWS.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public UserResponse Auth(AuthViewModel model)
        {
            UserResponse response = new UserResponse();
            using (var context = new Sales_CourseContext())
            {
                string password = Encrypt.GetSHA256(model.Password);
                var user = context.Users
                                 .Where(u => u.Email == model.Email
                                        && u.Password == password)
                                 .FirstOrDefault();
                if (user == null) return null;
                response.Email = user.Email;
                response.Token = GetToken(user);
            }
            return response;
        }
        private string GetToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretJWT);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                     new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Email, user.Email),
                    }
                ),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
             
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return  tokenHandler.WriteToken(token);
        }
    }


}