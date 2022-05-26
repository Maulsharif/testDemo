using System.Collections.Generic;
using System.Threading.Tasks;
using testDemo.Dto;
using testDemo.Models;
using testDemo.Models.Auth;

namespace testDemo.IRepo
{
    public interface IUserRepository
    {
        Task<User> GetUserByLogin(string login);
    }
}
