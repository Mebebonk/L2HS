using IncapsulatedObjects;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LevelEditor
{
	static internal class LevelEditorBack
	{
		public static void LoadLevel(ref CheckBox allowTP, ref LevelEditorTile[] tiles, ref Grid grid, ref Border border)
		{
			Field field;

			OpenFileDialog fileDialog = new()
			{
				Filter = "Map|*.json",
				Multiselect = false
			};

			if ((bool)fileDialog.ShowDialog())
			{
				field = FieldLoader.LoadField(fileDialog.FileName);
				if (field != null)
				{
					ParseFieldToTiles(field, ref tiles, ref grid, ref allowTP, ref border);
					return;
				}
			}

			LoadEmptyLevel(ref allowTP, ref tiles, ref grid, ref border);
		}

		public static void LoadEmptyLevel(ref CheckBox allowTp, ref LevelEditorTile[] tiles, ref Grid grid, ref Border border)
		{			
			ParseFieldToTiles(new(Array.Empty<Coordinate>()), ref tiles, ref grid, ref allowTp, ref border);
		}

		private static void ParseFieldToTiles(Field field, ref LevelEditorTile[] tiles, ref Grid grid, ref CheckBox allowTP, ref Border border)
		{
			List<LevelEditorTile> list = new();

			for (int x = 0; x < RuleSet.RuleSet.maxWidth; x++)
			{
				for (int y = 0; y < RuleSet.RuleSet.maxHeight; y++)
				{
					list.Add(new(grid, x, y, field.Walls.Contains(new(x, y))));
				}
			}
			allowTP.IsChecked = field.AllowTP;
			SwapTPWalls(ref allowTP, ref border);

			tiles = list.ToArray();

		}

		public static void SaveLevel(ref CheckBox allowTP, ref LevelEditorTile[] tiles)
		{
			List<Coordinate> list = new();
			foreach (LevelEditorTile tile in tiles)
			{
				if (tile.IsSet) { list.Add(tile.Location); }
			}

			Field field = new(list.ToArray(), (bool)allowTP.IsChecked);

			if (!field.IsValid()) { MessageBox.Show("Field is invalid!", "Error", MessageBoxButton.OK); return; };

			SaveFileDialog fileDialog = new()
			{
				Filter = "Map|*.json",
				CheckFileExists = false
			};

			if ((bool)fileDialog.ShowDialog())
			{

				FieldManager.FieldSaver.SaveField(field, fileDialog.FileName.Split('\\').Last().Replace(".json", ""));
			}

		}

		public static void InitDefinitions(ref Grid grid)
		{
			for (int i = 0; i < RuleSet.RuleSet.maxWidth; i++)
			{
				grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

			}
			for (int i = 0; i < RuleSet.RuleSet.maxWidth; i++)
			{
				grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
			}
		}

		public static void SwapTPWalls(ref CheckBox allowTpCheck, ref Border wrappBorder)
		{
			wrappBorder.Background = new SolidColorBrush((bool)allowTpCheck.IsChecked ? Colors.White : Colors.Gray);
		}		
	}
}


