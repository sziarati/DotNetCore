using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Users.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly appDbContext _context;

        public UserRepository(appDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(User user)
        {
            _context.Users.Add(user);
            var result = await _context.SaveChangesAsync();
            return result > 0 ? user.Id : 0;
        }

        public async Task<bool> Delete(int Id)
        {
            var user = _context.Users.FirstOrDefault(p => p.Id == Id);
            if (user is null)
                return false;

            _context.Users.Remove(user);
            var result = await _context.SaveChangesAsync();
            return result > 0 ? true : false;
        }

        public async Task<bool> Update(User user)
        {
            var userFounded = _context.Users.FirstOrDefault(p => p.Id == user.Id);

            if (userFounded == null)
                return false;

            _context.Entry(userFounded).State = EntityState.Modified;

            var result = await _context.SaveChangesAsync();
            return result > 0 ? true : false;
        }
    }
}

