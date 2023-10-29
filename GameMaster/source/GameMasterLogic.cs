using IncapsulatedObjects;
using InputHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterfaceAPI;

namespace GameMaster
{
	internal class GameMasterLogic
	{
		public Field Field { get; private set; }
		public Snek Snek { get; private set; }
		private Food? food;
		private bool isGameRunning = false;

		private readonly Random random;
		private readonly InputHandlerBase inputHandler;
		private readonly UIAPIBase ui;


		public GameMasterLogic(Field field, ref InputHandlerBase inputs, ref UIAPIBase uIAPI, int seed = 0)
		{

			Field = field;
			random = seed == 0 ? new Random(DateTime.Now.Millisecond) : new Random(seed);
			Snek = new(Field.SafeCoordinates[random.Next(Field.SafeCoordinates.Length)]);
			inputHandler = inputs;
			ui = uIAPI;

			foreach (Coordinate snekPart in Snek.SnekBody)
			{
				if (Field.Walls.Contains(snekPart)) throw new Exception($"Bad spawn location: {snekPart}");
			}

			ResupplyFood();
		}

		public void LaunchGame()
		{
			isGameRunning = true;
			DrawGame();
			GameLoop();
		}

		private void GameLoop()
		{
			while (isGameRunning)
			{
				ThreadHandler.ThreadHandlerAPI.ExecLocked(GamePattern);
			}
		}

		private void GamePattern()
		{
			Thread.Sleep(RuleSet.RuleSet.moveTime);

			Snek.Move(inputHandler.GetCurrentDiredction());
			if (Snek.SnekBody.Contains(food!.Location)) { Snek.QueFood(); ResupplyFood(); }

			if (Field.Walls.Contains(Snek.SnekBody[^1]) || Snek.SnekBody.FindAll(delegate (Coordinate c) { return c == Snek.SnekBody[^1]; }).Count > 1)
			{
				EndGame(); return;
			}
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
			DrawGame();
		}

		private void ResupplyFood()
		{
			List<Coordinate> temp = new(Field.SafeCoordinates);

			foreach (Coordinate snekPart in Snek.SnekBody) { temp.Remove(snekPart); }

			food = new(temp[random.Next(temp.Count)]);
		}

		private void DrawGame()
		{
			ui.Draw(Field.Walls, Snek, food!);
		}

		private void EndGame()
		{
			ui.RollCredits();
		}

	}
}
