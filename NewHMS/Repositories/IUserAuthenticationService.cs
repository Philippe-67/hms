using NewHMS.DTO;

namespace NewHMS.Repositories
{
    public interface IUserAuthenticationService
    {
        Task<Status> LoginAsync(LoginModel model) ;
        Task LogoutAsync();
         Task<Status> RegisterAsync(RegistrationModel model);
    }
}
