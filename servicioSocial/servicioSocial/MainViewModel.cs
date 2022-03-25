using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace servicioSocial
{
    public class MainViewModel : INotifyPropertyChanged
    {
        
        string amplitud = String.Empty;
        public string Amplitud
        {
            get => amplitud;
            set
            {
                if (amplitud == value)
                {
                    return;
                }

                amplitud = value;
                OnPropertyChanged(nameof(Amplitud));
            }
        }

        string temperatura = String.Empty;
        public string Temperatura
        {
            get => temperatura;
            set
            {
                if (temperatura == value)
                {
                    return;
                }

                amplitud = value;
                OnPropertyChanged(nameof(Temperatura));
            }
        }

        string conection = String.Empty;
        public string Conection
        {
            get => conection;
            set
            {
                if (conection == value)
                {
                    return;
                }

                conection = value;
                OnPropertyChanged(nameof(Conection));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string value)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(value.ToString()));
        }
    }
}
