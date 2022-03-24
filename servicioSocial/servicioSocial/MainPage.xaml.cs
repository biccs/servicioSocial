using servicioSocial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace servicioSocial
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public static bool conection = false;
        public static Equipo equipo;

        public MainPage()
        {
            //todo: test
            InitializeComponent();
        }
        public MainPage(bool conected, Models.Equipo equipo)
        {
            InitializeComponent();
            conection = conected;

            manageBluetoothConection(conection);

            DisplayAlert("Alert", "You have been alerted " + equipo, "OK");

            int longestSize = equipo.amplitud.Length < equipo.temperatura.Length ? equipo.temperatura.Length : equipo.amplitud.Length;
            
            //while(conection)
            //{
            //    for(int i = 0; i < longestSize; i++)
            //    {
            //        manageDataFlow(temperaturaValue, equipo.temperatura[i]);
            //        manageDataFlow(amplitudValue, equipo.amplitud[i]);
            //    }
            //}
        }

        public static void changeConectedState(bool state)
        {
            conection = state;
            manageBluetoothConection(conection);
        }

        void manageDataFlow(Label variableName,double data)
        {
            variableName.Text = data.ToString();
            Thread.Sleep(500);
        }

        static void manageBluetoothConection(bool con)
        {
            if (con)
            {
                etiquetaContectado.Text = "Conectado";
                imagenConectado.Source = "checked.png";
            }
            else
            {
                etiquetaContectado.Text = "Desconectado";
                imagenConectado.Source = "cancel.png";
            }
        }

        async void BluetoothPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DispositivosBluetoothView());
        }

        async void PropertiesButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EquiposView());
        }

    }
}