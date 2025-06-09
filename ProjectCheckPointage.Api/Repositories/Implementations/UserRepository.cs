using Microsoft.EntityFrameworkCore;
using ProjectCheckPointage.Api.Data;
using ProjectCheckPointage.Api.Repositories.Interfaces;

namespace ProjectCheckPointage.Api.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Utilisateur?> GetByUsernameAsync(string username)
        {
            return await _context.Utilisateurs
                                 .Include(u => u.RoleType)
                                 .FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<Utilisateur?> GetByIdAsync(Guid id)
        {
            return await _context.Utilisateurs.FindAsync(id);
        }

        public async Task AddAsync(Utilisateur user)
        {
            await _context.Utilisateurs.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Utilisateur user)
        {
            _context.Utilisateurs.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await GetByIdAsync(id);
            if (user is not null)
            {
                _context.Utilisateurs.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }

}
