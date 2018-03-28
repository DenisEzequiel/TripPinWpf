using Microsoft.OData.SampleService.Models.TripPin;
//using Microsoft.OData.Service.Sample.TrippinInMemory.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<Person> personas;

        public PersonasPage()
        {
            InitializeComponent();
            dataGridPersonas.Loaded += DataGridPersonas_Loaded;  
        }

        private async void DataGridPersonas_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                personas = new ObservableCollection<Person>(await ApiOperaciones.Container.People.GetAllPagesAsync());
                DataContext = personas;    
            }
            catch(Exception)
            {
                stPanelRecargar.Visibility = Visibility.Visible;
            }
            pbDataGridPersonas.Visibility = Visibility.Collapsed;
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NuevaPersonaPage());
            txtBuscar.Text = string.Empty;
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if(dataGridPersonas.SelectedIndex!= -1)
            {
                NavigationService.Navigate(new NuevaPersonaPage((Person)dataGridPersonas.SelectedValue));
                txtBuscar.Text = string.Empty;
            }
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPersonas.SelectedIndex != -1)
            {
                ApiOperaciones.Container.DeleteObject(dataGridPersonas.SelectedValue);
                ApiOperaciones.Container.SaveChanges();
                DataGridPersonas_Loaded(null, null);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            stPanelRecargar.Visibility = Visibility.Collapsed;
            pbDataGridPersonas.Visibility = Visibility.Visible;
            DataGridPersonas_Loaded(null, null);
        }

        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(personas != null)
                DataContext = personas.Where(x => GetPropiedad(x).ToUpper().StartsWith(txtBuscar.Text.ToUpper()));
        }

        private string GetPropiedad(Person x)
        {
            switch(cbBuscarPor.SelectedIndex)
            {
                case 0:
                    return x.UserName;
                case 1:
                    return x.FirstName;
                case 2:
                    return x.LastName;
                default:
                    return x.UserName;
            }
        }

        private void cbBuscarPor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtBuscar_TextChanged(null, null);
        }
    }
}
