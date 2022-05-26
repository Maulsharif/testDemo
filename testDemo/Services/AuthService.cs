using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using testDemo.Dto.Auth;
using testDemo.IRepo;
using testDemo.IServices;
using testDemo.Models.Auth;

namespace testDemo.Services
{
    public class AuthService:IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public AuthService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository  = userRepository;
            _roleRepository = roleRepository;
        }

        public bool CheckPassword(User user, LoginModel loginModel)
        {
            if (user.UserName == loginModel.UserName && user.Password == loginModel.Password)
                return true;
            return false; 
        }

        public async Task<bool> CheckUser(LoginModel loginModel )
        {
            var user = await _userRepository.GetUserByLogin(loginModel.UserName);
            if (user != null)
                return CheckPassword(user, loginModel);
            return false;

        }
        public async Task<string> GetToken(LoginModel loginModel)
        {
            var user = await  _userRepository.GetUserByLogin(loginModel.UserName);
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenConstants.SigningKey));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var claims = await  GetUserClaims(user);
            var tokeOptions = new JwtSecurityToken(
                issuer: TokenConstants.Issuer,
                audience: TokenConstants.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(TokenConstants.ExpiryInMinutes),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }

        public async Task<List<Claim>> GetUserClaims(User user)
        {
            var role = await _roleRepository.GetRoleById(user?.RoleId.ToString());

             var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, role.Code)
                };
            return claims;
        }
    }
}
