using PlayingWithFire;
using System.ComponentModel;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using WhatsNewInCSharp10;
using WhatsNewInCSharp10.Company.Models;
using WhatsNewInCSharp10.MathematicalConstants;

DemonstrateGlobalUsingNamespaces();

// https://github.com/dotnet/csharplang/issues/3428
// https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/GlobalUsingDirective.md
static void DemonstrateGlobalUsingNamespaces()
{
	WriteLine($"Hi, {nameof(Math.PI)} is {Math.PI}");
	WriteLine();

	var constants = ConstantsFactory.GetValues();

	foreach(var constant in constants)
	{
		WriteLine(constant.ToString());
	}
}

//DemonstrateFileScopedNamespaces();

// https://github.com/dotnet/csharplang/issues/137
// https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/file-scoped-namespaces.md
static void DemonstrateFileScopedNamespaces()
{
	var customer = new Customer(Guid.NewGuid(), "Jason");
	WriteLine(customer);
	WriteLine(typeof(Customer).FullName);
}

//DemonstrateRecordStructs();

// https://github.com/dotnet/csharplang/issues/4334
// https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/record-structs.md
static void DemonstrateRecordStructs()
{
	var customer = new StructCustomer(Guid.NewGuid(), "Jason");
	WriteLine(customer);
}

//DemonstrateSealedRecordToString();

// https://github.com/dotnet/csharplang/issues/4174
static void DemonstrateSealedRecordToString()
{
	var customer = new RecordCustomer(Guid.NewGuid(), "Jason");
	WriteLine(customer);

	var sealedToStringCustomer = new SealedToStringCustomer(Guid.NewGuid(), "Jason");
	WriteLine(sealedToStringCustomer);

	var sealedCustomer = new SealedCustomer(Guid.NewGuid(), "Jason");
	WriteLine(sealedCustomer);
}

//DemonstrateParameterlessStructConstructors();

// https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/parameterless-struct-constructors.md
// https://github.com/dotnet/csharplang/issues/99
static void DemonstrateParameterlessStructConstructors()
{
	var point = new Point { X = 1, Y = 2 };
	WriteLine(point);
}

//DemonstrateMixingDeclarationsAndVariablesInDeconstruction();

// https://github.com/dotnet/csharplang/issues/125
static void DemonstrateMixingDeclarationsAndVariablesInDeconstruction()
{
	var customer = new RecordCustomer(Guid.NewGuid(), "Jason");
	(var id, var name) = customer;
	WriteLine($"{id}, {name}");
	(var differentId, name) = customer;
	WriteLine($"{differentId}, {name}");
}

//DemonstrateWithExpressionsAndAnonymousTypes();

static void DemonstrateWithExpressionsAndAnonymousTypes()
{
	var customer = new { Id = Guid.NewGuid(), Name = "Jason" };
	var differentCustomer = customer with { Name = "Jane" };
	WriteLine(customer);
	WriteLine(differentCustomer);
}

//DemonstrateExtendedPropertyPatterns();

// https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/extended-property-patterns.md
// https://github.com/dotnet/csharplang/issues/4394
static void DemonstrateExtendedPropertyPatterns()
{
	var recordCustomer = new RecordCustomer(Guid.NewGuid(), "Jason");

	if (recordCustomer is RecordCustomer { Name: { Length: >= 5 } })
	{
		WriteLine("Old check works.");
	}

	if (recordCustomer is RecordCustomer { Name.Length: >= 5 })
	{
		WriteLine("New check works.");
	}
}

//DemonstrateBetterLambdas();

// https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/lambda-improvements.md
static void DemonstrateBetterLambdas()
{
	var recordCustomer = new RecordCustomer(Guid.NewGuid(), "Jason");
	var customerProcessor1 = new Func<RecordCustomer, BigInteger>(
		customer => customer.Name.Length + BigInteger.Parse(customer.Id.ToString("N"), NumberStyles.HexNumber));

	WriteLine($"{nameof(customerProcessor1)} : {customerProcessor1(recordCustomer)}");

	var customerProcessor2 = (RecordCustomer customer) =>
		customer.Name.Length + BigInteger.Parse(customer.Id.ToString("N"), NumberStyles.HexNumber);

	WriteLine($"{nameof(customerProcessor2)} : {customerProcessor2(recordCustomer)}");

	var oldMultiplier = new Func<int, int, int>((x, y) => x * y);
	var newMultiplier = (int x, int y) => x * y;
	WriteLine(oldMultiplier(3, 4));
	WriteLine(newMultiplier(3, 4));

	var value = "four";
	var withRefsAndAttributes = ([Description("Print the length")] ref string a) => a.Length;
	WriteLine(withRefsAndAttributes(ref value));

	var aLotOfParameters = (int x0, int x1, int x2, int x3,
		int x4, int x5, int x6, int x7, int x8,
		int x9, int x10, int x11, int x12,
		int x13, int x14, int x15, int x16, int x17, int x18) =>
		x0 + x1 + x2 + x3 + x4 + x5 + x6 + x7 +
			x8 + x9 + x10 + x11 + x12 + x13 + x14 + x15 + x16 + x17;
}

//DemonstrateConstantInterpolatedStrings();

// https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/constant_interpolated_strings.md
// https://github.com/dotnet/csharplang/issues/2951
static void DemonstrateConstantInterpolatedStrings()
{
	WriteLine(MethodNames.NamesViaHardCodedConcatenation);
	WriteLine(MethodNames.NamesViaConcatenation);
	WriteLine(MethodNames.NamesViaInterpolation);
}

//DemonstrateCallerArgumentExpression();

// https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/caller-argument-expression.md
// https://github.com/dotnet/csharplang/issues/287
static void DemonstrateCallerArgumentExpression()
{
	// It would've been nice if the "nameof(parameter)" feature would've made it into C# 10,
	// but it looks like it's getting pushed out...but keep it it in mind.
	// https://github.com/dotnet/csharplang/issues/373
	static void PrintBooleanResult(bool result,
		[CallerMemberName] string? callerMemberName = null, 
		[CallerArgumentExpression("result")] string? callerArgumentExpression = null) =>
			WriteLine($"{result} from {callerMemberName} doing {callerArgumentExpression}");

	PrintBooleanResult(Math.PI > Math.Sqrt(Math.PI));
	PrintBooleanResult(true);
}

//DemonstrateInterpolatedStringImprovements();

// https://devblogs.microsoft.com/dotnet/string-interpolation-in-c-10-and-net-6/
// https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/improved-interpolated-strings.md
// https://github.com/dotnet/csharplang/issues/4487
static void DemonstrateInterpolatedStringImprovements()
{
	// Reminder: Look at the compiler output of DemonstrateCallerArgumentExpression() 
	// to see how DefaultInterpolatedStringHandler is used by the compiler.
}

//DemonstrateAsyncMethodBuilderOverride();

// TODO
// https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/async-method-builders.md
// https://github.com/dotnet/csharplang/issues/1407
static void DemonstrateAsyncMethodBuilderOverride()
{

}

//DemonstrateStaticAbstractMembersInInterfaces();

// https://devblogs.microsoft.com/dotnet/preview-features-in-net-6-generic-math/
// https://github.com/dotnet/csharplang/issues/4436
// Turn <LangVersion> in the .props file to "preview"
// for this to work.
//[MyGeneric<string>]
static void DemonstrateStaticAbstractMembersInInterfaces()
{
	// Remember to look at the settings in the .csproj file.
	static T Add<T>(T left, T right)
		where T : INumber<T> => left + right;

	WriteLine(Add(3, 4));
	WriteLine(Add(3.4, 4.3));

	// Sadly, this doesn't work :(
	//WriteLine(Add(BigInteger.Parse("49043910940940104390"), BigInteger.Parse("59839583901984390184")));

	var customer = CreateableCustomer.Create();
	WriteLine(customer);
}