using System.ComponentModel.DataAnnotations;

namespace MembershipCore.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        //Relación para que el usuario pueda tener una membresía
        public Membership? Membership { get; set; }

    }
}
