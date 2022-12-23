namespace ViewModels.Controllers.Logs;

public class Exceptions
{
	public string Exception { get; set; }
	public string InnerException { get; set; }
}

public class Parameters
{
	public string Key1 { get; set; }
	public string Key4 { get; set; }
	public string Key2 { get; set; }
	public string Key3 { get; set; }
	public string Key5 { get; set; }
	public string Key6 { get; set; }
}

public class LogViewModel
{
    public string? DeviceId { get; set; }
	public string? message { get; set; }

}
