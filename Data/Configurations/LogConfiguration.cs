using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations;

public class LogConfiguration : IEntityTypeConfiguration<Log>
{
	public void Configure(EntityTypeBuilder<Log> builder)
	{
		builder.Property(x => x.ClassName).HasMaxLength(255);
		builder.Property(x => x.Exception).HasMaxLength(2000);
		builder.Property(x => x.InnerException).HasMaxLength(2000);
		builder.Property(x => x.HttpReferrer).HasMaxLength(255);
		builder.Property(x => x.Message).HasMaxLength(500);
		builder.Property(x => x.MethodName).HasMaxLength(255);
		builder.Property(x => x.Namespace).HasMaxLength(255);
		builder.Property(x => x.RemoteIP).HasMaxLength(255);
		builder.Property(x => x.RequestPath).HasMaxLength(255);
		builder.Property(x => x.Username).HasMaxLength(255);

	}
}
