using SalesWS.Models.Response;
using SalesWS.Models.ViewModels;

namespace SalesWS.Services
{
    public interface IUserService
    {
        UserResponse Auth(AuthViewModel model);
    }
}
