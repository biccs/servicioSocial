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
        public double _amplitud = 0;
        public double _temperatura = 0;
        string _conection = "Desconectado";
        public double Amplitud {
            get { return _amplitud; }
            set
            {
                _amplitud = value;
                OnPropertyChanged(nameof(Amplitud));
            }
        }

        public double Temperatura
        {
            get { return _temperatura; }
            set
            {
                _temperatura = value;
                OnPropertyChanged(nameof(Temperatura));
            }
        }

        public string Conection
        {
            get => _conection;
            set
            {
                if (_conection == value)
                {
                    return;
                }

                _conection = value;
                OnPropertyChanged(nameof(Conection));
            }
        }

        public Equipo equipo;

        public MainPage()
        {
            InitializeComponent();

            BindingContext = this;
            //etiquetaContectado.Text = "Desconectado";
            //amplitudValue.Text = "0";
            //temperaturaValue.Text = "0";
            //Conection = "Desconectado";
            //Amplitud = 0;
            //Temperatura = 0;

            MessagingCenter.Subscribe<DispositivosBluetoothView, Equipo>(this, "Hi", async (sender, arg) =>
            {
                amplitudValue.BindingContext = this;
                temperaturaValue.BindingContext = this;
                
                manageBluetoothConection(true, arg.nombre);
                manageDataFlow(arg.temperatura, arg.amplitud);

                equipo = arg;
            });
        }

        void manageDataFlow(double[] temperatura, double[] amplitud)
        {
            manageTemperatura(temperatura);
            manageAmplitud(amplitud);
        }

        async void manageTemperatura(double[] temperatura)
        {
            await Task.Run(() =>
            {

            for (int i = 0; i < 10000; i = i == temperatura.Length - 3 ? 0 : i + 1)
                {
                    if (!disconectButton.IsEnabled)
                        return;

                    this.Temperatura = temperatura[i];
                    Thread.Sleep(500);
                }
            });
                
            //temperaturaValue.SetBinding(Label.TextProperty, temperatura[0].ToString());
            //this.Temperatura = 50.4;
        }

        async void manageAmplitud(double[] amplitud)
        {
            await Task.Run(() =>
            {

                for (int i = 0; i < 1000; i = i == amplitud.Length - 3 ? 0 : i + 1)
                {
                    if (!disconectButton.IsEnabled)
                        return;

                    this.Amplitud = amplitud[i];
                    Thread.Sleep(500);
                }
            });
                
            //amplitudValue.SetBinding(Label.TextProperty, amplitud[0].ToString());
            //this.Amplitud = 20.3;
        }

        void manageBluetoothConection(bool con, string name)
        {
            if (con)
            {
                etiquetaContectado.Text = name;
                imagenConectado.Source = "checked.png";
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
            await Navigation.PushAsync(new EquiposView(this.equipo));
        }

        async void DisconnectDevice(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Desconectar Dispositivo", "Seguro que quieres desconectar el dispositivo?", "SI", "NO");
            if (res)
            {
                etiquetaContectado.Text = "Desconectado";
                imagenConectado.Source = "cancel.png";
                this.Amplitud = 0;
                this.Temperatura = 0;
                conectionButton.IsEnabled= true;
                disconectButton.IsEnabled= false;
                
            }
        }
    

    
    }
}