using Domain.Common;

namespace Domain.Entities
{
    public class Users : IdBaseEntity
    {
        public required string FirstName { get; set; }

        public string? SecondName { get; set; }

        public required string LastName { get; set; }

        public string? SecondLastName { get; set; }

        public required string FullName { get; set; }

        public required string UserName { get; set; }

        public required string PasswordHash { get; set; }

        public required string Email { get; set; }

        public bool IsActive { get; set; }

        public int RoleId { get; set; }

        public Roles Role { get; set; } = null!;

        public Guid LocationId { get; set; }

        public Locations Location { get; set; } = null!;
    }
}
