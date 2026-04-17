using System.ComponentModel.DataAnnotations;

namespace MembershipCore.Models
{
    public class Membership
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; } // FK hacia User
        public MembershipPlan Plan { get; set; } // Bronce, Plata, Oro
        public MembershipStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Navegación hacia el dueño
        public User? User { get; set; }
    }
}
