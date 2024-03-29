﻿using FieldManager;
using IncapsulatedObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WPFUserInterface;

namespace MainMenu
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{		
		public MainWindow()
		{
			InitializeComponent();
			MainMenuBack.LoadAndViewFields(ref mapList);
			
		}

		private void StartGameButton(object sender, RoutedEventArgs e)
		{
			MainMenuBack.StartGame(this, (mapList.SelectedItem as FieldListViewItem).FieldName);
		}

		private void OpenLevelEditor(object sender, RoutedEventArgs e)
		{
			MainMenuBack.OpenLevelEditor();
		}
	}
}
