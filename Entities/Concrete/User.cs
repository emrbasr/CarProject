using Core.Entities;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenEndTime { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }

    }
}
