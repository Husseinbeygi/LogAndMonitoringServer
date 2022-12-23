namespace ViewModels.Controllers.Logs
{
	public class EventMessage
	{
		public EventMessage()
		{
			Parameters = new();
			Exceptions = new();
		}

		public string? ClassName { get; set; }
		public Exceptions Exceptions { get; set; }
		public string? HttpReferrer { get; set; }
		public int? Level { get; set; }
		public string? Message { get; set; }
		public string? MethodName { get; set; }
		public string? Namespace { get; set; }
		public Parameters Parameters { get; set; }
		public string? RemoteIP { get; set; }
		public string? RequestPath { get; set; }
		public long? TimeStamp { get; set; }
		public string? Username { get; set; }
	}
}