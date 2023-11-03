using System;
using System.Collections.Generic;
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

namespace LevelEditor
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class LevelEditorWindow : Window
	{
		private LevelEditorTile[] tiles;

		public LevelEditorWindow()
		{
			InitializeComponent();
			LevelEditorBack.InitDefinitions(ref tileGrid);
			LevelEditorBack.LoadLevel(ref allowTpCheck, ref tiles, ref tileGrid, ref wrappBorder);
		}

		private void LoadLevel(object sender, RoutedEventArgs e)
		{
			LevelEditorBack.LoadLevel(ref allowTpCheck, ref tiles, ref tileGrid, ref wrappBorder);
		}

		private void SaveLevel(object sender, RoutedEventArgs e)
		{
			LevelEditorBack.SaveLevel(ref allowTpCheck, ref tiles);
		}

		private void CheckSwap(object sender, RoutedEventArgs e)
		{
			LevelEditorBack.SwapTPWalls(ref allowTpCheck, ref wrappBorder);
		}

		private void WipeLevel(object sender, RoutedEventArgs e)
		{
			LevelEditorBack.LoadEmptyLevel(ref allowTpCheck, ref tiles, ref tileGrid, ref wrappBorder);
		}
	}
}
