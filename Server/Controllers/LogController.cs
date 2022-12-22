using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using ViewModels.Controllers.Logs;

namespace Server.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class LogController : ControllerBase
	{
		private readonly DatabaseContext _databaseContext;

		public LogController(Data.DatabaseContext databaseContext)
		{
			_databaseContext = databaseContext;
		}

		[HttpPost]
		public async Task Log(LogViewModel? logs)
		{
			var @event = JsonSerializer
					.Deserialize<EventMessage>(logs.message);

			var log = new Log()
			{
				ClassName = @event.ClassName,
				Message = @event.Message,
				RemoteIP = @event.RemoteIP,
				RequestPath = @event.RequestPath,
				HttpReferrer = @event.HttpReferrer,
				Exception = @event.Exceptions.Exception,
				InnerException = @event.Exceptions.InnerException,
				MethodName = @event.MethodName,
				Namespace = @event.Namespace,
				TimeStamp = @event.TimeStamp,
				Username = @event.Username,
				Level = @event.Level,
				DeviceId = Guid.Parse(logs.DeviceId),
			};

			await _databaseContext.AddAsync(log);

			await _databaseContext.SaveChangesAsync();	
		}

	}


}
