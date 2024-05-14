using Common.Bases;
using Core.Dtos;
using Core.Entities;

namespace Core.Features.Accounts.Interfaces
{
    public interface IAccountReader : ITransient
    {
        public Task<List<AccountInfo>> GetHistory(Guid accountGuid, DateTime validFrom, DateTime validTo);
        public Account GetAccount(Guid accountGuid);

    }
}