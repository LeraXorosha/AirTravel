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
	/// Логика взаимодействия для FlightAddPage.xaml
	/// </summary>
	public partial class FlightAddPage : Page
	{
		private Flight _currentFlight = new Flight();
		public FlightAddPage(Flight selectedFlight)
		{
			InitializeComponent();
			DataContext = _currentFlight;

			if (selectedFlight != null )
			{
				_currentFlight  = selectedFlight;
			}
			ComboJetType.ItemsSource = AirTravelEntities.GetContext().JetType.ToList();
		}

		private void BtnSave_Click(object sender, RoutedEventArgs e)
		{
			StringBuilder erorrs = new StringBuilder();
			if (string.IsNullOrEmpty(_currentFlight.Departure))
			{
				erorrs.AppendLine("Укажите пункт отправления");
			}

			if (string.IsNullOrEmpty(_currentFlight.Arrival))
			{
				erorrs.AppendLine("Укажите пункт прибытия");
			}

			if (_currentFlight.DepartureTime == null)
			{
				erorrs.AppendLine("Укажите время отправления");
			}

			if (_currentFlight.ArrivalTime == null)
			{
				erorrs.AppendLine("Укажите время отправления");
			}

			if (_currentFlight.Price == null)
			{
				erorrs.AppendLine("Укажите стоимость рейса");
			}

			if (_currentFlight.JetType.Name == null)
			{
				erorrs.AppendLine("Укажите тип самолёта");
			}


			if (erorrs.Length > 0)
			{
				MessageBox.Show(erorrs.ToString());
				return;
			}

			if (_currentFlight.ID == 0)
			{
				AirTravelEntities.GetContext().Flight.Add(_currentFlight);
			}

			try
			{
				AirTravelEntities.GetContext().SaveChanges();
				MessageBox.Show("Информация успешно сохранена!");
				FlightAddFrame.Navigate(new FlightAdminPage());

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
	}
}
