using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace servicioSocial
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EquiposView : ContentPage
    {
        public EquiposView()
        {
            InitializeComponent();
        }

        async void AddDevice(object sender, EventArgs e)
        {
          string newDevice =  await DisplayPromptAsync("Agregar Equipo", "Ingresa Nombre del equipo:");
            if (newDevice == null)
            {
                await DisplayAlert("Cancelado", "No se agrego ningun dispositivo", "OK");
            } else
            {
                Button device = new Button();
                device.Text = newDevice;
                device.HorizontalOptions = LayoutOptions.Center;
                device.VerticalOptions = LayoutOptions.Center;
                device.FontSize = 20;
                device.TextColor = Color.FromRgb(246, 247, 235);
                device.BackgroundColor = Color.FromRgb(44, 165, 141);
                device.CornerRadius = 10;
                device.WidthRequest = 500;
                device.HeightRequest = 60;
                //device.Clicked += (s, er) => Navigation.PushAsync(new DatosEquiposView(newDevice, deviceId, creationDate));


                devicesList.Children.Add(device);

                await DisplayAlert("Notificacion", "El nuevo dispositivo '" + newDevice + "' ha sido agregado exitosamente!", "OK");
            }
            
        }
    }
}