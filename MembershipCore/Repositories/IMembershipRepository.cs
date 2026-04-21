using MembershipCore.Models;

namespace MembershipCore.Repositories
{
    public interface IMembershipRepository
    {
        // Obtener membresías por usuario
        Task<Membership?> GetByUserIdAsync(int userId);//Busca la membresía asociada al usuario
        Task AddAsync(Membership membership);
        Task UpdateAsync(Membership membership);
    }
}
