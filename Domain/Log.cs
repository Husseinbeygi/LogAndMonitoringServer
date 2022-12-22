using Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace Domain
{
	public class Log  : Entity
	{
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
		public long? TimeStamp { get; set; }
		public string? Username { get; set; }

        public Guid DeviceId { get; set; }
        public virtual Device Device { get; set; }
		public virtual List<Parameter> Parameters { get; set; }
	}
}
