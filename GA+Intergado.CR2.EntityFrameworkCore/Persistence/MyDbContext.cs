using GA_Intergado.CR2.Domain.IngredientPlaces;
using GA_Intergado.CR2.Domain.Ingredients;
using GA_Intergado.CR2.Domain.Recipes;
using Microsoft.EntityFrameworkCore;

namespace GA_Intergado.CR2.EntityFrameworkCore.Persistence;

public partial class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }
    public DbSet<IngredientPlace> IngredientPlaces { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Recipe> Recipes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\sqlite\\cr2database.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Model.GetEntityTypes()
            //.SelectMany(e => e.GetProperties())
            //.Where(p => p.IsPrimaryKey())
            //.ToList()
            //.ForEach(p => p.ValueGenerated = Microsoft.EntityFrameworkCore.Metadata.ValueGenerated.Never);

        modelBuilder
           .ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
