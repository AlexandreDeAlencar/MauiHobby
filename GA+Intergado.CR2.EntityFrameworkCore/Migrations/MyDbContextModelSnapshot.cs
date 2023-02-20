﻿// <auto-generated />
using System;
using GA_Intergado.CR2.EntityFrameworkCore.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GA_Intergado.CR2.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("GA_Intergado.CR2.Domain.IngredientPlaces.IngredientPlace", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModifiedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ModifierUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("IngredientPlaces", (string)null);
                });

            modelBuilder.Entity("GA_Intergado.CR2.Domain.Ingredients.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("DryMatterPercentage")
                        .HasColumnType("TEXT");

                    b.Property<int>("IngredientType")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastModifiedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ModifierUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("NameAbbreviation")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PlaceId")
                        .HasColumnType("TEXT");

                    b.Property<int>("status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Ingredients", (string)null);
                });

            modelBuilder.Entity("GA_Intergado.CR2.Domain.Recipes.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModifiedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("MixTimeMinute")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ModifierUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("NameAbbreviation")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<int>("Version")
                        .HasColumnType("INTEGER");

                    b.Property<int>("status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Recipes", (string)null);
                });

            modelBuilder.Entity("GA_Intergado.CR2.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModifiedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ModifierUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("UserType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("GA_Intergado.CR2.Domain.Recipes.Recipe", b =>
                {
                    b.OwnsMany("GA_Intergado.CR2.Domain.Recipes.Entities.RecipeIngredient", "RecipeIngredients", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("TEXT")
                                .HasColumnName("RecipeIngredientId");

                            b1.Property<Guid>("RecipeId")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("IngredientId")
                                .HasColumnType("TEXT");

                            b1.Property<DateTime>("LastModifiedDateTime")
                                .HasColumnType("TEXT");

                            b1.Property<decimal>("NaturalMatterPercentage")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<int>("Order")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("status")
                                .HasColumnType("INTEGER");

                            b1.HasKey("Id", "RecipeId");

                            b1.HasIndex("RecipeId");

                            b1.ToTable("RecipeIngredients", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("RecipeId");
                        });

                    b.Navigation("RecipeIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
