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
        private string nombre = String.Empty;
        private string equipoId = String.Empty;
        private string fechaCreacion = String.Empty;

        public string Nombre { get => nombre; set {
                if (nombre == value)
                {
                    return;
                }

                nombre = value;
                OnPropertyChanged(nameof(Nombre));
            } }

        public string EquipoId
        {
            get => equipoId; set
            {
                if (equipoId == value)
                {
                    return;
                }

                nombre = value;
                OnPropertyChanged(nameof(EquipoId));
            }
        }

        public string FechaCreacion
        {
            get => fechaCreacion; set
            {
                if (fechaCreacion == value)
                {
                    return;
                }

                nombre = value;
                OnPropertyChanged(nameof(FechaCreacion));
            }
        }

        public DatosEquiposView(Equipo equipo)
        {
            InitializeComponent();
            BindingContext = this;
            nombreEquipo.Text = equipo.nombre;
            idEquipo.Text = equipo.equipoId.ToString();
            fechaCrea.Text = equipo.fechaCreacion.ToString();
        }
    }
}