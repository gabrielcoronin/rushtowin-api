using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RushToWin.API.Domain.Entities;

namespace RushToWin.API.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(c => c.FullName)
                .IsRequired();

            builder.Property(c => c.CPF)
                 .IsRequired();

            builder.Property(c => c.Email)
                 .IsRequired();

            builder.Property(c => c.Password)
                 .IsRequired();

            builder.Property(c => c.CreatedAt)
                  .IsRequired();

            builder.Property(c => c.UpdatedAt)
                   .IsRequired();
    
            builder.HasOne(u => u.Wallet);

        }
    }
}
