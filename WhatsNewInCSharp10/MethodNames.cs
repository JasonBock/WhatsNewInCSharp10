namespace WhatsNewInCSharp10
{
	public static class MethodNames
	{
		public const string NamesViaHardCodedConcatenation = "A, B, C";
		public const string NamesViaConcatenation = nameof(A) + ", " + nameof(B) + ", " + nameof(C);

		// You can only use constants, and locale-specific information is based on where
		// it was compiled.
		public const string NamesViaInterpolation = $"{nameof(A)}, {nameof(B)}, {nameof(C)}";

		public static void A() { }
		public static void B() { }
		public static void C() { }
	}
}