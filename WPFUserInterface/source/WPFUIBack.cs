using IncapsulatedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFUserInterface.source
{
	internal class WPFUIBack
	{
		private readonly WPFUI ui;

		private readonly GameTile[] tiles;

		internal WPFUIBack(Field field, Window newOwner, Action<Directions> callback)
		{
			ui = new WPFUI (callback)
			{
				Owner = newOwner,
			};
			List<GameTile> list = new();

			for (int x = 0; x < RuleSet.RuleSet.maxWidth; x++)
			{
				for (int y = 0; y < RuleSet.RuleSet.maxHight; y++)
				{
					list.Add(new(ui.mainGrid, x, y));
					ui.mainGrid.RowDefinitions.Add(new System.Windows.Controls.RowDefinition { Height = GridLength.Auto });
				}
				ui.mainGrid.ColumnDefinitions.Add(new System.Windows.Controls.ColumnDefinition { Width = GridLength.Auto });
			}


			foreach (var wall in field.Walls)
			{
				SetTileStyle(wall, TileStyles.Wall);
			}
			tiles = list.ToArray();
		}

		internal void CreateUI()
		{
			ui.Show();
		}
		internal void Draw(Snek snek, Food food)
		{
			foreach(var tile in tiles)
			{
				tile.SetStyle(TileStyles.None);
				if (tile.Coordinate == food.Location) { tile.SetStyle(TileStyles.Food); }
				if (snek.SnekBody.Contains(tile.Coordinate)) { tile.SetStyle(TileStyles.Snake); }
			}			
		}

		private void SetTileStyle(Coordinate tyle, TileStyles style)
		{
			Array.Find(tiles, delegate (GameTile t) { return t.Coordinate == tyle; }).SetStyle(style);
		}
	}
}

