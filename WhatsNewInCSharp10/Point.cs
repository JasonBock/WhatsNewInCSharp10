namespace WhatsNewInCSharp10
{
	public struct Point
	{
		public Point() => (this.X, this.Y) = (0, 0);

		public override string ToString() => $"{this.X}, {this.Y}";

		public int X { get; init; }
		public int Y { get; init; }
	}
}