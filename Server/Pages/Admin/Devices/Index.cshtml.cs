using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Server.Pages.Admin.Devices;

[Microsoft.AspNetCore.Authorization
	.Authorize(Roles = Constants.Role.Admin)]
public class IndexModel : Infrastructure.BasePageModelWithDatabaseContext
{
	#region Constructor(s)
	public IndexModel(Data.DatabaseContext databaseContext,
		Microsoft.Extensions.Logging.ILogger<IndexModel> logger) :
		base(databaseContext: databaseContext)
	{
		Logger = logger;

		ViewModel =
			new System.Collections.Generic.List
			<ViewModels.Pages.Admin.Device.IndexItemViewModel>();
	}
	#endregion /Constructor(s)

	#region Property(ies)
	// **********
	private Microsoft.Extensions.Logging.ILogger<IndexModel> Logger { get; }
	// **********

	// **********
	public System.Collections.Generic.IList
		<ViewModels.Pages.Admin.Device.IndexItemViewModel> ViewModel
	{ get; private set; }
	// **********
	#endregion /Property(ies)

	#region OnGetAsync
	public async System.Threading.Tasks.Task
		<Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync()
	{
		try
		{
			ViewModel =
				await
				DatabaseContext.Device
				.OrderBy(current => current.Ordering)
				.Select(current => new ViewModels.Pages.Admin.Device.IndexItemViewModel
				{
					Id = current.Id,
					Cluster = current.Cluster.Title,
					IsActive = current.IsActive,
					IsSystemic = current.IsSystemic,
					Address = $"{current.Protcol}://{current.Url}{GetPort(current)}",
					IsUndeletable = current.IsUndeletable,
					InsertDateTime = current.InsertDateTime,
					UpdateDateTime = current.UpdateDateTime.Value,
				})
				.AsNoTracking()
				.ToListAsync()
				;
		}
		catch (System.Exception ex)
		{
			Logger.LogError
				(message: Constants.Logger.ErrorMessage, args: ex.Message);

			AddPageError
				(message: Resources.Messages.Errors.UnexpectedError);
		}
		finally
		{
			await DisposeDatabaseContextAsync();
		}

		return Page();
	}

	private static string GetPort(Device current)
	{
		if (current.Port == 0 
		|| current.Port == 80 
		|| current.Port == 443)
		{
			return string.Empty;
		}
		else
		{
			return current.Port.ToString();

		};
	}
	#endregion /OnGetAsync
}
