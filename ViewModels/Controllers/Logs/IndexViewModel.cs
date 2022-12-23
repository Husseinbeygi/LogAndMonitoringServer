using System;

namespace ViewModels.Controllers.Logs;

public class IndexViewModel 
{
    public Guid Id { get; set; }
    public string? ClassName { get; set; }
	public string? Exception { get; set; }
	public string? InnerException { get; set; }
	public string? HttpReferrer { get; set; }
	public int? Level { get; set; }
	public string? Message { get; set; }
	public string? MethodName { get; set; }
	public string? Namespace { get; set; }
	public string? RemoteIP { get; set; }
	public string? RequestPath { get; set; }
	public DateTime? TimeStamp { get; set; }
	public string? Username { get; set; }

	public Guid DeviceId { get; set; }

}
