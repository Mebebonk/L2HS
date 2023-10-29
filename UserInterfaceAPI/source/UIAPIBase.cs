using IncapsulatedObjects;

namespace UserInterfaceAPI
{
	abstract public class UIAPIBase
	{
		abstract public void Draw(Coordinate[] walls, Snek snek, Food food);

		public void RollCredits(int score = -1)
		{
			DrawEndGame();
			if (score != -1) { DrawScore(score); }
		}

		abstract protected void DrawEndGame();

		abstract protected void DrawScore(int score);
	}
}