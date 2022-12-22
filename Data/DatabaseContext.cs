using Microsoft.EntityFrameworkCore;

namespace Data;

public class DatabaseContext : DbContext
{
	public DatabaseContext
		(DbContextOptions<DatabaseContext> options) : base(options: options)
	{
	}
	public DbSet<Domain.Parameter> Parameters { get; set; }

	public DbSet<Domain.Log> Log { get; set; }

	public DbSet<Domain.Cluster> Cluster { get; set; }

	public DbSet<Domain.Device> Device { get; set; }

	public DbSet<Domain.Role> Roles { get; set; }

	public DbSet<Domain.User> Users { get; set; }

	public DbSet<Domain.UserLogin> UserLogins { get; set; }



	protected override void OnConfiguring
		(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
	}

	protected override void OnModelCreating
		(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly
			(assembly: typeof(Configurations.RoleConfiguration).Assembly);
	}

	protected override void ConfigureConventions
		(ModelConfigurationBuilder builder)
	{
		builder.Properties<System.DateOnly>()
			.HaveConversion<Conventions.DateTimeConventions.DateOnlyConverter>()
			.HaveColumnType(typeName: nameof(System.DateTime.Date))
			;

		builder.Properties<System.DateOnly?>()
			.HaveConversion<Conventions.DateTimeConventions.NullableDateOnlyConverter>()
			.HaveColumnType(typeName: nameof(System.DateTime.Date))
			;
	}
}
