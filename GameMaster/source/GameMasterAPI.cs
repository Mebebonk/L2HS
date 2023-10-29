using IncapsulatedObjects;
using InputHandler;
using System.Runtime.InteropServices;
using UserInterfaceAPI;

namespace GameMaster
{
	public class GameMasterAPI
	{
		private readonly GameMasterLogic GameMaster;
		public GameMasterAPI(Field field, ref InputHandlerBase inputs, ref UIAPIBase ui, int seed) 
		{
			GameMaster = new(field, ref inputs, ref ui, seed);
		}
	}
}