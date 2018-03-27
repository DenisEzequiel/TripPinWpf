using Microsoft.OData.SampleService.Models.TripPin;
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

namespace TripPinWpf
{
    /// <summary>
    /// Lógica de interacción para PersonasPage.xaml
    /// </summary>
    public partial class PersonasPage : Page
    {
        public PersonasPage()
        {
            InitializeComponent();
            dataGridPersonas.Loaded += DataGridPersonas_Loaded;           
        }

        private async void DataGridPersonas_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridPersonas.ItemsSource = await ApiOperaciones.Container.People.ExecuteAsync();
            pbDataGridPersonas.Visibility = Visibility.Collapsed;
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NuevaPersonaPage());
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if(dataGridPersonas.SelectedIndex!= -1)
            {
                NavigationService.Navigate(new NuevaPersonaPage((Person)dataGridPersonas.SelectedValue));
            }

        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
