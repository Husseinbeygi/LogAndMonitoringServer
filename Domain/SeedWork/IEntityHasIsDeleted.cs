namespace Domain.SeedWork
{
	public interface IEntityHasIsDeleted
	{
		bool IsDeleted { get; set; }

		System.DateTime? DeleteDateTime { get; }

		void SetDeleteDateTime();
	}
}
