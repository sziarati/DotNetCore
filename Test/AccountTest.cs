using WebApi.Dtos;
using WebApi.Validators;
using Xunit;

namespace Test
{
    public class AccountValidatorTest
    {
        private readonly WithdrawDtoValidator _withdrawDtoValidator;

        public AccountValidatorTest(WithdrawDtoValidator withdrawDtoValidator)
        {
            _withdrawDtoValidator = withdrawDtoValidator;
        }

        [Fact]
        [InlineData(100)]
        public async Task withdrawDtoValidatorTest()
        {
            //var dto = new WithdrawDto() { 
            //    FromAccount = Guid.NewGuid(),
            //    ToAccount = Guid.NewGuid(),
            //    Balance = 1,
            //};

            //_withdrawDtoValidator.ValidateAsync();
            //Assert.True(result);
            //Assert.False(result, "Money did note moved.");
        }
    }
}