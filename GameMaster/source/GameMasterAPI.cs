using IncapsulatedObjects;
using InputHandler;
using System.Runtime.InteropServices;
using UserInterfaceAPI;

namespace GameMaster
{
	public class GameMasterAPI
	{
		private readonly GameMasterLogic GameMaster;
		public GameMasterAPI(Field field, IInputHandlerBase inputs, UIAPIBase ui, int seed = 0, bool handleScore = true) 
		{
			GameMaster = new(field, inputs, ui, seed, handleScore);
		}

		public void StartGame()
		{
			GameMaster.LaunchGame();
		}
	}
}