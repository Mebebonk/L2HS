using IncapsulatedObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPFUserInterface;

namespace MainMenu
{
	static internal class MainMenuBack
	{
		static public void LoadAndViewFields(ref ListView listView)
		{
			List<FieldListViewItem> list = new();
			foreach (string file in Directory.EnumerateFiles($"..\\Maps", "*.json"))
			{
				list.Add(new FieldListViewItem(FieldLoader.LoadField(file), file));
			}
			listView.ItemsSource = list;
			listView.SelectedItem = list[0];
		}

		static public void StartGame(Window newOwner, string fileName)
		{
			WPFUIAPI ui = new();
			Action callback;
			ui.SetOwner(newOwner);
			Field field = FieldLoader.LoadField($"{fileName}.json");
			GameMaster.GameMasterAPI gm = new(field, ui, ui, out callback);

			ui.CreateUI(field, callback);

			gm.StartGame();
		}

		static public void OpenLevelEditor()
		{
			LevelEditor.LevelEditorWindow levelEditor = new();
			levelEditor.Show();
		}
	}
}
