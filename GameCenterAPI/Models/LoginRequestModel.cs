using Microsoft.EntityFrameworkCore;

namespace GameCenterAPI.Models
{
   
    public class LoginRequestModel
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class LoginResponseModel
    {
        public string Token { get; set; }
        public int userid { get; set; }
    }
    public interface IAuthService
    {
        Task<LoginResponseModel> LoginAsync(string username, string password);
    }
    public interface ITokenService
    { 
        string GenerateToken(TbUser user);
    }
    public class TokenServise() : ITokenService
    {
        public string GenerateToken(TbUser user)
        {
            // تستطيع انشاء توكن هنا
            // يمكنك استخدام مكتبة مثل System.IdentityModel.Tokens.Jwt لإنشاء الرموز
            return "generate_token";
        }
    }
    public interface IUserRepository
    {
        Task<TbUser> GetUserByUsernameAndPasswordAsync(string username, string password);
    }
    public class UserRepository : IUserRepository
    {
        private readonly GamecenterContext _context;
        public UserRepository(GamecenterContext context)
        {
            _context = context;
        }
        public async Task<TbUser> GetUserByUsernameAndPasswordAsync(string username, string password)
        {
            
           return await _context.TbUsers.FirstOrDefaultAsync(u=>u.UUsername == username && u.UPassword == password);
        }
    }
}
