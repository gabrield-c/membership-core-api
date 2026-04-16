using System.ComponentModel.DataAnnotations;

namespace MembershipCore.Models
{
    public class Membership
    {
        [Key]
        public int Id { get; set; }
    }
}
