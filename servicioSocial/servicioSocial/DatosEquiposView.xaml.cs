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
    public partial class DatosEquiposView : ContentPage
    {
        private Equipo equipo;

        public DatosEquiposView(Equipo equipo)
        {
            InitializeComponent();
            this.equipo = equipo;
        }
    }
}