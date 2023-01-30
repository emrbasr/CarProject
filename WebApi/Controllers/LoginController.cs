using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SqlDbContext context;
        private readonly IConfiguration configuration;

        public LoginController(SqlDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;

        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            User user = await context.Users
                                .Include(u => u.UserRoles)
                                .ThenInclude(p => p.Role)
                                .FirstOrDefaultAsync(p => p.Email == loginModel.Email && p.Password == loginModel.Password);
            if (user != null)
            {
                //Token Uretme asamasina gecelim.
                TokenHandler tokenHandler = new(configuration);
                Token token = tokenHandler.CreateAccessToken(user);

                //refresh toke'i User Tablosuna ekleyelim
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndTime = token.Expiration.AddMinutes(3);
                await context.SaveChangesAsync();
                return Ok(token);
            }
            return NotFound();
        }

    }
}
