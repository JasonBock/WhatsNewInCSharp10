using System;
using WhatsNewInCSharp10;

//DemonstrateGlobalNamespaces();
//DemonstrateFileScopedNamespaces();
//DemonstrateRecordStructs();

static void DemonstrateGlobalNamespaces() =>
	WriteLine("Hi");

static void DemonstrateFileScopedNamespaces()
{
	var customer = new RecordCustomer(Guid.NewGuid(), "Jason");
	WriteLine(customer);
}

static void DemonstrateRecordStructs()
{
	var customer = new StructCustomer(Guid.NewGuid(), "Jason");
	WriteLine(customer);
}