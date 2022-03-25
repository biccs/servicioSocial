using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace servicioSocial.Models
{
    public class Equipo : INotifyPropertyChanged
    {
        public string nombre { get; set; }
        public double equipoId { get; set; }
        public double[] temperatura { get; set; }
        public double[] amplitud { get; set; }
        public DateTime fechaCreacion { get; set; }
        
        public Equipo(string nombre, double equipoId) 
        {
            this.nombre = nombre;
            this.equipoId = equipoId;   
            this.temperatura = temperatura;
            this.amplitud = amplitud;
            this.fechaCreacion = DateTime.Today;
            generarTemperatura();
            generarAmplitud();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void generarTemperatura()
        {
            this.temperatura = new double[50];
            Random rand = new Random();
            for (int i = 0; i < this.temperatura.Length; i++)
            {
                this.temperatura[i] = rand.Next(0,60);
            }
        }

        public void generarAmplitud()
        {
            this.amplitud = new double[50];
            Random rand = new Random();
            for (int i = 0; i < this.amplitud.Length; i++)
            {
                this.amplitud[i] = rand.Next(0, 60);
            }
        }
    }
}
