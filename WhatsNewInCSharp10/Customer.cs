// TODO: This should be a file-scoped namespace, but...
// it's not working.
using System;

namespace WhatsNewInCSharp10
{
	public sealed class Customer
	{
		public Customer(Guid id, string name) =>
			(this.Id, this.Name) = (id, name);

		public int GetNameLength() => this.Name.Length;

		public override string ToString() => $"{this.Id}, {this.Name}";

		public Guid Id { get; init; }
		public string Name { get; init; }
	}
}