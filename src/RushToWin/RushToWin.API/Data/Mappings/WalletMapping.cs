using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RushToWin.API.Domain.Entities;

namespace RushToWin.API.Data.Mappings
{
    public class WalletMapping : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(c => c.Balance)
                .IsRequired();         
        }
    }
}
