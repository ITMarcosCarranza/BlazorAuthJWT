using BlazorJWT.Shared;

namespace BlazorJWT.Client
{
    public interface IAuthService
    {
        public Task<LoginResult> Login(LoginModel loginModel);
        public Task Logout();
    }
}
