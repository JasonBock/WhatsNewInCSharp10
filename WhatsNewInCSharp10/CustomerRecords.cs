namespace WhatsNewInCSharp10
{
	public record RecordCustomer(Guid Id, string Name);

	// Note that if you want it to be read-only,
	// use the `readonly` modifier.
	public record struct StructCustomer(Guid Id, string Name);

	public record SealedToStringCustomer(Guid Id, string Name)
	{
		public override sealed string ToString() => this.Name;
	}

	public record SealedCustomer(Guid Id, string Name)
		: SealedToStringCustomer(Id, Name);
}