
using MembershipCore.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace MembershipCore.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //Tablas
        public DbSet<User> Users { get; set; }
        public DbSet<Membership> Memberships { get; set; }

        //Configuración del modelo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Relacion de 1 a 1 entre User y Membership
            //Un usuario tiene solo una membresía
            modelBuilder.Entity<User>()
                .HasOne(u  => u.Membership)
                .WithOne(m  => m.User)
                .HasForeignKey<Membership>(m  => m.UserId);

            //Email unico por usuario
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }


    }
}
