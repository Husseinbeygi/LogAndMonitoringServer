using System;

namespace ViewModels.Pages.Admin.Cluster
{
	public class ViewModelBase
	{

		[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.Title),
		ResourceType = typeof(Resources.DataDictionary))]
		public string Title { get; set; }

		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Description),
			ResourceType = typeof(Resources.DataDictionary))]
		public string Description { get; set; }

	}
}