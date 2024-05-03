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
	/// Логика взаимодействия для FlightAddWindow.xaml
	/// </summary>
	public partial class FlightAddWindow : Window
	{
		public FlightAddWindow()
		{
			InitializeComponent();
			ComboJetType.ItemsSource = AirTravelEntities.GetContext().JetType.ToList();
		}
	}
}
