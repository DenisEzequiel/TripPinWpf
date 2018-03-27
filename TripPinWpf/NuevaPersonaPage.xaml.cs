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
    /// Lógica de interacción para NuevaPersonaPage.xaml
    /// </summary>
    public partial class NuevaPersonaPage : Page
    {
        public NuevaPersonaPage()
        {
            InitializeComponent();
            DataContext = new Person();
        }

        public NuevaPersonaPage(Person person)
        {
            InitializeComponent();
            DataContext = person;

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            ApiOperaciones.Container.UpdateObject((Person)DataContext);
            ApiOperaciones.Container.SaveChanges();
        }

        private void btnBorrarEmail_Click(object sender, RoutedEventArgs e)
        {
            ((Person)DataContext).Emails.Remove((string)LbEmail.SelectedItem);
        }

        private void LbEmail_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LbEmail.SelectedIndex != -1)
            {
                btnBorrarEmail.IsEnabled = true;
                btnEditarEmail.IsEnabled = true;
            }
            else
            {
                btnBorrarEmail.IsEnabled = false;
                btnEditarEmail.IsEnabled = false;
            }
        }

        private void btnEditarEmail_Click(object sender, RoutedEventArgs e)
        {
            txtEmail.Text = (string)LbEmail.SelectedItem;
        }

        private void btnAgregarEmail_Click(object sender, RoutedEventArgs e)
        {
            ((Person)DataContext).Emails.Add(txtEmail.Text);
            txtEmail.Text = "";
        }
    }
}
