using IncapsulatedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LevelEditor
{
	internal class LevelEditorTile
	{
		public Coordinate Location { get; private set; }

		public FrameworkElement TileVisual { get; private set; }

		public bool IsSet { get; private set; } = false;

		public LevelEditorTile(Grid grid, int x, int y, int size = RuleSet.RuleSet.tileSize)
		{
			TileVisual = new Border
			{
				Width = size,
				Height = size,
				Focusable = false,
				Margin = new Thickness(0.5)
			};

			Location = new(x, y);
			grid.Children.Add(TileVisual);
			Grid.SetColumn(TileVisual, x);
			Grid.SetRow(TileVisual, y);			
		}
	}
}
