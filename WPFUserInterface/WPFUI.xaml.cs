﻿using IncapsulatedObjects;
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

namespace WPFUserInterface
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class WPFUI : Window
	{
		private readonly Key[] keys = { Key.Left, Key.Right, Key.Up, Key.Down };	
	

		private readonly Action<Directions> callback;
		private readonly Action closeCallback;
		public WPFUI(Action<Directions> callback, Action closeCallback)
		{
			InitializeComponent();
			this.callback = callback;
			mainGrid.Focus();
			this.closeCallback = closeCallback;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			callback(Directions.Top);
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			callback(Directions.Left);
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			callback(Directions.Bottom);
		}

		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
			callback(Directions.Right);
		}

		private void Grid_KeyDown(object sender, KeyEventArgs e)
		{

			if (keys.Contains(e.Key))
			{
				callback(e.Key switch
				{
					Key.Left => Directions.Left,
					Key.Right => Directions.Right,
					Key.Up => Directions.Top,
					Key.Down => Directions.Bottom,
					_ => throw new Exception($"no. {e.Key}")
				});
			}
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			closeCallback();
		}
	}
}
