namespace WhatsNewInCSharp10.MathematicalConstants
{
	public static class ConstantsFactory
	{
		public static ImmutableDictionary<string, double> GetValues()
		{
			var builder = ImmutableDictionary.CreateBuilder<string, double>();
			builder.Add(nameof(Math.E), Math.E);
			builder.Add(nameof(Math.PI), Math.PI);
			builder.Add(nameof(Math.Tau), Math.Tau);

			return builder.ToImmutable();
		}
	}
}