using Framework.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<Domain.User>
{
	public UserConfiguration() : base()
	{
	}

	public void Configure
		(EntityTypeBuilder<Domain.User> builder)
	{
		builder
			.Property(current => current.EmailAddress)
			.IsUnicode(unicode: false);

		builder
			.HasIndex(current => new { current.EmailAddress })
			.IsUnique(unique: true);
		builder
			.HasIndex(current => new { current.EmailAddressVerificationKey })
			.IsUnique(unique: true);

		builder
			.Property(current => current.Username)
			.IsUnicode(unicode: false);

		builder
			.HasIndex(current => new { current.Username })
			.IsUnique(unique: true);

		builder
			.Property(current => current.CellPhoneNumber)
			.IsUnicode(unicode: false);

		builder
			.HasIndex(current => new { current.CellPhoneNumber })
			.IsUnique(unique: true);

		builder
			.Property(current => current.CellPhoneNumberVerificationKey)
			.IsUnicode(unicode: false);

		builder
			.HasIndex(current => new { current.CellPhoneNumberVerificationKey })
			.IsUnique(unique: true);

		builder
			.Property(current => current.Password)
			.IsUnicode(unicode: false);

		builder
			.HasMany(current => current.UserLogins)
			.WithOne(other => other.User)
			.IsRequired(required: true)
			.HasForeignKey(other => other.UserId)
			.OnDelete(deleteBehavior:
				Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

		var user =
			new Domain.User(emailAddress: "Admin@Domain.local")
			{
				Ordering = 1,

				IsActive = true,
				IsSystemic = true,
				IsProgrammer = true,
				IsUndeletable = true,
				IsProfilePublic = true,
				IsEmailAddressVerified = true,
				IsCellPhoneNumberVerified = true,

				Description = null,
				AdminDescription = null,

				Username = "Admin",
				FullName = "Administrator",
				CellPhoneNumber = "00989152020056",

				Password =
					Hashing.GetSha256(text: "admin"),
			};

		user.SetId(id: Domain.User.SuperUserId);

		builder.HasData(data: user);
	}
}
