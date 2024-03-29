﻿using IncapsulatedObjects;
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
		public Coordinate Location { get; private set; }


		public GameTile(Grid grid, int x, int y, Style style, int size = RuleSet.RuleSet.tileSize)
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
			TileVisual.Style = style;

		}
		public void SetStyle(Style style)
		{

			TileVisual.Style = style;

		}
	}
}
