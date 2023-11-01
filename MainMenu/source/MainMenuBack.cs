using IncapsulatedObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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
		}
	}
}
