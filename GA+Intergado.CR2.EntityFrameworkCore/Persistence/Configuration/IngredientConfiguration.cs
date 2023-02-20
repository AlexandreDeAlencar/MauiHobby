using GA_Intergado.CR2.Domain.Ingredients;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GA_Intergado.CR2.Domain.Ingredients.ValueObjects;
using GA_Intergado.CR2.Domain.Users.ValueObjects;
using GA_Intergado.CR2.Domain.IngredientPlaces.ValueObjects;

namespace GA_Intergado.CR2.EntityFrameworkCore.Persistence.Configuration
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            ConfigureIngredientTable(builder);
        }

        private void ConfigureIngredientTable(EntityTypeBuilder<Ingredient> builder)
        {
            builder.ToTable("Ingredients");

            builder.HasKey(m => m.Id);

            builder
              .Property(m => m.Id)
              .HasConversion(
                  id => id.Value,
                  value => IngredientId.Create(value));

            builder
                .Property(m => m.ModifierUserId)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value));

            builder.Property(x => x.status);

            builder
                .Property(m => m.LastModifiedDateTime);

            builder
                .Property(m => m.IngredientType);

            builder
                .Property(m => m.DryMatterPercentage);

            builder.Property(e => e.Name);

            builder
              .Property(m => m.Name)
              .HasMaxLength(100);

            builder.Property(m => m.NameAbbreviation)
            .HasMaxLength(30);

            builder
                .Property(m => m.PlaceId)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => IngredientPlaceId.Create(value));
        }
    }
}
