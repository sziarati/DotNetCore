using Common.Bases;
using Core.Dtos;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IAccountRepository: ITransient
    {
        public Task<Guid> Add(Account account);
        public Task<bool> Update(Account account);
        public Task<bool> Delete(int Id);
        public Task<bool> MoveMoney(Tuple<Guid, Guid> account, double balance);
        public Task<List<AccountInfo>> GetHistory(Guid accountGuid, DateTime validFrom, DateTime validTo);
    }
}