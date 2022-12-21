using System;

namespace ViewModels.Pages.Admin.Device
{
	public class ViewModelBase
	{

		public Guid ClusterId { get; set; }

		public DateTime DeleteDateTime { get; set; }

		public string? Description { get; set; }

		public bool IsActive { get; set; } = true;

		public bool IsDeleted { get; set; }

		public bool IsSystemic { get; set; }

		public bool IsUndeletable { get; set; } = false;

		public bool IsUnupdatable { get; set; }

		public int Port { get; set; }

		public string Protcol { get; set; }

		public string Title { get; set; }

		public DateTime UpdateDateTime { get; set; }

		public string Url { get; set; }
	}
}