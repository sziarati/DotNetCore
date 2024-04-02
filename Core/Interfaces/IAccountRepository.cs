using Core.Entities;

namespace Core.Interfaces
{
    public interface IAccountRepository
    {
        public Task<decimal> Add(Account account);
        public Task<bool> Update(Account account);
        public Task<bool> Delete(int Id);
        public Task<bool> MoveMoney(Tuple<Guid, Guid> account, double balance);
    }
}