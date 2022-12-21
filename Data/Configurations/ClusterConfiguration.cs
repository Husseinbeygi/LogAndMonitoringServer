using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations;

public class ClusterConfiguration : IEntityTypeConfiguration<Domain.Cluster>
{
	public void Configure(EntityTypeBuilder<Cluster> builder)
	{
		builder.Property(x => x.Title)
		 .IsRequired()
		 .HasMaxLength(255);

		builder.Property(x => x.Description)
		 .IsRequired()
		 .HasMaxLength(1000);
	}
}
