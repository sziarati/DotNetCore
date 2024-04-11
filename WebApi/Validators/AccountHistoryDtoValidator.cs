using FluentValidation;
using WebApi.Dtos;

namespace WebApi.Validators
{
    public class AccountHistoryDtoValidator : AbstractValidator<AccountHistoryDto>
    {
        public AccountHistoryDtoValidator()
        {
            RuleFor(model => model.AccountGuid)
                .NotEmpty()
                .NotNull();

            RuleFor(model => model.ValidFrom)
                .LessThanOrEqualTo(DateTime.Now)
                .NotNull();

            RuleFor(model => model.ValidTo)
                .LessThanOrEqualTo(DateTime.Now);
        }
    }
}