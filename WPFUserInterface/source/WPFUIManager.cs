using IncapsulatedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterfaceAPI;

namespace WPFUserInterface
{
	internal class WPFUIManager : UIAPIBase
	{
		public override void Draw(Coordinate[] walls, Snek snek, Food food)
		{
			throw new NotImplementedException();
		}

		protected override void DrawEndGame()
		{
			throw new NotImplementedException();
		}
		 
		protected override void DrawScore(int score)
		{
			throw new NotImplementedException();
		}
	}
}
