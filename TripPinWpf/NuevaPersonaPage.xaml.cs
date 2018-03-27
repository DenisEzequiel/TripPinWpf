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
            //DataContext = new Person() { AddressInfo = direcciones };
            modoPage = ModoPage.Nuevo;

            Person p = Person.CreatePerson(null, null, null, 1);
            p.AddressInfo = direcciones;
            DataContext = p;
        }

        public NuevaPersonaPage(Person person)
        {
            InitializeComponent();
            DataContext = person;
            modoPage = ModoPage.Edicion;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (modoPage == ModoPage.Nuevo)
            {
                
                ApiOperaciones.Container.AddToPeople((Person)DataContext);
               
            }
            else
            {
                ApiOperaciones.Container.UpdateObject((Person)DataContext);
            }

            var response = ApiOperaciones.Container.SaveChanges();
            foreach (var operationResponse in response)
            {
                Console.WriteLine(operationResponse.StatusCode);
            }
            NavigationService.GoBack();
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
