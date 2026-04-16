using System.ComponentModel.DataAnnotations;

namespace MembershipCore.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
    }
}
