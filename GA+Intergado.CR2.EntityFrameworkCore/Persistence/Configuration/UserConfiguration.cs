using GA_Intergado.CR2.Domain.Ingredients;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GA_Intergado.CR2.Domain.Users.ValueObjects;
using GA_Intergado.CR2.Domain.Users;

namespace GA_Intergado.CR2.EntityFrameworkCore.Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            ConfigureIngredientTable(builder);
        }

        private void ConfigureIngredientTable(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(m => m.Id);

            builder
              .Property(m => m.Id)
              .HasConversion(
                  id => id.Value,
                  value => UserId.Create(value));

            builder
                .Property(m => m.ModifierUserId)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value));

            builder.Property(x => x.status);

            builder
                .Property(m => m.LastModifiedDateTime);

            builder.Property(e => e.Password);

            builder
              .Property(m => m.UserName)
              .HasMaxLength(100);

            builder.Property(m => m.UserType);
        }
    }
}
