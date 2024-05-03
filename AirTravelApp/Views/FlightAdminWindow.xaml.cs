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
using System.Windows.Shapes;
using AirTravelApp.Models;

namespace AirTravelApp.Views
{
	/// <summary>
	/// Логика взаимодействия для FlightAdminWindow.xaml
	/// </summary>
	public partial class FlightAdminWindow : Window
	{
		public FlightAdminWindow()
		{
			InitializeComponent();
			DGFlightAdmin.ItemsSource = AirTravelEntities.GetContext().Flight.ToList();
		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e)
		{
			var newWindow = new FlightAddWindow();
			newWindow.Show();
		}
	}
}
