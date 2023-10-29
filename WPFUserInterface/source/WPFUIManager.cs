using IncapsulatedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterfaceAPI;

namespace WPFUserInterface
{
	public class WPFUIAPI : UIAPIBase
	{
		private App ui;

		public override void CreateUI(Field field)
		{
			ui = new App(field);
			ui.CreateUI();
		}

		public override void Draw(Snek snek, Food food)
		{
			ui.Draw(snek, food);
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
