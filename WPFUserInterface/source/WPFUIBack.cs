﻿using IncapsulatedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFUserInterface.source
{
	internal class WPFUIBack
	{
		private readonly WPFUI ui;
		private readonly GameTile[] tiles;
		private readonly GameTile[] walls;

		private Style defaultStyle, wallStyle, snekStyle, foodStyle;
		private int score = 0;

		internal WPFUIBack(Field field, Window newOwner, Action<Directions> callback, Action closeCallback)
		{
			ui = new WPFUI(callback, closeCallback)
			{
				Owner = newOwner,
			};
			List<GameTile> list = new();
			List<GameTile> lwalls = new();
			InitStyles();

			for (int x = 0; x < RuleSet.RuleSet.maxWidth; x++)
			{
				for (int y = 0; y < RuleSet.RuleSet.maxHight; y++)
				{
					GameTile a = new(ui.mainGrid, x, y, defaultStyle);
					list.Add(a);
					if (field.Walls.Contains(new Coordinate(x, y))) { lwalls.Add(a); a.SetStyle(wallStyle); }
					ui.mainGrid.RowDefinitions.Add(new System.Windows.Controls.RowDefinition { Height = GridLength.Auto });
				}
				ui.mainGrid.ColumnDefinitions.Add(new System.Windows.Controls.ColumnDefinition { Width = GridLength.Auto });
			}

			tiles = list.ToArray();
			walls = lwalls.ToArray();
						
		}

		internal void CreateUI()
		{
			ui.Show();
		}
		internal void Draw(Snek snek, Food food)
		{
			foreach (var tile in tiles)
			{
				if (!walls.Contains(tile)) { tile.SetStyle(defaultStyle); }
				if (tile.Coordinate == food.Location) { tile.SetStyle(foodStyle); }
				if (snek.SnekBody.Contains(tile.Coordinate)) { tile.SetStyle(snekStyle); }
			}
		}

		internal void DrawScore()
		{
			string message = score == 0 ? "Game over!" : $"Game over!\nScore: {score}";
			MessageBox.Show(message,"Game over", MessageBoxButton.OK);			
		}

		internal void UpdateScore(int score)
		{
			this.score = score;
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
}

