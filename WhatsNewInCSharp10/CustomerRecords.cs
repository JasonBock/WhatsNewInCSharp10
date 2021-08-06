using System;

namespace WhatsNewInCSharp10
{
	public record RecordCustomer(Guid Id, string Name);

	public record struct StructCustomer(Guid Id, string Name);
}