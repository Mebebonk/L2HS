using GameMaster;
using IncapsulatedObjects;
using InputHandler;
using System;
using System.Text.Json;
using UserInterfaceAPI;

namespace LessTwoHeadSnake
{
	internal class Snek
	{
		static void Main(string[] args)
		{
			WPFUserInterface.WPFUIAPI UI = new();
			var input = UI as IInputHandlerBase;
			var userInterface = UI as UIAPIBase;

			GameMasterAPI gm = new(new(new Coordinate[0]), ref input, ref userInterface);
		}
	}
}