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

namespace Test
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{		
			WPFUserInterface.WPFUIAPI UI = new();
			IncapsulatedObjects.Field field = new(new IncapsulatedObjects.Coordinate[0]);
			UI.SetOwner(this);			
			var input = UI as InputHandler.IInputHandlerBase;
			var userInterface = UI as UserInterfaceAPI.UIAPIBase;
			userInterface.CreateUI(field);

			GameMaster.GameMasterAPI gm = new(field, ref input, ref userInterface);
			gm.StartGame();
		}
	}
}
