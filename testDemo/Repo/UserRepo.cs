using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using testDemo.Data;
using testDemo.IRepo;
using testDemo.Models.Auth;

namespace testDemo.Repo
{
    public class UserRepo : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<User> GetUserByLogin(string login)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(p=>p.UserName==login);
        }
    }
}
