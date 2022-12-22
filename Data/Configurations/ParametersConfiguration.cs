using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations;

public class ParametersConfiguration : IEntityTypeConfiguration<Parameter>
{
	public void Configure(EntityTypeBuilder<Parameter> builder)
	{
		builder.Property(x => x.key).HasMaxLength(128);
		builder.Property(x => x.value).HasMaxLength(128);
	}
}
