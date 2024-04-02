using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Personels
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.AcountGuid)
                .HasDefaultValueSql("NEWID()");

            //TPH
            builder.HasDiscriminator<AccountType>("Type")
                 .HasValue<SavingAccount>(AccountType.SAVINGS_ACCOUNT)
                 .HasValue<CheckingAccount>(AccountType.CHECKING_ACCOUNT)
                 .HasValue<Account>(AccountType.UNKNOWN);

        }
    }
}
