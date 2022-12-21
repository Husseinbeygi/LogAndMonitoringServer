using System;

namespace ViewModels.Pages.Admin.Cluster;

public class IndexItemViewModel : ViewModelBase
{
	[System.ComponentModel.DataAnnotations.Display
	(Name = nameof(Resources.DataDictionary.Id),
	ResourceType = typeof(Resources.DataDictionary))]
	public Guid Id { get; set; }
}
