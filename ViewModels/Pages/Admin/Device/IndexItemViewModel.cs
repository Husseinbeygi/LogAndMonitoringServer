using System;

namespace ViewModels.Pages.Admin.Device;

public class IndexItemViewModel : ViewModelBase
{
    public Guid Id { get; set; }
	public string Cluster { get; set; }
	public string Address { get; set; }
	public DateTime InsertDateTime { get; set; }
	public string Owner { get; set; }
}
