using IncapsulatedObjects;

namespace UserInterfaceAPI
{
	abstract public class UIAPIBase
	{
		abstract public void CreateUI(Field field, Action closeCallback);

		abstract public void Draw(Snek snek, Food food);

		public void RollCredits(int score = -1)
		{
			if (score != -1) { DrawScore(score); }
			DrawEndGame();
		}

		abstract protected void DrawEndGame();

		abstract protected void DrawScore(int score);


	}
}