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
		private readonly Action<Directions> callback;
		public WPFUI(Action<Directions> callback)
		{
			InitializeComponent();
			this.callback = callback;
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
	}
}
