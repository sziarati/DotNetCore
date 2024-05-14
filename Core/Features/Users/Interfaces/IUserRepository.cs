using Common.Bases;
using Core.Entities;

namespace Core.Features.Users.Interfaces
{
    public interface IUserRepository : ITransient
    {
        public Task<int> Add(User user);
        public Task<bool> Update(User user);
        public Task<bool> Delete(int Id);
    }
}