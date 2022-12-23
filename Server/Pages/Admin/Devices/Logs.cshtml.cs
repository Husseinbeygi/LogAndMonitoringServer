using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModels.Controllers.Logs;

namespace Server.Pages.Admin.Devices
{
    public class LogsModel : Infrastructure.BasePageModelWithDatabaseContext
	{
		#region Constructor(s)
		public LogsModel(DatabaseContext databaseContext, ILogger<LogsModel> logger) : base(databaseContext)
		{
			Logger = logger;

			ViewModel = new List<IndexViewModel>();
		}
		#endregion /Constructor(s)

		#region Property(ies)
		// **********
		private ILogger<LogsModel> Logger { get; }
		// **********

		// **********
		public IList <IndexViewModel> ViewModel { get; private set; }
		// **********
		#endregion /Property(ies)


		public async System.Threading.Tasks.Task
			<IActionResult> OnGetAsync(Guid Id)
		{
			try
			{
				ViewModel =
					await
					DatabaseContext.Log
					.OrderByDescending(current => current.TimeStamp)
					.Where(current => current.DeviceId == Id)	
					.Select(current => new IndexViewModel
					{
						Id = current.Id,
						Level = current.Level,
						Message = current.Message,
						RemoteIP = current.RemoteIP,
						Username = current.Username,
						DeviceId = current.DeviceId,
						ClassName = current.ClassName,	
						Exception = current.Exception,
						Namespace = current.Namespace,

						TimeStamp = DateTimeOffset
									.FromUnixTimeMilliseconds
									(current.TimeStamp.Value)
									.DateTime
									.ToLocalTime(),

						MethodName = current.MethodName,
						RequestPath = current.RequestPath,
						HttpReferrer = current.HttpReferrer,
						InnerException = current.InnerException
					})
					.Take(1000)
					.AsNoTracking()
					.ToListAsync();
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

	}
}
