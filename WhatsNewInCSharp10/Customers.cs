// TODO: This should be a file-scoped namespace, but...
// it's not working.
using System;

namespace WhatsNewInCSharp10
{
	public record RecordCustomer(Guid Id, string Name);

	public record struct StructCustomer(Guid Id, string Name);

	public sealed class Customer
	{
		// TODO: The bang operator on the parameter name isn't working just yet
		public Customer(Guid id, string name) =>
			(this.Id, this.Name) = (id, name);

		public Guid Id { get; init; }
		public string Name { get; init; }

		public override string ToString() => $"{this.Id}, {this.Name}";
	}
}