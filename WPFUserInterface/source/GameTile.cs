using IncapsulatedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using WPFUserInterface.Properties;
using System.Threading;
using System.Windows.Threading;

namespace WPFUserInterface
{
	internal class GameTile
	{
		public FrameworkElement TileVisual { get; private set; }
		public Coordinate Coordinate { get; private set; }

		private Style defaultStyle, wallStyle, snekStyle, foodStyle;


		public GameTile(Grid grid, int x, int y, TileStyles style = TileStyles.None, int size = 20)
		{
			TileVisual = new Border
			{
				Width = size,
				Height = size,
				Focusable = false
			};

			Coordinate = new(x, y);
			grid.Children.Add(TileVisual);
			Grid.SetColumn(TileVisual, x);
			Grid.SetRow(TileVisual, y);
			InitStyles();
			SetStyle(style);



		}
		public void SetStyle(TileStyles style)
		{

			TileVisual.Style = style switch
			{
				TileStyles.None => defaultStyle,
				TileStyles.Wall => wallStyle,
				TileStyles.Snake => snekStyle,
				TileStyles.Food => foodStyle,
				_ => throw new Exception("Invalid style")
			};

		}

		private void InitStyles()
		{
			defaultStyle = new();
			wallStyle = new();
			snekStyle = new();
			foodStyle = new();

			defaultStyle.Setters.Add(new Setter { Property = Control.BackgroundProperty, Value = new SolidColorBrush(Colors.White) });
			wallStyle.Setters.Add(new Setter { Property = Control.BackgroundProperty, Value = new SolidColorBrush(Colors.Black) });
			snekStyle.Setters.Add(new Setter { Property = Control.BackgroundProperty, Value = new SolidColorBrush(Colors.Green) });
			foodStyle.Setters.Add(new Setter { Property = Control.BackgroundProperty, Value = new SolidColorBrush(Colors.Red) });
		}
	}

	internal enum TileStyles
	{
		None = 0,
		Wall = 1,
		Snake = 2,
		Food = 3
	}
}
