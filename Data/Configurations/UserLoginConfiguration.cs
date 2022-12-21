using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations;

internal class UserLoginConfiguration : IEntityTypeConfiguration<Domain.UserLogin>
{
	public UserLoginConfiguration() : base()
	{
	}

	public void Configure
		(EntityTypeBuilder<Domain.UserLogin> builder)
	{

		builder
			.Property(current => current.UserIP)
			.IsUnicode(unicode: false);

		builder
			.HasIndex(current => new { current.UserIP })
			.IsUnique(unique: false);

	}
}
