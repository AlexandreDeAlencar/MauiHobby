using GA_Intergado.CR2.Domain.Ingredients.ValueObjects;
using GA_Intergado.CR2.Domain.Recipes;
using GA_Intergado.CR2.Domain.Recipes.Entities;
using GA_Intergado.CR2.Domain.Recipes.ValueObjects;
using GA_Intergado.CR2.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GA_Intergado.CR2.EntityFrameworkCore.Persistence.Configuration
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            ConfigureRecipeTable(builder);
            ConfigureRecipeIngredientsTable(builder);
        }

        private void ConfigureRecipeTable(EntityTypeBuilder<Recipe> builder)
        {
            builder.ToTable("Recipes");

            builder.HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .HasConversion(
                    id => id.Value,
                    value => RecipeId.Create(value));

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
                .Property(m => m.MixTimeMinute); 

            builder
                .Property(m => m.Name)
                .HasMaxLength(100);

            builder.Property(m => m.NameAbbreviation)
            .HasMaxLength(30);
        }

        private void ConfigureRecipeIngredientsTable(EntityTypeBuilder<Recipe> builder)
        {
            builder.OwnsMany(m => m.RecipeIngredients, sectionBuilder =>
            {
                sectionBuilder.ToTable("RecipeIngredients");

                sectionBuilder
                    .WithOwner()
                    .HasForeignKey("RecipeId");

                sectionBuilder.HasKey("Id", "RecipeId");

                sectionBuilder.Property(s => s.Id)
                    .HasColumnName("RecipeIngredientId")
                    .HasConversion(
                        id => id.Value,
                        value => RecipeIngredientId.Create(value));

                builder
                   .Property(m => m.ModifierUserId)
                   .ValueGeneratedNever()
                   .HasConversion(
                       id => id.Value,
                       value => UserId.Create(value));

                builder.Property(x => x.status);

                builder
                    .Property(m => m.LastModifiedDateTime);

                sectionBuilder
                    .Property(s => s.IngredientId)
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => IngredientId.Create(value));

                sectionBuilder
                    .Property(s => s.NaturalMatterPercentage)
                    .HasColumnType("decimal(18,2)");

            });

            builder.Metadata
                .FindNavigation(nameof(Recipe.RecipeIngredients))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

    }
}
