using IncapsulatedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LevelEditor
{
	internal class LevelEditorTile
	{
		public Coordinate Location { get; private set; }

		public Control TileVisual { get; private set; }

		public bool IsSet { get; private set; }

		public LevelEditorTile(Grid grid, int x, int y, bool isSet = false, int size = RuleSet.RuleSet.tileSize)
		{
			IsSet = isSet;
			TileVisual = new Button
			{
				Width = size,
				Height = size,
				Focusable = false,
				Margin = new Thickness(0.5),
				Background = new SolidColorBrush(IsSet ? Colors.Gray : Colors.White)
			};
			(TileVisual as Button).Click += (o, e) => { SwapState(); };

			Location = new(x, y);
			grid.Children.Add(TileVisual);
			Grid.SetColumn(TileVisual, x);
			Grid.SetRow(TileVisual, y);
		}

		private void SwapState()
		{
			IsSet = !IsSet;
			TileVisual.Background = new SolidColorBrush(IsSet ? Colors.Gray : Colors.White);

		}
	}
}
