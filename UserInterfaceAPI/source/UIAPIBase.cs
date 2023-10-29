using IncapsulatedObjects;

namespace UserInterfaceAPI
{
	abstract public class UIAPIBase
	{
		abstract public void CreateUI(Field field);

		abstract public void Draw(Snek snek, Food food);

		public void RollCredits(int score = -1)
		{
			DrawEndGame();
			if (score != -1) { DrawScore(score); }
		}

		abstract protected void DrawEndGame();

		abstract protected void DrawScore(int score);
	}
}