using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations;

internal class RoleConfiguration : IEntityTypeConfiguration<Domain.Role>
{
	public RoleConfiguration() : base()
	{
	}

	public void Configure
		(EntityTypeBuilder<Domain.Role> builder)
	{
		builder
			.HasIndex(current => new { current.Name })
			.IsUnique(unique: true);

		builder
			.HasMany(current => current.Users)
			.WithOne(other => other.Role)
			.IsRequired(required: false)
			.HasForeignKey(other => other.RoleId)
			.OnDelete(deleteBehavior:
				Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
	}
}
