using MembershipCore.Data;
using MembershipCore.Models;
using Microsoft.EntityFrameworkCore;

namespace MembershipCore.Repositories
{
    public class MembershipRepository : IMembershipRepository //implementa la interfaz
    {

        private readonly AppDbContext _context; //Conexión a la base de datos

        public MembershipRepository(AppDbContext context)
        {
            _context = context;
        }

        //Buscar membresía por usuario
        public async Task<Membership?> GetByUserIdAsync(int userId)
       => await _context.Memberships
           .FirstOrDefaultAsync(m => m.UserId == userId);

        //Crear membresía
        public async Task AddAsync(Membership membership)
        {
            await _context.Memberships.AddAsync(membership);
            await _context.SaveChangesAsync();
        }

        //Actualizar membresía
        public async Task UpdateAsync(Membership membership)
        {
            _context.Memberships.Update(membership);
            await _context.SaveChangesAsync();
        }

    }
}
