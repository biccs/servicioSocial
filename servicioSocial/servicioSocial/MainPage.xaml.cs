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
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        async void BluetoothPage(object sender, EventArgs e)
        {
            await DisplayAlert("HOLA MUNDO", "QUE SHOW", "TODO BIEN");
            await Shell.Current.GoToAsync(nameof(DispositivosBluetoothView));
        }

        async void PropertiesButton(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(EquiposView));
        }

    }
}