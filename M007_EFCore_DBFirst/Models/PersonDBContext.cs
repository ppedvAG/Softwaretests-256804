using Microsoft.EntityFrameworkCore;

namespace M007_EFCore_DBFirst.Models;

public partial class PersonDBContext : DbContext
{
    public PersonDBContext() { }

    public PersonDBContext(DbContextOptions<PersonDBContext> options) : base(options) { }

	/////////////////////////////////////////////////////////////

	/// <summary>
	/// DbSet
	/// 
	/// Allow access to the tables (-> data)
	/// For every table there is one DbSet
	/// </summary>
    public virtual DbSet<Personen> Personen { get; set; }

	/////////////////////////////////////////////////////////////

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=PersonDB;Integrated Security=True;Encrypt=False");

	/// <summary>
	/// This code creates the relations between the entities in our C# application
	/// Can generally be ignored
	/// </summary>
	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}