namespace WhatsNewInCSharp10
{
	public sealed class NullCheckCustomer
	{
		// TODO: The bang operator on the parameter name isn't working just yet
		public NullCheckCustomer(Guid id, string name) =>
			(this.Id, this.Name) = (id, name);

		// TODO: If it did, it would prevent this from even being called.
		public int GetNameLength() => this.Name.Length;

		public Guid Id { get; init; }
		public string Name { get; init; }

		public override string ToString() => $"{this.Id}, {this.Name}";
	}
}