namespace WhatsNewInCSharp10
{
	public interface ICreatable<TSelf>
		where TSelf : ICreatable<TSelf>
	{
		static abstract TSelf Create();
	}

	public sealed class CreateableCustomer 
		: ICreatable<CreateableCustomer>
	{
		public static CreateableCustomer Create() =>
			new()
			{
				Id = Guid.NewGuid(),
				Name = "Jason"
			};

		private CreateableCustomer() { }

		public override string ToString() => $"{this.Id}, {this.Name}";

		public Guid Id { get; init; }	
		public string? Name { get; init; }
	}
}