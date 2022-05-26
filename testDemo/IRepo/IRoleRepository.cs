using System.Collections.Generic;
using System.Threading.Tasks;
using testDemo.Models.Auth;

namespace testDemo.IRepo
{
    public interface IRoleRepository
    {
        Task<Role> GetRoleById(string roleId);
    }
}
