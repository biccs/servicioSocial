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
        public bool conection = false;
        public Equipo equipo;
        private string _nombreEquipo = "Desconectado";
        public string nombreEquipo
        {
            get
            {
                return _nombreEquipo;
            }
            set
            {
                _nombreEquipo = value;
                // read here about OnPropertyChanged built-in method https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.bindableobject.onpropertychanged?view=xamarin-forms
                OnPropertyChanged("nombreEquipo");
            }
        }

        public MainPage()
        {
            //todo: test
            // Note: binding context can also to another view model class of this view, but here we will use the class of this specific view
            // So, you can also do something like that:
            // BindingContext = new useracViewModel() 
            BindingContext = this;
            // you can also change the default value of _TheUserName by getting it from database, xml file etc...
            //TheUserName = GetCurrentUserName();

            InitializeComponent();
            MessagingCenter.Subscribe<DispositivosBluetoothView, Equipo>(this, "Hi", async (sender, arg) =>
            {
                manageBluetoothConection(true, arg.nombre);
            });
        }
        public MainPage(bool conected, Models.Equipo equipo)
        {
            InitializeComponent();
            conection = conected;

            manageBluetoothConection(conection, equipo.nombre);

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

        void changeConectedState(bool state)
        {
            conection = state;
            manageBluetoothConection(conection, null);
        }

        void manageDataFlow(Label variableName, double data)
        {
            variableName.Text = data.ToString();
            Thread.Sleep(500);
        }

        void manageBluetoothConection(bool con, string name)
        {
            if (con)
            {
                etiquetaContectado.Text = name;
                imagenConectado.Source = "checked.png";
                //conectionButton.Text = "Desconectar";
                //conectionButton.Clicked += DisconnectDevice;
                disconectButton.IsEnabled = true;
                conectionButton.IsEnabled = false;
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

        async void DisconnectDevice(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Desconectar Dispositivo", "Seguro que quieres desconectar el dispositivo?", "SI", "NO");
            if (res)
            {
                etiquetaContectado.Text = "Desconectado";
                imagenConectado.Source = "cancel.png";
                conectionButton.IsEnabled= true;
                disconectButton.IsEnabled= false;
            }
        }
    

    
    }
}