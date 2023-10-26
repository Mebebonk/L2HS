



namespace IncapsulatedObjects
{
	static public class Validator
	{
		public static bool ValidationTest(Coordinate tile)
		{
			return tile.X > 0 && tile.X < RuleSet.RuleSet.maxWidth && tile.Y > 0 && tile.Y < RuleSet.RuleSet.maxHight;
		}
	}
}