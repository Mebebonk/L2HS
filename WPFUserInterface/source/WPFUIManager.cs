using IncapsulatedObjects;
using InputHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UserInterfaceAPI;
using WPFUserInterface.source;

namespace WPFUserInterface
{
	public class WPFUIAPI : UIAPIBase, IInputHandlerBase
	{
		private WPFUIBack ui;
		private Window newOwner;
		private Directions direction = Directions.Top;

		public void SetOwner(Window newOwner)
		{
			this.newOwner = newOwner;
		}
		public override void CreateUI(Field field)
		{
			ui = new(field, newOwner, SetCurrentDirection);
			ui.CreateUI();
		}

		public override void Draw(Snek snek, Food food)
		{
			Application.Current.Dispatcher.Invoke(new Action(() => ui.Draw(snek, food)));
		}

		public Directions GetCurrentDiredction()
		{
			return direction;
		}

		public void SetCurrentDirection(Directions direction)
		{

			this.direction = direction;


		}

		protected override void DrawEndGame()
		{
			ui.DrawScore();
		}

		protected override void DrawScore(int score)
		{
			ui.UpdateScore(score);
		}
	}
}
