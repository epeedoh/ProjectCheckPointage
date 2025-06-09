using ProjectCheckPointage.Api.Data;

namespace ProjectCheckPointage.Api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<Utilisateur?> GetByUsernameAsync(string username);
        Task<Utilisateur?> GetByIdAsync(Guid id);
        Task AddAsync(Utilisateur user);
        Task UpdateAsync(Utilisateur user);
        Task DeleteAsync(Guid id);
    }
}
