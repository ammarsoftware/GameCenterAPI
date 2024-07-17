using GameCenterAPI.Models;

namespace GameCenterAPI.Controllers
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<LoginResponseModel> LoginAsync(string username, string password)
        {
            //للتحقق من المستخدم
            var user = await _userRepository.GetUserByUsernameAndPasswordAsync(username, password);
            if (user == null)
            {
                return null;
            }

            var token = _tokenService.GenerateToken(user);

            return new LoginResponseModel
            {
                Token = token,
                userid = user.UId
            };
        }
    }
}
//end