using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Resources;
using Leasing.API.App.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Leasing.API.App.Persistence.Repositories
{

    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }
        
        public async Task<User> FindByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> FindByEmailAndPasswordAsync(string email, string password)
        {
            var User =  _context.Users.
                Where(u=>u.Correo == email && u.Contrasenia==password)
                .FirstOrDefault();

            return User;
        }

        public async Task AddAsync(User User)
        {
            await _context.Users.AddAsync(User);
        }

        public void Update(User User)
        {
            _context.Users.Update(User);
        }

        public void Remove(User User)
        {
            _context.Users.Remove(User);
        }
    }
}