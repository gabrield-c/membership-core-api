
using MembershipCore.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace MembershipCore.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Membership> Memberships { get; set; }

    }
}
