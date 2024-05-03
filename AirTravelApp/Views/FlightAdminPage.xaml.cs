using AirTravelApp.Models;
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

namespace AirTravelApp.Views
{
	/// <summary>
	/// Логика взаимодействия для FlightAdminPage.xaml
	/// </summary>
	public partial class FlightAdminPage : Page
	{
		public FlightAdminPage()
		{
			InitializeComponent();
		}

		private void Window_isVisiableChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (Visibility == Visibility.Visible)
			{
				AirTravelEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(entry => { entry.Reload(); });
				DGFlightAdmin.ItemsSource = AirTravelEntities.GetContext().Flight.ToList();
			}
		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e)
		{
			//var newWindow = new FlightAddWindow();
			//newWindow.Show();
			FlightFrame.Navigate(new FlightAddPage(null)); 


		}

		private void BtnDetail_Click(object sender, RoutedEventArgs e)
		{
			FlightFrame.Navigate(new FlightAddPage((sender as Button).DataContext as Flight));
		}
	}
}
