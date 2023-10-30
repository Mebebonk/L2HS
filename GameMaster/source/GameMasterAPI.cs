using IncapsulatedObjects;
using InputHandler;
using System.Runtime.InteropServices;
using UserInterfaceAPI;

namespace GameMaster
{
	public class GameMasterAPI
	{
		private readonly GameMasterLogic GameMaster;
		public GameMasterAPI(Field field, IInputHandlerBase inputs, UIAPIBase ui, int seed = 0) 
		{
			GameMaster = new(field, inputs, ui, seed);
		}

		public void StartGame()
		{
			GameMaster.LaunchGame();
		}
	}
}