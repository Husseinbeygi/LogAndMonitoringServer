using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Framework.Security;
using Framework;
using System.Diagnostics;

namespace Server.Pages.Admin.Devices;

[Microsoft.AspNetCore.Authorization
	.Authorize(Roles = Constants.Role.Admin)]
public class CreateModel : Infrastructure.BasePageModelWithDatabaseContext
{
	#region Constructor(s)
	public CreateModel(Data.DatabaseContext databaseContext,
		ILogger<CreateModel> logger) :
		base(databaseContext: databaseContext)
	{
		Logger = logger;

		ViewModel = new();

		RolesViewModel =
			new System.Collections.Generic.List
			<ViewModels.Shared.KeyValueViewModel>();
	}
	#endregion /Constructor(s)

	#region Property(ies)
	// **********
	private ILogger<CreateModel> Logger { get; }
	// **********

	// **********
	public System.Collections.Generic.IList
		<ViewModels.Shared.KeyValueViewModel> RolesViewModel
	{ get; private set; }
	// **********

	// **********
	[Microsoft.AspNetCore.Mvc.BindProperty]
	public ViewModels.Pages.Admin.Device.CreateViewModel ViewModel { get; set; }
	// **********
	#endregion /Property(ies)

	#region OnGetAsync
	public async System.Threading.Tasks.Task
		<Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync()
	{
		try
		{
			await SetAccessibleClustersAsync();

			return Page();
		}
		catch (System.Exception ex)
		{
			Logger.LogError
				(message: Constants.Logger.ErrorMessage, args: ex.Message);

			AddToastError
				(message: Resources.Messages.Errors.UnexpectedError);

			return RedirectToPage(pageName: "Index");
		}
		finally
		{
			await DisposeDatabaseContextAsync();
		}
	}
	#endregion /OnGetAsync

	#region OnPostAsync
	public async System.Threading.Tasks.Task
		<Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync()
	{
		if (ModelState.IsValid == false)
		{
			return Page();
		}

		try
		{
			var foundedAny =
				await
				DatabaseContext.Device
				.Where(current => 
				current.Title.ToLower() == ViewModel.Title.ToLower()
				 || 
				 (current.Url.ToLower() == ViewModel.Url.ToLower()
				 && current.Port == ViewModel.Port))
				.AnyAsync();

			if (foundedAny)
			{
				// **************************************************
				var errorMessage = string.Format
					(format: Resources.Messages.Errors.AlreadyExists,
					arg0: Resources.DataDictionary.EmailAddress);

				AddPageError
					(message: errorMessage);
				// **************************************************

				return Page();
			}

			// **************************************************
			var fixedDescription =
				Utility.FixText
				(text: ViewModel.Description);

			var newEntity =
				new Domain.Device()
				{
					Description = fixedDescription,
					Port = ViewModel.Port,
					Url = ViewModel.Url,
					Title = ViewModel.Title,
					ClusterId = ViewModel.ClusterId,
					IsActive = ViewModel.IsActive,
					IsSystemic = ViewModel.IsSystemic,
					IsUndeletable = ViewModel.IsUndeletable,
					Protcol = ViewModel.Protcol,
					IsUnupdatable = ViewModel.IsUnupdatable,

				};

			var entityEntry =
				await
				DatabaseContext.AddAsync(entity: newEntity);

			var affectedRow =
				await
				DatabaseContext.SaveChangesAsync();
			// **************************************************

			// **************************************************
			var successMessage = string.Format
				(format: Resources.Messages.Successes.Created,
				arg0: Resources.DataDictionary.User);

			AddToastSuccess(message: successMessage);
			// **************************************************

			return RedirectToPage(pageName: "Index");
		}
		catch (System.Exception ex)
		{
			Logger.LogError
				(message: Constants.Logger.ErrorMessage, args: ex.Message);

			AddToastError
				(message: Resources.Messages.Errors.UnexpectedError);

			return RedirectToPage(pageName: "Index");
		}
		finally
		{
			await DisposeDatabaseContextAsync();
		}
	}
	#endregion OnPostAsync

	#region SetAccessibleRoleAsync
	private async System.Threading.Tasks.Task SetAccessibleClustersAsync()
	{
		RolesViewModel =
			await
			DatabaseContext.Cluster
			.OrderBy(current => current.Ordering)
			.ThenBy(current => current.Title)
			.Select(current => new ViewModels.Shared.KeyValueViewModel
			{
				Id = current.Id,
				Name = current.Title,
			})
			.ToListAsync()
			;
	}
	#endregion /SetAccessibleRoleAsync
}
