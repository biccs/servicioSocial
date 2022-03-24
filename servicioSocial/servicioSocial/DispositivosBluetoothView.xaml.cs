using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using servicioSocial.Models;

namespace servicioSocial
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DispositivosBluetoothView : ContentPage
    {
        public DispositivosBluetoothView()
        {
            InitializeComponent();
        }

        async void searchDevices(object sender, EventArgs e)
        {
            await DisplayAlert("Buscando dispositivos bluetooth...", "Se han encontrado un dispositivo!", "OK");

            Random rand = new Random();
            double equipoId = rand.Next();

            Equipo nuevoEquipo = new Equipo("Dispositivo-" + equipoId,equipoId);
            nuevoEquipo.generarTemperatura();
            nuevoEquipo.generarAmplitud();

            Button device = new Button();
            device.Text = nuevoEquipo.nombre;
            device.HorizontalOptions = LayoutOptions.Center;
            device.VerticalOptions = LayoutOptions.Center;
            device.FontSize = 20;
            device.TextColor = Color.FromRgb(246, 247, 235);
            device.BackgroundColor = Color.FromRgb(44, 165, 141);
            device.CornerRadius = 10;
            device.WidthRequest = 500;
            device.HeightRequest = 60;
            device.Clicked += (o,er) => manageBluetoothConection(nuevoEquipo);

            dispositivosBluetoothContainer.Children.Add(device);
        }

        async void manageBluetoothConection(Equipo equipo)
        {
            await DisplayAlert("Conexion", "Conectado Con Exito!", "OK");
            MainPage.changeConectedState(true);
            MainPage.equipo = equipo;
            await Navigation.PopAsync();
            //await Navigation.PushAsync(new NavigationPage(new MainPage(true, equipo)));
        }
    }
}