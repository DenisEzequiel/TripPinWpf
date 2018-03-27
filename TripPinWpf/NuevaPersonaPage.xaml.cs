using Microsoft.OData.SampleService.Models.TripPin;
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
    /// Lógica de interacción para NuevaPersonaPage.xaml
    /// </summary>
    public partial class NuevaPersonaPage : Page
    {
        public NuevaPersonaPage()
        {
            InitializeComponent();
            ObservableCollection<Location> direcciones = new ObservableCollection<Location>();
            direcciones.Add(new Location() { City = new City()});
            DataContext = new Person() { AddressInfo = direcciones};
            //ForzarValidacion();
        }

        //private void ForzarValidacion()
        //{
        //    foreach (FrameworkElement item in gridDatosPersonas.Children)
        //    {
        //        if (item is TextBox)
        //        {
        //            TextBox txt = item as TextBox;
        //            txt.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
        //        }
        //    }
        //}

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
            bool itemSeleccionado = LbEmail.SelectedIndex != -1;
            btnBorrarEmail.IsEnabled = itemSeleccionado;
            btnEditarEmail.IsEnabled = itemSeleccionado;
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

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidacionTexto validacion = new ValidacionTexto() { LargoMaximo = 30, Requerido = false, ExpReg = @"^\S+@\S+$" };
            btnAgregarEmail.IsEnabled = validacion.Validate(txtEmail.Text,null).IsValid;
        }
    }
}
