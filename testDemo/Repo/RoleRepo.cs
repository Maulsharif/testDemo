using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using testDemo.Data;
using testDemo.IRepo;
using testDemo.Models.Auth;

namespace testDemo.Repo
{
    public class RoleRepo : IRoleRepository
    {
        private readonly AppDbContext _appDbContext;
        public RoleRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

       public async Task<Role> GetRoleById(string roleId)
        {
            return await _appDbContext.Roles.FirstOrDefaultAsync(p=>p.ID.ToString()== roleId);
        }
    }
}
