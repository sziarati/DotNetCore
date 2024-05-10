﻿using Core.Entities;
using Core.Features.Accounts.Commands;
using Core.Interfaces;

namespace Application.Features.Account.Commands;

public class AccountCommandServices(IAccountRepository accountRepository) : IAccountCommandServices
{
    public async Task<Guid> CreateAccount(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var accountToAdd = AccountFactory.Create(request.Type, request.Balance);
        return await accountRepository.Add(accountToAdd);
    }
    public async Task<bool> DeleteAccount(DeleteAccountCommand request, CancellationToken cancellationToken)
    {
        return await accountRepository.Delete(request.AccountId);
    }
    public async Task<bool> WithDraw(WithdrawCommand request, CancellationToken cancellationToken)
    {
        var accounts = Tuple.Create(request.FromAccount, request.ToAccount);
        return await accountRepository.MoveMoney(accounts, request.Balance);
    }
}
