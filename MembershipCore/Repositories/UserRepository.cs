using MembershipCore.Data;
using MembershipCore.Models;
using Microsoft.EntityFrameworkCore;

namespace MembershipCore.Repositories
{
    public class UserRepository : IUserRepository //Implementa la interfaz IUserRepository
    {
        private readonly AppDbContext _context; // Conexion con la base de datos

        //Constructor donde se inyectan las dependencias 
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        //Obtener todos los usuarios
        public async Task<IEnumerable<User>> GetAllAsync() // se implementa GetAllAsync() de IUserRepository
            => await _context.Users.ToListAsync(); // se implementa ToListAsync(), un metodo de extension que equivale a: SELECT * FROM Users

        //Buscar usuario por ID
        public async Task<User?> GetByIdAsync(int id)
            => await _context.Users 
            .Include(u => u.Membership)//carga la relación Membership
            .FirstOrDefaultAsync(u => u.Id == id);

        //Buscar usuario por email
        public async Task<User?> GetByEmailAsync(string email)
            => await _context.Users 
            .FirstOrDefaultAsync(u => u.Email == email);

        //Crear usuario
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user); //agrega el usuario al contexto
            await _context.SaveChangesAsync(); //guarda en la base de datos.
        }

        //Actualizar usuario
        public async Task UpdateAsync(User user)
        {
            //Marca el usuario como modificado y guarda
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        //Eliminar usuario
        public async Task DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if (user is not null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
