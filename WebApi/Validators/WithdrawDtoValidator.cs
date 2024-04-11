using FluentValidation;
using WebApi.Dtos;

namespace WebApi.Validators
{
    public class WithdrawDtoValidator : AbstractValidator<WithdrawDto>
    {
        public WithdrawDtoValidator()
        {
            RuleFor(model => model.FromAccount)
                .NotEmpty()
                .NotNull();

            RuleFor(model => model.ToAccount)
                .NotEmpty()
                .NotNull();

            RuleFor(model => model.Balance)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
        }
    }
}