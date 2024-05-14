using Common.Bases;
using Core.Entities;

namespace Core.Features.Accounts.Interfaces
{
    public interface IAccountRepository : ITransient
    {
        public Task<Guid> Add(Account account);
        public Task<bool> Update(Account account);
        public Task<bool> Delete(int Id);
        public Task<bool> MoveMoney(Tuple<Guid, Guid> account, double balance);
    }
}