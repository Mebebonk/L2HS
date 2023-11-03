using IncapsulatedObjects;
using InputHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadHandler;
using UserInterfaceAPI;

namespace GameMaster
{
	internal class GameMasterLogic
	{
		private Food? food;
		private bool isGameRunning = false;

		Thread? gameThread;
		private readonly CancellationTokenSource cancellationTokenSource;

		private readonly Field Field;
		private readonly Snek Snek;
		private readonly bool handleScore;
		private readonly Random random;
		private readonly IInputHandlerBase inputHandler;
		private readonly UIAPIBase ui;


		public GameMasterLogic(Field field, IInputHandlerBase inputs, UIAPIBase uIAPI, out Action closeCallback, int seed, bool handleScore)
		{

			Field = field;
			random = seed == 0 ? new Random(DateTime.Now.Millisecond) : new Random(seed);
			Snek = new(Field.SafeCoordinates[random.Next(Field.SafeCoordinates.Length)]);
			inputHandler = inputs;
			ui = uIAPI;
			this.handleScore = handleScore;
			cancellationTokenSource = new();

			foreach (Coordinate snekPart in Snek.SnekBody)
			{
				if (Field.Walls.Contains(snekPart)) throw new Exception($"Bad spawn location: {snekPart}");
			}
			closeCallback = ForcedGameEnd;
			ResupplyFood();
		}

		public void LaunchGame()
		{
			isGameRunning = true;
			DrawGame();
			gameThread = new(() => GameLoop(cancellationTokenSource.Token));
			gameThread.Start();
		}

		private void GameLoop(CancellationToken token)
		{
			while (isGameRunning)
			{
				for (int i = 0; i < 4; i++)
				{
					if (token.IsCancellationRequested) { cancellationTokenSource.Dispose(); isGameRunning = false; break; }
					Thread.Sleep(RuleSet.RuleSet.moveTime / 4);
				}

				GamePattern();
			}
		}

		private void GamePattern()
		{			
			Snek.Move(inputHandler.GetCurrentDiredction());
			if (!Snek.SnekBody[^1].IsValid())
			{
				if (!Field.AllowTP)
				{
					EndGame(); return;
				}
				else
				{
					Snek.TeleportHead();
				}
			}
			if (Snek.SnekBody.Contains(food!.Location)) { Snek.QueFood(); ResupplyFood(); }

			if (Field.Walls.Contains(Snek.SnekBody[^1]) || Snek.SnekBody.FindAll(delegate (Coordinate c) { return c == Snek.SnekBody[^1]; }).Count > 1)
			{
				EndGame(); return;
			}
			DrawGame();
		}

		private void ResupplyFood()
		{
			List<Coordinate> temp = new(Field.SafeCoordinates);

			foreach (Coordinate snekPart in Snek.SnekBody) { temp.Remove(snekPart); }
			if (temp.Count == 0) { EndGame(); return; }
			food = new(temp[random.Next(temp.Count)]);
		}

		private void DrawGame()
		{
			if (isGameRunning) { ui.Draw(Snek, food!); }
		}

		private void EndGame()
		{
			isGameRunning = false;
			ui.RollCredits(handleScore ? Snek.SnekBody.Count - 2 : -1);
			cancellationTokenSource.Dispose();
		}

		private void ForcedGameEnd()
		{
			if (isGameRunning) { cancellationTokenSource.Cancel(); }
		}
	}
}
