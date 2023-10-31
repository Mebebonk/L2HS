using IncapsulatedObjects;
using InputHandler;
using System.Runtime.InteropServices;
using UserInterfaceAPI;

namespace GameMaster
{
	public class GameMasterAPI
	{
		private readonly GameMasterLogic GameMaster;
		public GameMasterAPI(Field field, IInputHandlerBase inputs, UIAPIBase ui, out Action closeCallback, int seed = 0, bool handleScore = true) 
		{
			GameMaster = new(field, inputs, ui, out closeCallback, seed, handleScore);
		}

		public void StartGame()
		{
			GameMaster.LaunchGame();
		}
	}
}