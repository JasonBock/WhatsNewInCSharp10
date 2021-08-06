using System;
using WhatsNewInCSharp10;

//DemonstrateGlobalUsingNamespaces();
//DemonstrateFileScopedNamespaces();
//DemonstrateRecordStructs();
//DemonstrateConstantInterpolatedStrings();
//DemonstrateInterpolatedStringImprovements();
//DemonstrateSealedRecordToString();

// https://github.com/dotnet/csharplang/issues/3428
// https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/GlobalUsingDirective.md
static void DemonstrateGlobalUsingNamespaces() =>
	WriteLine("Hi");

// https://github.com/dotnet/csharplang/issues/137
// https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/file-scoped-namespaces.md
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

// https://github.com/dotnet/csharplang/issues/2951
// https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/constant_interpolated_strings.md
static void DemonstrateConstantInterpolatedStrings()
{
	WriteLine(MethodNames.NamesViaHardCodedConcatenation);
	WriteLine(MethodNames.NamesViaConcatenation);
	WriteLine(MethodNames.NamesViaInterpolation);
}

static void DemonstrateInterpolatedStringImprovements()
{
}

static void DemonstrateSealedRecordToString()
{
}