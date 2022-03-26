using servicioSocial.Models;
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
        private Equipo equipoConectado;
        private List<Equipo> equipos = new List<Equipo>();

        public EquiposView(Equipo equipo)
        {
            InitializeComponent();
            this.equipoConectado = equipo;
        }

        async void AddDevice(object sender, EventArgs e)
        {
          string newDevice =  await DisplayPromptAsync("Agregar Equipo", "Ingresa Nombre del equipo:");
            if (newDevice == null)
            {
                await DisplayAlert("Cancelado", "No se agrego ningun dispositivo", "OK");
            } else
            {
                equipoConectado.nombre = newDevice;
                equipoConectado.equipoId = 1;
                equipoConectado.fechaCreacion = DateTime.Now;

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
                device.Clicked += (s, er) => showDetails(equipoConectado, device);


                devicesList.Children.Add(device);

                this.equipos.Add(equipoConectado);

                await DisplayAlert("Notificacion", "El nuevo dispositivo '" + newDevice + "' ha sido agregado exitosamente!", "OK");
            }
            
        }

        async void showDetails(Equipo equipo, View equipoboton)
        {
           string action = await DisplayActionSheet("Selecciona una opcion...", "Cancelar", null, "Eliminar", "Ver Detalles");
            if (action == "Ver Detalles")
            {
                await Navigation.PushAsync(new DatosEquiposView(equipo));
            } else if (action == "Eliminar")
            {
                this.equipos.Remove(equipo);
                devicesList.Children.Remove(equipoboton);
                await DisplayAlert("Notificacion", "Lis Length" + this.equipos.Count , "OK");
            }


        }
    }
}