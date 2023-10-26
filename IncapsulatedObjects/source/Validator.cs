



namespace IncapsulatedObjects
{
	static public class Validator
	{
		static public bool ValidationTest(Coordinate tile)
		{
			return tile.X > 0 && tile.X < RuleSet.RuleSet.maxWidth && tile.Y > 0 && tile.Y < RuleSet.RuleSet.maxHight;
		}
	}
}