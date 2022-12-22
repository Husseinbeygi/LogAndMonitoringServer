using System;
using System.Reflection.Metadata.Ecma335;

namespace Domain
{
	public class Parameter
	{
		public Parameter(string? key, string? value)
		{
			this.key = key;
			this.value = value;
		}
        public Guid Id { get; set; }
        public string? key { get; set; }
		public string? value { get; set; }
	}
}	