using IncapsulatedObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;

namespace WPFUserInterface
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private readonly WPFUI ui;

		private readonly GameTile[] tiles;
		internal App(Field field)
		{
			ui = new WPFUI();
			List<GameTile> list = new();

			for (int x = 0; x < RuleSet.RuleSet.maxWidth; x++)
			{
				for (int y = 0; y < RuleSet.RuleSet.maxHight; y++)
				{
					list.Add(new(ui.mainGrid, x, y));
				}
			}

			foreach (var wall in field.Walls)
			{
				SetTileStyle(wall, TileStyles.Wall);
			}
		}

		internal void CreateUI()
		{
			ui.Show();
		}
		internal void Draw(Snek snek, Food food)
		{
			SetTileStyle(food.Location, TileStyles.Food);
			foreach (Coordinate c in snek.SnekBody)
			{
				SetTileStyle(c, TileStyles.Snake);
			}
		}

		private void SetTileStyle(Coordinate tyle, TileStyles style)
		{
			Array.Find(tiles, delegate (GameTile t) { return t.Coordinate == tyle; }).SetStyle(style);
		}
	}
}
