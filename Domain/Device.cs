using Domain.SeedWork;
using System;

namespace Domain;

public class Device :
				Entity,
				IEntityHasIsActive,
				IEntityHasIsDeleted,
				IEntityHasIsSystemic,
				IEntityHasIsUndeletable,
				IEntityHasIsUnupdatable,
				IEntityHasUpdateDateTime
{
	public string Title { get; set; }

	public string Protcol { get; set; }

	public string Url { get; set; }

	public int Port { get; set; }

	public string? Description { get; set; }

	public Guid ClusterId { get; set; }

	public virtual Cluster Cluster { get; set; }

	public bool IsActive { get; set; }

	public bool IsDeleted { get; set; }

	public bool IsSystemic { get; set; }

	public bool IsUnupdatable { get; set; }

	public DateTime? DeleteDateTime { get; set; }

	public DateTime? UpdateDateTime { get; set; }

	public bool IsUndeletable { get; set; }

	public void SetDeleteDateTime()
	{
		DeleteDateTime = DateTime.UtcNow;
	}

	public void SetUpdateDateTime()
	{
		UpdateDateTime = DateTime.UtcNow;
	}
}
