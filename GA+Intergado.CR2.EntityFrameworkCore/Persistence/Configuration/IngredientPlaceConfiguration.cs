using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GA_Intergado.CR2.Domain.Ingredients;
using GA_Intergado.CR2.Domain.Recipes.ValueObjects;
using GA_Intergado.CR2.Domain.Users.ValueObjects;
using GA_Intergado.CR2.Domain.Ingredients.ValueObjects;
using GA_Intergado.CR2.Domain.IngredientPlaces;
using GA_Intergado.CR2.Domain.IngredientPlaces.ValueObjects;

namespace GA_Intergado.CR2.EntityFrameworkCore.Persistence.Configuration
{
    public class IngredientPlaceConfiguration : IEntityTypeConfiguration<IngredientPlace>
    {
        public void Configure(EntityTypeBuilder<IngredientPlace> builder)
        {
            ConfigureIngredientPlaceTable(builder);
        }

        private void ConfigureIngredientPlaceTable(EntityTypeBuilder<IngredientPlace> builder)
        {

            builder.ToTable("IngredientPlaces");

            builder.HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .HasConversion(
                    id => id.Value,
                    value => IngredientPlaceId.Create(value));

            builder
                .Property(m => m.ModifierUserId)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value));

            builder.Property(x => x.Status);

            builder
                .Property(m => m.LastModifiedDateTime);

            builder
                .Property(m => m.Name)
                .HasMaxLength(100);
        }
    }
}
