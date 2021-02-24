using BuisnessLogicLayer.Interfaces;
using BuisnessLogicLayer.Models;
using DataAccessLayer.Constants;
using DataAccessLayer.Helpers;
using DataAccessLayer.Repository;
using DataAccessLayer.UnitOfWork;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TsukatTestTask.Entities;

namespace BuisnessLogicLayer.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _userRepository;
        private readonly TokenManagement _tokenManagement;
        public UsersService(IUnitOfWork unitOfWork, IOptions<TokenManagement> tokenManagement)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.GetRepository<User>();
            _tokenManagement = tokenManagement.Value;
        }

        public async Task AddUser(User user)
        {
            user.RoleId = new Guid(Constant.UserRoleId);
            _userRepository.Add(user);
            await _unitOfWork.SaveChanges();
        }

        public async Task DeleteUser(Guid id)
        {
            var user = _userRepository.GetOne(e => e.Id == id);
            _userRepository.Remove(user);
            await _unitOfWork.SaveChanges();
        }

        public IEnumerable<User> GetAllUser() => _userRepository.GetAll();                

        public async Task UpdateUser(Guid id, User updatedUser)
        {
            var user = _userRepository.GetOne(e => e.Id == id);
            user.Name = updatedUser.Name;
            user.Age = updatedUser.Age;
            _userRepository.Update(user);
            await _unitOfWork.SaveChanges();
        }

        private User Authorize(string email, string password)
        {
            var user = _userRepository.GetWithInclude(p => p.Role).FirstOrDefault(e => e.Email == email);
            if (Hash.VerifyHashedPassword(password, user.Password, _tokenManagement.Salt))
            {
                return user;
            }
            else
            {
                throw new Exception("You Have entered wrong password");
            }
        }
        private string GenerateJwt(User user)
        {
            var claim = new[]
            {
                    new Claim("Id", user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role.Name)
                };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                _tokenManagement.Issuer,
                _tokenManagement.Audience,
                claim,
                expires: DateTime.Now.AddMinutes(_tokenManagement.AccessLifetimeMinutes),
                signingCredentials: credentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return token;
        }

        public LoginResponse SignIn(LoginModel login)
        {
            var user = Authorize(login.Email, login.Password);
            var token = GenerateJwt(user);
            return (new LoginResponse()
            {
                Token = token
            });
        }
    }
}
