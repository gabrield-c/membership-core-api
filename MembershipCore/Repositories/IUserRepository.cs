using MembershipCore.Models;

namespace MembershipCore.Repositories
{
    // Interfaz para manejar usuarios en la base de datos
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();// Obtener todos los usuarios
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}
