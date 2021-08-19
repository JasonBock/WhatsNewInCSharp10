using WhatsNewInCSharp10;

//DemonstrateGlobalUsingNamespaces();
//DemonstrateFileScopedNamespaces();
//DemonstrateRecordStructs();
//DemonstrateMixingDeclarationsAndVariablesInDeconstruction();
DemonstrateExtendedPropertyPatterns();
//DemonstrateExtendedPropertyPatterns();
//DemonstrateConstantInterpolatedStrings();
//DemonstrateInterpolatedStringImprovements();
//DemonstrateSealedRecordToString();

// https://github.com/dotnet/csharplang/issues/3428
// https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/GlobalUsingDirective.md
static void DemonstrateGlobalUsingNamespaces() =>
	WriteLine($"Hi, Pi is {Math.PI}");

// https://github.com/dotnet/csharplang/issues/137
// https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/file-scoped-namespaces.md
static void DemonstrateFileScopedNamespaces()
{
	var customer = new RecordCustomer(Guid.NewGuid(), "Jason");
	WriteLine(customer);
}

// https://github.com/dotnet/csharplang/issues/4334
static void DemonstrateRecordStructs()
{
	var customer = new StructCustomer(Guid.NewGuid(), "Jason");
	WriteLine(customer);
}

// https://github.com/dotnet/csharplang/issues/125
static void DemonstrateMixingDeclarationsAndVariablesInDeconstruction()
{
	var customer = new RecordCustomer(Guid.NewGuid(), "Jason");
	(var id, var name) = customer;
	WriteLine($"{id}, {name}");
	(var differentId, name) = customer;
	WriteLine($"{differentId}, {name}");
}

static void DemonstrateExtendedPropertyPatterns()
{
	var recordCustomer = new RecordCustomer(Guid.NewGuid(), "Jason Record");

	if(recordCustomer is RecordCustomer { Name: { Length: > 5 } })
	{
		WriteLine("Old check works.");
	}

	if (recordCustomer is RecordCustomer { Name.Length: > 5 } )
	{
		WriteLine("New check works.");
	}
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