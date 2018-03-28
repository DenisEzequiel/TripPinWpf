using Microsoft.OData.SampleService.Models.TripPin;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace TripPinWpf
{
    /// <summary>
    /// Lógica de interacción para NuevaPersonaPage.xaml
    /// </summary>
    public partial class NuevaPersonaPage : Page
    {
        private enum ModoPage { Nuevo,Edicion};
        private ModoPage modoPage;
        public NuevaPersonaPage()
        {
            InitializeComponent();
            ObservableCollection<Location> direcciones = new ObservableCollection<Location>();
            direcciones.Add(new Location() { City = new City() });
            DataContext = new Person() { AddressInfo = direcciones };
            modoPage = ModoPage.Nuevo;
            Title = "Nueva Persona";
        }

        public NuevaPersonaPage(Person person)
        {
            InitializeComponent();
            DataContext = person;
            modoPage = ModoPage.Edicion;
            Title = "Editar Persona";
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (modoPage == ModoPage.Nuevo)
                {
                    ApiOperaciones.Container.AddToPeople((Person)DataContext);
                }
                else
                {
                    ApiOperaciones.Container.UpdateObject((Person)DataContext);
                }
                ApiOperaciones.Container.SaveChanges();
            }
            catch(Exception)
            {
                MessageBox.Show("Ha ocurrido un error");
            }

            NavigationService.GoBack();
        }

        private void btnBorrarEmail_Click(object sender, RoutedEventArgs e)
        {
            ((Person)DataContext).Emails.Remove((string)LbEmail.SelectedItem);
        }

        private void LbEmail_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnBorrarEmail.IsEnabled = LbEmail.SelectedIndex != -1;
        }

        private void btnAgregarEmail_Click(object sender, RoutedEventArgs e)
        {
            ((Person)DataContext).Emails.Add(txtEmail.Text);
            txtEmail.Text = "";
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidacionTexto validacion = new ValidacionTexto() { LargoMaximo = 30, Requerido = false, ExpReg = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" };
            btnAgregarEmail.IsEnabled = validacion.Validate(txtEmail.Text,null).IsValid;
        }
    }
}
