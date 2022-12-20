namespace Domain.SeedWork
{
	public interface IEntity<T>
	{
		// **********
		public T Id { get; }
		// **********

		// **********
		public int Ordering { get; set; }
		// **********

		// **********
		public System.DateTime InsertDateTime { get; }
		// **********
	}
}
