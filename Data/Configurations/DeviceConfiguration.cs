using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations;

public class DeviceConfiguration : IEntityTypeConfiguration<Domain.Device>
{
	public void Configure(EntityTypeBuilder<Device> builder)
	{
		builder.Property(x => x.Title)
		 .IsRequired()
		 .HasMaxLength(255);

		builder.Property(x => x.Protcol)
		 .IsRequired()
		 .HasMaxLength(10);

		builder.Property(x => x.Url)
		 .IsRequired()
		 .HasMaxLength(2048);

		builder.Property(x => x.Description)
		 .HasMaxLength(1000);
	}
}
