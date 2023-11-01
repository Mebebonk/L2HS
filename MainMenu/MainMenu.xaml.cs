using IncapsulatedObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainMenu
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private FieldListViewItem[] fieldListViewItems;
		public MainWindow()
		{
			InitializeComponent();
			List<FieldListViewItem> fields = new();
			foreach (string file in Directory.EnumerateFiles($"..\\Maps", "*.json"))
			{
				fields.Add(new FieldListViewItem(FieldLoader.LoadField(file), file));
			}
			fieldListViewItems = fields.ToArray();
		}
	}
}
