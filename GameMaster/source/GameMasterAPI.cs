using IncapsulatedObjects;
using InputHandler;
using System.Runtime.InteropServices;
using UserInterfaceAPI;

namespace GameMaster
{
	public class GameMasterAPI
	{
		private readonly GameMasterLogic GameMaster;
		public GameMasterAPI(Field field, ref IInputHandlerBase inputs, ref UIAPIBase ui, int seed = 0) 
		{
			GameMaster = new(field, ref inputs, ref ui, seed);
		}

		public void StartGame()
		{
			GameMaster.LaunchGame();
		}
	}
}