using System.Threading.Tasks;
using testDemo.Dto.Auth;
using testDemo.Models.Auth;

namespace testDemo.IServices
{
    public interface IAuthService
    {
        Task<bool> CheckUser(LoginModel loginModel);
        Task<string> GetToken(LoginModel loginModel);
    }
}
